using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-11 10:41
    /// 描 述：个人标准工资明细
    /// </summary>
    public class Hr_personalStandards_fileMap : EntityTypeConfiguration<Hr_personalStandards_fileEntity>
    {
        public Hr_personalStandards_fileMap()
        {
            #region 表、主键
            //表
            this.ToTable("HR_PERSONALSTANDARDS_FILE");
            //主键
            this.HasKey(t => t.F_ps01);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

