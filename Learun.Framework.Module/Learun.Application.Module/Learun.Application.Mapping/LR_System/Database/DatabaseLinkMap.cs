using Learun.Application.Base.SystemModule;
using System.Data.Entity.ModelConfiguration;

namespace Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：数据库连接
    /// </summary>
    public class DataBaseLinkMap : EntityTypeConfiguration<DatabaseLinkEntity>
    {
        public DataBaseLinkMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_BASE_DATABASELINK");
            //主键
            this.HasKey(t => t.F_DatabaseLinkId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
