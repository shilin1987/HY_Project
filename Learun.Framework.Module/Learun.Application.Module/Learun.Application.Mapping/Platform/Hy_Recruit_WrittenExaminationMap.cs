using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-31 10:54
    /// 描 述：RWrittenExamination
    /// </summary>
    public class Hy_Recruit_WrittenExaminationMap : EntityTypeConfiguration<Hy_Recruit_WrittenExaminationEntity>
    {
        public Hy_Recruit_WrittenExaminationMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_RECRUIT_WRITTENEXAMINATION");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

