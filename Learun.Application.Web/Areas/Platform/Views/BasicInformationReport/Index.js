﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-02-23 14:41
 * 描  述：应聘者基础信息报表
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.bind();
            page.initGird();
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
            //流程
            $('#SubProcessId').lrDataSourceSelect({ code: 'SubProcess', value: 'MainProcessId', text: 'name' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/BasicInformationReport/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/BasicInformationReport/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/Platform/BasicInformationReport/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/BasicInformationReport/GetPageList',
                headData: [
                        { label: '员工编号', name: 'F_EnCode', width: 100, align: "center" },
                    { label: '姓名', name: 'F_RealName', width: 100, align: "center" },
                    { label: '部门', name: 'F_DepartmentNmae', width: 100, align: "center" },
                    { label: '入职日期', name: 'F_Entrydate', width: 100, align: "center" },
                    { label: '证件类型', name: 'F_DocumentType', width: 100, align: "center" },
                    { label: '身份证号', name: 'F_IDCard', width: 150, align: "center" },
                    { label: '婚姻状况', name: 'F_MaritalStatus', width: 100, align: "center" },
                    { label: '出生日期', name: 'F_Birthday', width: 100, align: "center" },
                        {
                            label: '性别', name: 'F_Gender', width: 45, align: 'center' ,
                            formatter: function (cellvalue) {
                                return cellvalue == 0 ? "女" : "男";
                            }
                        },
                    { label: '籍贯', name: 'F_NativePlace', width: 100, align: "center" },
                    { label: '家庭居住地', name: 'F_ResidentialAddress', width: 200, align: "center" },
                    { label: '联系方式', name: 'F_Mobile', width: 100, align: "center" },
                    { label: '通讯地址', name: 'F_CurrentAddress', width: 200, align: "center" },
                    { label: '户籍地址', name: 'F_IDCardAddress', width: 200, align: "center" },
                    { label: '职业名称', name: 'F_PostName', width: 100, align: "center" },
                    { label: '户籍性质', name: 'F_RRNature', width: 100, align: "center" },
                    { label: '民族', name: 'F_Nation', width: 50, align: "center" },
                    { label: '最高学历开始时间', name: 'F_EducationStartDate', width: 100, align: "center" },
                    { label: '最高学历结束时间', name: 'F_EducationEndDate', width: 100, align: "center" },
                    { label: '学历', name: 'F_Education', width: 100, align: "center" },
                    { label: '毕业院校', name: 'F_GraduationUniversitie', width: 100, align: "center" },
                    { label: '专业', name: 'F_MajorStudied', width: 100, align: "center" },
                    { label: '外语水平', name: 'F_ForeignLanguageLevel', width: 100, align: "center" },
                    { label: '开户银行', name: 'F_BankDeposit', width: 200, align: "center" },
                    { label: '银行卡号', name: 'F_BankCardNumber', width: 200, align: "center" },
                    { label: '内部推荐人公司', name: 'F_InternalCompany', width: 200, align: "center" },
                    { label: '内部推荐人编码', name: 'F_InternalCode', width: 100, align: "center" },
                    { label: '内部推荐人姓名', name: 'F_InternalName', width: 100, align: "center" },
                    { label: '身份证开始日期', name: 'F_IDCardStartDate', width: 100, align: "center" },
                    { label: '身份证结束日期', name: 'F_IDCardEndDate', width: 100, align: "center" },
                    { label: '政治面貌', name: 'F_PoliticalOutlook', width: 100, align: "center" },
                    { label: '紧急联系人', name: 'F_EmergencyContact', width: 100, align: "center" },
                    { label: '紧急联系人关系', name: 'F_EContactRelationship', width: 100, align: "center" },
                    { label: '紧急联系人电话', name: 'F_EContactNumber', width: 100, align: "center" },
                    { label: '招聘渠道', name: 'F_RecruitmentChannels', width: 100, align: "center" },
                    { label: '第一工作经历', name: 'F_OneWorkexperience', width: 200, align: "center" },
                    { label: '第二工作经历', name: 'F_TwoWorkexperience', width: 200, align: "center" },
                    {
                        label: "面试官", name: "F_CreateUserName", width: 100, align: "left"
                        //formatterAsync: function (callback, value, row, op, $cell) {
                        //    learun.clientdata.getAsync('custmerData', {
                        //        url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                        //        key: value,
                        //        keyId: 'f_userid',
                        //        callback: function (_data) {
                        //            callback(_data['f_realname']);
                        //        }
                        //    });
                        //}
                    },
                ],
                mainId:'F_UserId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
