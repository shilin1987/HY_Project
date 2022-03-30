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
    /// 日 期：2021-11-04 15:16
    /// 描 述：工龄工资
    /// </summary>
    public class SeniorityPayClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HR_SeniorityPayTableEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                s.F_RealName F_UserName,
                t.F_MonthLength,
                t.F_CostMoney
                ");
                strSql.Append("  FROM HR_SeniorityPayTable t,lr_base_user s ");
                strSql.Append("  WHERE 1=1 and t.F_UserId = s.F_UserId ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId",queryParam["F_UserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserId = @F_UserId ");
                }
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserName Like @F_UserName ");
                }
                return this.BaseRepository().FindList<HR_SeniorityPayTableEntity>(strSql.ToString(),dp, pagination);
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

        public IEnumerable<HR_SeniorityPayTableEntity> GetList(string f_Userid, string f_Month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                s.F_RealName F_UserName,
                t.F_MonthLength,
                t.F_CostMoney
                ");
                strSql.Append("  FROM HR_SeniorityPayTable t,lr_base_user s ");
                strSql.Append("  WHERE 1=1 and t.F_UserId = s.F_UserId ");
                // 虚拟参数
                if (!f_Userid.IsEmpty())
                {
                    strSql.Append(" AND t.F_UserId = '"+ f_Userid + "' ");
                }
                if (!f_Month.IsEmpty())
                {
                    strSql.Append(" AND t.F_MonthLength = '"+ f_Month + "' ");
                }
                return this.BaseRepository().FindList<HR_SeniorityPayTableEntity>(strSql.ToString());
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
        /// 获取HR_SeniorityPayTable表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public HR_SeniorityPayTableEntity GetHR_SeniorityPayTableEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<HR_SeniorityPayTableEntity>(keyValue);
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
                this.BaseRepository().Delete<HR_SeniorityPayTableEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, HR_SeniorityPayTableEntity entity)
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
