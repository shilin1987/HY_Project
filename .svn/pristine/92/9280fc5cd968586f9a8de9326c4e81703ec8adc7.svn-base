using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-29 16:05
    /// 描 述：考勤工资表达式
    /// </summary>
    public interface AttendanceSalaryFormulaIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(string shiftType);


        IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList();
        /// <summary>
        /// 获取Hy_hr_AttendanceSalaryFormula表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_AttendanceSalaryFormulaEntity GetHy_hr_AttendanceSalaryFormulaEntity(string keyValue);

        /// <summary>
        /// 查询班次信息
        /// </summary>
        /// <param name="shiftType"></param>
        /// <returns></returns>
        Hy_hr_AttendanceSalaryFormulaEntity GetAttendanceSalaryFormulaEntity(string shiftType);

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon SaveEntity(string keyValue, Hy_hr_AttendanceSalaryFormulaEntity entity);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        void UpdateState(string keyValue, int state);
        #endregion

    }
}
