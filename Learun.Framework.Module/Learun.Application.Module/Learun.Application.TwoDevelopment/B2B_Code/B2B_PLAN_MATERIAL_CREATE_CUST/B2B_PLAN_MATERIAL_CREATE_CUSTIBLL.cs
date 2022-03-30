using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_PLAN_MATERIAL_CREATE_CUST;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-10 13:46
    /// 描 述：客户端月度来料计划填报
    /// </summary>
    public interface B2B_PLAN_MATERIAL_CREATE_CUSTIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_INCOMING_MATERIALEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>  GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(string keyValue);
        /// <summary>
        /// 获取B2B_PLAN_INCOMING_MATERIAL表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_PLAN_INCOMING_MATERIALEntity GetB2B_PLAN_INCOMING_MATERIALEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void AddSaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity, List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBList, out bool have, out string msg, out bool err);
        void SaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity,List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBEntity,out bool have, out string msg, out bool err);
        IEnumerable<MES_PRODUCT_DATA> GetProuduct(string partid);
        IEnumerable<MES_PRODUCT_DATA> GetPartidData(string custcode, string pRODUCT_MODEL, string pACKAGING_TYPE, string pACKAGE_MODEL, string wAFER_MODEL);
        IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetPageListSub(string keyValue);
        #endregion
    }
}