using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-08-05 18:22
    /// 描 述：培训内容和结果
    /// </summary>
    public class Hy_hr_trainingMap : EntityTypeConfiguration<Hy_hr_trainingEntity>
    {
        public Hy_hr_trainingMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_HR_TRAINING");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

