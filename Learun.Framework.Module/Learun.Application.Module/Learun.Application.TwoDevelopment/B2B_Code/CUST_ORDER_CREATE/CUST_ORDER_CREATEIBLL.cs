using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-04 18:21
    /// 描 述：客户订单维护
    /// </summary>
    public interface CUST_ORDER_CREATEIBLL

    #region 获取数据
    { 
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_CUST_ORDEREntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取B2B_CUST_ORDER表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_CUST_ORDEREntity GetB2B_CUST_ORDEREntity(string keyValue);
        IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetB2B_CUST_ORDER_PARAMEntity(string keyValue);
        IEnumerable<B2B_CUST_ORDER_SUBEntity> GetB2B_CUST_ORDER_SUBEntity(string keyValue);

        #endregion

        #region 查找接口数据
        List<string> GetCustDeviceList(string entity);
        List<string> GetProductList(string custCode, string custDevice);
        List<string> GetProductList(string custCode, string custDevice, string inputPart);
        List<string> GetPackingTypeList(string custCode, string custDevice, string inputPart);
        List<string> GetOrderAttParamList(int type);
        void SaveEntity(string keyValue, B2B_CUST_ORDEREntity entity, List<B2B_CUST_ORDER_PARAMEntity> B2B_CUST_PARAMEntity, List<B2B_CUST_ORDER_SUBEntity> b2B_CUST_ORDER_SUBEntity);
        IEnumerable<B2B_CUST_ORDER_SUBEntity> GetPageListSub(string keyValue);
        void DeleteEntity(string keyValue);
        void UploadSaveEntity(B2B_CUST_ORDEREntity entity, List<B2B_CUST_ORDER_SUBEntity> entitysub);
        IEnumerable<ExcelParam> GetPartidData(string custcode, string pRODUCT_MODEL, string pACKAGING_TYPE, string pACKAGE_MODEL, string wAFER_MODEL );
        IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetParamtListSub(string keyValue, string partId);
        List<B2B_CUST_ORDER_PARAMEntity> GetOrderParamList(string pARTID);

        #endregion

    }
}
