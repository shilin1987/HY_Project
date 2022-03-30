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
    /// 日 期：2021-06-03 18:39
    /// 描 述：考勤班次维护
    /// </summary>
    public class AttendanceMaintenanceClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_SHIFTTIMETAB_fileEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.OID,
                t.shift_no,
                t.shift_name,
                t.timelimit,
                t.attendancesystem
                ");
                strSql.Append("  FROM Hr_SHIFTTIMETAB_file t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["shift_no"].IsEmpty())
                {
                    dp.Add("shift_no", "%" + queryParam["shift_no"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.shift_no Like @shift_no ");
                }
                if (!queryParam["shift_name"].IsEmpty())
                {
                    dp.Add("shift_name", "%" + queryParam["shift_name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.shift_name Like @shift_name ");
                }
                if (!queryParam["attendancesystem"].IsEmpty())
                {
                    dp.Add("attendancesystem", "%" + queryParam["attendancesystem"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.attendancesystem Like @attendancesystem ");
                }
                return this.BaseRepository().FindList<Hr_SHIFTTIMETAB_fileEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hr_SHIFTTIMETAB_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_SHIFTTIMETAB_fileEntity GetHr_SHIFTTIMETAB_fileEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_SHIFTTIMETAB_fileEntity>(keyValue);
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
        /// 获取Hr_SHIFTTIMETAB_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_SHIFTTIMETAB_fileEntity GetOneSHIFTTIMETAB_fileEntity(string flightNumber)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_SHIFTTIMETAB_fileEntity>(t => t.shift_no == flightNumber);
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
                this.BaseRepository().Delete<Hr_SHIFTTIMETAB_fileEntity>(t=>t.OID == keyValue);
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
        public void SaveEntity(string keyValue, Hr_SHIFTTIMETAB_fileEntity entity)
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
