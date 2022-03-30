using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 18:39
    /// 描 述：考勤班次维护
    /// </summary>
    public class Hr_SHIFTTIMETAB_fileMap : EntityTypeConfiguration<Hr_SHIFTTIMETAB_fileEntity>
    {
        public Hr_SHIFTTIMETAB_fileMap()
        {
            #region 表、主键
            //表
            this.ToTable("HR_SHIFTTIMETAB_FILE");
            //主键
            this.HasKey(t => t.OID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

