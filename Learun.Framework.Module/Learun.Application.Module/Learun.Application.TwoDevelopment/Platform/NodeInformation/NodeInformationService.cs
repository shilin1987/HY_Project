using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-22 09:14
    /// 描 述：节点信息查询
    /// </summary>
    public class NodeInformationService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NodeInformationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_UserId,
                t.F_RealName,
                t.F_Mobile,
                t.F_IDCard,
                t.F_RecruitmentChannels,
                t.F_Education,
                sp.Name,
                p.OperationTime,
                p.Operator
                ");
                strSql.Append("  from dbo.Hy_Recruit_Candidates t ");
                strSql.Append("  left join dbo.Hy_Recruit_ProcessOperation p on t.F_UserId=p.CandidatesId ");
                strSql.Append("  left join dbo.Hy_Recruit_SubProcess sp on  p.SubProcessId=sp.ID ");
                strSql.Append("  left join dbo.Hy_Recruit_WrittenExamination w on t.F_UserId=w.F_CandidatesID ");
                strSql.Append("  left join dbo.Hy_Recruit_Interview i on t.F_UserId=i.F_CandidatesID ");
                strSql.Append("  left join dbo.Hy_Recruit_ReportNodeApproval a on t.F_UserId=a.F_UserId ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", "%" + queryParam["F_RealName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_RealName ");
                }
                if (!queryParam["F_IDCard"].IsEmpty())
                {
                    dp.Add("F_IDCard", "%" + queryParam["F_IDCard"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IDCard Like @F_IDCard ");
                }
                return this.BaseRepository().FindList<NodeInformationEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hy_Recruit_Candidates表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public NodeInformationEntity GetHy_Recruit_CandidatesEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<NodeInformationEntity>(keyValue);
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
                this.BaseRepository().Delete<NodeInformationEntity>(t=>t.F_RealName == keyValue);
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
        public void SaveEntity(string keyValue, NodeInformationEntity entity)
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
