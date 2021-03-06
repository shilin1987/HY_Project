using Dapper;
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform.Hy_Recruit_ProcessOperation;
using Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity;
using Learun.Application.TwoDevelopment.Platform.WL_BaseService;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 15:16
    /// 描 述：面试信息
    /// </summary>
    public class RecruitInterviewService : RepositoryFactory
    {
        ReturnCommon _return;
        #region 构造函数和属性

        private string fieldSql;
        public RecruitInterviewService()
        {
            fieldSql = @"
                t.F_UserId,
                t.F_RealName,
                t.F_IDCard,
                t.F_Gender,
                t.F_Mobile ,
                t.F_Education,
                p.OperationTime,
                p.Operator,
                p.OperationStatus,
                i.F_CreateUserName as F_Iuserid
            ";
            _return = new ReturnCommon();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_InterviewEntity> GetList(string queryJson)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Recruit_Interview t ");
                return this.BaseRepository().FindList<Hy_Recruit_InterviewEntity>(strSql.ToString());
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<InterviewEntityDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" from dbo.Hy_Recruit_Candidates  t left join   dbo.Hy_Recruit_ProcessOperation p on t.F_UserId=p.CandidatesId left join dbo.Hy_Recruit_Interview i on t.F_UserId=i.F_CandidatesID ");
                strSql.Append("  where  t.F_UserId = p.CandidatesId  and p.OperationContent = '面试' ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( p.OperationTime >= @startTime AND p.OperationTime <= @endTime ) ");
                }
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", queryParam["F_RealName"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_RealName like @F_RealName ");
                }
                if (!queryParam["F_IDCard"].IsEmpty())
                {
                    dp.Add("F_IDCard", queryParam["F_IDCard"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_IDCard like @F_IDCard ");
                }
                if (!queryParam["OperationStatus"].IsEmpty())
                {
                    dp.Add("F_InterviewResult", queryParam["OperationStatus"].ToString(), DbType.String);
                    strSql.Append(" AND p.OperationStatus like @OperationStatus ");
                }
                return this.BaseRepository().FindList<InterviewEntityDTO>(strSql.ToString(), dp, pagination);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_InterviewEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_InterviewEntity>(keyValue);
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
                var isDel = this.BaseRepository().Delete<Hy_Recruit_InterviewEntity>(t => t.F_Id == keyValue);
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
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
            return _return;
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, InterviewEntityDTO entity)
        {
            ReturnCommon rc = new ReturnCommon();
            var db = this.BaseRepository().BeginTrans();
            try
            {

                var baodao = this.BaseRepository().FindList<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue);
                Hy_Recruit_InterviewEntity ientity = new Hy_Recruit_InterviewEntity();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    UserInfo userInfo = LoginUserInfo.Get();
                    if (entity.OperationStatus == 0)
                    {
                        var sql = @"update dbo.Hy_Recruit_ProcessOperation  set OperationStatus=-1 ,OperationTime='" + DateTime.Now.ToString() + "',Operator='" + userInfo.userId + "' where CandidatesId='" + keyValue + "' and OperationContent='面试' ";
                        var isDel = this.BaseRepository().ExecuteBySql(sql.ToString());
                        if (isDel > 0)
                        {
                            _return.Status = true;
                            _return.Message = "操作成功";
                        }
                        else
                        {
                            _return.Status = false;
                            _return.Message = "操作失败";
                        }
                    }
                    else
                    {
                        var sql = @"update dbo.Hy_Recruit_ProcessOperation  set OperationStatus=1 ,OperationTime='" + DateTime.Now.ToString() + "',Operator='" + userInfo.userId + "' where CandidatesId='" + keyValue + "' and OperationContent='面试' ";
                        var isDel = this.BaseRepository().ExecuteBySql(sql.ToString());
                        if (isDel > 0)
                        {
                            _return.Status = true;
                            _return.Message = "操作成功";
                        }
                        else
                        {
                            _return.Status = false;
                            _return.Message = "操作失败";
                        }

                        if (baodao.Count() < 7)
                        {
                            //写流程状态表
                            BaseService bsService = new BaseService();
                            Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("面试");
                            var data = bsService.GetProcessInfo(hsEntity.ID);
                            ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                            rc = poBLL.SaveNodeInfoEntity(db, data, keyValue, hsEntity.ID, hsEntity.Name);
                        }
                        ientity.F_CandidatesID = keyValue;
                        ientity.F_CreateDate = entity.OperationTime;
                        ientity.F_ModifyUserName = entity.Operator;
                        ientity.F_InterviewResult = entity.OperationStatus;
                        ientity.F_CreateUserName = entity.F_Iuserid;
                        InterviewEntity(keyValue, ientity);
                    }
                }

                db.Commit();
                _return.Message = "操作成功";
            }
            catch (Exception ex)
            {
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
            return _return;
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon InterviewEntity(string keyValue, Hy_Recruit_InterviewEntity Ientity)
        {
            try
            {
                var isy = this.BaseRepository().FindList<Hy_Recruit_InterviewEntity>(t => t.F_CandidatesID == keyValue);
                if (isy.Count() == 0)
                {
                    Ientity.Create();
                    this.BaseRepository().Insert(Ientity);
                    _return.Status = true;
                    _return.Message = "操作成功";
                }
                else
                {
                    Ientity.Modify(isy.First().F_Id);
                    this.BaseRepository().Update(Ientity);
                    _return.Status = true;
                    _return.Message = "操作成功";
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
            return _return;
        }
        #endregion



    }
}
