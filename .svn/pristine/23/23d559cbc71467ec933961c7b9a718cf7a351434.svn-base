/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-16 14:11
 * 描  述：来料计划产能分配
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
            $('#F_ALLOT_MONTH').lrDataItemSelect({ code: 'Month' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/Form',
                    width: 1100,
                    height: 700,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_GUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/Form?keyValue=' + keyValue,
                        width: 1100,
                        height: 700,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_GUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                /* $('#gridtable').jqprintTable();*/
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "产能分配批量导入模版-注:在导入时请将标题行删除！",
                        columnJson: JSON.stringify([
                            { "label": "F_CUST_CODE", "name": "F_CUST_CODE", "width": 100, "align": "center" },
                            { "label": "F_PRODUCT_SERIES", "name": "F_PRODUCT_SERIES", "width": 100, "align": "center" },
                            { "label": "F_PACKAGE_MODEL", "name": "F_PACKAGE_MODEL", "width": 100, "align": "center" },                            
                            { "label": "F_PLAN_MONTH_ONE", "name": "F_PLAN_MONTH_ONE", "width": 100, "align": "center" },
                            { "label": "F_REAL_MONTH_ONE", "name": "F_REAL_MONTH_ONE", "width": 100, "align": "center" },
                            { "label": "F_PLAN_MONTH_TWO", "name": "F_PLAN_MONTH_TWO", "width": 100, "align": "center" },
                            { "label": "F_REAL_MONTH_TWO", "name": "F_REAL_MONTH_TWO", "width": 100, "align": "center" },
                            { "label": "F_PLAN_MONTH_THREE", "name": "F_PLAN_MONTH_THREE", "width": 100, "align": "center" },
                            { "label": "F_REAL_MONTH_THREE", "name": "F_REAL_MONTH_THREE", "width": 100, "align": "center" },
                            { "label": "F_WT_QTY", "name": "F_WT_QTY", "width": 100, "align": "center" },
                            { "label": "F_KC_QTY", "name": "F_KC_QTY", "width": 100, "align": "center" },
                            { "label": "F_ALLOT_QTY", "name": "F_ALLOT_QTY", "width": 100, "align": "center" },
                            { "label": "F_ALLOT_DAY_QTY", "name": "F_ALLOT_DAY_QTY", "width": 100, "align": "center" }]),
                        dataJson: JSON.stringify([{
                            "F_CUST_CODE": "客户代码","F_PRODUCT_SERIES": "系列", "F_PACKAGE_MODEL": "外形", 
                            "F_PLAN_MONTH_ONE": "月份一计划", "F_REAL_MONTH_ONE": "月份一实际", "F_PLAN_MONTH_TWO": "月份二计划",
                            "F_REAL_MONTH_TWO": "月份二实际", "F_PLAN_MONTH_THREE": "月份三计划", "F_REAL_MONTH_THREE": "月份三实际",
                            "F_WT_QTY": "未投", "F_KC_QTY": "库存", "F_ALLOT_QTY": "产能", "F_ALLOT_DAY_QTY": "日投量"
                        }])
                    }
                });
            });
            //  导入
            $('#B2B_INPUT').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '批导功能',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/ImportExcel',
                    width: 380,
                    height: 400,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/GetPageList',
                headData: [
                    { label: "分配月份", name: "F_ALLOT_MONTH", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'Month',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "分配人员", name: "F_ALLOT_PERSON", width: 100, align: "left"},
                ],
                mainId:'F_GUID',
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
