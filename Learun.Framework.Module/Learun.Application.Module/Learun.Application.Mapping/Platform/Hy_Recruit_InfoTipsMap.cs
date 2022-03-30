using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-11 09:36
    /// 描 述：作业员招聘信息提示
    /// </summary>
    public class Hy_Recruit_InfoTipsMap : EntityTypeConfiguration<Hy_Recruit_InfoTipsEntity>
    {
        public Hy_Recruit_InfoTipsMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_RECRUIT_INFOTIPS");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

