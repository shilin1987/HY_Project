using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-28 14:04
    /// 描 述：岗级工资和基本工资维护
    /// </summary>
    public class PostLevelService : RepositoryFactory
    {
        ReturnCommon _return;
        public PostLevelService()
        {
            _return = new ReturnCommon();
        }

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_PostLevelEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_PostlevelCode,
                t.F_PostlevelName,
                t.F_PostSalaryMinimum,
                t.F_PostSalaryMaximum,
                t.F_BasePay,
                t.F_PerformancePay,
                t.F_SkillSalary,
                t.F_PerfectAttendance,
                t.F_ManagementSkillSalary,
                t.F_TransportationSubsidy,
                t.F_HousingSubsidy,
                t.F_DutyAllowance,
                t.F_MissedMealAllowance
                ");
                strSql.Append("  FROM Hy_hr_PostLevel t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_PostlevelCode"].IsEmpty())
                {
                    dp.Add("F_PostlevelCode", "%" + queryParam["F_PostlevelCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PostlevelCode Like @F_PostlevelCode ");
                }
                if (!queryParam["F_PostlevelName"].IsEmpty())
                {
                    dp.Add("F_PostlevelName", "%" + queryParam["F_PostlevelName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PostlevelName Like @F_PostlevelName ");
                }
                if (!queryParam["F_PostSalaryMinimum"].IsEmpty())
                {
                    dp.Add("F_PostSalaryMinimum", "%" + queryParam["F_PostSalaryMinimum"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PostSalaryMinimum Like @F_PostSalaryMinimum ");
                }
                if (!queryParam["F_PostSalaryMaximum"].IsEmpty())
                {
                    dp.Add("F_PostSalaryMaximum", "%" + queryParam["F_PostSalaryMaximum"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PostSalaryMaximum Like @F_PostSalaryMaximum ");
                }
                if (!queryParam["F_BasePay"].IsEmpty())
                {
                    dp.Add("F_BasePay", "%" + queryParam["F_BasePay"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_BasePay Like @F_BasePay ");
                }
                return this.BaseRepository().FindList<Hy_hr_PostLevelEntity>(strSql.ToString(), dp, pagination);
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
        /// <param name="postLevelNumber"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_PostLevelEntity> GetPostLevelEntityList(string postLevelNumber)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_PostlevelCode,
                t.F_PostlevelName,
                t.F_PostSalaryMinimum,
                t.F_PostSalaryMaximum,
                t.F_BasePay,
                t.F_PerformancePay,
                t.F_SkillSalary,
                t.F_ManagementSkillSalary,
                t.F_TransportationSubsidy,
                t.F_HousingSubsidy,
                t.F_DutyAllowance,
                t.F_MissedMealAllowance
                ");
                strSql.Append("  FROM Hy_hr_PostLevel t ");
                strSql.Append("  WHERE 1=1 ");

                if (!string.IsNullOrEmpty(postLevelNumber))
                {
                    strSql.Append(" AND t.F_PostlevelCode Like "+"'%"+ postLevelNumber + "'");
                }
               
                return this.BaseRepository().FindList<Hy_hr_PostLevelEntity>(strSql.ToString());
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
        /// 获取Hy_hr_PostLevel表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_PostLevelEntity GetHy_hr_PostLevelEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_PostLevelEntity>(keyValue);
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
                var isDel = this.BaseRepository().Delete<Hy_hr_PostLevelEntity>(t => t.F_ID == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_PostLevelEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_PostLevelEntity>(t => t.F_PostlevelCode == entity.F_PostlevelCode && t.F_PostlevelName == entity.F_PostlevelName);

                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_ID != keyValue)
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
                } //添加
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
