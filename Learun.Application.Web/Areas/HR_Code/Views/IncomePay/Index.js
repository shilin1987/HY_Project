/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-05-26 11:59
 * 描  述：收入支出详细
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_PayerUserId').lrDataSourceSelect({ code: 'userdata',value: 'f_userid',text: 'f_account' });
            $('#F_Operation_Id').lrDataSourceSelect({ code: 'IncomePay',value: 'f_itemid',text: 'f_item' });
            $('#F_Formula').lrDataItemSelect({ code: 'CalculationFormula' });
            $('#F_EnabledMark').lrRadioCheckbox({
                type: 'radio',
                code: 'IsEnd',
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/IncomePay/Form',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OperationRelationId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/IncomePay/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 250,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OperationRelationId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/IncomePay/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            ////  导入
            //$('#lr_import').on('click', function () {
            //});
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/IncomePay/GetPageList',
                headData: [
                    {
                        label: "用户账号", name: "F_PayerUserId", width: 150, align: "center", sort: true,
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                                 key: value,
                                 keyId: 'f_userid',
                                 callback: function (_data) {
                                     callback(_data['f_account']);
                                 }
                             });
                        }},
                    { label: "收支年月", name: "F_OperationDate", width: 150, align: "center", sort: true},
                    {
                        label: "收支项目", name: "F_Operation_Id", width: 150, align: "center", sort: true,
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'IncomePay',
                                 key: value,
                                 keyId: 'f_itemid',
                                 callback: function (_data) {
                                     callback(_data['f_item']);
                                 }
                             });
                        }},
                    {
                        label: "收支公式", name: "F_Formula", width: 120, align: "center", sort: true,
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'CalculationFormula',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "收支费用", name: "F_Cost", width: 150, align: "center", sort: true},
                    {
                        label: "是否有效", name: "F_EnabledMark", width: 120, align: "center", sort: true,
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'IsEnd',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                ],
                mainId:'F_OperationRelationId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
