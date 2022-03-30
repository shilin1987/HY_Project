using Dapper;
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
    /// 日 期：2021-06-29 16:05
    /// 描 述：考勤工资表达式
    /// </summary>
    public class AttendanceSalaryFormulaService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_FormulaId,
                t.F_ShiftType,
                t.F_FormulaCode,
                t.F_FormulaName,
                t.F_EnabledMark,
                t.F_Expression
                ");
                strSql.Append("  FROM Hy_hr_AttendanceSalaryFormula t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_FormulaCode"].IsEmpty())
                {
                    dp.Add("F_FormulaCode", "%" + queryParam["F_FormulaCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FormulaCode Like @F_FormulaCode ");
                }
                if (!queryParam["F_FormulaName"].IsEmpty())
                {
                    dp.Add("F_FormulaName", "%" + queryParam["F_FormulaName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FormulaName Like @F_FormulaName ");
                }
                if (!queryParam["F_Expression"].IsEmpty())
                {
                    dp.Add("F_Expression", "%" + queryParam["F_Expression"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Expression Like @F_Expression ");
                }
                return this.BaseRepository().FindList<Hy_hr_AttendanceSalaryFormulaEntity>(strSql.ToString(),dp, pagination);
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

        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(string shiftType)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_FormulaId,
                t.F_ShiftType,
                t.F_FormulaCode,
                t.F_FormulaName,
                t.F_Expression
                ");
                strSql.Append("  FROM Hy_hr_AttendanceSalaryFormula t ");
                strSql.Append("  WHERE 1=1 and ");
                strSql.Append("  t.F_ShiftType = '"+ shiftType + "' ");
                return this.BaseRepository().FindList<Hy_hr_AttendanceSalaryFormulaEntity>(strSql.ToString());
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
        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_FormulaId,
                t.F_ShiftType,
                t.F_FormulaCode,
                t.F_FormulaName,
                t.F_Expression
                ");
                strSql.Append("  FROM Hy_hr_AttendanceSalaryFormula t ");
                strSql.Append("  WHERE 1=1");
                return this.BaseRepository().FindList<Hy_hr_AttendanceSalaryFormulaEntity>(strSql.ToString());
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
        /// <param name="shiftType"></param>
        /// <returns></returns>
        public  Hy_hr_AttendanceSalaryFormulaEntity GetAttendanceSalaryFormulaEntity(string shiftType)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_AttendanceSalaryFormulaEntity>(e => shiftType.Equals(e.F_ShiftType));
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
        /// 获取Hy_hr_AttendanceSalaryFormula表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_AttendanceSalaryFormulaEntity GetHy_hr_AttendanceSalaryFormulaEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_AttendanceSalaryFormulaEntity>(keyValue);
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
                this.BaseRepository().Delete<Hy_hr_AttendanceSalaryFormulaEntity>(t=>t.F_FormulaId == keyValue);
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
        public void SaveEntity(string keyValue, Hy_hr_AttendanceSalaryFormulaEntity entity)
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
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Hy_hr_AttendanceSalaryFormulaEntity attendancesalary = new Hy_hr_AttendanceSalaryFormulaEntity();
                attendancesalary.Modify(keyValue);
                attendancesalary.F_EnabledMark = state;
                this.BaseRepository().Update(attendancesalary);
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
