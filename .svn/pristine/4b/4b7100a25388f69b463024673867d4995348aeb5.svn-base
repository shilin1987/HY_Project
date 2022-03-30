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
    /// 日 期：2021-11-24 09:07
    /// 描 述：来料计划产能分配报表
    /// </summary>
    public class B2B_PLAN_MATERIAL_ALLOT_REPORTService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_GUID,
                t.F_ALLOT_MONTH,
                t.F_ALLOT_PERSON,
                t.F_ALLOT_DATE,
                t1.F_CUST_CODE,
                t1.F_PRODUCT_SERIES,
                t1.F_PACKAGE_MODEL,
                t1.F_PLAN_MONTH_ONE,
                t1.F_REAL_MONTH_ONE,
                t1.F_PLAN_MONTH_TWO,
                t1.F_REAL_MONTH_TWO,
                t1.F_PLAN_MONTH_THREE,
                t1.F_REAL_MONTH_THREE,
                t1.F_WT_QTY,
                t1.F_KC_QTY,
                t1.F_ALLOT_QTY,
                t1.F_ALLOT_DAY_QTY
                ");
                strSql.Append("  FROM B2B_PLAN_MATERIAL_ALLOT t ");
                strSql.Append("  LEFT JOIN B2B_PLAN_MATERIAL_ALLOT_SUB t1 ON t1.F_GUID = t.F_GUID ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ALLOT_MONTH"].IsEmpty())
                {
                    dp.Add("F_ALLOT_MONTH", "%" + queryParam["F_ALLOT_MONTH"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ALLOT_MONTH Like @F_ALLOT_MONTH ");
                }
                if (!queryParam["F_ALLOT_PERSON"].IsEmpty())
                {
                    dp.Add("F_ALLOT_PERSON", "%" + queryParam["F_ALLOT_PERSON"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ALLOT_PERSON Like @F_ALLOT_PERSON ");
                }
                if (!queryParam["F_CUST_CODE"].IsEmpty())
                {
                    dp.Add("F_CUST_CODE", "%" + queryParam["F_CUST_CODE"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_CUST_CODE Like @F_CUST_CODE ");
                }
                if (!queryParam["F_PACKAGE_MODEL"].IsEmpty())
                {
                    dp.Add("F_PACKAGE_MODEL", "%" + queryParam["F_PACKAGE_MODEL"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_PACKAGE_MODEL Like @F_PACKAGE_MODEL ");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取B2B_PLAN_MATERIAL_ALLOT_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_ALLOT_SUBEntity GetB2B_PLAN_MATERIAL_ALLOT_SUBEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>(t=>t.F_GUID == keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_ALLOT表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_ALLOTEntity GetB2B_PLAN_MATERIAL_ALLOTEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_MATERIAL_ALLOTEntity>(keyValue);
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
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                var b2B_PLAN_MATERIAL_ALLOTEntity = GetB2B_PLAN_MATERIAL_ALLOTEntity(keyValue); 
                db.Delete<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>(t=>t.F_GUID == b2B_PLAN_MATERIAL_ALLOTEntity.F_GUID);
                db.Delete<B2B_PLAN_MATERIAL_ALLOTEntity>(t=>t.F_GUID == keyValue);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
        public void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_ALLOTEntity entity,B2B_PLAN_MATERIAL_ALLOT_SUBEntity b2B_PLAN_MATERIAL_ALLOT_SUBEntity)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var b2B_PLAN_MATERIAL_ALLOTEntityTmp = GetB2B_PLAN_MATERIAL_ALLOTEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>(t=>t.F_GUID == b2B_PLAN_MATERIAL_ALLOTEntityTmp.F_GUID);
                    b2B_PLAN_MATERIAL_ALLOT_SUBEntity.Create();
                    b2B_PLAN_MATERIAL_ALLOT_SUBEntity.F_GUID = b2B_PLAN_MATERIAL_ALLOTEntityTmp.F_GUID;
                    db.Insert(b2B_PLAN_MATERIAL_ALLOT_SUBEntity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    b2B_PLAN_MATERIAL_ALLOT_SUBEntity.Create();
                    b2B_PLAN_MATERIAL_ALLOT_SUBEntity.F_GUID = entity.F_GUID;
                    db.Insert(b2B_PLAN_MATERIAL_ALLOT_SUBEntity);
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
