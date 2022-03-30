using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-09-27 09:59
    /// 描 述：黑名单永不录用
    /// </summary>
    public class Hy_Platform_BlacklistMap : EntityTypeConfiguration<Hy_Platform_BlacklistEntity>
    {
        public Hy_Platform_BlacklistMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_RECRUIT_BLACKLIST");
            //主键
            this.HasKey(t => t.F_ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

