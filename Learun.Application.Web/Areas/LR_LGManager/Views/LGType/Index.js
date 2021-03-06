/* * 版 本 Learun-ADMS V7.0.6 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2020 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2018-04-10 15:08
 * 描  述：语言类型
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
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
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_LGManager/LGType/Form',
                    width: 300,
                    height: 180,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_LGManager/LGType/Form?keyValue=' + keyValue,
                        width: 300,
                        height: 180,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    if (selectedRow.F_IsMain === 1) {
                        learun.alert.warning("主语言不能删除！");
                        return false;
                    }
                    learun.httpAsyncGet(top.$.rootUrl + '/LR_LGManager/LGMap/GetListByTypeCode?TypeCode=' + selectedRow.F_Code, function (res) {
                        if (res.data.length != 0) {
                            learun.alert.warning("请先删除编码对应数据！");
                            return false;
                        }
                        else {
                            learun.layerConfirm('是否确认删除该项！', function (res) {
                                if (res) {
                                    learun.deleteForm(top.$.rootUrl + '/LR_LGManager/LGType/DeleteForm', { keyValue: keyValue }, function () {
                                        refreshGirdData();
                                    });
                                }
                            });
                        }
                    });
                }
            });
            $('#lr_mainlg').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认设为主语言！', function (res, index) {
                        if (res) {
                            learun.loading(true, '正在设置主语言');
                            learun.httpAsyncPost(top.$.rootUrl + '/LR_LGManager/LGType/SetMainLG', { keyValue: keyValue }, function (res) {
                                learun.loading(false);
                                if (res.code == learun.httpCode.success) {
                                    learun.alert.success(res.info);
                                    refreshGirdData();
                                }
                                else {
                                    learun.alert.error(res.info);
                                    learun.httpErrorLog(res.info);
                                }
                                top.layer.close(index)
                            });
                        }
                    })
                }
            });
        },
        initGrid: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_LGManager/LGType/GetList',
                headData: [
                    { label: '名称', name: 'F_Name', width: 200, align: "left" },
                    { label: '编码', name: 'F_Code', width: 300, align: "left" },
                    {
                        label: '主语言', name: 'F_IsMain', width: 80, align: "left",
                        formatter: function (cellvalue) {
                            if (cellvalue == 1) {
                                return '<span class=\"label label-info\" style=\"cursor: pointer;\">是</span>';
                            }
                            else return '<span class=\"label label-danger\" style=\"cursor: pointer;\">否</span>';
                        }
                    },
                ],
                mainId: 'F_Id',
                reloadSelected: true,
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
