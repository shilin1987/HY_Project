using Dapper;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_MB52;
using Learun.Application.TwoDevelopment.SAP_Rfc;
using Learun.DataBase.Repository;
using Learun.Util;
using SAP.Middleware.Connector;
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
    /// 日 期：2022-02-23 14:08
    /// 描 述：MB52报表
    /// </summary>
    public class B2B_Report_MB52Service : RepositoryFactory
    {
        #region 获取数据
        private SapRfc sapService = new SapRfc();
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_MB52Entity> GetPageList(Pagination pagination, B2B_Report_MB52Entity queryJson)
        {
            try
            {               
                IRfcTable rfcFields = sapService.getSapStockInventory(queryJson);
                List<B2B_Report_MB52Entity> deliveryStocks = new List<B2B_Report_MB52Entity>();

                foreach (IRfcStructure item in rfcFields)
                {
                    deliveryStocks.Add(new B2B_Report_MB52Entity
                    {
                        MATNR = item["MATNR"].GetValue().ToString(),
                        MAKTX = item["MAKTX"].GetValue().ToString(),
                        PARTID = item["PARTID"].GetValue().ToString(),
                        LGORT = item["LGORT"].GetValue().ToString(),
                        LGOBE = item["LGOBE"].GetValue().ToString(),
                        WERKS = item["WERKS"].GetValue().ToString(),
                        CLABS = item["CLABS"].GetLong(),
                        CUMLM = item["CUMLM"].GetLong(),
                        CSPEM = item["CSPEM"].GetLong(),
                        UNIT = item["UNIT"].GetValue().ToString(),
                        CHARG = item["CHARG"].GetValue().ToString(),
                        SOBKZ = item["SOBKZ"].GetValue().ToString(),
                        ERSDA = item["ERSDA"].GetValue().ToString(),
                        CUST_PARTIN = item["CUST_PARTIN"].GetValue().ToString(),
                        CUST_PARTOUT = item["CUST_PARTOUT"].GetValue().ToString(),
                        ZZJGLX = item["ZZJGLX"].GetValue().ToString(),
                        PACKAGE_M = item["PACKAGE_M"].GetValue().ToString(),
                        CUST_CODE = item["CUST_CODE"].GetValue().ToString(),
                        KUNNR = item["KUNNR"].GetValue().ToString(),
                        ZCUST_LOT = item["ZCUST_LOT"].GetValue().ToString(),
                        CHILD_LOT = item["CHILD_LOT"].GetValue().ToString(),
                        DATECODE = item["DATECODE"].GetValue().ToString(),
                        BIN = item["BIN"].GetValue().ToString(),
                        WAFER_LOT_NO = item["WAFER_LOT_NO"].GetValue().ToString(),
                        STOCK_TYPE = item["STOCK_TYPE"].GetValue().ToString(),
                        ZZGYLC = item["ZZGYLC"].GetValue().ToString(),
                        PACKAGE_TYPE = item["PACKAGE_TYPE"].GetValue().ToString(),
                        ZZBZFS_DESC = item["ZZBZFS_DESC"].GetValue().ToString(),
                        ZASSY_GRADE = item["ZASSY_GRADE"].GetValue().ToString(),
                        ZEP_GRADE = item["ZEP_GRADE"].GetValue().ToString(),
                        ORDER_TYPE = item["ORDER_TYPE"].GetValue().ToString(),
                        INBOX_NO = item["INBOX_NO"].GetValue().ToString(),
                        ZOUT_BOX = item["ZOUT_BOX"].GetValue().ToString(),
                        RECEIPT_NO = item["RECEIPT_NO"].GetValue().ToString(),
                        LOTID = item["LOTID"].GetValue().ToString(),
                        CUST_BIN = item["CUST_BIN"].GetValue().ToString(),
                        CUST_PO = item["CUST_PO"].GetValue().ToString(),
                        CUST_DEVICE = item["CUST_DEVICE"].GetValue().ToString(),
                        MARKING_INFO = item["MARKING_INFO"].GetValue().ToString(),
                        REMARK = item["REMARK"].GetValue().ToString(),
                        VMI = item["VMI"].GetValue().ToString(),
                        ZBIN = item["ZBIN"].GetValue().ToString(),
                        ZZBIZ_TYPE = item["ZZBIZ_TYPE"].GetValue().ToString()
                    });
                }
                return deliveryStocks;
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
        #endregion

    }
}
