﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软框架开发组
 * 日  期：2017-06-21 16:30
 * 描  述：数据权限
 */
var objectId = request("objectId");
var objectType = request("objectType");


var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";

    var interfaceId = '';
    var formId = '';
    var page = {
        init: function () {
            page.inittree();
            page.initGrid();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            if (!!objectId) {
                // 新增
                $('#lr_add').on('click', function () {
                    if (!interfaceId) {
                        learun.alert.warning('请选择左侧功能！');
                        return false;
                    }
                    learun.layerForm({
                        id: 'form',
                        title: '新增数据权限',
                        url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/Form?interfaceId=' + interfaceId + '&objectId=' + objectId + '&objectType=' + objectType + '&type=2' + '&formId=' + formId,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                });
            }
            else {
                $('#lr_add').hide();
            }
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                var _interfaceId = $('#gridtable').jfGridValue('F_InterfaceId');

                if (learun.checkrow(keyValue)) {
                    if (!formId) {
                        var _list = $('#interface_tree')[0]._lrtree.dfop.data;
                        $.each(_list, function (_index, _item) {
                            if (_item.id == _interfaceId) {
                                formId = _item.value;
                                return false;
                            }
                        });
                    }
                  

                    learun.layerForm({
                        id: 'form',
                        title: '编辑数据权限',
                        url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/Form?interfaceId=' + _interfaceId + '&objectId=' + objectId + '&objectType=' + objectType + '&keyValue=' + keyValue + '&type=2' + '&formId=' + formId,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        inittree: function () {
            $('#interface_tree').lrtree({
                url: top.$.rootUrl + '/LR_FormModule/FormRelation/GetTree',
                nodeClick: page.treeNodeClick
            });
        },
        treeNodeClick: function (item) {
            interfaceId = item.id;
            formId = item.value;

            console.log(interfaceId, formId);

            $('#titleinfo').text(item.text);
            page.search();
        },
        initGrid: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/GetRelationPageList?type=2',
                headData: [
                    { label: "名称", name: "F_Name", width: 180, align: "left" },
                    {
                        label: "用户/角色", name: "F_ObjectId", width: 180, align: "left",
                        formatter: function (cellvalue, row) {
                            return !!row.UserName ? row.UserName : row.RoleName;
                        }
                    },
                    { label: "公式", name: "F_Formula", width: 280, align: "left" },
                    {
                        label: '创建人', name: 'F_CreateUserName', width: 100, align: 'left'
                    },
                    {
                        label: "创建时间", name: "F_CreateDate", width: 100, align: "left",
                        formatter: function (cellvalue) {
                            return learun.formatDate(cellvalue, 'yyyy-MM-dd');
                        }
                    }
                ],
                isPage: true,
                reloadSelected: true,
                mainId: 'F_Id'
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.interfaceId = interfaceId;
            param.objectId = objectId;
            $('#gridtable').jfGridSet('reload', param);
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
