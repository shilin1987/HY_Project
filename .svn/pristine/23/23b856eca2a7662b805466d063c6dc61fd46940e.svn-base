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
    /// 日 期：2021-11-04 15:55
    /// 描 述：薪酬计算财务扣款
    /// </summary>
    public class FinancialDeductionsClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_FinancialDeductionsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserID,
                s.F_RealName F_UserName,
                t.F_MonthFinancial,
                t.F_DeductionsMoney
                ");
                strSql.Append("  FROM Hr_FinancialDeductions t,lr_base_user s ");
                strSql.Append("  WHERE 1=1 and t.F_UserId = s.F_UserId  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UserID"].IsEmpty())
                {
                    dp.Add("F_UserID",queryParam["F_UserID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserID = @F_UserID ");
                }
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserName Like @F_UserName ");
                }
                if (!queryParam["F_MonthFinancial"].IsEmpty())
                {
                    dp.Add("F_MonthFinancial", "%" + queryParam["F_MonthFinancial"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MonthFinancial Like @F_MonthFinancial ");
                }
                return this.BaseRepository().FindList<Hr_FinancialDeductionsEntity>(strSql.ToString(),dp, pagination);
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

        public  IEnumerable<Hr_FinancialDeductionsEntity> GetList(string f_Userid, string f_month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserID,
                s.F_RealName F_UserName,
                t.F_MonthFinancial,
                t.F_DeductionsMoney
                ");
                strSql.Append("  FROM Hr_FinancialDeductions t,lr_base_user s ");
                strSql.Append("  WHERE 1=1 and t.F_UserId = s.F_UserId  ");

                if (!f_Userid.IsEmpty())
                {
                    strSql.Append(" AND t.F_UserID = '"+ f_Userid + "' ");
                }
                if (!f_month.IsEmpty())
                {
                    strSql.Append(" AND t.F_MonthFinancial = '"+ f_month + "' ");
                }
                return this.BaseRepository().FindList<Hr_FinancialDeductionsEntity>(strSql.ToString());
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

        internal IEnumerable<Hr_FinancialDeductionsEntity> GetList(string v1, string f_Userid, string v2, string f_month)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取Hr_FinancialDeductions表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_FinancialDeductionsEntity GetHr_FinancialDeductionsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_FinancialDeductionsEntity>(keyValue);
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
                this.BaseRepository().Delete<Hr_FinancialDeductionsEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, Hr_FinancialDeductionsEntity entity)
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
