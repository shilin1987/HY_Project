using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HY_Logistics
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 17:02
    /// 描 述：餐别补贴规则
    /// </summary>
    public interface MealSubsidyRulesClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hr_MealAllowanceStandardEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hr_MealAllowanceStandard表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hr_MealAllowanceStandardEntity GetHr_MealAllowanceStandardEntity(string keyValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Hr_MealAllowanceStandardEntity GetVgOneMealAllowanceStandardEntity(string shfitType);
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
        void SaveEntity(string keyValue, Hr_MealAllowanceStandardEntity entity);
        #endregion

    }
}
