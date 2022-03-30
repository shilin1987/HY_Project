using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_CUST_ORDER_CHECK;
using System.Text;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 16:29
    /// 描 述：客户订单审核
    /// </summary>
    public class B2B_CUST_ORDER_CHECKBLL : B2B_CUST_ORDER_CHECKIBLL
    {
        private B2B_CUST_ORDER_CHECKService b2B_CUST_ORDER_CHECKService = new B2B_CUST_ORDER_CHECKService();

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
                return b2B_CUST_ORDER_CHECKService.GetPageList(pagination, queryJson);
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
                return b2B_CUST_ORDER_CHECKService.GetB2B_CUST_ORDEREntity(keyValue);
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
        /// 获取B2B_CUST_ORDER_PARAM表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetB2B_CUST_ORDER_PARAMEntity(string keyValue)
        {
            try
            {
                return b2B_CUST_ORDER_CHECKService.GetB2B_CUST_ORDER_PARAMEntity(keyValue);
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
        /// 获取B2B_CUST_ORDER_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_CUST_ORDER_SUBEntity GetB2B_CUST_ORDER_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_CUST_ORDER_CHECKService.GetB2B_CUST_ORDER_SUBEntity(keyValue);
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
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                b2B_CUST_ORDER_CHECKService.DeleteEntity(keyValue);
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
                return b2B_CUST_ORDER_CHECKService.GetPageListSub(keyValue);
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

        public IEnumerable<B2BResultSub> CheckEntity(string keyValue,out string msgbox)
        {
            try
            {
                List<B2BOrders> B2BOrders = new List<B2BOrders>();
                List<BocAttr> BocAttr = new List<BocAttr>();
                List<B2BResultSub> B2BResultSub = new List<B2BResultSub>();
                var main_order = b2B_CUST_ORDER_CHECKService.GetB2B_CUST_ORDEREntity(keyValue);
                var param_order = b2B_CUST_ORDER_CHECKService.GetB2B_CUST_ORDER_PARAMEntity(keyValue);
                var sub_order = b2B_CUST_ORDER_CHECKService.GetPageListSub(keyValue);

                foreach (var item in param_order)
                {
                    BocAttr.Add(new BocAttr
                    {
                        Key = item.FPARAM_CODE is null?"": item.FPARAM_CODE,
                        Value = item.FPARAM_VALUE is null?"":item.FPARAM_VALUE
                    });
                };
                foreach (var item in sub_order)
                {
                    B2BOrders.Add(new B2BOrders
                    {
                        GUID = main_order.FGUID,
                        ID = item.FID,
                        CUST_CODE = main_order.FCUST_CODE,
                        CUST_DEVICE = item.FWAFER_TYPE,
                        INPUT_PARTID = item.FPRODUCT_TYPE,
                        PACKAGE = item.FPACKAGE_TYPE,
                        ORDER_TYPE = main_order.FORDER_TYPE,
                        WAFER_LOT = item.FWAFER_BATCH is null ? "" : item.FWAFER_BATCH,
                        CUST_PO = item.FCUST_PO is null ? "" : item.FCUST_PO,
                        WAFER_QTY = item.FWAFER_NUMBER,
                        ORDER_QTY = item.FWAFER_QTY,
                        WAFER_NO = (item.FWAFER_NO).Split(','),
                        BD_DIAGRAM = item.FBONDING_CODE is null ? "" : item.FBONDING_CODE,
                        TEST = item.FIS_TEST,
                        TEST_SPEC = item.FTEST_CODE is null ? "" : item.FTEST_CODE,
                        MARK =item.FIS_PRINT,
                        MARK_SPEC= item.FPRINT_CODE is null ? "" : item.FPRINT_CODE,
                        PACKING_TYPE = item.FPACKING_TYPE is null ? "" : item.FPACKING_TYPE,
                        PACKAGE_GRADE = item.FPACKAGE_LEVE is null ? "" : item.FPACKAGE_LEVE,
                        ENV_GRADE = item.FGREEN_LEVE is null ? "" : item.FGREEN_LEVE,
                        TRADE_TYPE = item.FBATCH_TYPE is null ? "" : item.FBATCH_TYPE,
                        MAPPING = item.FGETWAFER_TYPE is null ? "" : item.FGETWAFER_TYPE,
                        REMARK = main_order.FREMARK is null ? "" : main_order.FREMARK,
                        bocAttr = BocAttr
                    });
                }
                string orderobje = "{"+"B2BOrders"+":"+ B2BOrders.ToJson()+"}";

                string result = b2B_CUST_ORDER_CHECKService.CheckEntity(orderobje);

                B2BResult rt = Newtonsoft.Json.JsonConvert.DeserializeObject<B2BResult>(result);

                foreach (var item in rt.MsgDet)
                {
                    B2BResultSub.Add(new B2BResultSub
                    {
                        GUID = item.GUID,
                        ID = item.ID,
                        ORDER_STATUS = item.ORDER_STATUS,
                        BR = item.BR,
                        MSG = item.MSG
                    });
                }

                if (rt.Code == "true")
                {
                    b2B_CUST_ORDER_CHECKService.UpdateOrder(keyValue);
                }
                msgbox= rt.Code;
                return B2BResultSub;
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

                return b2B_CUST_ORDER_CHECKService.GetParamtListSub(keyValue, partId);
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
