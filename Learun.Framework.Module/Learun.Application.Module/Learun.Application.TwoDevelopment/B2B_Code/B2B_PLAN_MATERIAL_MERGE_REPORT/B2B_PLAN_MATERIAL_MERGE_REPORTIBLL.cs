using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-05 15:35
    /// 描 述：客户月度来料计划合并报表
    /// </summary>
    public interface B2B_PLAN_MATERIAL_MERGE_REPORTIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPageList(Pagination pagination, string queryJson);

        #endregion
        

    }
}
