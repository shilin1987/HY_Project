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
    /// 日 期：2022-01-12 21:11
    /// 描 述：菜价补贴月明细数据
    /// </summary>
    public class FSVegetablePriceSubsidyMonthlyDetailsService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePriceSubsidyMonthlyDetailsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_UserName,
                t.F_Year,
                t.F_Month,
                t.F_ShiftType,
                s.shift_name F_ShiftName,
                s.shift_type F_ShiftTypeExend,
                t.F_Time,
                s.timelimit F_ShiftTime,
                t.F_Qk,
                t.F_Breakfast,
                t.F_Lunch,
                t.F_Dinner,
                t.F_Night,
                t.F_StandardCombined
                ");
                strSql.Append("  FROM FS_VegetablePriceSubsidyMonthlyDetails t left join Hr_SHIFTTIMETAB_file s  on t.F_ShiftType = s.shift_no ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", "%" + queryParam["F_UserId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserId Like @F_UserId ");
                }
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserName Like @F_UserName ");
                }
                if (!queryParam["F_Year"].IsEmpty())
                {
                    dp.Add("F_Year", "%" + queryParam["F_Year"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Year Like @F_Year ");
                }
                if (!queryParam["F_Month"].IsEmpty())
                {
                    dp.Add("F_Month", "%" + queryParam["F_Month"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Month Like @F_Month ");
                }
                return this.BaseRepository().FindList<FS_VegetablePriceSubsidyMonthlyDetailsEntity>(strSql.ToString(),dp, pagination);
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

        public IEnumerable<FS_VegetablePriceSubsidyMonthlyDetailsEntity> GetAllList(string year, string month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_UserName,
                t.F_Year,
                t.F_Month,
                t.F_ShiftType,
                t.F_Qk,
                t.F_Breakfast,
                t.F_Lunch,
                t.F_Dinner,
                t.F_Night,
                t.F_StandardCombined
                ");
                strSql.Append("  FROM FS_VegetablePriceSubsidyMonthlyDetails t ");
                strSql.Append("  WHERE 1=1 and t.F_Year='"+year+ "' AND t.F_Month ='"+ month + "' ");
                return this.BaseRepository().FindList<FS_VegetablePriceSubsidyMonthlyDetailsEntity>(strSql.ToString());
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
        /// 获取FS_VegetablePriceSubsidyMonthlyDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public FS_VegetablePriceSubsidyMonthlyDetailsEntity GetFS_VegetablePriceSubsidyMonthlyDetailsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<FS_VegetablePriceSubsidyMonthlyDetailsEntity>(keyValue);
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
                this.BaseRepository().Delete<FS_VegetablePriceSubsidyMonthlyDetailsEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, FS_VegetablePriceSubsidyMonthlyDetailsEntity entity)
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
