using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_MB52;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-23 14:08
    /// 描 述：MB52报表
    /// </summary>
    public class B2B_Report_MB52BLL : B2B_Report_MB52IBLL
    {
        private B2B_Report_MB52Service b2B_Report_MB52Service = new B2B_Report_MB52Service();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_MB52Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                IEnumerable<B2B_Report_MB52Entity> datalist = new List<B2B_Report_MB52Entity>();
                B2B_Report_MB52Entity query = Newtonsoft.Json.JsonConvert.DeserializeObject<B2B_Report_MB52Entity>(queryJson);
                if (query.CUST_CODE !=null )
                {
                    datalist= b2B_Report_MB52Service.GetPageList(pagination, query);
                }
                return datalist;
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

        #region 提交数据

        #endregion

    }
}
