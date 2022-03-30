using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-29 16:05
    /// 描 述：考勤工资表达式
    /// </summary>
    public class AttendanceSalaryFormulaBLL : AttendanceSalaryFormulaIBLL
    {
        private AttendanceSalaryFormulaService attendanceSalaryFormulaService = new AttendanceSalaryFormulaService();


        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_department_"; // +加公司主键
        #endregion
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return attendanceSalaryFormulaService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shiftType"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList(string shiftType)
        {
            try
            {
                return attendanceSalaryFormulaService.GetPageList(shiftType);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> GetPageList()
        {
            try
            {
                return attendanceSalaryFormulaService.GetPageList();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取Hy_hr_AttendanceSalaryFormula表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_AttendanceSalaryFormulaEntity GetHy_hr_AttendanceSalaryFormulaEntity(string keyValue)
        {
            try
            {
                return attendanceSalaryFormulaService.GetHy_hr_AttendanceSalaryFormulaEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shiftType"></param>
        /// <returns></returns>
        public Hy_hr_AttendanceSalaryFormulaEntity GetAttendanceSalaryFormulaEntity(string shiftType)
        {
            try
            {
                return attendanceSalaryFormulaService.GetAttendanceSalaryFormulaEntity(shiftType);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                attendanceSalaryFormulaService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_AttendanceSalaryFormulaEntity entity)
        {
            ReturnCommon rc = new ReturnCommon();
            try
            {
                FormulaToCalculateIBLL ftc = new FormulaToCalculateBLL();
                //判断考勤正常班总公式是否唯一或者公式项是否唯一

                IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalaryFormulaService.GetPageList().Where(e => entity.F_FormulaCode.Equals(e.F_FormulaCode) || "TotalNormalShifts".Contains(e.F_ShiftType)).ToList();

                IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asfs = attendanceSalaryFormulaService.GetPageList().Where(e => entity.F_FormulaCode.Equals(e.F_FormulaCode) || "TotalChangeShifts".Contains(e.F_ShiftType)).ToList();
                //公式编号存在,且为新增
                if ((asf.Count() > 0 && string.IsNullOrEmpty(keyValue)) && "TotalNormalShifts".Equals(entity.F_ShiftType))
                {
                    rc.Status = false;
                    rc.Message = "公式编号:"+ entity.F_FormulaCode+"存在或者白班总公式已经存在,请重新修改";
                }else if ((asfs.Count() > 0 && string.IsNullOrEmpty(keyValue)) && "TotalChangeShifts".Equals(entity.F_ShiftType))
                {
                    rc.Status = false;
                    rc.Message = "公式编号:" + entity.F_FormulaCode + "存在或者倒班总公式已经存在,请重新修改";
                }
                else
                {   
                    //公式编号不存在，新增修改
                    rc.Status = true;
                    if (string.IsNullOrEmpty(entity.F_FormulaCode))
                    {
                        entity.F_FormulaCode = ftc.getTableFileNum("","", "", 1, "", "");
                    }
                    attendanceSalaryFormulaService.SaveEntity(keyValue, entity);
                }
                return rc;

            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Hy_hr_AttendanceSalaryFormulaEntity attendansesalary =GetHy_hr_AttendanceSalaryFormulaEntity(keyValue);
                cache.Remove(cacheKey + attendansesalary.F_FormulaId);
                cache.Remove(cacheKey + "dic", CacheId.department);
                attendanceSalaryFormulaService.UpdateState(keyValue, state);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        #endregion

    }
}
