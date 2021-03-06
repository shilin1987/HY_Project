using Learun.Application.TwoDevelopment.Platform;
using Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-30 17:09
    /// 描 述：子流程信息表
    /// </summary>
    public class Hy_Recruit_SubProcessMap : EntityTypeConfiguration<Hy_Recruit_SubProcessEntity>
    {
        public Hy_Recruit_SubProcessMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_RECRUIT_SUBPROCESS");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

