/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-24 09:07
 * 描  述：来料计划产能分配报表
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            //  导出
            $('#output_execl').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT_REPORT/GetPageList',
                headData: [
                    { label: "分配月份", name: "F_ALLOT_MONTH", width: 100, align: "left" },
                    { label: "客户代码", name: "F_CUST_CODE", width: 100, align: "left" },
                    { label: "产品系列", name: "F_PRODUCT_SERIES", width: 100, align: "left" },
                    { label: "产品外形", name: "F_PACKAGE_MODEL", width: 100, align: "left" },
                    {
                        label: '月份一', name: 'A', width: 100, align: 'center',
                        children: [
                            { label: "计划数量", name: "F_PLAN_MONTH_ONE", width: 100, align: "left" },
                            { label: "实际数量", name: "F_REAL_MONTH_ONE", width: 100, align: "left" }
                        ]
                    },
                    {
                        label: '月份二', name: 'B', width: 100, align: 'center',
                        children: [
                            { label: "计划数量", name: "F_PLAN_MONTH_TWO", width: 100, align: "left" },
                            { label: "实际数量", name: "F_REAL_MONTH_TWO", width: 100, align: "left" }
                        ]
                    },
                    {
                        label: '月份三', name: 'C', width: 100, align: 'center',
                        children: [
                            { label: "计划数量", name: "F_PLAN_MONTH_THREE", width: 100, align: "left" },
                            { label: "实际数量", name: "F_REAL_MONTH_THREE", width: 100, align: "left" }
                        ]
                    },     
                    { label: "未投数量", name: "F_WT_QTY", width: 100, align: "left"},
                    { label: "库存数量", name: "F_KC_QTY", width: 100, align: "left"},
                    { label: "分配数量", name: "F_ALLOT_QTY", width: 100, align: "left"},
                    { label: "日分配数量", name: "F_ALLOT_DAY_QTY", width: 100, align: "left"},
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
