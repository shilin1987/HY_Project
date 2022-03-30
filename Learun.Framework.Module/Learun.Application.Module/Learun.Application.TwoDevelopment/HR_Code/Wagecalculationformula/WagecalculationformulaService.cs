using Dapper;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-01 10:05
    /// 描 述：工资计算公式
    /// </summary>
    public class WagecalculationformulaService : RepositoryFactory
    {
        ReturnCommon _return;
        public WagecalculationformulaService()
        {
            _return = new ReturnCommon();
        }

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_WageCalculationFormulaEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_FormulaId,
                t.F_FormulaCode,
                t.F_FormulaName
                ");
                strSql.Append("  FROM Hy_hr_WageCalculationFormula t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_FormulaCode"].IsEmpty())
                {
                    dp.Add("F_FormulaCode", "%" + queryParam["F_FormulaCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FormulaCode Like @F_FormulaCode ");
                }
                if (!queryParam["F_FormulaName"].IsEmpty())
                {
                    dp.Add("F_FormulaName", "%" + queryParam["F_FormulaName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FormulaName Like @F_FormulaName ");
                }
                return this.BaseRepository().FindList<Hy_hr_WageCalculationFormulaEntity>(strSql.ToString(), dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取Hy_hr_WageCalculationFormula表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_WageCalculationFormulaEntity GetHy_hr_WageCalculationFormulaEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_WageCalculationFormulaEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
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
        public ReturnCommon DeleteEntity(string keyValue)
        {
            try
            {
                var isDel = this.BaseRepository().Delete<Hy_hr_WageCalculationFormulaEntity>(t => t.F_FormulaId == keyValue);
                if (isDel > 0)
                {
                    _return.Status = true;
                    _return.Message = "删除成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "删除失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_WageCalculationFormulaEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_WageCalculationFormulaEntity>(t => t.F_FormulaCode == entity.F_FormulaCode && t.F_FormulaName == entity.F_FormulaName);
                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_FormulaId != keyValue)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.Modify(keyValue);
                        addOrEdit = this.BaseRepository().Update(entity);
                    }
                }
                //添加
                else
                {
                    if (isExistItem != null)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.Create();
                        addOrEdit = this.BaseRepository().Insert(entity);
                    }
                }

                if (addOrEdit > 0)
                {
                    _return.Status = true;
                    _return.Message = "保存成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "保存失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }
        #endregion

    }
}
