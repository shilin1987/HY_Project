using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_WaferStock;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-25 17:20
    /// 描 述：晶圆库存报表
    /// </summary>
    public class B2B_Report_WaferStockBLL : B2B_Report_WaferStockIBLL
    {
        private B2B_Report_WaferStockService b2B_Report_WaferStockService = new B2B_Report_WaferStockService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_WaferStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_Report_WaferStockService.GetPageList(pagination, queryJson);
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
