using Learun.Application.Base.SystemModule;
using System.Data.Entity.ModelConfiguration;

namespace Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：行政区域
    /// </summary>
    public class AreaMap : EntityTypeConfiguration<AreaEntity>
    {
        public AreaMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_BASE_AREA");
            //主键
            this.HasKey(t => t.F_AreaId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
