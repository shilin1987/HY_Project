﻿using Learun.Application.Base.Desktop;
using System.Data.Entity.ModelConfiguration;

namespace Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.6 力软敏捷开发框架
    /// Copyright (c) 2013-2020 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-29 09:56
    /// 描 述：桌面消息列表配置
    /// </summary>
    public class DTListMap : EntityTypeConfiguration<DTListEntity>
    {
        public DTListMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_DT_LIST");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
