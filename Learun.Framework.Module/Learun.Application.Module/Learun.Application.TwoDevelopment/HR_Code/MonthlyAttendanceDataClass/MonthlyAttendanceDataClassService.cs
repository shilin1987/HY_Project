using Dapper;
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
    /// 日 期：2021-06-07 14:19
    /// 描 述：考勤班次维护
    /// </summary>
    public class MonthlyAttendanceDataClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_MonthlyDataSummary_fileEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.oid,
                t.userid,
                t.username,
                t.shift_no,
                t.AttendanceDate,
                t.DateofAttendance,
                t.AttendanceHours,
                t.Outforhours,
                t.Onthejobworkhours,
                t.WorkSystem
                ");
                strSql.Append("  FROM Hr_MonthlyDataSummary_file t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["userid"].IsEmpty())
                {
                    dp.Add("userid", "%" + queryParam["userid"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.userid Like @userid ");
                }
                if (!queryParam["username"].IsEmpty())
                {
                    dp.Add("username", "%" + queryParam["username"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.username Like @username ");
                }
                if (!queryParam["shift_no"].IsEmpty())
                {
                    dp.Add("shift_no", "%" + queryParam["shift_no"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.shift_no Like @shift_no ");
                }
                return this.BaseRepository().FindList<Hr_MonthlyDataSummary_fileEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hr_MonthlyDataSummary_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_MonthlyDataSummary_fileEntity GetHr_MonthlyDataSummary_fileEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_MonthlyDataSummary_fileEntity>(keyValue);
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
                this.BaseRepository().Delete<Hr_MonthlyDataSummary_fileEntity>(t=>t.oid == keyValue);
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
        public void SaveEntity(string keyValue, Hr_MonthlyDataSummary_fileEntity entity)
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
