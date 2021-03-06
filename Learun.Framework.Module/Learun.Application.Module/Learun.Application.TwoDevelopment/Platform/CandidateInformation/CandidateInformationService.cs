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
    /// 日 期：2021-12-30 18:10
    /// 描 述：应聘者信息
    /// </summary>
    public class CandidateInformationService : RepositoryFactory
    {
        ReturnCommon _return;
        public CandidateInformationService()
        {
            _return = new ReturnCommon();
        }
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_CandidatesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_UserId,
                t.F_RealName,
                t.F_IDCard,
                t.F_Mobile,
                t.F_Education,
                t.F_ExpectedentryDate,
                t.F_RecruitmentChannels,
                t.F_InternalCode,
                t.F_InternalName,
                t.F_InternalCompany,
                t.F_CreateDate,
                t.F_RecruitmentCompany
                ");
                strSql.Append("  FROM Hy_Recruit_Candidates t ");
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
                if (!queryParam["F_Mobile"].IsEmpty())
                {
                    dp.Add("F_Mobile", "%" + queryParam["F_Mobile"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Mobile Like @F_Mobile ");
                }
                if (!queryParam["F_Education"].IsEmpty())
                {
                    dp.Add("F_Education", queryParam["F_Education"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Education = @F_Education ");
                }
                if (!queryParam["F_ExpectedentryDate"].IsEmpty())
                {
                    dp.Add("F_ExpectedentryDate", queryParam["F_ExpectedentryDate"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ExpectedentryDate = @F_ExpectedentryDate ");
                }
                if (!queryParam["F_RecruitmentChannels"].IsEmpty())
                {
                    dp.Add("F_RecruitmentChannels", queryParam["F_RecruitmentChannels"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_RecruitmentChannels = @F_RecruitmentChannels ");
                }
                if (!queryParam["F_InternalCode"].IsEmpty())
                {
                    dp.Add("F_InternalCode", "%" + queryParam["F_InternalCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_InternalCode Like @F_InternalCode ");
                }
                if (!queryParam["F_InternalName"].IsEmpty())
                {
                    dp.Add("F_InternalName", "%" + queryParam["F_InternalName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_InternalName Like @F_InternalName ");
                }
                if (!queryParam["F_InternalCompany"].IsEmpty())
                {
                    dp.Add("F_InternalCompany", "%" + queryParam["F_InternalCompany"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_InternalCompany Like @F_InternalCompany ");
                }
                if (!queryParam["F_RecruitmentCompany"].IsEmpty())
                {
                    dp.Add("F_RecruitmentCompany", "%" + queryParam["F_RecruitmentCompany"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RecruitmentCompany Like @F_RecruitmentCompany ");
                }

                strSql.Append(" order by F_CreateDate desc");

                return this.BaseRepository().FindList<Hy_Recruit_CandidatesEntity>(strSql.ToString(), dp, pagination);
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
        /// 报道环节证件审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnCommon SavDormitory(DormitoryDTO model)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                Hy_Recruit_ProcessOperationEntity operactEntity = null;
                Hy_Recruit_CandidatesEntity entity =  this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(e => e.F_IDCard == model.F_CardId);
                operactEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(e => e.CandidatesId == entity.F_UserId &&
                e.OperationContent == "上传信息审核" && e.OperationStatus == 0);
                if (operactEntity != null)
                {
                    //批量操作日志
                    BaseService bsService = new BaseService();
                    Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("上传信息审核");
                    var data = bsService.GetProcessInfo(hsEntity.ID);
                    ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                    _return = poBLL.SaveNodeInfoEntity(db, data, entity.F_UserId, hsEntity.ID, hsEntity.Name);
                    _return.Status = true;
                    _return.Message = "证件照审批成功";
                    db.Commit();
                }
                else
                {
                    operactEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(e => e.CandidatesId == entity.F_UserId && e.OperationContent == "上传信息审核" && e.OperationStatus == 1);
                    if (operactEntity != null)
                    {
                        _return.Status = false;
                        _return.Message = "此证件照已经审核,不允许重复审核";
                    }
                    else
                    {
                        _return.Status = false;
                        _return.Message = "未查到该条操作信息,请联系管理员";
                    }
                }

            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
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

        /// 报道节点生成实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Hy_Recruit_CandidatesEntity GetICardEntity(string keyValue)
        {
            try
            {
                Hy_Recruit_CandidatesEntity entity
                    = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(e => e.F_IDCard == keyValue);
                if (entity != null)
                {
                    string url = Config.GetValue("ImgUrl");
                    if (!string.IsNullOrEmpty(entity.F_HeadIcon))
                    {
                        entity.F_HeadIcon = url + entity.F_IDCard + entity.F_HeadIcon;
                    }
                }
                return entity;
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

        /// 获取用户信息
        /// <summary>
        /// <param name="F_IDCard">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Platform_BlacklistEntity> GetUserBlackList(string F_IDCard)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"* ");
                strSql.Append("  from Hy_Recruit_Blacklist ");
                strSql.Append("  WHERE F_IDCard='" + F_IDCard + "'");
                var userBlacklistModel = this.BaseRepository().FindList<Hy_Platform_BlacklistEntity>(strSql.ToString());
                return userBlacklistModel;

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
        /// 获取Hy_Recruit_Candidates表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_CandidatesEntity GetHy_Recruit_CandidatesEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(keyValue);
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
                var delete = this.BaseRepository().Delete<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue);
                var isDel = this.BaseRepository().Delete<Hy_Recruit_CandidatesEntity>(t => t.F_UserId == keyValue);
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
        public ReturnCommon SaveEntity(Hy_Recruit_CandidatesEntity entity)
        {
            try
            {
                entity.Create();
                var isSuccess = this.BaseRepository().Insert(entity);
                if (isSuccess > 0)
                {
                    _return.Status = true;
                    _return.Message = "添加成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "添加失败";
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_CandidatesEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                Hr_hy_ComparisonOfIdCardVerificationEntity ComparisonOfIdCardVerificationEntity = new Hr_hy_ComparisonOfIdCardVerificationEntity();
                ComparisonOfIdCardVerificationClassService ComparisonOfIdCardVerificationEntityservser = new ComparisonOfIdCardVerificationClassService();
                //身份证是否重复提交
                var isExistCandidates = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(t => t.F_IDCard == entity.F_IDCard);
                //手机号是否重复提交
                var isMobile = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(t => t.F_Mobile == entity.F_Mobile);
                //黑名单
                var isBlack = this.BaseRepository().FindEntity<Hy_Platform_BlacklistEntity>(t => t.F_IDCard == entity.F_IDCard);

                if (isBlack != null)
                {
                    _return.Status = false;
                    _return.Message = "该人员为黑名单用户，请慎重录用！";
                    return _return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        entity.Modify(keyValue);
                        this.BaseRepository().Update(entity);
                        //写流程状态表
                        BaseService bsService = new BaseService();
                        Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("应聘者注册");
                        var data = bsService.GetProcessInfo(hsEntity.ID);
                        ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                        poBLL.SaveNodeInfoEntity(db, data, entity.F_UserId, hsEntity.ID, hsEntity.Name);
                        //ComparisonOfIdCardVerificationEntity.Create();
                        //ComparisonOfIdCardVerificationEntity.F_CardID = entity.F_IDCard;
                        //ComparisonOfIdCardVerificationEntity.F_UserName = entity.F_RealName;
                        //ComparisonOfIdCardVerificationEntity.F_UserId = entity.F_UserId;
                        //ComparisonOfIdCardVerificationEntityservser.SaveEntity(null, ComparisonOfIdCardVerificationEntity);
                    }
                    else
                    {
                        if (isExistCandidates != null)
                        {
                            _return.Status = false;
                            _return.Message = "身份证号已被其他在职员工使用";
                            return _return;
                        }
                        if (isMobile != null)
                        {
                            _return.Status = false;
                            _return.Message = "手机号已被其他在职员工使用";
                            return _return;
                        }
                        entity.Create();
                        this.BaseRepository().Insert(entity);
                        var yanzheng = this.BaseRepository().FindList<Hr_hy_ComparisonOfIdCardVerificationEntity>(t => t.F_UserId == entity.F_UserId);
                        if (yanzheng.Count() == 0)
                        {
                            //写流程状态表
                            BaseService bsService = new BaseService();
                            Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("应聘者注册");
                            var data = bsService.GetProcessInfo(hsEntity.ID);
                            ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                            poBLL.SaveNodeInfoEntity(db, data, entity.F_UserId, hsEntity.ID, hsEntity.Name);
                            ComparisonOfIdCardVerificationEntity.Create();
                            ComparisonOfIdCardVerificationEntity.F_CardID = entity.F_IDCard;
                            ComparisonOfIdCardVerificationEntity.F_UserName = entity.F_RealName;
                            ComparisonOfIdCardVerificationEntity.F_UserId = entity.F_UserId;
                            ComparisonOfIdCardVerificationEntityservser.SaveEntity(null, ComparisonOfIdCardVerificationEntity);
                        }
                    }
                    db.Commit();
                    _return.Status = true;
                    _return.Message = "操作成功";
                }
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
        #endregion
    }
}
