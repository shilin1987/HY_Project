﻿using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-24 19:07
    /// 描 述：月考勤数据
    /// </summary>
    public class Hy_hr_AttendanceSheetEntity 
    {
        #region 实体成员
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 考勤日期(年月)
        /// </summary>
        [Column("F_ATTENDANCEMONTH")]
        public string F_AttendanceMonth { get; set; }
        /// <summary>
        /// 排班天数
        /// </summary>
        [Column("F_SCHEDULINGDAYS")]
        public decimal? F_SchedulingDays { get; set; }
        /// <summary>
        /// 出勤天数
        /// </summary>
        [Column("F_ATTENDANCEDAYS")]
        public decimal? F_AttendanceDays { get; set; }
        /// <summary>
        /// 排班工时
        /// </summary>
        [Column("F_SCHEDULINGHOURS")]
        public decimal? F_SchedulingHours { get; set; }
        /// <summary>
        /// 出勤百分率
        /// </summary>
        [Column("F_PERCENTAGEATTENDANCE")]
        public decimal? F_PercentageAttendance { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_ATTENDANCESHEETID")]
        public string F_AttendanceSheetId { get; set; }
        /// <summary>
        /// 在岗工时
        /// </summary>
        [Column("F_ONDUTYHOURS")]
        public decimal? F_OnDutyHours { get; set; }
        /// <summary>
        /// 实际出勤工时
        /// </summary>
        [Column("F_ACTUALATTENDANCEHOURS")]
        public decimal? F_ActualAttendanceHours { get; set; }
        /// <summary>
        /// 白班天数
        /// </summary>
        [Column("F_DAYSHIFTDAYS")]
        public decimal? F_DayShiftDays { get; set; }
        /// <summary>
        /// 夜班天数
        /// </summary>
        [Column("F_NIGHTSHIFTDAYS")]
        public decimal? F_NightShiftDays { get; set; }
        /// <summary>
        /// 长白班天数
        /// </summary>
        [Column("F_DAYSCHANGBAISHIFT")]
        public decimal? F_DaysChangbaiShift { get; set; }

        /// <summary>
        /// 长夜班天数
        /// </summary>
        [Column("F_DAYSLONGNIGHTSHIFT")]
        public decimal? F_DaysLongNightShift { get; set; }
        
        /// <summary>
        /// 特殊夜班工时
        /// </summary>
        [Column("F_SPECIALNIGHTSHIFTHOURS")]
        public decimal? F_SpecialNightShiftHours { get; set; }
        /// <summary>
        /// 特殊白班工时
        /// </summary>
        [Column("F_SPECIALDAYSHIFT")]
        public decimal? F_SpecialDayShift { get; set; }
        /// <summary>
        /// 缺勤工时
        /// </summary>
        [Column("F_ABSENCEHOURS")]
        public decimal? F_AbsenceHours { get; set; }
        /// <summary>
        /// OT1-确认
        /// </summary>
        [Column("F_OT1CONFIRM")]
        public decimal? F_OT1Confirm { get; set; }
        /// <summary>
        /// OT1-统计
        /// </summary>
        [Column("F_OT1STATISTICS")]
        public decimal? F_OT1Statistics { get; set; }
        /// <summary>
        /// 倒班平日加班
        /// </summary>
        [Column("F_SHIFTWORKOVERTIMEONWEEKDAYS")]
        public decimal? F_ShiftWorkOvertimeOnWeekdays { get; set; }
        /// <summary>
        /// 倒班双休加班
        /// </summary>
        [Column("F_OVERTIMEONSHIFT")]
        public decimal? F_OvertimeOnShift { get; set; }
        /// <summary>
        /// OT2-统计
        /// </summary>
        [Column("F_OT2STATISTICS")]
        public decimal? F_OT2Statistics { get; set; }
        /// <summary>
        /// OT2-确认
        /// </summary>
        [Column("F_OT2CONFIRM")]
        public decimal? F_OT2Confirm { get; set; }
        /// <summary>
        /// OT3-确认
        /// </summary>
        [Column("F_OT3CONFIRM")]
        public decimal? F_OT3Confirm { get; set; }
        /// <summary>
        /// OT3-统计
        /// </summary>
        [Column("F_OT3STATISTICS")]
        public decimal? F_OT3Statistics { get; set; }
        /// <summary>
        /// 年假/时
        /// </summary>
        [Column("F_ANNUALLEAVEHOUR")]
        public decimal? F_AnnualLeaveHour { get; set; }
        /// <summary>
        /// 集团年假/时
        /// </summary>
        [Column("F_GROUPANNUALLEAVEHOUR")]
        public decimal? F_GroupAnnualLeaveHour { get; set; }
        /// <summary>
        /// 调休/时
        /// </summary>
        [Column("F_COMPENSATORYLEAVEHOUR")]
        public decimal? F_CompensatoryLeaveHour { get; set; }
        /// <summary>
        /// 放班假/时
        /// </summary>
        [Column("F_CLASSLEAVEHOUR")]
        public decimal? F_ClassLeaveHour { get; set; }
        /// <summary>
        /// 旷工次数
        /// </summary>
        [Column("F_ABSENTEEISMNUMBER")]
        public decimal? F_AbsenteeismNumber { get; set; }
        /// <summary>
        /// 旷工/时
        /// </summary>
        [Column("F_ABSENTEEISMTIMES")]
        public decimal? F_AbsenteeismTimes { get; set; }
        /// <summary>
        /// 事假/时
        /// </summary>
        [Column("F_COMPASSIONATELEAVEHOUR")]
        public decimal? F_CompassionateLeaveHour { get; set; }
        /// <summary>
        /// 病假/时
        /// </summary>
        [Column("F_SICKLEAVE")]
        public decimal? F_SickLeave { get; set; }
        /// <summary>
        /// 婚假/时
        /// </summary>
        [Column("F_MARRIAGEHOLIDAY")]
        public decimal? F_MarriageHoliday { get; set; }
        /// <summary>
        /// 丧假/时
        /// </summary>
        [Column("F_BEREAVEMENTLEAVEHOUR")]
        public decimal? F_BereavementLeaveHour { get; set; }
        /// <summary>
        /// 产检/时
        /// </summary>
        [Column("F_PRENATALEXAMINATIONHOUR")]
        public decimal? F_PrenatalExaminationHour { get; set; }
        /// <summary>
        /// 产假/时
        /// </summary>
        [Column("F_MATERNITYLEAVEHOUR")]
        public decimal? F_MaternityLeaveHour { get; set; }
        /// <summary>
        /// 护理假/时
        /// </summary>
        [Column("F_NURSINGLEAVEHOUR")]
        public decimal? F_NursingLeaveHour { get; set; }
        /// <summary>
        /// 工伤假/时
        /// </summary>
        [Column("F_WORKRELATEDINJURYLEAVEHOUR")]
        public decimal? F_WorkRelatedInjuryLeaveHour { get; set; }
        /// <summary>
        /// 哺乳假/时
        /// </summary>
        [Column("F_LACTATIONLEAVEHOUR")]
        public decimal? F_LactationLeaveHour { get; set; }
        /// <summary>
        /// 医疗期/时
        /// </summary>
        [Column("F_MEDICALPERIODHOUR")]
        public decimal? F_MedicalPeriodHour { get; set; }
        /// <summary>
        /// 产前挂职/时
        /// </summary>
        [Column("F_ANTENATALSUSPENDJOBHOUR")]
        public decimal? F_AntenatalSuspendJobHour { get; set; }
        /// <summary>
        /// 停薪留职/时
        /// </summary>
        [Column("F_STAYWITHOUTPAYHOUR")]
        public decimal? F_StayWithoutPayHour { get; set; }
        /// <summary>
        /// 陪产假/时
        /// </summary>
        [Column("F_PATERNITYLEAVEHOUR")]
        public decimal? F_PaternityLeaveHour { get; set; }
        /// <summary>
        /// 其他假/时
        /// </summary>
        [Column("F_OTHERLEAVEHOUR")]
        public decimal? F_OtherLeaveHour { get; set; }
        /// <summary>
        /// 出差/时
        /// </summary>
        [Column("F_BUSINESSTRAVEL")]
        public decimal? F_BusinessTravel { get; set; }
        /// <summary>
        /// 公出/时
        /// </summary>
        [Column("F_BEAWAYONBUSINESS")]
        public decimal? F_BeAwayOnBusiness { get; set; }
        /// <summary>
        /// 补卡次数
        /// </summary>
        [Column("F_NUMBERCARDFILLING")]
        public int? F_NumberCardFilling { get; set; }
        /// <summary>
        /// 迟到分钟
        /// </summary>
        [Column("F_MINUTESLATE")]
        public int? F_MinutesLate { get; set; }
        /// <summary>
        /// 早退分钟
        /// </summary>
        [Column("F_LEAVEEARLY")]
        public int? F_LeaveEarly { get; set; }
        /// <summary>
        /// 迟到次数
        /// </summary>
        [Column("F_TIMESBEINGLLATE")]
        public int? F_TimesBeingLlate { get; set; }
        /// <summary>
        /// 早退次数
        /// </summary>
        [Column("F_NUMBEREARLYLEAVE")]
        public int? F_NumberEarlyLeave { get; set; }
        /// <summary>
        /// 白班天数
        /// </summary>
        [Column("F_BAIBANSHIFTDAYS")]
        public decimal? F_BaiBanShiftDays { get; set; }
        /// <summary>
        /// 小夜天数
        /// </summary>
        [Column("F_DAYSSMALLNIGHT")]
        public int? F_DaysSmallNight { get; set; }
        /// <summary>
        /// 大夜天数
        /// </summary>
        [Column("F_DAYSBIGNIGHT")]
        public int? F_DaysBigNight { get; set; }

        /// <summary>
        /// 节假日三倍工时
        /// </summary>
        [Column("F_TRIPLEPAYFORHOLIDAYS")]
        public int? F_TriplePayForHolidays { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_AttendanceSheetId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_AttendanceSheetId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

