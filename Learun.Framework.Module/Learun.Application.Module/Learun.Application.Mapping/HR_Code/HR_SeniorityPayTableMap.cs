using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-04 15:16
    /// 描 述：工龄工资
    /// </summary>
    public class HR_SeniorityPayTableMap : EntityTypeConfiguration<HR_SeniorityPayTableEntity>
    {
        public HR_SeniorityPayTableMap()
        {
            #region 表、主键
            //表
            this.ToTable("HR_SENIORITYPAYTABLE");
            //主键
            this.HasKey(t => t.F_ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

