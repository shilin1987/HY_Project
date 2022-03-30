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
    /// 创 建：B2B_Account
    /// 日 期：2021-10-28 15:35
    /// 描 述：来料计划填报
    /// </summary>
    public class B2B_PLAN_CREATEService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_INCOMING_MATERIALEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_GUID,
                t.F_CUST_CODE,
                t.F_WRITE_MONTH,
                t.F_WRITE_PRESON,
                t.F_WRITE_DATE
                ");
                strSql.Append("  FROM B2B_PLAN_INCOMING_MATERIAL t ");
                //strSql.Append("  WHERE F_MERGE_FLG=0 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CUST_CODE"].IsEmpty())
                {
                    dp.Add("F_CUST_CODE", "%" + queryParam["F_CUST_CODE"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CUST_CODE Like @F_CUST_CODE ");
                }
                if (!queryParam["F_WRITE_MONTH"].IsEmpty())
                {
                    dp.Add("F_WRITE_MONTH", queryParam["F_WRITE_MONTH"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_WRITE_MONTH = @F_WRITE_MONTH ");
                }
                if (!queryParam["F_WRITE_PRESON"].IsEmpty())
                {
                    dp.Add("F_WRITE_PRESON", "%" + queryParam["F_WRITE_PRESON"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_WRITE_PRESON Like @F_WRITE_PRESON ");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_INCOMING_MATERIALEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetB2B_PLAN_INCOMING_MATERIAL_SUBList(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == keyValue);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_INCOMING_MATERIAL_SUBEntity GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == keyValue);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_INCOMING_MATERIALEntity GetB2B_PLAN_INCOMING_MATERIALEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_PLAN_INCOMING_MATERIALEntity>(keyValue);
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

        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetPartidData(string custcode, string PRODUCT_MODEL, string PACKAGING_TYPE, string PACKAGE_MODEL, string WAFER_MODEL)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"SELECT PARTID,产品型号 F_PRODUCT_MODEL,内部封装外形 F_PACKAGE_MODEL,封装等级 F_PRODUCT_LEVEL," +
                $"包装方式 F_PACKAGING_TYPE, 芯片型号 F_WAFER_MODEL, 晶圆尺寸 F_WAFER_SIZE, 焊线物料编码 F_WIRE_SOLDER_CODE," +
                $"焊线物料描述 F_WIRE_SOLDER_NAME, 框架物料编码 F_SHELL_FRAM_CODE, 框架物料描述 as F_SHELL_FRAM_NAME  " +
                $"FROM V_PLAN_MESPARTID where 客户代码 = '{custcode}' and 产品型号 like '%{PRODUCT_MODEL}%' " +
                $" and 内部封装外形 like '%{PACKAGE_MODEL}%' and 包装方式 like '%{PACKAGING_TYPE}%' and 芯片型号 like '%{WAFER_MODEL}%' order by 内部封装外形");

                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(strSql.ToString());
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

        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetPageListSub(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == keyValue); ;
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
        public void DeleteEntity(string keyValue, out bool have)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                DataTable plandata = db.FindTable($"select * from B2B_PLAN_INCOMING_MATERIAL where f_guid='{keyValue}' and f_merge_flg=1");
                if (plandata.Rows.Count > 0)
                {
                    have = true;
                }
                else
                {
                    have = false;
                    var b2B_PLAN_INCOMING_MATERIALEntity = GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
                    db.Delete<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == b2B_PLAN_INCOMING_MATERIALEntity.F_GUID);
                    db.Delete<B2B_PLAN_INCOMING_MATERIALEntity>(t => t.F_GUID == keyValue);
                    db.Commit();
                }
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
        public void SaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity, List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBList, out bool have, out string outmsg, out bool inforerror)
        {
            bool err = false;
            have = false;
            string msg = "";
            var id = 1;
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {                   
                    DataTable plandata = db.FindTable($"select * from B2B_PLAN_INCOMING_MATERIAL where  F_CUST_CODE='{entity.F_CUST_CODE}' and  f_write_month='{entity.F_WRITE_MONTH}'");
                    if (plandata.Rows.Count > 0)
                    {
                        have = false;
                        err = false;
                        foreach (DataRow item in plandata.Rows)
                        {
                            if (item["F_MERGE_FLG"].ToString() == "1")
                            {
                                have = true;
                                err = true;
                                msg = "已经对此客户的料计划进行了合并,不能重复填报！";
                            }
                            if (plandata.Rows.Count >= 1 && keyValue == "")
                            {
                                have = true;
                                err = true;
                                msg = "已经对此客户进行过来料计划填报！如果数据不对请进行修改或删除后重新填报！";
                            }
                        }
                    }
                    if (err == false)  
                    {       
                        var b2B_PLAN_INCOMING_MATERIALEntityTmp = GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
                        entity.Modify(keyValue);
                        db.Update(entity);
                        db.Delete<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == b2B_PLAN_INCOMING_MATERIALEntityTmp.F_GUID);
                        foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBList)
                        {
                            DataTable partdata = db.FindTable($"select partid,客户代码 from V_PLAN_MESPARTID where partid='{item.PARTID}'");
                            if (partdata.Rows.Count > 0)
                            {
                                foreach (DataRow itemsub in partdata.Rows)
                                {
                                    if (itemsub["客户代码"].ToString() == Convert.ToString(entity.F_CUST_CODE))
                                    {
                                        item.Create();
                                        item.F_GUID = b2B_PLAN_INCOMING_MATERIALEntityTmp.F_GUID;
                                        item.F_ID = Convert.ToString(id);
                                        db.Insert(item);
                                        id++;
                                    }
                                    else
                                    {
                                        msg = "PARTID：" + item.PARTID.ToString() + "不是指定客户的信息！";
                                        err = true;
                                    }
                                }
                            }
                            else
                            {
                                msg = "上传的Partid:" + item.PARTID.ToString() + "在MES系统中没找到对应的信息！";
                                err = true;
                            }
                        }
                    }
                }
                else
                {
                    have = false;
                    entity.Create();
                    entity.F_MERGE_FLG = 0;
                    entity.F_WRITE_DATE = Convert.ToString(DateTime.Now);
                    db.Insert(entity);
                    foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBList)
                    {
                        DataTable partdata = db.FindTable($"select partid,客户代码 from V_PLAN_MESPARTID where partid='{item.PARTID}'");
                        if (partdata.Rows.Count > 0)
                        {
                            foreach (DataRow itemsub in partdata.Rows)
                            {
                                if (itemsub["客户代码"].ToString() == Convert.ToString(entity.F_CUST_CODE))
                                {
                                    item.Create();
                                    item.F_GUID = entity.F_GUID;
                                    item.F_ID = Convert.ToString(id);
                                    db.Insert(item);
                                    id++;
                                }
                                else
                                {
                                    msg = "PARTID：" + item.PARTID.ToString() + "不是指定客户的信息！";
                                    err = true;
                                }
                            }
                        }
                        else
                        {
                            msg = "上传的Partid:" + item.PARTID.ToString() + "在MES系统中没找到对应的信息！"; ;
                            err = true;
                        }
                    }
                }
                if (err == false)
                {
                    db.Commit();
                }
                inforerror = err;
                outmsg = msg;
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
