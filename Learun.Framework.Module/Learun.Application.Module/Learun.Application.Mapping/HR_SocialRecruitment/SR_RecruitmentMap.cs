using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-21 17:09
    /// 描 述：社招
    /// </summary>
    public class SR_RecruitmentMap : EntityTypeConfiguration<SR_RecruitmentEntity>
    {
        public SR_RecruitmentMap()
        {
            #region 表、主键
            //表
            this.ToTable("dbo.SR_RECRUITMENT");
            //主键
            this.HasKey(t => t.F_ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

