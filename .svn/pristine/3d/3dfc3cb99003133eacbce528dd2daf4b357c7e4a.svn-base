/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-16 19:34
 * 描  述：菜价补贴月汇总数据
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
            }, 120, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            //  导出
            $('#lr_emport').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/HrMonthAllData/GetPageList',
                headData: [
                    //{ label: "系统id", name: "Oid", width: 180, align: "center", ishide: true },
                    { label: "年份", name: "Yearno", width: 100, align: "center" },
                    { label: "月份", name: "Monthno", width: 100, align: "center" },
                    { label: "成本中心编号", name: "Cost_centerno", width: 180, align: "center" },
                    { label: "成本中心", name: "Cost_center", width: 180, align: "center"},
                    { label: "成本中心人员合计", name: "Countperson", width: 180, align: "center"},
                    { label: "成本中心金额合计", name: "Summoney", width: 180, align: "center"},
                    { label: "平均金额", name: "Avgmoney", width: 180, align: "center"},
                    { label: "备注", name: "Bk", width: 180, align: "center"},
                ],
               // mainId:'Oid',
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
