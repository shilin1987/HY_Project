using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_WIP;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-03-01 16:38
    /// 描 述：WIP产品报表
    /// </summary>
    public class B2B_Report_WIPBLL : B2B_Report_WIPIBLL
    {
        private B2B_Report_WIPService b2B_Report_WIPService = new B2B_Report_WIPService();

        public DataTable getexecl(string queryJson)
        {
            try
            {
                return b2B_Report_WIPService.getexecl(queryJson);
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

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_WIPEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_Report_WIPService.GetPageList(pagination, queryJson);
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
