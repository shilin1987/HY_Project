using Learun.Application.TwoDevelopment.Platform;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-07-29 17:58
    /// 描 述：设备管理
    /// </summary>
    public class Hy_DeviceInfoMap : EntityTypeConfiguration<Hy_DeviceInfoEntity>
    {
        public Hy_DeviceInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_DEVICEINFO");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

