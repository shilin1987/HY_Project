using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using Newtonsoft.Json.Linq;
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
    /// 日 期：2022-01-10 14:53
    /// 描 述：新菜价补贴计算
    /// </summary>
    public class FSVegetablePricesCalculationService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePricesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Id,
                t.F_UserId,
                t.F_UserName,
                t.F_Year,
                t.F_Month,
                t.F_DeptId,
                t.F_DeptName,
                t.F_CostCenterno,
                t.F_CostCenterName,
                t.F_MonBreakfastTogether,
                t.F_MonLunchTogether,
                t.F_MonDinnerTogether,
                t.F_MonSupperTogether,
                t.F_CountMoney
                ");
                strSql.Append("  FROM FS_VegetablePrices t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", "%" + queryParam["F_UserId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserId Like @F_UserId ");
                }
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserName Like @F_UserName ");
                }
                if (!queryParam["F_Year"].IsEmpty())
                {
                    dp.Add("F_Year", "%" + queryParam["F_Year"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Year Like @F_Year ");
                }
                if (!queryParam["F_Month"].IsEmpty())
                {
                    dp.Add("F_Month", "%" + queryParam["F_Month"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Month Like @F_Month ");
                }
                if (!queryParam["F_CostCenterName"].IsEmpty())
                {
                    dp.Add("F_CostCenterName", "%" + queryParam["F_CostCenterName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CostCenterName Like @F_CostCenterName ");
                }
                if (!queryParam["F_DeptName"].IsEmpty())
                {
                    dp.Add("F_DeptName", "%" + queryParam["F_DeptName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DeptName Like @F_DeptName ");
                }
                return this.BaseRepository().FindList<FS_VegetablePricesEntity>(strSql.ToString(),dp, pagination);
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
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePricesEntity> GetList(string year, string month)
        {
            try 
            { 
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                    t.F_Id,
                    t.F_UserId,
                    t.F_UserName,
                    t.F_Year,
                    t.F_Month,
                    t.F_DeptId,
                    t.F_DeptName,
                    t.F_CostCenterno,
                    t.F_CostCenterName,
                    t.F_MonBreakfastTogether,
                    t.F_MonLunchTogether,
                    t.F_MonDinnerTogether,
                    t.F_MonSupperTogether,
                    t.F_CountMoney
                    ");
                strSql.Append("  FROM FS_VegetablePrices t ");
                strSql.Append("  WHERE 1=1 and t.F_Year = '"+year+ "' and t.F_Month = '"+month+"' ");
          
                return this.BaseRepository().FindList<FS_VegetablePricesEntity>(strSql.ToString());
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

        public  DataTable GetExportList(Pagination paginationobj, string queryJson)
        {
            try
            {
                JObject queryParam = new JObject();
                if (queryJson != null && queryJson != "null")
                {
                    queryParam = queryJson.ToJObject();
                }



                var strSql = new StringBuilder();
                var year = DateTime.Now.Year.ToString();
                var month = (DateTime.Now.Month - 1).ToString();
                //表示1月需要修改
                if (DateTime.Now.Month == 1)
                {
                    month = 12 + "";
                    year = Convert.ToInt32(year) - 1 + "";
                }
                if (paginationobj != null && queryJson != null)
                {
                    if (queryParam["yearno"].IsEmpty() && queryParam["monthno"].IsEmpty())
                    {
                        // month = month.Replace("0", "");
                        if (DateTime.Now.Month == 1)
                        {
                            month = 12 + "";
                            year = Convert.ToInt32(year) - 1 + "";
                        }
                    }
                    else
                    {
                        if (!queryParam["yearno"].IsEmpty() && !queryParam["monthno"].IsEmpty())
                        {
                            year = queryParam["yearno"].ToString();
                            month = queryParam["monthno"].ToString();
                        }
                    }
                }
               // var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                    t.F_Id,
                    t.F_UserId,
                    t.F_UserName,
                    t.F_Year,
                    t.F_Month,
                    t.F_DeptId,
                    t.F_DeptName,
                    t.F_CostCenterno,
                    t.F_CostCenterName,
                    t.F_MonBreakfastTogether,
                    t.F_MonLunchTogether,
                    t.F_MonDinnerTogether,
                    t.F_MonSupperTogether,
                    t.F_CountMoney
                    ");
                strSql.Append("  FROM FS_VegetablePrices t ");
                strSql.Append("  WHERE 1=1 and t.F_Year = '" + year + "' and t.F_Month = '" + month + "' ");

                return this.BaseRepository().FindTable(strSql.ToString());
            }
            catch(Exception ex)
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
        /// 获取FS_VegetablePrices表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public FS_VegetablePricesEntity GetFS_VegetablePricesEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<FS_VegetablePricesEntity>(keyValue);
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
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<FS_VegetablePricesEntity>(t=>t.F_Id == keyValue);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, FS_VegetablePricesEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
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

    }
}
