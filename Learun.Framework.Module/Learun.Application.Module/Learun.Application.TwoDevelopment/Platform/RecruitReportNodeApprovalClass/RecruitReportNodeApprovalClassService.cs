using Dapper;
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform.Hy_Recruit_ProcessOperation;
using Learun.Application.TwoDevelopment.Platform.RecruitReportNodeApprovalClass;
using Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity;
using Learun.Application.TwoDevelopment.Platform.WL_BaseService;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-27 18:33
    /// 描 述：报道节点审批维护
    /// </summary>
    public class RecruitReportNodeApprovalClassService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_ReportNodeApprovalDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_UserId F_ID,
                t.F_RealName as F_UserName,
                t.F_IDCard  as F_CardId,
                case when ((SUBSTRING(t.F_IDCard,17,1) % 2)= '1') then '男' else '女' end  F_Sex,
                t.F_Mobile F_Contact,
                t.F_Education F_EducationInformation,
                s.OperationTime F_StoryTime,
                t.F_BankCardNumber,
                t.F_HeadIcon,
                s.SubProcessId F_NodeWhere,
                t.F_Dormitory F_DormitoryButton,
                s.OperationStatus F_WhetherTheAudit,
                s.OperationContent F_Description
                ");
                strSql.Append("  FROM Hy_Recruit_Candidates t left join  Hy_Recruit_ProcessOperation s on t.F_UserId  = s.CandidatesId ");
                strSql.Append("  WHERE 1=1 and s.OperationStatus = 0 and s.SubProcessId in (7,8,9)  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( s.OperationTime >= @startTime AND s.OperationTime <= @endTime ) ");
                }
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_UserName ");
                }
                if (!queryParam["F_CardId"].IsEmpty())
                {
                    dp.Add("F_CardId", "%" + queryParam["F_CardId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IDCard Like @F_CardId ");
                }
                if (!queryParam["F_WhetherTheAudit"].IsEmpty())
                {
                    dp.Add("F_WhetherTheAudit", queryParam["F_WhetherTheAudit"].ToString(), DbType.String);
                    strSql.Append(" AND s.OperationStatus = @F_WhetherTheAudit ");
                }
                return this.BaseRepository().FindList<Hy_Recruit_ReportNodeApprovalDTO>(strSql.ToString(), dp, pagination);
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
        /// 获取Hy_Recruit_ReportNodeApproval表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_ReportNodeApprovalEntity GetHy_Recruit_ReportNodeApprovalEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_ReportNodeApprovalEntity>(keyValue);
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
        /// 审批通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon AuditInfo(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                ReturnCommon rc = new ReturnCommon();

                if (!string.IsNullOrEmpty(keyValue))
                {
                    int count = this.BaseRepository().FindList<Hy_Recruit_ProcessOperationEntity>(e => e.CandidatesId == keyValue && e.OperationContent == "报到完成" && e.OperationStatus == 0).ToList().Count();
                    if (count > 0)
                    {
                        Hy_Recruit_ReportNodeApprovalEntity entity = new Hy_Recruit_ReportNodeApprovalEntity();
                        entity.Create();
                        entity.F_WhetherTheAudit = 1;
                        entity.F_StoryTime = DateTime.Now;
                        db.Insert(entity);
                        //入职日期
                        Hy_Recruit_CandidatesEntity candentity = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(e => e.F_UserId == keyValue);
                        candentity.F_Entrydate = DateTime.Now;
                        db.Update(candentity);
                        //写流程状态表
                        BaseService bsService = new BaseService();
                        Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("报到完成");
                        var data = bsService.GetProcessInfo(hsEntity.ID);
                        ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                        rc = poBLL.SaveNodeInfoEntity(db, data, keyValue, hsEntity.ID, hsEntity.Name);
                        db.Commit();
                        rc.Status = true;
                        rc.Message = "报道审核未通过设置成功";
                    }
                    else
                    {
                        count = this.BaseRepository().FindList<Hy_Recruit_ProcessOperationEntity>(e => e.CandidatesId == keyValue && e.OperationContent == "报到完成" && e.OperationStatus == 1).ToList().Count();
                        if (count > 0)
                        {
                            rc.Status = false;
                            rc.Message = "报道审核已完成不允许重复审核";
                        }
                        else
                        {
                            rc.Status = false;
                            rc.Message = "报道审核未成功，未查到当前实例信息";
                        }
                    }
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "报道审核未成功，未查到当前实例信息";
                }
                return rc;
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
        }
        /// <summary>
        /// 重新上传
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon ResetInfo(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                ReturnCommon rc = new ReturnCommon();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    Hy_Recruit_ProcessOperationEntity entity =
                 this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.OperationContent == "上传信息审核" && t.OperationStatus == 0);
                    if (entity != null)
                    {
                        db.Delete<Hy_Recruit_ProcessOperationEntity>(entity);
                        Hy_Recruit_ProcessOperationEntity entity1 =
                 this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.OperationContent == "上传证件照等信息" && t.OperationStatus == 1);
                        if (entity1 != null)
                        {
                            entity1.OperationStatus = 0;
                            db.Update(entity1);
                        }
                        else
                        {
                            rc.Status = false;
                            rc.Message = "重新上传设置失败";
                        }
                    }
                    db.Commit();
                    rc.Status = true;
                    rc.Message = "重新上传设置成功";
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "请选择数据";
                }
                return rc;
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon BatchAuditInfo(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                ReturnCommon rc = new ReturnCommon();
                if (!string.IsNullOrEmpty(keyValue))
                {

                    List<string> List = new List<string>(keyValue.Split(','));

                    List<Hy_Recruit_ReportNodeApprovalEntity> entityList = (List<Hy_Recruit_ReportNodeApprovalEntity>)this.BaseRepository().FindList<Hy_Recruit_ReportNodeApprovalEntity>(
                        t => List.Contains(t.F_ID));

                    if (entityList != null && entityList.Count > 0)
                    {
                        foreach (var entity in entityList)
                        {
                            entity.Modify(keyValue);
                            entity.F_WhetherTheAudit = 1;

                            entity.F_StoryTime = DateTime.Now;
                            db.Update(entity);
                            //批量操作日志
                            BaseService bsService = new BaseService();
                            Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("报到签到");
                            var data = bsService.GetProcessInfo(hsEntity.ID);
                            ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                            rc = poBLL.SaveNodeInfoEntity(db, data, entity.F_UserId, hsEntity.ID, hsEntity.Name);


                        }
                        db.Commit();
                        rc.Status = true;
                        rc.Message = "报道审核通过设置成功";

                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "报道审核未成功，未查到当前实例信息";
                    }
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "请选择数据";
                }


                return rc;
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
                this.BaseRepository().Delete<Hy_Recruit_ReportNodeApprovalEntity>(t => t.F_ID == keyValue);
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
        /// 报道审核未通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon UnAuditInfo(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {

                ReturnCommon rc = new ReturnCommon();
                Hy_Recruit_ReportNodeApprovalEntity entity = this.BaseRepository().FindEntity<Hy_Recruit_ReportNodeApprovalEntity>(t => t.F_ID == keyValue);
                if (entity != null)
                {
                    entity.Modify(keyValue);
                    entity.F_WhetherTheAudit = 3;
                    entity.F_DeleteMark = 1;
                    entity.F_StoryTime = DateTime.Now;
                    db.Update(entity);


                    //批量操作日志
                    BaseService bsService = new BaseService();
                    Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("报到签到");
                    var data = bsService.GetProcessInfo(hsEntity.ID);
                    ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                    rc = poBLL.SaveNodeInfoEntity(db, data, entity.F_UserId, hsEntity.ID, hsEntity.Name);
                    db.Commit();
                    rc.Status = true;
                    rc.Message = "报道审核未通过设置成功";
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "报道审核未成功，未查到当前实例信息";
                }
                return rc;
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
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, Hy_Recruit_ReportNodeApprovalEntity entity)
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
