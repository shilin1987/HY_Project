using Dapper;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcess;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-28 10:05
    /// 描 述：简历审批结果查询
    /// </summary>
    public class RecruitmentProcessService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SR_RecruitmentProcessNodeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_HrIndicatesOrderNumber,
                m.F_fileName as F_ResumeName,
                m.F_State as F_WhetherThrough
                ");
                strSql.Append("  FROM SR_RecruitmentProcessNode t, SR_ProcessAttachment m  ");
                strSql.Append("  WHERE 1=1 and  t.F_ID=m.F_ID  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate>= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_HrIndicatesOrderNumber"].IsEmpty())
                {
                    dp.Add("F_HrIndicatesOrderNumber", "%" + queryParam["F_HrIndicatesOrderNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HrIndicatesOrderNumber Like @F_HrIndicatesOrderNumber ");
                }
                if (!queryParam["F_WhetherThrough"].IsEmpty())
                {
                    if (queryParam["F_WhetherThrough"].ToString()=="1") 
                    {
                        dp.Add("F_WhetherThrough", "通过", DbType.String);
                    }
                    else
                    {
                        dp.Add("F_WhetherThrough", "未通过", DbType.String);
                    }
                    strSql.Append(" AND m.F_State = @F_WhetherThrough ");
                }
                if (!queryParam["F_ApprovalTime"].IsEmpty())
                {
                    dp.Add("F_ApprovalTime",queryParam["F_ApprovalTime"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateDate= @F_ApprovalTime ");
                }
                return this.BaseRepository("SRDB").FindList<SR_RecruitmentProcessNodeEntity>(strSql.ToString(),dp, pagination);
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

        public IEnumerable<SRProcessExportDataDTO> GetExportProcessInfo(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                    un1.F_HrIndicatesOrderNumber, 
                    un1.F_ResumeName, 
                    un1.F_WhetherThrough, 
                    un1.F_ProcessTheOrder,
                    un1.F_OaFlowNumber,
                    un2.F_CheckpointName,
                    un2.F_Approver,
                    un2.F_ApprovalDate,
                    un2.F_ApprovalResults,
                    un2.F_ApprovalComments
                ");
                strSql.Append(" from ( ");
                strSql.Append(" select   t.F_ID, t.F_HrIndicatesOrderNumber, ");
                strSql.Append(" t.F_OaFlowNumber , ");
                strSql.Append(" case when t.F_ProcessTheOrder =1 then '社招申请流程' when t.F_ProcessTheOrder =2 ");
                strSql.Append(" then '简历分发流程' when t.F_ProcessTheOrder =3 ");
                strSql.Append(" then '面试流程' else '录用流程' end F_ProcessTheOrder, ");
                strSql.Append(" m.F_fileName as F_ResumeName, ");
                strSql.Append(" m.F_State as F_WhetherThrough from SR_RecruitmentProcessNode t LEFT JOIN SR_ProcessAttachment m ON t.F_ID=m.F_ID ");
                strSql.Append(" ) un1 left join ( ");
                strSql.Append(" SELECT ");
                strSql.Append(" p.f_id, ");
                strSql.Append(" p.F_CheckpointName, ");
                strSql.Append(" u.F_RealName as F_Approver, ");
                strSql.Append(" p.F_ApprovalTime as F_ApprovalDate, ");
                strSql.Append(" p.F_WhetherThrough as F_ApprovalResults, ");
                strSql.Append(" p.F_Opinion as F_ApprovalComments ");
                strSql.Append(" from  dbo.SR_ProcessNode p left join  HYDatabase.dbo.lr_base_user u on p.F_TheApprover=u.F_EnCode left  join SR_RecruitmentProcessNode rn on p.F_ID=rn.F_ID ");
                strSql.Append(" )  un2  on un1.f_id = un2.f_id  ");
                // strSql.Append(" where un1.F_HrIndicatesOrderNumber ='SR-20211208000002' ");
                 strSql.Append(" where 1=1  ");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
               
                if (!queryParam["F_HrIndicatesOrderNumber"].IsEmpty())
                {
                    dp.Add("F_HrIndicatesOrderNumber", "%" + queryParam["F_HrIndicatesOrderNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND un1.F_HrIndicatesOrderNumber Like @F_HrIndicatesOrderNumber ");
                }
                if (!queryParam["F_WhetherThrough"].IsEmpty())
                {
                    dp.Add("F_WhetherThrough", "%" + queryParam["F_WhetherThrough"].ToString() + "%", DbType.String);
                    strSql.Append(" AND un1.F_WhetherThrough Like @F_WhetherThrough ");
                }
                if (!queryParam["F_ApprovalTime"].IsEmpty())
                {
                    dp.Add("F_ApprovalTime", queryParam["F_ApprovalTime"].ToString(), DbType.String);
                    strSql.Append(" AND un2.F_CreateDate= @F_ApprovalTime ");
                }
                strSql.Append(" order by F_ApprovalDate ");
                return this.BaseRepository("SRDB").FindList<SRProcessExportDataDTO>(strSql.ToString(), dp);
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
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
 
        /// <summary>
        /// 获取SR_RecruitmentProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_RecruitmentProcessNodeEntity GetSR_RecruitmentProcessNodeEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("SRDB").FindEntity<SR_RecruitmentProcessNodeEntity>(keyValue);
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
        /// 获取页面显示子表数据
        /// <summary>
        /// <param name="fid">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SR_ApprovalProcessEntity> GetSubList(string fid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                p.f_id,
                rn.F_ProcessName,
                u.F_RealName as F_Approver,
                p.F_ApprovalTime as F_ApprovalDate,
                p.F_WhetherThrough as F_ApprovalResults,
                p.F_Opinion as F_ApprovalComments
                ");
                strSql.Append("  from  dbo.SR_ProcessNode p left join  HYDatabase.dbo.lr_base_user u on p.F_TheApprover=u.F_EnCode left  join SR_RecruitmentProcessNode rn on p.F_ID=rn.F_ID ");
                strSql.Append("  WHERE p.f_id='"+fid+"' ");
                strSql.Append("  order by F_ApprovalDate ");
                return this.BaseRepository("SRDB").FindList<SR_ApprovalProcessEntity>(strSql.ToString());
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
        /// <summary>
        /// <param name="fid">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SR_RecruitmentProcessNodeEntity> GetList(string fid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                p.f_id,
                p.F_ProcessName,
                p.F_ApprovalTime,
                p.F_WhetherThrough
                ");
                strSql.Append("  from  SR_RecruitmentProcessNode p");
                strSql.Append("  WHERE p.f_id='" + fid + "'  and ");
                strSql.Append("  order by F_ApprovalTime ");
                return this.BaseRepository("SRDB").FindList<SR_RecruitmentProcessNodeEntity>(strSql.ToString());
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
                this.BaseRepository("SRDB").Delete<SR_RecruitmentProcessNodeEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("SRDB").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("SRDB").Insert(entity);
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
