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
    /// 日 期：2021-11-10 13:46
    /// 描 述：客户端月度来料计划填报
    /// </summary>
    public class B2B_PLAN_MATERIAL_CREATE_CUSTService : RepositoryFactory
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
                t.F_WRITE_MONTH,
                t.F_CUST_CODE,
                t.F_WRITE_PRESON,
                t.F_WRITE_DATE
                ");
                strSql.Append("  FROM B2B_PLAN_INCOMING_MATERIAL t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(string keyValue)
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
                //DataTable plan_data = db.FindTable($"select * from B2B_PLAN_INCOMING_MATERIAL where f.guid='{keyValue}' and f_merge_flg=1");
                //if (plan_data.Rows.Count > 0)
                //{
                //    //have = true;
                //}
                //else
                //{
                //    //have = false;
                var b2B_PLAN_INCOMING_MATERIALEntity = GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
                db.Delete<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == b2B_PLAN_INCOMING_MATERIALEntity.F_GUID);
                db.Delete<B2B_PLAN_INCOMING_MATERIALEntity>(t => t.F_GUID == keyValue);
                db.Commit();
                //}

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

        public IEnumerable<MES_PRODUCT_DATA> GetProuduct(string partid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"select distinct partid,产品型号 as F_PRODUCT_MODEL,内部封装外形 F_PACKAGE_MODEL," +
                $"封装等级 F_PRODUCT_LEVEL,芯片型号 F_WAFER_MODEL,晶圆尺寸 F_WAFER_SIZE,包装方式 F_PACKAGING_TYPE,焊线物料编码 F_WIRE_SOLDER_CODE," +
                $"焊线物料描述 F_WIRE_SOLDER_NAME,框架物料编码 F_SHELL_FRAM_CODE,框架物料描述 F_SHELL_FRAM_NAME from SATSP_ADMIN.V_PLAN_MESPARTID WHERE partid='{partid}'");

                return this.BaseRepository("B2BDatabase").FindList<MES_PRODUCT_DATA>(strSql.ToString());

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

        public IEnumerable<MES_PRODUCT_DATA> GetPartidData(string custcode, object pRODUCT_MODEL, object pACKAGING_TYPE, object pACKAGE_MODEL, object wAFER_MODEL)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"select distinct partid,产品型号 as F_PRODUCT_MODEL,内部封装外形 F_PACKAGE_MODEL," +
                $"封装等级 F_PRODUCT_LEVEL,芯片型号 F_WAFER_MODEL,晶圆尺寸 F_WAFER_SIZE,包装方式 F_PACKAGING_TYPE,焊线物料编码 F_WIRE_SOLDER_CODE," +
                $"焊线物料描述 F_WIRE_SOLDER_NAME,框架物料编码 F_SHELL_FRAM_CODE,框架物料描述 F_SHELL_FRAM_NAME " +
                $"from SATSP_ADMIN.V_PLAN_MESPARTID where 客户代码 = '{custcode}' and 产品型号 like '%{pRODUCT_MODEL}%' " +
                $" and 内部封装外形 like '%{pACKAGE_MODEL}%' and 包装方式 like '%{pACKAGING_TYPE}%' and 芯片型号 like '%{wAFER_MODEL}%'");

                return this.BaseRepository("B2BDatabase").FindList<MES_PRODUCT_DATA>(strSql.ToString());

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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void AddSaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity,List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBEntity, out bool have, out string outmsg, out bool inforerror)
        {
            var id = 1;
            bool err = false;
            string msg = "";
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                DataTable plan_data = db.FindTable($"select * from B2B_PLAN_INCOMING_MATERIAL where F_CUST_CODE='{entity.F_CUST_CODE}' and f_write_month='{entity.F_WRITE_MONTH}' and f_merge_flg=1");
                if (plan_data.Rows.Count > 0)
                {
                    have = false;
                    err = false;
                    foreach (DataRow item in plan_data.Rows)
                    {
                        if (item["F_MERGE_FLG"].ToString() == "1")
                        {
                            have = true;
                            err = true;
                            msg = "已经对此客户的料计划进行了合并,不能重复填报！";
                        }
                        if (plan_data.Rows.Count >= 1 && keyValue == "")
                        {
                            have = true;
                            err = true;
                            msg = "已经对此客户进行过来料计划填报！如果数据不对请进行修改或删除后重新填报！";
                        }
                    }
                }
                else
                {
                    have = false;
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var b2B_PLAN_INCOMING_MATERIALEntityTmp = GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
                        entity.Modify(keyValue);
                        entity.F_MERGE_FLG = 0;
                        entity.F_WRITE_DATE = Convert.ToString(DateTime.Now);
                        db.Update(entity);
                        db.Delete<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == b2B_PLAN_INCOMING_MATERIALEntityTmp.F_GUID);
                        foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBEntity)
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
                    else
                    {
                        entity.Create();
                        entity.F_MERGE_FLG = 0;
                        entity.F_WRITE_DATE = Convert.ToString(DateTime.Now);
                        db.Insert(entity);
                        foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBEntity)
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

        public void SaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity, List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBEntity, out bool have, out string outmsg, out bool inforerror)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {
                bool err = false;
                string msg = "";
                var id = 1;
                DataTable plan_data = db.FindTable($"select * from B2B_PLAN_INCOMING_MATERIAL where f_write_month='{entity.F_WRITE_MONTH}' and f_merge_flg=1");
                if (plan_data.Rows.Count > 0)
                {
                    have = true;
                }
                else
                {
                    have = false;
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var b2B_PLAN_INCOMING_MATERIALEntityTmp = GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
                        entity.Modify(keyValue);
                        db.Update(entity);
                        db.Delete<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>(t => t.F_GUID == b2B_PLAN_INCOMING_MATERIALEntityTmp.F_GUID);
                        foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBEntity)
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
                    else
                    {
                        entity.Create();
                        entity.F_MERGE_FLG = 0;
                        entity.F_WRITE_DATE = Convert.ToString(DateTime.Now);
                        db.Insert(entity);
                        foreach (B2B_PLAN_INCOMING_MATERIAL_SUBEntity item in b2B_PLAN_INCOMING_MATERIAL_SUBEntity)
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
