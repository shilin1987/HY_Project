/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-05 15:35
 * 描  述：客户月度来料计划合并报表
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
            //  导出
            $('#B2B_OUTPUT').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {           
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_MERGE_REPORT/GetPageList',
                headData: [
                    { label: "合并月份", name: "F_MERGE_MONTH", width: 100, align: "left" },
                    {
                        label: '客户代码', name: 'F_CUST_CODE', width: 100, align: 'left'
                    },
                    {
                        label: '产品型号', name: 'F_PRODUCT_MODEL', width: 100, align: 'left'
                    },
                    {
                        label: '封装形式', name: 'F_PACKAGE_MODEL', width: 100, align: 'left'
                    },
                    {
                        label: '封装等级', name: 'F_PRODUCT_LEVEL', width: 100, align: 'left'
                    },
                    {
                        label: '芯片型号', name: 'F_WAFER_MODEL', width: 100, align: 'left'
                    },
                    {
                        label: '晶圆尺寸', name: 'F_WAFER_SIZE', width: 100, align: 'left'
                    },
                    {
                        label: '包装方式', name: 'F_PACKAGING_TYPE', width: 100, align: 'left'
                    },                   
                    {
                        label: '填报月份', name: 'A', width: 100, align: 'center',
                        children: [
                            {
                                label: '一', name: 'F_MONTH_ONE', width: 70, align: 'center'
                            },
                            {
                                label: '二', name: 'F_MONTH_TWO', width: 70, align: 'center'
                            },
                            {
                                label: '三', name: 'F_MONTH_THREE', width: 70, align: 'center'
                            },
                            {
                                label: '四', name: 'F_MONTH_FOUR', width: 70, align: 'center'
                            },
                            {
                                label: '五', name: 'F_MONTH_FIVE', width: 70, align: 'center'
                            },
                            {
                                label: '六', name: 'F_MONTH_SIX', width: 70, align: 'center'
                            }
                        ]
                    },
                    {
                        label: '焊线描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'
                    },
                    {
                        label: '框架描述', name: 'F_SHELL_FRAM_NAME', width: 100, align: 'left'
                    },
                ],               
                isPage: true,
                isSubGrid: false
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
