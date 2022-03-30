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
    /// 日 期：2022-01-24 14:32
    /// 描 述：晶圆清单导入
    /// </summary>
    public class B2B_WAFER_LISTService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_WAFER_LISTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.FGUID,
                t.FCUST_CODE,
                t.FCREATE_DATE,
                t.FFILE_NAME,
                t.FADRESS,
                t.FCHECK_DATE,
                t.FCHECK_PERSON,
                case when t.FMANAGE_FLG=0 then '未审核' else '已审核' end FMANAGE_FLG
                ");
                strSql.Append("  FROM B2B_WAFER_LIST t ");              
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository("B2BDatabase").FindList<B2B_WAFER_LISTEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取B2B_WAFER_LIST表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_WAFER_LISTEntity GetB2B_WAFER_LISTEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_WAFER_LISTEntity>(t=>t.FGUID == keyValue);
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
        /// 获取B2B_WAFER_LIST_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_WAFER_LIST_SUBEntity GetB2B_WAFER_LIST_SUBEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_WAFER_LIST_SUBEntity>(keyValue);
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
                db.Delete<B2B_WAFER_LISTEntity>(t=>t.FGUID == keyValue);
                db.Delete<B2B_WAFER_LIST_SUBEntity>(t=>t.FGUID == keyValue);
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

        public void Saveupload(B2B_WAFER_LISTEntity entity, List<B2B_WAFER_LIST_SUBEntity> entitysub)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            int id = 1;
            try
            {
                entity.Create();
                entity.FCREATE_DATE = System.DateTime.Now;
                entity.FMANAGE_FLG = "0";

                db.Insert(entity);
                foreach (var item in entitysub)
                {
                    item.Create();
                    item.FGUID = entity.FGUID;
                    item.FID = Convert.ToString(id);
                    db.Insert(item);                  
                    id++;
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

        public IEnumerable<B2B_WAFER_LIST_SUBEntity> GetPageListSub(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"SELECT * FROM b2b_wafer_list_sub where FGUID = '{keyValue}'");

                return this.BaseRepository("B2BDatabase").FindList<B2B_WAFER_LIST_SUBEntity>(strSql.ToString());
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
        public void SaveEntity(string keyValue, B2B_WAFER_LIST_SUBEntity entity,B2B_WAFER_LISTEntity b2B_WAFER_LISTEntity)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var b2B_WAFER_LIST_SUBEntityTmp = GetB2B_WAFER_LIST_SUBEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<B2B_WAFER_LISTEntity>(t=>t.FGUID == b2B_WAFER_LIST_SUBEntityTmp.FGUID);
                    b2B_WAFER_LISTEntity.Create();
                    b2B_WAFER_LISTEntity.FGUID = b2B_WAFER_LIST_SUBEntityTmp.FGUID;
                    db.Insert(b2B_WAFER_LISTEntity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    b2B_WAFER_LISTEntity.Create();
                    b2B_WAFER_LISTEntity.FGUID = entity.FGUID;
                    db.Insert(b2B_WAFER_LISTEntity);
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
