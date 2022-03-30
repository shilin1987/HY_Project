﻿using Learun.Util;
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
    public interface B2B_Report_WaferStockIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_Report_WaferStockEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取TESTA表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        
        #endregion

    }
}
