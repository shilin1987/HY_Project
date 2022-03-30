using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-19 14:58
    /// 描 述：薪酬计算党费
    /// </summary>
    public class Hr_PayDuesTableMap : EntityTypeConfiguration<Hr_PayDuesTableEntity>
    {
        public Hr_PayDuesTableMap()
        {
            #region 表、主键
            //表
            this.ToTable("HR_PAYDUESTABLE");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

