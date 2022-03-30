using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.SalaryGeneration;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using Newtonsoft.Json.Linq;
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
    /// 日 期：2021-06-03 10:51
    /// 描 述：最终工资结算展示
    /// </summary>
    public class SalaryGenerationService : RepositoryFactory
    {

        ReturnCommon<DataTable> _return;
        public SalaryGenerationService()
        {
            _return = new ReturnCommon<DataTable>();
        }
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_SalaryGenerationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_WagesYearMonth,
                t.F_AbsenceFromDuty,
                t.F_RewardPunishmentSubsidy,
                t.F_FiveInsurancesOneFund,
                t.F_RoomRate,
                t.F_OvertimePay,
                t.F_TotalManagementSystem,
                t.F_WagesPayable,
                t.F_PersonalIncomeTax,
                t.F_ElectricityFees,
                t.F_PartyMembershipDues,
                t.F_FinancialDeduction,
                t.F_NetSalary
                ");
                strSql.Append("  FROM Hy_hr_SalaryGeneration t ");
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
                    dp.Add("F_UserId",queryParam["F_UserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserId = @F_UserId ");
                }
                if (!queryParam["F_WagesYearMonth"].IsEmpty())
                {
                    dp.Add("F_WagesYearMonth", "%" + queryParam["F_WagesYearMonth"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_WagesYearMonth Like @F_WagesYearMonth ");
                }
                
                return this.BaseRepository().FindList<Hy_hr_SalaryGenerationEntity>(strSql.ToString(),dp, pagination);
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
        /// 
        /// </summary>
        /// <param name="f_Userid"></param>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_SalaryGenerationEntity> GetHy_hr_SalaryGenerationEntity(string f_Userid, string yearMonth)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_WagesYearMonth,
                t.F_AbsenceFromDuty,
                t.F_RewardPunishmentSubsidy,
                t.F_FiveInsurancesOneFund,
                t.F_RoomRate,
                t.F_OvertimePay,
                t.F_TotalManagementSystem,
                t.F_WagesPayable,
                t.F_PersonalIncomeTax,
                t.F_ElectricityFees,
                t.F_PartyMembershipDues,
                t.F_FinancialDeduction,
                t.F_NetSalary
                ");
                strSql.Append("  FROM Hy_hr_SalaryGeneration t ");
                strSql.Append("  WHERE 1=1 ");
                strSql.Append("  and  t.F_UserId= '"+ f_Userid + "' and  t.F_WagesYearMonth= '"+ yearMonth + "' ");

                return this.BaseRepository().FindList<Hy_hr_SalaryGenerationEntity>(strSql.ToString());
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
        /// 
        /// </summary>
        /// <param name="f_Userid"></param>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public IEnumerable<SalaryGenerationEntityDTO> GetSalaryGenerationEntityList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_WagesYearMonth,
                lbu.F_WorkingSystem F_Category,
                lbu.F_SalaryMethod F_PostLevel,
                s.f_ps15 F_StandardWage,
                t.F_ID,
                t.F_UserId,
                s.f_ps03 NAME,
                lbd.F_FullName F_DeptName,
                '' F_Jobs,
                lbu.F_Entrydate F_StartTime,
                case when (lbu.F_TypesResignation = '' or lbu.F_TypesResignation is null) then '在职' else '离职' end F_UserState,
                lbu.F_DepartureDate F_LeaveTime,
                t.F_StatutoryHolidaysMoney,
                t.F_CommunicationAllowance,
                t.F_SeniorityPay,
                t.F_DelaySalary,
                t.F_NightShiftAllowance,
                t.F_Note,
                s.f_ps04 F_BasePay,
                s.f_ps14 F_PerformancePay,
                s.f_ps05 F_SkillSalary,
                s.f_ps09 F_HousingSubsidy,
                s.f_ps08 F_TransportationSubsidy,
                s.f_ps10 F_DutyAllowance,
                s.f_ps07 F_PerfectAttendance,
                d.F_SocialInsurance F_SocialInsurance,
                d.F_HousingAccumulationFund F_HousingAccumulationFund,
                t.F_AbsenceFromDuty,
                t.F_RewardPunishmentSubsidy,
                t.F_FiveInsurancesOneFund,
                ro.F_Cost F_RoomRate,
                t.F_OvertimePay,
                t.F_TotalManagementSystem,
                t.F_WagesPayable,
                t.F_PersonalIncomeTax,
                we.F_SettlementCost F_ElectricityFees,
                t.F_PartyMembershipDues,
                t.F_FinancialDeduction,
                t.F_NetSalary
                ");
                strSql.Append("  FROM Hy_hr_SalaryGeneration t , Hr_personalStandards_file s ,Hy_hr_FiveInsurancesOneFund d,lr_base_user lbu,lr_base_department lbd , Hy_hr_RoomRate ro ,Hy_hr_WaterElectricity we");
                strSql.Append("  WHERE 1=1 AND t.F_UserId = s.f_ps02 and t.F_UserId = d.F_UserId and d.F_SettlementYearMonth = t.F_WagesYearMonth and t.F_UserId = lbu.F_UserId and lbu.F_SecondaryOrganization = lbd.F_DepartmentId and  t.F_UserId = ro.F_UserId  and t.F_WagesYearMonth = ro.F_RoomRateYreaMonth  and  t.F_UserId = we.F_UserId  and t.F_WagesYearMonth = we.F_SettlementYearMonth ");
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
                if (!queryParam["F_WagesYearMonth"].IsEmpty())
                {
                    dp.Add("F_WagesYearMonth", "%" + queryParam["F_WagesYearMonth"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_WagesYearMonth Like @F_WagesYearMonth ");
                }

                return this.BaseRepository().FindList<SalaryGenerationEntityDTO>(strSql.ToString(), dp, pagination);
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
        /// 获取Hy_hr_SalaryGeneration表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_SalaryGenerationEntity GetHy_hr_SalaryGenerationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_SalaryGenerationEntity>(keyValue);
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
                this.BaseRepository().Delete<Hy_hr_SalaryGenerationEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, Hy_hr_SalaryGenerationEntity entity)
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


        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  int SaveListEntity(List<Hy_hr_SalaryGenerationEntity> entity)
        {
            int count = 0;
            try
            {
                count = this.BaseRepository().Update(entity);
                this.BaseRepository().Commit();
            }
            catch (Exception ex)
            {
                //出现异常事物回滚
            //    this.BaseRepository().Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
            return count;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public DataTable ExcelreportEntity(Pagination pagination, string queryJson) {
            DataTable data = new DataTable();
            try
            {
                JObject queryParam = new JObject();
                if (queryJson != null && queryJson != "null")
                {
                    queryParam = queryJson.ToJObject();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("序号");//序号
                dt.Columns.Add("月份");
                dt.Columns.Add("类别");
                dt.Columns.Add("岗级");
                dt.Columns.Add("员工编号");
                dt.Columns.Add("姓名");
                dt.Columns.Add("部门");
                dt.Columns.Add("岗位");
                dt.Columns.Add("入职时间");
                dt.Columns.Add("员工状态");
                dt.Columns.Add("离职时间");
                dt.Columns.Add("工资标准");
                dt.Columns.Add("基本工资");
                dt.Columns.Add("绩效工资");
                dt.Columns.Add("技能工资");
                dt.Columns.Add("住房补贴");
                dt.Columns.Add("交通补贴");
                dt.Columns.Add("值班补贴");
                dt.Columns.Add("全勤奖（应发）");
                dt.Columns.Add("缺勤扣款");
                dt.Columns.Add("奖惩补贴");
                dt.Columns.Add("法定节假日加班工资");
                dt.Columns.Add("通讯补贴");
                dt.Columns.Add("工龄工资（倒班）");
                dt.Columns.Add("延时工资（倒班）");
                dt.Columns.Add("夜班津贴（倒班）");
                dt.Columns.Add("应发工资");
                dt.Columns.Add("社会保险");
                dt.Columns.Add("住房公积金");
                dt.Columns.Add("个税缴纳");
                dt.Columns.Add("房费");
                dt.Columns.Add("电费");
                dt.Columns.Add("党费");
                dt.Columns.Add("财务扣款");
                dt.Columns.Add("实发工资");
                dt.Columns.Add("备注");

                string strSql = "select  t.F_WagesYearMonth,lbu.F_WorkingSystem F_Category, lbu.F_SalaryMethod F_PostLevel,s.f_ps15 F_StandardWage,t.F_ID," +
                "lbu.F_EnCode,s.f_ps03 NAME,lbd.F_FullName F_DeptName, '' F_Jobs,lbu.F_Entrydate F_StartTime,case when(lbu.F_TypesResignation = '' or lbu.F_TypesResignation is null) then '在职' else '离职' end F_UserState," +
                "lbu.F_DepartureDate F_LeaveTime,t.F_StatutoryHolidaysMoney, t.F_CommunicationAllowance,t.F_SeniorityPay, t.F_DelaySalary,t.F_NightShiftAllowance,t.F_Note, s.f_ps04 F_BasePay," +
                " s.f_ps14 F_PerformancePay, s.f_ps05 F_SkillSalary,s.f_ps09 F_HousingSubsidy,s.f_ps08 F_TransportationSubsidy," +
                "s.f_ps10 F_DutyAllowance, s.f_ps07 F_PerfectAttendance,d.F_SocialInsurance F_SocialInsurance,d.F_HousingAccumulationFund F_HousingAccumulationFund, t.F_AbsenceFromDuty," +
                "t.F_RewardPunishmentSubsidy,t.F_FiveInsurancesOneFund,t.F_RoomRate," +
                "t.F_WagesPayable, t.F_PersonalIncomeTax,t.F_ElectricityFees," +
                "t.F_PartyMembershipDues, t.F_FinancialDeduction,t.F_NetSalary" +
                "  FROM Hy_hr_SalaryGeneration t , Hr_personalStandards_file s ,Hy_hr_FiveInsurancesOneFund d,lr_base_user lbu,lr_base_department lbd " +
                "  WHERE 1=1 AND t.F_UserId = s.f_ps02 and t.F_UserId = d.F_UserId and d.F_SettlementYearMonth = t.F_WagesYearMonth and t.F_UserId = lbu.F_UserId and lbu.F_SecondaryOrganization = lbd.F_DepartmentId ";

               data = this.BaseRepository().FindTable(strSql);

                if (data?.Rows.Count > 0)
                {
                    int idx = 1;
                    foreach (DataRow dr in data.Rows)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = idx.ToString();
                        row[1] = dr["F_WagesYearMonth"].ToString();
                        row[2] = dr["F_Category"].ToString();
                        row[3] = dr["F_PostLevel"].ToString();
                        row[4] = dr["F_EnCode"].ToString();
                        row[5] = dr["NAME"].ToString();
                        row[6] = dr["F_DeptName"].ToString();
                        row[7] = dr["F_Jobs"].ToString();
                        row[8] = dr["F_StartTime"].ToString();
                        row[9] = dr["F_UserState"].ToString(); ;
                        row[10] = dr["F_LeaveTime"].ToString();
                        row[11] = dr["F_StandardWage"].ToString();
                        row[12] = dr["F_BasePay"].ToString();
                        row[13] = dr["F_PerformancePay"].ToString();
                        row[14] = dr["F_SkillSalary"].ToString();
                        row[15] = dr["F_HousingSubsidy"].ToString();
                        row[16] = dr["F_TransportationSubsidy"].ToString();
                        row[17] = dr["F_DutyAllowance"].ToString();
                        row[18] = dr["F_PerfectAttendance"].ToString();
                        row[19] = dr["F_AbsenceFromDuty"].ToString();
                        row[20] = dr["F_RewardPunishmentSubsidy"].ToString();
                        row[21] = dr["F_StatutoryHolidaysMoney"].ToString();
                        row[22] = dr["F_CommunicationAllowance"].ToString();
                        row[23] = dr["F_SeniorityPay"].ToString();
                        row[24] = dr["F_DelaySalary"].ToString();
                        row[25] = dr["F_NightShiftAllowance"].ToString();
                        row[26] = dr["F_WagesPayable"].ToString();
                        row[27] = dr["F_SocialInsurance"].ToString();
                        row[28] = dr["F_HousingAccumulationFund"].ToString();
                        row[29] = dr["F_PersonalIncomeTax"].ToString();
                        row[30] = dr["F_RoomRate"].ToString();
                        row[31] = dr["F_ElectricityFees"].ToString();
                        row[32] = dr["F_PartyMembershipDues"].ToString();
                        row[33] = dr["F_FinancialDeduction"].ToString();
                        row[34] = dr["F_NetSalary"].ToString();
                        row[35] = dr["F_Note"].ToString();
                        dt.Rows.Add(row);
                        idx++;
                    }
                }
                data = dt;
                return data;
                //_return.Status = true;
                //_return.Data = dt;
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }
            return data;
        }

       
        #endregion

    }
}
