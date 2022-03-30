using Dapper;
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
    /// 日 期：2021-11-05 15:35
    /// 描 述：客户月度来料计划合并报表
    /// </summary>
    public class B2B_PLAN_MATERIAL_MERGE_REPORTService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"       
                t1.F_CUST_CODE,
                t1.F_MERGE_MONTH,
                t1.F_PRODUCT_MODEL,
                t1.F_PACKAGE_MODEL,
                t1.F_WAFER_MODEL,
                t1.F_WAFER_SIZE,
                t1.F_PRODUCT_LEVEL,
                t1.F_PACKAGING_TYPE,
                t1.F_WIRE_SOLDER_NAME,
                t1.F_SHELL_FRAM_NAME,
                t1.F_MONTH_ONE,
                t1.F_MONTH_TWO,
                t1.F_MONTH_THREE,
                t1.F_MONTH_FOUR,
                t1.F_MONTH_FIVE,
                t1.F_MONTH_SIX
                ");
                strSql.Append("  FROM B2B_PLAN_MATERIAL_MERGE t ");
                strSql.Append("  LEFT JOIN B2B_PLAN_MATERIAL_MERGE_SUB t1 ON t1.F_GUID = t.F_GUID ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_MERGE_DATE >= @startTime AND t.F_MERGE_DATE <= @endTime ) ");
                }
                if (!queryParam["F_MERGE_MONTH"].IsEmpty())
                {
                    dp.Add("F_MERGE_MONTH", "%" + queryParam["F_MERGE_MONTH"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MERGE_MONTH Like @F_MERGE_MONTH ");
                }
                if (!queryParam["F_MERGE_PRESON"].IsEmpty())
                {
                    dp.Add("F_MERGE_PRESON", "%" + queryParam["F_MERGE_PRESON"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MERGE_PRESON Like @F_MERGE_PRESON ");
                }
                if (!queryParam["F_PRODUCT_MODEL"].IsEmpty())
                {
                    dp.Add("F_PRODUCT_MODEL", "%" + queryParam["F_PRODUCT_MODEL"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_PRODUCT_MODEL Like @F_PRODUCT_MODEL ");
                }
                if (!queryParam["F_PACKAGING_TYPE"].IsEmpty())
                {
                    dp.Add("F_PACKAGING_TYPE", "%" + queryParam["F_PACKAGING_TYPE"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_PACKAGING_TYPE Like @F_PACKAGING_TYPE ");
                }
                if (!queryParam["F_PRODUCT_LEVEL"].IsEmpty())
                {
                    dp.Add("F_PRODUCT_LEVEL", "%" + queryParam["F_PRODUCT_LEVEL"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_PRODUCT_LEVEL Like @F_PRODUCT_LEVEL ");
                }        
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(strSql.ToString(), dp, pagination);
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
