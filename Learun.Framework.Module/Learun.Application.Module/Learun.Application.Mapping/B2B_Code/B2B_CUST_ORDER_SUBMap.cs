﻿using Learun.Application.TwoDevelopment.B2B_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 16:29
    /// 描 述：客户订单审核
    /// </summary>
    public class B2B_CUST_ORDER_SUBMap : EntityTypeConfiguration<B2B_CUST_ORDER_SUBEntity>
    {
        public B2B_CUST_ORDER_SUBMap()
        {
            #region 表、主键
            //表
            this.ToTable("SATSP_ADMIN.B2B_CUST_ORDER_SUB");
            //主键
            this.HasKey(t => t.FGUID);
            this.HasKey(t => t.FID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

