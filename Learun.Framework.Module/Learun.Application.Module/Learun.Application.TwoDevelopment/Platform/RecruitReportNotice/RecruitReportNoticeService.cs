using Dapper;
using Learun.Application.Organization.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-12 09:36
    /// 描 述：通知单管理
    /// </summary>
    public class RecruitReportNoticeService : RepositoryFactory
    {
        ReturnCommon _return = new ReturnCommon() { Status = false};
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_ReportNoticeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Id,
                t.F_SubProcessId,
                t.F_Description,
                t.f_Content
                ");
                strSql.Append("  FROM Hy_Recruit_ReportNotice t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<Hy_Recruit_ReportNoticeEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hy_Recruit_ReportNotice表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_ReportNoticeEntity GetHy_Recruit_ReportNoticeEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_ReportNoticeEntity>(keyValue);
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
        /// 获取Hy_Recruit_ReportNotice表实体数据
        /// <param name="sunbid">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_ReportNoticeEntity GetPageListData(string subid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" * ");
                strSql.Append("  FROM Hy_Recruit_ReportNotice t ");
                strSql.Append("  WHERE 1=1 and t.F_SubProcessId='"+subid+ "' and t.F_Description like '%报到告知单%'");
                var reportNoticeEntity = this.BaseRepository().FindList<Hy_Recruit_ReportNoticeEntity>(strSql.ToString());
                if (reportNoticeEntity == null)
                {
                    return null;
                }
                else { return reportNoticeEntity.FirstOrDefault(); }
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
                this.BaseRepository().Delete<Hy_Recruit_ReportNoticeEntity>(t=>t.F_Id == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_ReportNoticeEntity entity)
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
                _return.Status = true;
                _return.Message = "操作成功";
            }
            catch (Exception ex)
            {
                _return.Message = "保存失败：" + ex.Message;
            }
            return _return;
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="subid">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntityList(string subid, Hy_Recruit_ReportNoticeEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(subid))
                {
                    var strSql = new StringBuilder();
                    strSql.Append("update ");
                    strSql.Append(" Hy_Recruit_ReportNotice ");
                    strSql.Append(" set f_Content ='"+entity.f_Content+"'");
                    strSql.Append("  WHERE 1=1 and F_SubProcessId='" + subid + "' ");
                    int i=this.BaseRepository().ExecuteBySql(strSql.ToString());
                    if (i > 0)
                    {
                        _return.Status = true;
                        _return.Message = "保存成功";
                    }
                    else
                    {
                        _return.Message = "保存失败";
                    }
                }
            }
            catch (Exception ex)
            {
                _return.Message = "保存失败："+ex.Message;
            }
            return _return;
        }
        #endregion

    }
}
