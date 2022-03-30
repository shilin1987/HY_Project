﻿using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-22 16:56
    /// 描 述：来料计划填报推送提醒
    /// </summary>
    public class B2B_CUST_PLAN_WARNService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_CUST_PLAN_WARNEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_GUID,
                t.F_CUST_CODE,
                t.F_SUBJECT,
                t.F_RECIPIENTS,
                t.F_COPY_TO,
                t.F_CONTENT,
                t.F_DAY,
                t.F_TIME
                ");
                strSql.Append("  FROM B2B_CUST_PLAN_WARN t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CUST_CODE"].IsEmpty())
                {
                    dp.Add("F_CUST_CODE", "%" + queryParam["F_CUST_CODE"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CUST_CODE Like @F_CUST_CODE ");
                }
                if (!queryParam["F_DAY"].IsEmpty())
                {
                    dp.Add("F_DAY",queryParam["F_DAY"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DAY = @F_DAY ");
                }
                if (!queryParam["F_TIME"].IsEmpty())
                {
                    dp.Add("F_TIME",queryParam["F_TIME"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_TIME = @F_TIME ");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_CUST_PLAN_WARNEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取B2B_CUST_PLAN_WARN表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_CUST_PLAN_WARNEntity GetB2B_CUST_PLAN_WARNEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_CUST_PLAN_WARNEntity>(keyValue);
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
                this.BaseRepository("B2BDatabase").Delete<B2B_CUST_PLAN_WARNEntity>(t=>t.F_GUID == keyValue);
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
        public void SaveEntity(string keyValue, B2B_CUST_PLAN_WARNEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("B2BDatabase").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("B2BDatabase").Insert(entity);
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
