using Learun.Application.TwoDevelopment.HR_Code;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-29 16:05
    /// 描 述：考勤工资表达式
    /// </summary>
    public class Hy_hr_AttendanceSalaryFormulaMap : EntityTypeConfiguration<Hy_hr_AttendanceSalaryFormulaEntity>
    {
        public Hy_hr_AttendanceSalaryFormulaMap()
        {
            #region 表、主键
            //表
            this.ToTable("HY_HR_ATTENDANCESALARYFORMULA");
            //主键
            this.HasKey(t => t.F_FormulaId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

