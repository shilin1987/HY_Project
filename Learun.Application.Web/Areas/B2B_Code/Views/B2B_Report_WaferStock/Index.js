/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-02-25 17:20
 * 描  述：晶圆库存报表
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
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
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_Report_WaferStock/GetPageList',
                headData: [
                    { label: "状态", name: "STATUS", width: 100, align: "left" },
                    { label: "客户代码", name: "CUST_CODE", width: 100, align: "left" },
                    { label: "客户型号", name: "CUST_DEVICE", width: 100, align: "left" },
                    { label: "晶圆型号", name: "DEVICE", width: 100, align: "left" },
                    { label: "PARTID", name: "PART_ID", width: 100, align: "left" },
                    { label: "晶圆批号", name: "CUSTLOTID", width: 100, align: "left" },
                    { label: "入库数量", name: "START_QTY", width: 100, align: "left" },
                    { label: "当前数量", name: "CURRENT_QTY", width: 100, align: "left" },
                    { label: "入库片数", name: "START_WAFER", width: 100, align: "left" },
                    { label: "当前片数", name: "CURRENT_WAFER", width: 100, align: "left" },
                    { label: "入库时间", name: "START_DATE", width: 100, align: "left" },
                    { label: "入库时间", name: "START_DATE1", width: 100, align: "left" },
                    { label: "入库时间", name: "START_DATE1", width: 100, align: "left" },
                    { label: "工单状态", name: "LOT_STATUS", width: 100, align: "left" },
                    { label: "晶圆片号", name: "WAFER_NO", width: 100, align: "left" },
                    { label: "库位", name: "WAFER_LOCATION", width: 100, align: "left" },
                    { label: "入库片数", name: "PARAM_8", width: 100, align: "left" },                  
                    { label: "取片方式", name: "PO_PARAM_17", width: 100, align: "left" },
                    { label: "工单号", name: "LOTID", width: 100, align: "left" },
                    { label: "区域", name: "WAFER_AREA", width: 100, align: "left" },
                    { label: "工单类型", name: "LOT_TYPE", width: 100, align: "left" },
                    { label: "备注", name: "REMARK", width: 100, align: "left" },
                    { label: "备注2", name: "REMARK2 ", width: 100, align: "left" }
                ],
                mainId:'F_GUID',
                isPage: true
            });
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
