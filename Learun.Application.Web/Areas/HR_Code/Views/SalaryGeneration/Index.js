

/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-03 10:51
 * 描  述：最终工资结算展示
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
            }, 160, 400);
            $('#F_UserId').lrDataSourceSelect({ code: 'userdata', value: 'f_userid', text: 'f_account', allowSearch: true });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/SalaryGeneration/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/SalaryGeneration/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            //请求计算逻辑
            $('#lr_culat').on('click', function () {
                learun.generalPostForm(top.$.rootUrl + '/HR_Code/SalaryGeneration/CalculateMonthlySettlement', { keyValue: "1" },"正在计算...", function () {
                    refreshGirdData();
                });
            });

            // 删除

            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/SalaryGeneration/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  导出
            $('#lr-export').on('click', function () {
                $.ajax({
                    type: "get",  //提交方式  
                    url: top.$.rootUrl + '/HR_Code/SalaryGeneration/GetExportList',//路径  
                    success: function (result) {//返回数据根据结果进行相应的处理  
                        var obj = JSON.parse(result);
                        console.log("result.info" + obj.info)
                        window.location.href = obj.info;
                    }
                }); 
                $.ajax();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/SalaryGeneration/GetPageList',
                headData: [
                    { label: "结算日期", name: "F_WagesYearMonth", width: 100, align: "center" },
                    { label: "类别", name: "F_Category", width: 100, align: "center" },
                    { label: "岗级", name: "F_PostLevel", width: 100, align: "center" },
                    {
                        label: "员工账号", name: "F_UserId", width: 150, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                                key: value,
                                keyId: 'f_userid',
                                callback: function (_data) {
                                    callback(_data['f_account']);
                                }
                            });
                        }
                    },
                    { label: "姓名", name: "NAME", width: 100, align: "center" },
                    { label: "部门", name: "F_DeptName", width: 100, align: "center" },
                    { label: "岗位", name: "F_Jobs", width: 100, align: "center" },
                    { label: "入职时间", name: "F_StartTime", width: 100, align: "center" },
                    { label: "员工状态", name: "F_UserState", width: 100, align: "center" },
                    { label: "离职时间", name: "F_LeaveTime", width: 100, align: "center" },
                    { label: "工资标准", name: "F_StandardWage", width: 100, align: "center" },
                    { label: "基本工资", name: "F_BasePay", width: 100, align: "center" },
                    { label: "绩效工资", name: "F_PerformancePay", width: 100, align: "center" },
                    { label: "技能工资", name: "F_SkillSalary", width: 100, align: "center" },
                    { label: "住房补贴", name: "F_HousingSubsidy", width: 100, align: "center" },
                    { label: "交通补贴", name: "F_TransportationSubsidy", width: 100, align: "center" },
                    { label: "值班补贴", name: "F_DutyAllowance", width: 100, align: "center" },
                    { label: "全勤奖(应发)", name: "F_PerfectAttendance", width: 100, align: "center" },
                    { label: "缺勤扣款", name: "F_AbsenceFromDuty", width: 100, align: "center" },
                    { label: "奖惩补贴", name: "F_RewardPunishmentSubsidy", width: 100, align: "center" },
                    { label: "法定节假日加班工资", name: "F_StatutoryHolidaysMoney", width: 100, align: "center" },
                    { label: "通讯补贴", name: "F_CommunicationAllowance", width: 100, align: "center" },
                    { label: "工龄工资(倒班)", name: "F_SeniorityPay", width: 100, align: "center" },
                    { label: "延时工资(倒班)", name: "F_DelaySalary", width: 100, align: "center" },
                    { label: "夜班津贴(倒班)", name: "F_NightShiftAllowance", width: 100, align: "center" },
                    { label: "应发工资", name: "F_WagesPayable", width: 100, align: "center" },
                    {
                        label: "五险一金", name: "MyProperty", width: 80, align: 'center',
                        children: [
                            {
                                name: "F_SocialInsurance", label: "社会保险", width: 80, align: "center",
                                formatter: function (cellvalue) {
                                    return learun.toDecimal(cellvalue);
                                }
                            },
                            {
                                name: "F_HousingAccumulationFund", label: "住房公积金", width: 80, align: "center",
                                formatter: function (cellvalue) {
                                    return learun.toDecimal(cellvalue);
                                }
                            },
                        ]
                    },
                    { label: "个税缴纳", name: "F_PersonalIncomeTax", width: 100, align: "center" },
                    { label: "房费", name: "F_RoomRate", width: 100, align: "center" },
                    { label: "电费", name: "F_ElectricityFees", width: 100, align: "center" },
                    { label: "党费", name: "F_PartyMembershipDues", width: 100, align: "center" },
                    { label: "财务扣款", name: "F_FinancialDeduction", width: 100, align: "center" },
                    { label: "实发工资", name: "F_NetSalary", width: 100, align: "center" },
                    { label: "备注", name: "F_Note", width: 100, align: "center" },
                ],
                mainId: 'F_ID',
                isPage: true
            });
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
