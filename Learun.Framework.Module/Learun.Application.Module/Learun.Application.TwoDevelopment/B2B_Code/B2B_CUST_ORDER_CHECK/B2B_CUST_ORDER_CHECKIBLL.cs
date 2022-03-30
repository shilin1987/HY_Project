﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_CUST_ORDER_CHECK;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 16:29
    /// 描 述：客户订单审核
    /// </summary>
    public interface B2B_CUST_ORDER_CHECKIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<B2B_CUST_ORDEREntity> GetPageList(Pagination pagination, string queryJson);
        IEnumerable<B2B_CUST_ORDER_SUBEntity> GetPageListSub(string keyValue);
        /// <summary>
        /// 获取B2B_CUST_ORDER表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_CUST_ORDEREntity GetB2B_CUST_ORDEREntity(string keyValue);

        /// <summary>
        /// 获取B2B_CUST_ORDER_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        B2B_CUST_ORDER_SUBEntity GetB2B_CUST_ORDER_SUBEntity(string keyValue);
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
        IEnumerable<B2BResultSub> CheckEntity(string keyValue, out string msgbox);
        IEnumerable<B2B_CUST_ORDER_PARAMEntity> GetParamtListSub(string keyValue, string partId);
        #endregion

    }
}
