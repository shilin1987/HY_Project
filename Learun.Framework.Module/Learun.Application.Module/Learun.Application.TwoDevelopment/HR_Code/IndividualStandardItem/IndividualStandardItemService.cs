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
    /// 日 期：2021-10-11 10:41
    /// 描 述：个人标准工资明细
    /// </summary>
    public class IndividualStandardItemService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_personalStandards_fileEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ps01,
                t.F_ps02,
                t.f_ps03,
                t.f_ps13,
                t.f_ps04,
                t.f_ps05,
                t.f_ps06,
                t.f_ps07,
                t.f_ps08,
                t.f_ps09,
                t.f_ps10,
                t.f_ps11,
                t.f_ps12,
                t.f_ps14,
                t.f_ps15,
                t.f_ps16,
                t.f_ps17
                ");
                strSql.Append("  FROM Hr_personalStandards_file t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ps02"].IsEmpty())
                {
                    dp.Add("F_ps02", "%" + queryParam["F_ps02"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ps02 Like @F_ps02 ");
                }
                if (!queryParam["f_ps03"].IsEmpty())
                {
                    dp.Add("f_ps03", "%" + queryParam["f_ps03"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.f_ps03 Like @f_ps03 ");
                }
                return this.BaseRepository().FindList<Hr_personalStandards_fileEntity>(strSql.ToString(),dp, pagination);
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

        public IEnumerable<Hr_personalStandards_fileEntity> GetPageList(string f_userid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ps01,
                t.F_ps02,
                t.f_ps03,
                t.f_ps13,
                t.f_ps04,
                t.f_ps05,
                t.f_ps06,
                t.f_ps07,
                t.f_ps08,
                t.f_ps09,
                t.f_ps10,
                t.f_ps11,
                t.f_ps12,
                t.f_ps14,
                t.f_ps15
                ");
                strSql.Append("  FROM Hr_personalStandards_file t ");
                strSql.Append("  WHERE 1=1 ");

                if (!string.IsNullOrEmpty(f_userid))
                {
                    strSql.Append(" AND t.F_ps02 = '"+ f_userid + "' ");
                }
            
                return this.BaseRepository().FindList<Hr_personalStandards_fileEntity>(strSql.ToString());
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
        /// 获取Hr_personalStandards_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_personalStandards_fileEntity GetHr_personalStandards_fileEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_personalStandards_fileEntity>(keyValue);
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
                this.BaseRepository().Delete<Hr_personalStandards_fileEntity>(t=>t.F_ps01 == keyValue);
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
        public void SaveEntity(string keyValue, Hr_personalStandards_fileEntity entity)
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
