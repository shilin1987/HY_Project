using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-22 14:41
    /// 描 述：身份证信息读取对比
    /// </summary>
    public class Hr_hy_ComparisonOfIdCardVerificationMap : EntityTypeConfiguration<Hr_hy_ComparisonOfIdCardVerificationEntity>
    {
        public Hr_hy_ComparisonOfIdCardVerificationMap()
        {
            #region 表、主键
            //表
            this.ToTable("HR_HY_COMPARISONOFIDCARDVERIFICATION");
            //主键
            this.HasKey(t => t.F_ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

