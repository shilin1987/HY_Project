﻿using Learun.Application.Extention.TaskScheduling;
using System.Data.Entity.ModelConfiguration;

namespace Learun.Application.Mapping.LR_Extention.TaskScheduling
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.6 力软敏捷开发框架
    /// Copyright (c) 2013-2020 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：任务模板信息
    /// </summary>
    public class TSSchemeMap : EntityTypeConfiguration<TSSchemeEntity>
    {
        public TSSchemeMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_TS_SCHEME");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
