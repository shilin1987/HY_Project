using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.MonthlyAttendanceDataAutoClass;
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
    /// 日 期：2021-06-07 19:52
    /// 描 述：菜价补贴考勤数据明细
    /// </summary>
    public class MonthlyAttendanceDataAutoClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_user_attendanceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.oid,
                t.user_code,
                t.user_name,
                t.rq,
                t.bc,
                t.chaiq02,
                t.chaiq01,
                t.cqgs,
                t.yearno,
                t.monthno
                ");
                strSql.Append("  FROM Hr_user_attendance t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["user_code"].IsEmpty())
                {
                    dp.Add("user_code", "%" + queryParam["user_code"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.user_code Like @user_code ");
                }
                if (!queryParam["user_name"].IsEmpty())
                {
                    dp.Add("user_name", "%" + queryParam["user_name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.user_name Like @user_name ");
                }
                if (!queryParam["yearno"].IsEmpty())
                {
                    dp.Add("yearno", "%" + queryParam["yearno"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.yearno Like @yearno ");
                }
                if (!queryParam["monthno"].IsEmpty())
                {
                    dp.Add("monthno", "%" + queryParam["monthno"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.monthno Like @monthno ");
                }
                return this.BaseRepository().FindList<Hr_user_attendanceEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AttendanceUserDTO> GetInitPageList(string year ,string month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  DISTINCT ");
                strSql.Append(@"
                t.user_code,
                t.user_name,
                t.yearno,
                t.monthno,
                t.deptid ,
                t.deptname,
                s.center_cost_code ,
                s.center_cost 
                ");
                strSql.Append("  FROM Hr_user_attendance t left join Hr_center_cost s on t.deptid = s.deptid  ");
                strSql.Append("  WHERE 1=1 ");
                strSql.Append("  AND   yearno ='" + year + "' AND monthno = '"+ month + "' ORDER BY user_code ");
                return this.BaseRepository().FindList<AttendanceUserDTO>(strSql.ToString());
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QkAndShiftDTO> GetQkAndShiftPageList(string year, string month,string userid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  ");
                strSql.Append(@"
                t.user_code,
                t.yearno,
                t.monthno,
                t.bc,
                t.rq,
                (t.cqgs +t.chaiq02 + t.chaiq01) countTime
                ");
                strSql.Append("  FROM Hr_user_attendance t With (NoLock) ");
                strSql.Append("  WHERE 1=1 ");
                strSql.Append("  AND t.yearno ='" + year + "' AND t.monthno = '" + month + "' and  t.user_code='"+ userid + "'  ORDER BY t.RQ ");
                return this.BaseRepository().FindList<QkAndShiftDTO>(strSql.ToString());
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QkAndShiftDTO> GetQkAndShiftPageListDetil(string year, string month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  ");
                strSql.Append(@"
                t.user_code,
                t.user_name,
                t.deptid, 
                t.deptname,
                t.yearno,
                t.monthno,
                t.bc,
                t.rq,
                s.timelimit,
                s.shift_type,
                (t.cqgs +t.chaiq02 + t.chaiq01) countTime
                ");
                strSql.Append("  FROM Hr_user_attendance t left join Hr_SHIFTTIMETAB_file s on t.bc = s.shift_no ");
                strSql.Append("  WHERE 1=1 ");
                strSql.Append("  AND t.yearno ='" + year + "' AND t.monthno = '" + month + "'  ORDER BY t.user_code,t.RQ ");
                return this.BaseRepository().FindList<QkAndShiftDTO>(strSql.ToString());
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
        /// 获取Hr_user_attendance表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_user_attendanceEntity GetHr_user_attendanceEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_user_attendanceEntity>(keyValue);
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
                this.BaseRepository().Delete<Hr_user_attendanceEntity>(t=>t.oid == keyValue);
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
        public void SaveEntity(string keyValue, Hr_user_attendanceEntity entity)
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
