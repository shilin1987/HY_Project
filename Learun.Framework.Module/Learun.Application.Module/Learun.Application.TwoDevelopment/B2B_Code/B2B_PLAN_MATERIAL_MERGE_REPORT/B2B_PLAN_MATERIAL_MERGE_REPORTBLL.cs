using Learun.Util;
using System;
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
    public class B2B_PLAN_MATERIAL_MERGE_REPORTBLL : B2B_PLAN_MATERIAL_MERGE_REPORTIBLL
    {
        private B2B_PLAN_MATERIAL_MERGE_REPORTService b2B_PLAN_MATERIAL_MERGE_REPORTService = new B2B_PLAN_MATERIAL_MERGE_REPORTService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_PLAN_MATERIAL_MERGE_REPORTService.GetPageList(pagination, queryJson);
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
