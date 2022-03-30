/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-24 19:07
 * 描  述：月考勤数据
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
            }, 250, 450);
            $('#F_UserId').lrDataSourceSelect({ code: 'userdata',value: 'f_userid',text: 'f_encode' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/MonthlyAttendanceReport/Form',
                    width: 800,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_AttendanceSheetId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/MonthlyAttendanceReport/Form?keyValue=' + keyValue,
                        width: 800,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_AttendanceSheetId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/MonthlyAttendanceReport/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  导入
            $('#lr-import').on('click', function () {
            });
            //  导出
            $('#lr_emport').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/MonthlyAttendanceReport/GetPageList',
                headData: [
                    { label: "员工工号", name: "F_UserId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                                 key: value,
                                 keyId: 'f_userid',
                                 callback: function (_data) {
                                     callback(_data['f_encode']);
                                 }
                             });
                        }},
                    { label: "考勤日期", name: "F_AttendanceMonth", width: 100, align: "left"},
                    { label: "排班/天", name: "F_SchedulingDays", width: 100, align: "left"},
                    { label: "出勤天数", name: "F_AttendanceDays", width: 100, align: "left"},
                    { label: "排班工时", name: "F_SchedulingHours", width: 100, align: "left"},
                    { label: "出勤百分率", name: "F_PercentageAttendance", width: 100, align: "left"},
                    { label: "在岗工时", name: "F_OnDutyHours", width: 100, align: "left"},
                    { label: "实际工时", name: "F_ActualAttendanceHours", width: 100, align: "left"},
                    { label: "白班天数", name: "F_DayShiftDays", width: 100, align: "left"},
                    { label: "夜班天数", name: "F_NightShiftDays", width: 100, align: "left"},
                    { label: "长白班天数", name: "F_DaysChangbaiShift", width: 100, align: "left" }, 
                    { label: "长夜班天数", name: "F_DaysLongNightShift", width: 100, align: "left" },
                    { label: "特殊夜班工时", name: "F_SpecialNightShiftHours", width: 100, align: "left"},
                    { label: "特殊白班工时", name: "F_SpecialDayShift", width: 100, align: "left"},
                    { label: "缺勤工时", name: "F_AbsenceHours", width: 100, align: "left"},
                    { label: "OT1确认", name: "F_OT1-Confirm", width: 100, align: "left"},
                    { label: "OT1统计", name: "F_OT1-Statistics", width: 100, align: "left"},
                    { label: "OT2确认", name: "F_OT2-Confirm", width: 100, align: "left"},
                    { label: "OT2统计", name: "F_OT2-Statistics", width: 100, align: "left"},
                    { label: "OT3确认", name: "F_OT3-Confirm", width: 100, align: "left"},
                    { label: "OT3统计", name: "F_OT3-Statistics", width: 100, align: "left"},
                    { label: "倒班平日加班", name: "F_ShiftWorkOvertimeOnWeekdays", width: 100, align: "left"},
                    { label: "倒班双休加班", name: "F_OvertimeOnShift", width: 100, align: "left"},
                    { label: "年假/时", name: "F_AnnualLeaveHour", width: 100, align: "left"},
                    { label: "集团年假/时", name: "F_GroupAnnualLeaveHour", width: 100, align: "left"},
                    { label: "调休/时", name: "F_CompensatoryLeaveHour", width: 100, align: "left"},
                    { label: "放班假/时", name: "F_ClassLeaveHour", width: 100, align: "left"},
                    { label: "旷工次数", name: "F_AbsenteeismNumber", width: 100, align: "left"},
                    { label: "旷工/时", name: "F_AbsenteeismTimes", width: 100, align: "left"},
                    { label: "事假/时", name: "F_CompassionateLeaveHour", width: 100, align: "left"},
                    { label: "病假/时", name: "F_SickLeave", width: 100, align: "left"},
                    { label: "婚假/时", name: "F_MarriageHoliday", width: 100, align: "left"},
                    { label: "丧假/时", name: "F_BereavementLeaveHour", width: 100, align: "left"},
                    { label: "产检/时", name: "F_PrenatalExaminationHour", width: 100, align: "left"},
                    { label: "产假/时", name: "F_MaternityLeaveHour", width: 100, align: "left"},
                    { label: "护理假/时", name: "F_NursingLeaveHour", width: 100, align: "left"},
                    { label: "工伤假/时", name: "F_WorkRelatedInjuryLeaveHour", width: 100, align: "left"},
                    { label: "哺乳假/时", name: "F_LactationLeaveHour", width: 100, align: "left"},
                    { label: "医疗期/时", name: "F_MedicalPeriodHour", width: 100, align: "left"},
                    { label: "产前挂职/时", name: "F_AntenatalSuspendJobHour", width: 100, align: "left"},
                    { label: "停薪留职/时", name: "F_StayWithoutPayHour", width: 100, align: "left"},
                    { label: "陪产假/时", name: "F_PaternityLeaveHour", width: 100, align: "left"},
                    { label: "其他假/时", name: "F_OtherLeaveHour", width: 100, align: "left"},
                    { label: "出差/时", name: "F_BusinessTravel", width: 100, align: "left"},
                    { label: "公出/时", name: "F_BeAwayOnBusiness", width: 100, align: "left"},
                    { label: "补卡次数", name: "F_NumberCardFilling", width: 100, align: "left"},
                    { label: "迟到分钟", name: "F_MinutesLate", width: 100, align: "left"},
                    { label: "早退分钟", name: "F_LeaveEarly", width: 100, align: "left"},
                    { label: "迟到次数", name: "F_TimesBeingLlate", width: 100, align: "left"},
                    { label: "早退次数", name: "F_NumberEarlyLeave", width: 100, align: "left"},
                    { label: "白班天数", name: "F_BaiBanShiftDays", width: 100, align: "left"},
                    { label: "小夜天数", name: "F_DaysSmallNight", width: 100, align: "left"},
                    { label: "大夜天数", name: "F_DaysBigNight", width: 100, align: "left" },
                    { label: "节假日三倍工时", name: "F_TriplePayForHolidays", width: 100, align: "left" },
                ],
                mainId:'F_AttendanceSheetId',
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
