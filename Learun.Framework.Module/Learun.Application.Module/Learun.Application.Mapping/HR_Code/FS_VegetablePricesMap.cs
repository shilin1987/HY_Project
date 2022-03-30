using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 14:53
    /// 描 述：新菜价补贴计算
    /// </summary>
    public class FS_VegetablePricesMap : EntityTypeConfiguration<FS_VegetablePricesEntity>
    {
        public FS_VegetablePricesMap()
        {
            #region 表、主键
            //表
            this.ToTable("FS_VEGETABLEPRICES");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

