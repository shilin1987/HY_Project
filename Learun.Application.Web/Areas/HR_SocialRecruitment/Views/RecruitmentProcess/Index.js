/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-10-28 10:05
 * 描  述：简历审批结果查询
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

            //
            $('#F_WhetherThrough').lrDataItemSelect({ code: 'IsAdopt' });
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
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_SocialRecruitment/RecruitmentProcess/DeleteForm', { keyValue: keyValue}, function () {
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
            $('#lr_export').on('click', function () {
                var newUrl = top.$.rootUrl + '/HR_SocialRecruitment/RecruitmentProcess/ExportExsel';     //设置新提交地址
                $("#formname").attr('action', newUrl);     //通过jquery为action属性赋值
                $("#formname").submit();     //提交ID为myform的表单
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_SocialRecruitment/RecruitmentProcess/GetPageList',
                headData: [
                    { label: "申请单编号", name: "F_HrIndicatesOrderNumber", width: 200, align: "left"},
                    { label: "简历名称", name: "F_ResumeName", width: 200, align: "left"},
                    { label: "审批结果", name: "F_WhetherThrough", width: 100, align: "left"}
                   
                ],
                mainId: 'F_ID',
                isPage: true,
                reloadSelected: true,
                isSubGrid: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/HR_SocialRecruitment/RecruitmentProcess/GetSubList',
                        headData: [
                            { label: "审批流程", name: "F_ProcessName", width: 100, align: "left" },
                            { label: "审批人", name: "F_Approver", width: 100, align: "left" },
                            { label: "审批结果", name: "F_ApprovalResults", width: 100, align: "left" },
                            { label: "审批日期", name: "F_ApprovalDate", width: 150, align: "left" },
                            { label: "审批意见", name: "F_ApprovalComments", width: 100, align: "left" }
                        ]
                    });
                    $('#' + subid).jfGridSet('reload', { fid: rowdata.F_ID });
                }
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
