using Learun.Application.TwoDevelopment.B2B_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-22 17:11
    /// 描 述：计划与实际来料完成情况推送提醒功能
    /// </summary>
    public class B2B_CUST_PLAN_CONTRAST_WARNMap : EntityTypeConfiguration<B2B_CUST_PLAN_CONTRAST_WARNEntity>
    {
        public B2B_CUST_PLAN_CONTRAST_WARNMap()
        {
            #region 表、主键
            //表
            this.ToTable("SATSP_ADMIN.B2B_CUST_PLAN_CONTRAST_WARN");
            //主键
            this.HasKey(t => t.F_GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

