using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public class SR_ProcessNodeMap : EntityTypeConfiguration<SR_ProcessNodeEntity>
    {
        public SR_ProcessNodeMap()
        {
            #region 表、主键
            //表
            this.ToTable("dbo.SR_ProcessNode");
            //主键
            this.HasKey(t => new {t.F_ID,t.F_SubID});
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

