using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-24 09:07
    /// 描 述：来料计划产能分配报表
    /// </summary>
    public interface B2B_PLAN_MATERIAL_ALLOT_REPORTIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取B2B_PLAN_MATERIAL_ALLOT_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_PLAN_MATERIAL_ALLOT_SUBEntity GetB2B_PLAN_MATERIAL_ALLOT_SUBEntity(string keyValue);
        /// <summary>
        /// 获取B2B_PLAN_MATERIAL_ALLOT表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_PLAN_MATERIAL_ALLOTEntity GetB2B_PLAN_MATERIAL_ALLOTEntity(string keyValue);
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
        void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_ALLOTEntity entity,B2B_PLAN_MATERIAL_ALLOT_SUBEntity b2B_PLAN_MATERIAL_ALLOT_SUBEntity);
        #endregion

    }
}
