using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-11 10:50
    /// 描 述：人证审查
    /// </summary>
    public class Hy_Recruit_CandidatesMap : EntityTypeConfiguration<Hy_Recruit_CandidatesEntity>
    {
        public Hy_Recruit_CandidatesMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_RECRUIT_CANDIDATES");
            //主键
            this.HasKey(t => t.F_UserId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

