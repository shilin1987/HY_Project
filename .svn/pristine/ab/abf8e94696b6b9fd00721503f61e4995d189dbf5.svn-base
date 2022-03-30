using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.MonthlyVegetablePriceSubsidy;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-07 14:19
    /// 描 述：考勤班次维护
    /// </summary>
    public class MonthlyVegetablePriceSubsidyBLL : MonthlyVegetablePriceSubsidyIBLL
    {
        private MonthlyVegetablePriceSubsidyService monthlyVegetablePriceSubsidyService = new MonthlyVegetablePriceSubsidyService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MonthlyVegetablePriceSubsidyDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return monthlyVegetablePriceSubsidyService.GetPageList(pagination, queryJson);
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
