using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-28 14:04
    /// 描 述：岗级工资和基本工资维护
    /// </summary>
    public class Hy_hr_PostLevelMap : EntityTypeConfiguration<Hy_hr_PostLevelEntity>
    {
        public Hy_hr_PostLevelMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_HR_POSTLEVEL");
            //主键
            this.HasKey(t => t.F_ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

