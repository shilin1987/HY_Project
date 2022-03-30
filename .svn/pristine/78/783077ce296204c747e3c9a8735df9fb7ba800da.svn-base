using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-02 16:41
    /// 描 述：客户月度来料计划合并功能
    /// </summary>
    public interface B2B_PLAN_MATERIAL_ＭERGE_CREATEIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_MATERIAL_MERGEEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetB2B_PLAN_MATERIAL_MERGE_SUBList(string keyValue);

        IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPlanData(string moth);
        /// <summary>
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_PLAN_MATERIAL_MERGE_SUBEntity GetB2B_PLAN_MATERIAL_MERGE_SUBEntity(string keyValue);
        /// <summary>
        /// 获取B2B_PLAN_MATERIAL_MERGE表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_PLAN_MATERIAL_MERGEEntity GetB2B_PLAN_MATERIAL_MERGEEntity(string keyValue);
        

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
        void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_MERGEEntity entity,List<B2B_PLAN_MATERIAL_MERGE_SUBEntity> b2B_PLAN_MATERIAL_MERGE_SUBList);
        #endregion

    }
}
