using Dapper;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_PLAN_MATERIAL_CREATE_CUST;
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
    /// 日 期：2021-11-02 16:41
    /// 描 述：客户月度来料计划合并功能
    /// </summary>
    public class B2B_PLAN_MATERIAL_ＭERGE_CREATEService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_GUID,
                t.F_MERGE_MONTH,
                t.F_MERGE_PRESON
                ");
                strSql.Append("  FROM B2B_PLAN_MATERIAL_MERGE t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_MERGE_MONTH"].IsEmpty())
                {
                    dp.Add("F_MERGE_MONTH", queryParam["F_MERGE_MONTH"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_MERGE_MONTH = @F_MERGE_MONTH ");
                }
                if (!queryParam["F_MERGE_PRESON"].IsEmpty())
                {
                    dp.Add("F_MERGE_PRESON", "%" + queryParam["F_MERGE_PRESON"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MERGE_PRESON Like @F_MERGE_PRESON ");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_MATERIAL_MERGEEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetB2B_PLAN_MATERIAL_MERGE_SUBList(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(t => t.F_GUID == keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_MERGE_SUBEntity GetB2B_PLAN_MATERIAL_MERGE_SUBEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(t => t.F_GUID == keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_MERGEEntity GetB2B_PLAN_MATERIAL_MERGEEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_MATERIAL_MERGEEntity>(keyValue);
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
                    var b2B_PLAN_MATERIAL_MERGEEntity = GetB2B_PLAN_MATERIAL_MERGEEntity(keyValue);
                    //查找来料计划的GUID
                    var plandataguid = db.FindEntity<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(t => t.F_GUID == b2B_PLAN_MATERIAL_MERGEEntity.F_GUID);
                    var plandata = db.FindEntity<B2B_PLAN_INCOMING_MATERIALEntity>(t => t.F_GUID == plandataguid.F_SUBGUID);
                    //恢复删除的计划数据
                    plandata.F_MERGE_FLG = 0;
                    db.Update(plandata);

                    db.Delete<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(t => t.F_GUID == b2B_PLAN_MATERIAL_MERGEEntity.F_GUID);
                    db.Delete<B2B_PLAN_MATERIAL_MERGEEntity>(t => t.F_GUID == keyValue);
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

        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPlanData(string moth)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"select a.f_guid F_SUBGUID,b.PARTID F_PARTID,b.F_PRODUCT_MODEL,b.F_PACKAGE_MODEL," +
                $"a.F_CUST_CODE,b.F_PRODUCT_LEVEL, b.F_WAFER_MODEL, b.F_WAFER_SIZE, b.F_PACKAGING_TYPE," +
                $"b.F_WIRE_SOLDER_CODE, b.F_WIRE_SOLDER_NAME, b.F_SHELL_FRAM_CODE," +
                $"b.F_SHELL_FRAM_NAME, sum(b.F_MONTH_ONE) F_MONTH_ONE, sum(b.F_MONTH_TWO) F_MONTH_TWO," +
                $"sum(b.F_MONTH_THREE) F_MONTH_THREE,sum(b.F_MONTH_FOUR) F_MONTH_FOUR, sum(b.F_MONTH_FIVE) F_MONTH_FIVE," +
                $"sum(b.F_MONTH_SIX) F_MONTH_SIX,b.f_wire_solder_name,b.f_shell_fram_name,b.f_wire_solder_code,b.f_shell_fram_code " +
                $"from b2b_plan_incoming_material a inner join b2b_plan_incoming_material_sub b on a.f_guid = b.f_guid where a.F_MERGE_FLG=0 and a.f_write_month ='{moth}'" +
                $"group by a.f_guid, b.PARTID, b.F_PRODUCT_MODEL, b.F_PACKAGE_MODEL,b.F_PRODUCT_LEVEL, b.F_WAFER_MODEL, b.F_WAFER_SIZE, b.F_PACKAGING_TYPE,b.F_WIRE_SOLDER_CODE, b.F_WIRE_SOLDER_NAME, b.F_SHELL_FRAM_CODE," +
                $"a.F_CUST_CODE,b.F_SHELL_FRAM_NAME,b.f_wire_solder_name,b.f_shell_fram_name,b.f_wire_solder_code,b.f_shell_fram_code");

                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(strSql.ToString());

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
        public void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_MERGEEntity entity, List<B2B_PLAN_MATERIAL_MERGE_SUBEntity> b2B_PLAN_MATERIAL_MERGE_SUBList)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            int id = 1;
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.F_MERGE_DATE = DateTime.Now;
                    entity.F_PLAN_ALLOT_FLG = 0;
                    var b2B_PLAN_MATERIAL_MERGEEntityTmp = GetB2B_PLAN_MATERIAL_MERGEEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<B2B_PLAN_MATERIAL_MERGE_SUBEntity>(t => t.F_GUID == b2B_PLAN_MATERIAL_MERGEEntityTmp.F_GUID);
                    foreach (B2B_PLAN_MATERIAL_MERGE_SUBEntity item in b2B_PLAN_MATERIAL_MERGE_SUBList)
                    {
                        item.Create();
                        item.F_GUID = b2B_PLAN_MATERIAL_MERGEEntityTmp.F_GUID;
                        item.F_ID = Convert.ToString(id);
                        item.F_MERGE_MONTH = entity.F_MERGE_MONTH;
                        db.Insert(item);
                        id++;
                        var plandata = db.FindEntity<B2B_PLAN_INCOMING_MATERIALEntity>(t => t.F_GUID == item.F_SUBGUID);
                        plandata.F_MERGE_FLG = 1;
                        db.Update(plandata);
                    }
                }
                else
                {
                    entity.Create();
                    entity.F_MERGE_DATE = DateTime.Now;
                    entity.F_PLAN_ALLOT_FLG = 0;
                    db.Insert(entity);
                    foreach (B2B_PLAN_MATERIAL_MERGE_SUBEntity item in b2B_PLAN_MATERIAL_MERGE_SUBList)
                    {
                        item.Create();
                        item.F_GUID = entity.F_GUID;
                        item.F_ID = Convert.ToString(id);
                        item.F_MERGE_MONTH = entity.F_MERGE_MONTH;
                        db.Insert(item);
                        id++;
                        var plandata = db.FindEntity<B2B_PLAN_INCOMING_MATERIALEntity>(t => t.F_GUID == item.F_SUBGUID);
                        plandata.F_MERGE_FLG = 1;
                        db.Update(plandata);
                    }
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
