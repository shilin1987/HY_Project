using Dapper;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;
using Learun.DataBase.Repository;
using Learun.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-04 18:21
    /// 描 述：客户订单维护
    /// </summary>
    public class CUST_ORDER_CREATEService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_CUST_ORDEREntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                distinct t.FGUID,
                t.FCUST_CODE,
                t.FORDER_TYPE,
                t.FCREATE_DATE,
                t.FCHECK_PERSON,
                t.FCHECK_DATE,
                case when t.FMANAGE_FLG=0 then '待审核' 
                     when t.FMANAGE_FLG=1 then '已审核' 
                     when t.FMANAGE_FLG=2 then '已被MES系统接收'end FMANAGE_FLG,
                t.FREMARK
                ");
                strSql.Append("  FROM B2B_CUST_ORDER_SUB t1 ");
                strSql.Append("  LEFT JOIN B2B_CUST_ORDER t ON t1.FGUID = t.FGUID ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["FCUST_CODE"].IsEmpty())
                {
                    dp.Add("FCUST_CODE", "%" + queryParam["FCUST_CODE"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.FCUST_CODE Like @FCUST_CODE ");
                }
                if (!queryParam["FWAFER_TYPE"].IsEmpty())
                {
                    dp.Add("FWAFER_TYPE",queryParam["FWAFER_TYPE"].ToString(), DbType.String);
                    strSql.Append(" AND t1.FWAFER_TYPE = @FWAFER_TYPE ");
                }
                if (!queryParam["FPRODUCT_TYPE"].IsEmpty())
                {
                    dp.Add("FPRODUCT_TYPE",queryParam["FPRODUCT_TYPE"].ToString(), DbType.String);
                    strSql.Append(" AND t1.FPRODUCT_TYPE = @FPRODUCT_TYPE ");
                }
                if (!queryParam["FPACKAGE_TYPE"].IsEmpty())
                {
                    dp.Add("FPACKAGE_TYPE",queryParam["FPACKAGE_TYPE"].ToString(), DbType.String);
                    strSql.Append(" AND t1.FPACKAGE_TYPE = @FPACKAGE_TYPE ");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_CUST_ORDEREntity>(strSql.ToString(),dp, pagination);
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

        public void DeleteEntity(string keyValue)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            try
            {                                         
                    db.Delete<B2B_CUST_ORDEREntity>(t => t.FGUID == keyValue);
                    db.Delete<B2B_CUST_ORDER_PARAMEntity>(t => t.FGUID == keyValue);
                    db.Delete<B2B_CUST_ORDER_SUBEntity>(t => t.FGUID == keyValue);
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
        /// 获取B2B_CUST_ORDER表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_CUST_ORDEREntity GetB2B_CUST_ORDEREntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindEntity<B2B_CUST_ORDEREntity>(t=>t.FGUID == keyValue);
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
        public IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetB2B_CUST_ORDER_PARAMEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_CUST_ORDER_PARAMEntity>(t => t.FGUID == keyValue);
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

        public string GetMesList(string CustCode,string CustDevice,string InputPart,int type)
        {
            string Get_url = "";            
            Dictionary<String, String> keyValues = new Dictionary<string, string>();
            if (type == 1)//调芯片型号
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetCustDeviceList";
                keyValues.Add("CustCode", CustCode == null ? "" : CustCode);
            }
            if (type == 2)//调产品型号
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetInputPartList";
                keyValues.Add("CustCode", CustCode == null ? "" : CustCode);
                keyValues.Add("CustDevice", CustDevice == null ? "" : CustDevice);
            }
            if (type == 3)//调封装形式
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetPackageList";
                keyValues.Add("CustCode", CustCode == null ? "" : CustCode);
                keyValues.Add("CustDevice", CustDevice == null ? "" : CustDevice);
                keyValues.Add("InputPart", InputPart == null ? "" : InputPart);
            }
            if (type == 4)//调包装方式
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetPackingTypeList";
                keyValues.Add("CustCode", CustCode == null ? "" : CustCode);
                keyValues.Add("CustDevice", CustDevice == null ? "" : CustDevice);
                keyValues.Add("InputPart", InputPart == null ? "" : InputPart);
            }
            if (type == 5)//调封装等级、环保等级、取片方式
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetOrderAttParamList";
                keyValues.Add("","");       
            }
            if (type == 6)//调扩展参数
            {
                Get_url = "http://10.100.200.42:12345/api/B2B/GetOrderParamList";
                keyValues.Add("PARTID", CustCode == null ? "" : CustCode);
            }
            HttpWebRequest request = WebRequest.Create(new Uri(Get_url)) as HttpWebRequest;
            String paramValue = JsonConvert.SerializeObject(keyValues);
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(paramValue);
            // Set the content length in the request headers
            request.ContentLength = byteData.Length;
            request.Method = "POST";
            request.ContentType = "application/json";

            // Write data
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            using (HttpWebResponse wr = request.GetResponse() as HttpWebResponse)
            {
                StreamReader sr = new StreamReader(wr.GetResponseStream()); //创建一个stream读取流
                return sr.ReadToEnd();   //从头读到尾，放到字符串html
            }
        }       

        /// <summary>
        /// 获取B2B_CUST_ORDER_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_CUST_ORDER_SUBEntity> GetB2B_CUST_ORDER_SUBEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_CUST_ORDER_SUBEntity>(t => t.FGUID == keyValue);
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

        public void SaveEntity(string keyValue, B2B_CUST_ORDEREntity entity,List<B2B_CUST_ORDER_PARAMEntity> b2B_CUST_PARAMEntity, List<B2B_CUST_ORDER_SUBEntity> b2B_CUST_ORDER_SUBEntity)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            int id = 1;
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {                    
                    entity.Modify(keyValue);
                    entity.FCREATE_DATE = DateTime.Now;
                    entity.FCHECK_PERSON = "";
                    entity.FMANAGE_FLG = "0";
                    db.Update(entity);

                    db.Delete<B2B_CUST_ORDER_SUBEntity>(t => t.FGUID == keyValue);
                    db.Delete<B2B_CUST_ORDER_PARAMEntity>(t => t.FGUID == keyValue);

                    foreach (var item in b2B_CUST_PARAMEntity)
                    {
                        item.Create();
                        item.FGUID = entity.FGUID;
                        item.FID = Convert.ToString(id);
                        db.Insert(b2B_CUST_PARAMEntity);
                        id++;
                    }
                    foreach (var item in b2B_CUST_ORDER_SUBEntity)
                    {
                        item.Create();
                        item.FGUID = entity.FGUID;
                        item.FID = Convert.ToString(id);
                        db.Insert(b2B_CUST_ORDER_SUBEntity);
                        id++;
                    }
                }
                else
                {
                    entity.Create();
                    entity.FCREATE_DATE = DateTime.Now;
                    entity.FCHECK_PERSON = "";
                    entity.FMANAGE_FLG="0";
                    db.Insert(entity);

                    foreach (var item in b2B_CUST_PARAMEntity)
                    {
                        item.Create();
                        item.FGUID = entity.FGUID;
                        item.FID = Convert.ToString(id);
                        db.Insert(b2B_CUST_PARAMEntity);
                        id++;
                    }
                    foreach (var item in b2B_CUST_ORDER_SUBEntity)
                    {
                        item.Create();
                        item.FGUID = entity.FGUID;
                        item.FID = Convert.ToString(id);
                        db.Insert(b2B_CUST_ORDER_SUBEntity);
                        id++;
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

        public IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetParamtListSub(string keyValue, string partId)
        {
            try
            {
                return this.BaseRepository("B2BDatabase").FindList<B2B_CUST_ORDER_PARAMEntity>(t => t.FGUID == keyValue && t.FPARTID==partId);
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

        public IEnumerable<ExcelParam> GetPartidData(string custcode, string pRODUCT_MODEL, string pACKAGING_TYPE, string pACKAGE_MODEL, string wAFER_MODEL)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append($"SELECT PARTID Column1,产品型号 Column2,内部封装外形 Column3,封装等级 Column4," +
                $"包装方式 Column5, 芯片型号 Column6, 晶圆尺寸 Column7,测试程序及版本 Column8," + 
                $"压焊图号及版本 Column9,环保等级 Column10,印章规范及版本号 Column11 " +
                $"FROM V_PLAN_MESPARTID where 客户代码 = '{custcode}' and 产品型号 like '%{pRODUCT_MODEL}%' " +
                $" and 内部封装外形 like '%{pACKAGE_MODEL}%' and 包装方式 like '%{pACKAGING_TYPE}%' and 芯片型号 like '%{wAFER_MODEL}%'");

                return this.BaseRepository("B2BDatabase").FindList<ExcelParam>(strSql.ToString());
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

        public void UploadSaveEntity(B2B_CUST_ORDEREntity entity, List<B2B_CUST_ORDER_SUBEntity> entitysub)
        {
            var db = this.BaseRepository("B2BDatabase").BeginTrans();
            int id = 1;
            try
            {
                entity.Create();
                entity.FCREATE_DATE = DateTime.Now;
                entity.FCHECK_PERSON = "";
                entity.FMANAGE_FLG = "0";
                db.Insert(entity);
 
                foreach (var item in entitysub)
                {
                    item.Create();
                    item.FGUID = entity.FGUID;
                    item.FID = Convert.ToString(id);
                    db.Insert(entitysub);
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

        #endregion
    }
}
