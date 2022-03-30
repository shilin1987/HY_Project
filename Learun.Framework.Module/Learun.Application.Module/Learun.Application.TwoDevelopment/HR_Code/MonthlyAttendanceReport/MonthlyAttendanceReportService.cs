﻿using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-24 19:07
    /// 描 述：月考勤数据
    /// </summary>
    public class MonthlyAttendanceReportService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_AttendanceSheetEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_AttendanceSheetId,
                t.F_UserId,
                t.F_AttendanceMonth,
                t.F_SchedulingDays,
                t.F_AttendanceDays,
                t.F_SchedulingHours,
                t.F_PercentageAttendance,
                t.F_OnDutyHours,
                t.F_ActualAttendanceHours,
                t.F_DayShiftDays,
                t.F_NightShiftDays,
                t.F_DaysChangbaiShift,
                t.F_DaysLongNightShift,
                t.F_SpecialNightShiftHours,
                t.F_SpecialDayShift,
                t.F_AbsenceHours,
                t.F_OT1Confirm,
                t.F_OT1Statistics,
                t.F_OT2Confirm,
                t.F_OT2Statistics,
                t.F_OT3Confirm,
                t.F_OT3Statistics,
                t.F_ShiftWorkOvertimeOnWeekdays,
                t.F_OvertimeOnShift,
                t.F_AnnualLeaveHour,
                t.F_GroupAnnualLeaveHour,
                t.F_CompensatoryLeaveHour,
                t.F_ClassLeaveHour,
                t.F_AbsenteeismNumber,
                t.F_AbsenteeismTimes,
                t.F_CompassionateLeaveHour,
                t.F_SickLeave,
                t.F_MarriageHoliday,
                t.F_BereavementLeaveHour,
                t.F_PrenatalExaminationHour,
                t.F_MaternityLeaveHour,
                t.F_NursingLeaveHour,
                t.F_WorkRelatedInjuryLeaveHour,
                t.F_LactationLeaveHour,
                t.F_MedicalPeriodHour,
                t.F_AntenatalSuspendJobHour,
                t.F_StayWithoutPayHour,
                t.F_PaternityLeaveHour,
                t.F_OtherLeaveHour,
                t.F_BusinessTravel,
                t.F_BeAwayOnBusiness,
                t.F_NumberCardFilling,
                t.F_MinutesLate,
                t.F_LeaveEarly,
                t.F_TimesBeingLlate,
                t.F_NumberEarlyLeave,
                t.F_BaiBanShiftDays,
                t.F_DaysSmallNight,
                t.F_DaysBigNight
                ");
                strSql.Append("  FROM Hy_hr_AttendanceSheet t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", queryParam["F_UserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserId = @F_UserId ");
                }
                if (!queryParam["F_AttendanceMonth"].IsEmpty())
                {
                    dp.Add("F_AttendanceMonth", "%" + queryParam["F_AttendanceMonth"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_AttendanceMonth Like @F_AttendanceMonth ");
                }
                if (!queryParam["F_AttendanceDays"].IsEmpty())
                {
                    dp.Add("F_AttendanceDays", "%" + queryParam["F_AttendanceDays"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_AttendanceDays Like @F_AttendanceDays ");
                }
                if (!queryParam["F_PercentageAttendance"].IsEmpty())
                {
                    dp.Add("F_PercentageAttendance", "%" + queryParam["F_PercentageAttendance"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PercentageAttendance Like @F_PercentageAttendance ");
                }
                if (!queryParam["F_SchedulingHours"].IsEmpty())
                {
                    dp.Add("F_SchedulingHours", "%" + queryParam["F_SchedulingHours"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_SchedulingHours Like @F_SchedulingHours ");
                }
                if (!queryParam["F_OnDutyHours"].IsEmpty())
                {
                    dp.Add("F_OnDutyHours", "%" + queryParam["F_OnDutyHours"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OnDutyHours Like @F_OnDutyHours ");
                }
                if (!queryParam["F_ActualAttendanceHours"].IsEmpty())
                {
                    dp.Add("F_ActualAttendanceHours", "%" + queryParam["F_ActualAttendanceHours"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ActualAttendanceHours Like @F_ActualAttendanceHours ");
                }
                return this.BaseRepository().FindList<Hy_hr_AttendanceSheetEntity>(strSql.ToString(), dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        public IEnumerable<Hy_hr_AttendanceSheetEntity> GetMonthList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_AttendanceSheetId,
                t.F_UserId,
                t.F_AttendanceMonth,
                t.F_SchedulingDays,
                t.F_AttendanceDays,
                t.F_SchedulingHours,
                t.F_PercentageAttendance,
                t.F_OnDutyHours,
                t.F_ActualAttendanceHours,
                t.F_DayShiftDays,
                t.F_NightShiftDays,
                t.F_DaysChangbaiShift,
                t.F_DaysLongNightShift,
                t.F_SpecialNightShiftHours,
                t.F_SpecialDayShift,
                t.F_AbsenceHours,
                t.F_OT1Confirm,
                t.F_OT1Statistics,
                t.F_OT2Confirm,
                t.F_OT2Statistics,
                t.F_OT3Confirm,
                t.F_OT3Statistics,
                t.F_ShiftWorkOvertimeOnWeekdays,
                t.F_OvertimeOnShift,
                t.F_AnnualLeaveHour,
                t.F_GroupAnnualLeaveHour,
                t.F_CompensatoryLeaveHour,
                t.F_ClassLeaveHour,
                t.F_AbsenteeismNumber,
                t.F_AbsenteeismTimes,
                t.F_CompassionateLeaveHour,
                t.F_SickLeave,
                t.F_MarriageHoliday,
                t.F_BereavementLeaveHour,
                t.F_PrenatalExaminationHour,
                t.F_MaternityLeaveHour,
                t.F_NursingLeaveHour,
                t.F_WorkRelatedInjuryLeaveHour,
                t.F_LactationLeaveHour,
                t.F_MedicalPeriodHour,
                t.F_AntenatalSuspendJobHour,
                t.F_StayWithoutPayHour,
                t.F_PaternityLeaveHour,
                t.F_OtherLeaveHour,
                t.F_BusinessTravel,
                t.F_BeAwayOnBusiness,
                t.F_NumberCardFilling,
                t.F_MinutesLate,
                t.F_LeaveEarly,
                t.F_TimesBeingLlate,
                t.F_NumberEarlyLeave,
                t.F_BaiBanShiftDays,
                t.F_DaysSmallNight,
                t.F_DaysBigNight,
                t.F_TriplePayForHolidays
                ");

                strSql.Append("  FROM Hy_hr_AttendanceSheet t ");
                strSql.Append("  WHERE 1=1 ");
                return this.BaseRepository().FindList<Hy_hr_AttendanceSheetEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取Hy_hr_AttendanceSheet表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_AttendanceSheetEntity GetHy_hr_AttendanceSheetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_AttendanceSheetEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<Hy_hr_AttendanceSheetEntity>(t => t.F_AttendanceSheetId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, Hy_hr_AttendanceSheetEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
