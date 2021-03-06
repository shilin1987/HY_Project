/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-27 18:33
 * 描  述：报道节点审批维护
 */
var refreshGirdData;
var selectedRow = null;
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
            $('#F_WhetherTheAudit').lrDataItemSelect({ code: 'approvalStatus' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                selectedRow = $('#gridtable').jfGridGet('rowdata');
              
                var keyValue = $('#gridtable').jfGridValue('F_ID');
      
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            //  重新上传
            $('#lr_upfile').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                //console.log("打印回传的值:" + keyValue);
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否重新上传！', function (res) {
                        if (res) {
                            learun.generalPostForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/ResetInfo', { keyValue: keyValue }, "", function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  报道审批通过
            $('#lr_audit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                //console.log("打印回传的值:" + keyValue);
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否报道审批通过！', function (res) {
                        if (res) {
                            learun.generalPostForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/AuditInfo', { keyValue: keyValue }, "", function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  报道审批不通过
            $('#lr_unaudit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                //console.log("打印回传的值:" + keyValue);
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否报道审批不通过！', function (res) {
                        if (res) {
                            learun.generalPostForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/UnAuditInfo', { keyValue: keyValue }, "", function () {
                                //var dataObj = eval("(" + res + ")");
                                //learun.alert.info(dataObj.info);
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  批量审批通过
            $('#lr_Batch').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                //console.log("打印回传的值:" + keyValue);
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否批量审批通过！', function (res) {
                        if (res) {
                            learun.generalPostForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/BatchAuditInfo', { keyValue: keyValue }, "", function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/GetPageList',
                headData: [
                    { label: "人员姓名", name: "F_UserName", width: 100, align: "center"},
                    { label: "身份证号", name: "F_CardId", width: 100, align: "center" },
                    { label: "性别", name: "F_Sex", width: 100, align: "center" },
                    { label: "联系方式", name: "F_Contact", width: 100, align: "center" },
                    { label: "学历", name: "F_EducationInformation", width: 100, align: "center" },
                    { label: "银行卡号", name: "F_BankCardNumber", width: 100, align: "center" },
                    {
                        label: "证件审核操作", name: "F_HeadIcon", width: 100, align: "center",
                        formatter: function (value, row, op, $cell) {
                            var $div = $('<div></div>');
                            var $hbtn = $('<span class=\"label label-info\" style=\"cursor: pointer;margin-right:8px;\">证件信息' + '</span>');
                            $hbtn.on('click', function () {
                                //var name = $(this).text();
                                //alert(name);
                                var keyValue = $('#gridtable').jfGridValue('F_CardId');
                                if (learun.checkrow(keyValue)) {
                                    learun.layerForm({
                                        id: 'DormitoryForm',
                                        title: '证件审核',
                                        url: top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/DormitoryForm?keyValue=' + keyValue,
                                        width: 600,
                                        height: 400,
                                        callBack: function (id) {
                                            return top[id].acceptClick(refreshGirdData);
                                        }
                                    });
                                }
                            });
                            $div.append($hbtn);
                            return $div;
                        }},
                    { label: "报道时间", name: "F_StoryTime", width: 100, align: "center" },
                    {
                        label: "所处环节", name: "F_NodeWhere", width: 100, align: "center" ,
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'inductionProcess',
                                key: value,
                                keyId: 'id',
                                callback: function (_data) {
                                    callback(_data['name']);
                                }
                            });
                        }
                    },
                    {
                        label: "报道审批操作", name: "F_WhetherTheAudit", width: 100, align: "center",
                        formatter: function (value, row, op, $cell) {
                            var $div = $('<div></div>');
                            var $hbtn = $('<span class=\"label label-info\" style=\"cursor: pointer;margin-right:8px;\">报道通过' + '</span>');
                            $hbtn.on('click', function () {
                                var keyValue = $('#gridtable').jfGridValue('F_ID');
                                //console.log("打印回传的值:" + keyValue);
                                if (learun.checkrow(keyValue)) {
                                    learun.layerConfirm('是否报道审批通过！', function (res) {
                                        if (res) {
                                            learun.generalPostForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/AuditInfo', { keyValue: keyValue }, "", function () {
                                                refreshGirdData();
                                            });
                                        }
                                    });
                                }
                            });
                            $div.append($hbtn);
                            return $div;
                        }
                    },
                    {
                        label: "所住宿舍", name: "F_DormitoryButton", width: 100, align: "center"
                    }
                ],
                mainId: 'F_ID',
                //isEidt: true,
                isMultiselect: true,
                //multiselectfield: 'F_ID',
                isPage: true
            });
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        },
        onSelectRow: function (item) {
            selectedRow = item.F_ID;
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
