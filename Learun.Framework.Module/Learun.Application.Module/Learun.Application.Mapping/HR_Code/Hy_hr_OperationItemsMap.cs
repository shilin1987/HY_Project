using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-05-27 14:10
    /// 描 述：收支分类子项
    /// </summary>
    public class Hy_hr_OperationItemsMap : EntityTypeConfiguration<Hy_hr_OperationItemsEntity>
    {
        public Hy_hr_OperationItemsMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_HR_OPERATIONITEMS");
            //主键
            this.HasKey(t => t.F_ItemId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

