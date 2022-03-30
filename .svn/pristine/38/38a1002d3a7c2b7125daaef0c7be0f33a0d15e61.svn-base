using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.HrMonthAllData;
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
    /// 日 期：2021-06-16 19:34
    /// 描 述：菜价补贴月汇总数据
    /// </summary>
    public class HrMonthAllDataService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HrMonthDataEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                //初始化时间
                var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();
                if (queryParam["yearno"].IsEmpty() && queryParam["monthno"].IsEmpty())
                {
                    // month = month.Replace("0", "");
                    if (!month.Equals("1"))
                    {
                        month = Convert.ToInt32(month) - 1 + "";
                    }
                    else
                    {
                        month = "12";
                        year = Convert.ToInt32(year) - 1 + "";
                    }
                }
                else
                {
                    if (!queryParam["yearno"].IsEmpty() && !queryParam["monthno"].IsEmpty())
                    {
                        year = queryParam["yearno"] + "";
                        month = queryParam["monthno"] + "";

                    }
                    else
                    {
                        if (!month.Equals("1"))
                        {
                            month = Convert.ToInt32(month) - 1 + "";
                        }
                        else
                        {
                            month = "12";
                            year = Convert.ToInt32(year) - 1 + "";
                        }
                    }
                }
                string sql = " (SELECT dbo.[FunGetUUID32](NEWID()) oid, F_Year yearno, F_Month monthno, F_CostCenterno cost_centerno, F_CostCenterName cost_center, isnull(sum(F_CountMoney),0) summoney,count(F_UserId) countperson,isnull(sum(F_CountMoney),0)/count(F_UserId) avgmoney,'' bk " +
                " FROM HYDatabase.dbo.FS_VegetablePrices where F_Year ='"+ year + "' and F_Month='"+ month + "' " +
                " group by F_Year, F_Month, F_CostCenterno,F_CostCenterName) t ";
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                     t.oid, " +
                 " t.yearno, " +
                 " t.monthno   , " +
                 " t.cost_centerno, " +
                 " t.cost_center, " +
                 " t.summoney, " +
                 " t.countperson, " +
                 " t.avgmoney," +
                 " t.bk   ");
                strSql.Append(" from  " + sql + " ");

                strSql.Append("  WHERE 1=1 ");

                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["center_cost"].IsEmpty())
                {
                    dp.Add("center_cost", "%" + queryParam["center_cost"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.center_cost Like @center_cost ");
                }
                return this.BaseRepository().FindList<HrMonthDataEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hr_vpsmonthdataALL表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_vpsmonthdataALLEntity GetHr_vpsmonthdataALLEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_vpsmonthdataALLEntity>(keyValue);
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
                this.BaseRepository().Delete<Hr_vpsmonthdataALLEntity>(t=>t.oid == keyValue);
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
        public void SaveEntity(string keyValue, Hr_vpsmonthdataALLEntity entity)
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
