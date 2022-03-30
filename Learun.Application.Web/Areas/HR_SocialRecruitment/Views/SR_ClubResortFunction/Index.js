/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-11 17:52
 * 描  述：招聘流程流程节点维护
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.inittree();
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 初始化左侧树形数据

            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 100, 200);
            $('#F_ProcessId').lrDataSourceSelect({ code: 'ProcessNodeTable',value: 'f_id',text: 'f_processnodename' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_SocialRecruitment/SR_ClubResortFunction/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_SocialRecruitment/SR_ClubResortFunction/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_SocialRecruitment/SR_ClubResortFunction/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        inittree: function () {
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/HR_SocialRecruitment/SR_ClubResortFunction/GetTree',
                param: { parentId: '' },
                nodeClick: page.treeNodeClick
            });
            $('#dataTree').lrtreeSet('setValue', '1a5c0195-d4d5-44a7-b677-048b6441a068');
        },
        treeNodeClick: function (item) {
            F_id = item.F_id
            $('#titleinfo').text(item.text);
 
            page.search();
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_SocialRecruitment/SR_ClubResortFunction/GetPageList',
                headData: [
                    { label: "招聘流程节点", name: "F_ProcessId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ProcessNodeTable',
                                 key: value,
                                 keyId: 'f_id',
                                 callback: function (_data) {
                                     callback(_data['f_processnodename']);
                                 }
                             });
                        }},
                    { label: "招聘节点功能", name: "F_FunticonName", width: 100, align: "left"},
                ],
                mainId:'F_id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.F_id = F_id;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
