using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-04 18:21
    /// 描 述：客户订单维护
    /// </summary>
    public class CUST_ORDER_CREATEBLL : CUST_ORDER_CREATEIBLL
    {
        private CUST_ORDER_CREATEService cUST_ORDER_CREATEService = new CUST_ORDER_CREATEService();

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
                return cUST_ORDER_CREATEService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                return cUST_ORDER_CREATEService.GetB2B_CUST_ORDEREntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                cUST_ORDER_CREATEService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<string> GetCustDeviceList(string custCode)
        {
            try
            {
                string result = cUST_ORDER_CREATEService.GetMesList(custCode, "", "", 1);

                MesPort rt = Newtonsoft.Json.JsonConvert.DeserializeObject<MesPort>(result);

                return rt.ListItems;

            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<string> GetProductList(string custCode, string custDevice)
        {
            try
            {
                string result = cUST_ORDER_CREATEService.GetMesList(custCode, custDevice, "", 2);

                MesPort rt = Newtonsoft.Json.JsonConvert.DeserializeObject<MesPort>(result);

                return rt.ListItems;
            }
            catch (Exception ex)
            {

                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<string> GetProductList(string custCode, string custDevice, string inputPart)
        {
            try
            {
                string result = cUST_ORDER_CREATEService.GetMesList(custCode, custDevice, inputPart, 3);

                MesPort rt = Newtonsoft.Json.JsonConvert.DeserializeObject<MesPort>(result);

                return rt.ListItems;
            }
            catch (Exception ex)
            {

                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<string> GetPackingTypeList(string custCode, string custDevice, string inputPart)
        {
            try
            {
                string result = cUST_ORDER_CREATEService.GetMesList(custCode, custDevice, inputPart, 4);

                MesPort rt = Newtonsoft.Json.JsonConvert.DeserializeObject<MesPort>(result);

                return rt.ListItems;
            }
            catch (Exception ex)
            {

                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<string> GetOrderAttParamList(int type)
        {
            try
            {
                List<string> listdata = new List<string>();
                string result = cUST_ORDER_CREATEService.GetMesList("", "", "", 5);
                MesPort rt = Newtonsoft.Json.JsonConvert.DeserializeObject<MesPort>(result);

                if (type == 1)
                {
                    listdata = rt.envList;
                }
                else if (type == 2)
                {
                    listdata = rt.assemblyList;
                }
                else if (type == 3)
                {
                    listdata = rt.mapList;
                }
                else if (type == 4)
                {
                    listdata = rt.orderList;
                }
                return listdata;
            }
            catch (Exception ex)
            {

                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public List<B2B_CUST_ORDER_PARAMEntity> GetOrderParamList(string partid)
        {
            try
            {
                string result = cUST_ORDER_CREATEService.GetMesList(partid, "", "", 6);
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                MesPort rt = Serializer.Deserialize<MesPort>(result);

                List<B2B_CUST_ORDER_PARAMEntity> listparams = new List<B2B_CUST_ORDER_PARAMEntity>();

                foreach (var item in rt.ListOrderParams)
                {
                    listparams.Add(new B2B_CUST_ORDER_PARAMEntity
                    {
                        FPARTID= partid,
                        FPARAM_CODE = item.ParamName,
                        FPARAM_NAME = item.ParamDesc,
                        FPARAM_TYPE = item.value
                    });
                }
                return listparams;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public void SaveEntity(string keyValue, B2B_CUST_ORDEREntity entity, List<B2B_CUST_ORDER_PARAMEntity> B2B_CUST_PARAMEntity, List<B2B_CUST_ORDER_SUBEntity> b2B_CUST_ORDER_SUBEntity)
        {
            try
            {
                cUST_ORDER_CREATEService.SaveEntity(keyValue, entity, B2B_CUST_PARAMEntity, b2B_CUST_ORDER_SUBEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<B2B_CUST_ORDER_SUBEntity> GetPageListSub(string keyValue)
        {
            try
            {
                return cUST_ORDER_CREATEService.GetB2B_CUST_ORDER_SUBEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetB2B_CUST_ORDER_PARAMEntity(string keyValue)
        {
            try
            {
                return cUST_ORDER_CREATEService.GetB2B_CUST_ORDER_PARAMEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<B2B_CUST_ORDER_SUBEntity> GetB2B_CUST_ORDER_SUBEntity(string keyValue)
        {
            try
            {
                return cUST_ORDER_CREATEService.GetB2B_CUST_ORDER_SUBEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public void UploadSaveEntity(B2B_CUST_ORDEREntity entity, List<B2B_CUST_ORDER_SUBEntity> entitysub)
        {            
            try
            {            
                cUST_ORDER_CREATEService.UploadSaveEntity(entity, entitysub);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<ExcelParam> GetPartidData(string custcode, string pRODUCT_MODEL, string pACKAGING_TYPE, string pACKAGE_MODEL, string wAFER_MODEL)
        {
            try
            {

                return cUST_ORDER_CREATEService.GetPartidData(custcode, pRODUCT_MODEL, pACKAGING_TYPE, pACKAGE_MODEL, wAFER_MODEL);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetParamtListSub(string keyValue, string partId)
        {
            try
            {
                return cUST_ORDER_CREATEService.GetParamtListSub(keyValue, partId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

    }
}
