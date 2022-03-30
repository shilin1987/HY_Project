/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-03-01 16:38
 * 描  述：WIP产品报表
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
            }, 220, 490);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_Report_WIP/GetPageList',
                headData: [
                    { label: "客户代码", name: "customer", width: 100, align: "left" },
                    { label: "客户PO", name: "cust_po", width: 100, align: "left" },
                    { label: "封装形式", name: "package_code", width: 100, align: "left" },
                    { label: "产品型号", name: "custpartin", width: 100, align: "left" },
                    { label: "工单类型", name: "lottype", width: 100, align: "left" },
                    { label: "PartID", name: "part_id", width: 100, align: "left" },
                    { label: "工单号", name: "parentid", width: 100, align: "left" },
                    { label: "下线日期", name: "loading_date2", width: 100, align: "left" },
                    { label: "总数量", name: "total", width: 100, align: "left" },
                    { label: "下线数量", name: "loading_qty", width: 100, align: "left" },
                    { label: "PDS", name: "pds", width: 100, align: "left" },
                    { label: "晶圆检验", name: "iqc002", width: 100, align: "left" },
                    { label: "划片工序", name: "dsw010", width: 100, align: "left" },
                    { label: "上芯工序", name: "dat020", width: 100, align: "left" },
                    { label: "压焊工序", name: "wbd030", width: 100, align: "left" },
                    { label: "PDM", name: "pdm", width: 100, align: "left" },
                    { label: "压塑工序", name: "mld040", width: 100, align: "left" },
                    { label: "后固化工序", name: "pmc050", width: 100, align: "left" },
                    { label: "锡化工序", name: "plt060", width: 100, align: "left" },
                    { label: "灌胶工序", name: "flg070", width: 100, align: "left" },
                    { label: "切筋工序", name: "tnf080", width: 100, align: "left" },
                    { label: "封装完结", name: "afn090", width: 100, align: "left" },
                    { label: "测试待产", name: "xfe_test", width: 100, align: "left" },
                    { label: "测试工序", name: "tst100", width: 100, align: "left" },
                    { label: "FVI", name: "fvi", width: 100, align: "left" },
                    { label: "包装工序", name: "packing", width: 100, align: "left" },
                    { label: "外包工序", name: "out_packing", width: 100, align: "left" },
                    { label: "出厂产品型号", name: "custpartout", width: 100, align: "left" },
                    { label: "流水号", name: "cust_unique_id", width: 100, align: "left" },
                    { label: "芯片型号", name: "custdevice", width: 100, align: "left" },
                    { label: "批号", name: "waferlotno", width: 100, align: "left" },
                    { label: "周号", name: "datecode", width: 100, align: "left" },
                    { label: "下线日期", name: "loading_date", width: 100, align: "left" },
                    { label: "FLG", name: "flg", width: 100, align: "left" },
                    { label: "封装等级", name: "assemblygrade", width: 100, align: "left" },
                    { label: "行项目", name: "po_line_no ", width: 100, align: "left" },
                    { label: "过期日期", name: "delivery_date ", width: 100, align: "left" },
                ],
                mainId: 'F_GUID',
                isPage: true
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
