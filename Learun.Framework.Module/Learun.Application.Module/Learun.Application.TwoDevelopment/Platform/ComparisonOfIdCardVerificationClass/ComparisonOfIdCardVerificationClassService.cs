using Dapper;
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface;
using Learun.Application.TwoDevelopment.Platform.ComparisonOfIdCardVerificationClass;
using Learun.Application.TwoDevelopment.Platform.Hy_Recruit_ProcessOperation;
using Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity;
using Learun.Application.TwoDevelopment.Platform.WL_BaseService;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员 
    /// 日 期：2021-12-22 14:41
    /// 描 述：身份证信息读取对比
    /// </summary>
    public class ComparisonOfIdCardVerificationClassService : RepositoryFactory
    {
        public ComparisonOfIdCardVerificationClassService()
        {

        }
        #region 获取数据
        ReturnCommon _rc;
        public ComparisonOfIdCardVerificationClassService(ReturnCommon _rc)
        {
            _rc = new ReturnCommon();
        }
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_hy_ComparisonOfIdCardVerificationDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 t.f_userid F_ID,
                    t.F_RealName F_UserName,
                    t.F_IDCard F_CardID,
                    case when ((SUBSTRING(t.F_IDCard,17,1) % 2)= '1') then '男' else '女' end  F_Sex,
                    t.F_Mobile F_Contact,
                    t.F_Education F_EducationInformation,
                    CASE WHEN S.SubProcessId ='3' THEN s.OperationStatus+1 else s.OperationStatus+3 end F_State,
                    s.OperationTime F_OperatingTime,
                    s.Operator F_OperationPerson,
                    s.Remark F_InformationContrastDifference
                ");
                strSql.Append("  from Hy_Recruit_Candidates t left join Hy_Recruit_ProcessOperation s on t.F_UserId  = s.CandidatesId  ");
                strSql.Append("  WHERE 1=1 and s.OperationStatus = 0 and s.SubProcessId in (4,3) ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UserName"].IsEmpty())
                {
                    dp.Add("F_UserName", "%" + queryParam["F_UserName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_UserName ");
                }
                if (!queryParam["F_CardID"].IsEmpty())
                {
                    dp.Add("F_CardID", "%" + queryParam["F_CardID"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IDCard Like @F_CardID ");
                }
                if (!queryParam["F_State"].IsEmpty())
                {
                    dp.Add("F_State",queryParam["F_State"].ToString(), DbType.String);
                    strSql.Append(" AND (s.OperationStatus+1) = @F_State ");
                }
                return this.BaseRepository().FindList<Hr_hy_ComparisonOfIdCardVerificationDTO>(strSql.ToString(),dp, pagination);
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
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public Hr_hy_ComparisonOfIdCardVerificationEntity GetOneEntity(string key)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 t.f_userid F_ID,
                    t.F_RealName F_UserName,
                    t.F_IDCard F_CardID,
                    '' F_Sex,
                    s.OperationStatus+1 F_State,
                    s.OperationTime F_OperatingTime,
                    s.Operator F_OperationPerson,
                    s.Remark F_InformationContrastDifference
                ");
                strSql.Append("  from Hy_Recruit_Candidates t left join Hy_Recruit_ProcessOperation s on t.F_UserId  = s.CandidatesId  ");
                strSql.Append("  WHERE 1=1 and s.SubProcessId in (4,3)  and t.f_userid = '" + key + "' ");
                return this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(strSql.ToString());
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
        /// 获取Hr_hy_ComparisonOfIdCardVerification表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_hy_ComparisonOfIdCardVerificationEntity GetHr_hy_ComparisonOfIdCardVerificationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(keyValue);
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
        /// <param name="jsonStr"></param>
        public void SaveKeepIdCard(string jsonStr)
        {
            try
            {
                Root root = (Root)JsonNewtonsoft.FromJSON<Root>(jsonStr);
                if ("1".Equals(root.code))
                {
                    //读取失败，修改自身状态 
                }
                else
                {
                    //读取成功1.认证对比2.修改信息
                    Hr_hy_ComparisonOfIdCardVerificationEntity hrcardEntity = this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(t => t.F_CardID == root.IDCardInfo.cardID);
                
                    if (hrcardEntity != null)
                    {
                        //根据身份证查到信息
                        if (hrcardEntity.F_UserName.Equals(root.IDCardInfo.name))
                        {
                            //自动对比通过
                            hrcardEntity.F_OperatingTime = DateTime.Now;
                            hrcardEntity.F_OperationPerson = "System";
                            hrcardEntity.F_InformationContrastDifference = "身份验证成功无差异";
                            hrcardEntity.F_State = 4;
                        }
                        else
                        {
                            //待人工检查
                            hrcardEntity.F_State = 3;
                            hrcardEntity.F_InformationContrastDifference = "人员姓名错误,请排查";
                        }
                        this.BaseRepository().Update(hrcardEntity);

                    }
                    else
                    {
                        //身份证号码错误,查看待核对人员里面是否错在人员
                        Hr_hy_ComparisonOfIdCardVerificationEntity hrcardEntityPerson = this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(t => t.F_UserName == root.IDCardInfo.name && t.F_State == 1);
                        if (hrcardEntityPerson != null)
                        {
                            //待人工检查
                            hrcardEntityPerson.F_State = 3;
                            hrcardEntityPerson.F_InformationContrastDifference = "人员身份证号码出错";
                            this.BaseRepository().Update(hrcardEntityPerson);
                        }
                    }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public ReturnCommon VerifyIDCardAjxaData(string jsonStr)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                ReturnCommon rc = new ReturnCommon();
                // string url = ConfigurationManager.AppSettings["identificationCard"];

                // string result = HttpHelper.Helper.GetURLReSource(url, null);
                RootDTO root = (RootDTO)JsonNewtonsoft.FromJSON<RootDTO>(jsonStr);
                if (root == null)
                {
                    rc.Status = false;
                    rc.Message = "仪器读取失败,仪器未启用";
                }
                else
                {
                    if ("1".Equals(root.code))
                    {
                        rc.Status = false;
                        rc.Message = "仪器读取失败,高台仪上面未放置身份证";
                    }
                    else
                    {
                        //读取成功1.认证对比2.修改信息
                        Hr_hy_ComparisonOfIdCardVerificationEntity hrcardEntity = this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(t => t.F_CardID == root.cardID); ;
                        if (hrcardEntity != null)
                        {
                            //根据身份证查到信息
                            if (hrcardEntity.F_UserName.Equals(root.name))
                            {
                                //自动对比通过
                                hrcardEntity.F_OperatingTime = DateTime.Now;
                                hrcardEntity.F_OperationPerson = "System";
                                hrcardEntity.F_InformationContrastDifference = "身份验证成功无差异";
                                hrcardEntity.F_State = 4;
                                Hy_Recruit_WrittenExaminationEntity weEntity = new Hy_Recruit_WrittenExaminationEntity();
                                weEntity.Create();
                                //用户id
                                weEntity.F_CandidatesID = hrcardEntity.F_UserId;
                                //身份证编号
                                weEntity.F_IDCard = hrcardEntity.F_CardID;

                                RWrittenExaminationIBLL weIBLL = new RWrittenExaminationBLL();

                                rc = weIBLL.NodeSaveEntity(db, null, weEntity);

                                //getHy_Recruit_SubProcessEntity
                                //批量操作日志
                                BaseService bsService = new BaseService();
                                Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("自动对比");
                                var data = bsService.GetProcessInfo(hsEntity.ID);
                                ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                                rc = poBLL.SaveNodeInfoEntity(db, data, hrcardEntity.F_UserId, hsEntity.ID, hsEntity.Name);
                            }
                            else
                            {
                                //待人工检查
                                hrcardEntity.F_State = 3;
                                hrcardEntity.F_InformationContrastDifference = "人员姓名错误,请排查";
                                //节点操作表信息
                                BaseService bsService = new BaseService();
                                Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("自动对比");
                                var data = bsService.GetProcessInfo(hsEntity.ID);
                                ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                                //设置自动对比失败进入人工对比
                                if (data.Status == false)
                                {
                                    rc.Status = false;
                                    rc.Message = "操作流程节点表信息失败";
                                }
                                else
                                {
                                    data.Status = false;
                                    rc = poBLL.SaveNodeInfoEntity(db, data, hrcardEntity.F_UserId, hsEntity.ID, hsEntity.Name);
                                }

                            }
                            db.Update(hrcardEntity);

                        }
                        else
                        {
                            //身份证号码错误,查看待核对人员里面是否错在人员
                            Hr_hy_ComparisonOfIdCardVerificationEntity hrcardEntityPerson = this.BaseRepository().FindEntity<Hr_hy_ComparisonOfIdCardVerificationEntity>(t => t.F_UserName == root.name && t.F_State == 1);
                            if (hrcardEntityPerson != null)
                            {
                                //待人工检查
                                hrcardEntityPerson.F_State = 3;
                                hrcardEntityPerson.F_InformationContrastDifference = "人员身份证号码出错";
                                this.BaseRepository().Update(hrcardEntityPerson);
                                rc.Status = false;
                                rc.Message = "人员身份证号码出错";
                            }
                        }
                    }
                }
                db.Commit();
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
        /// 身份证信息对比
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon VerifyIDCard(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
 
            try {
                ReturnCommon rc = new ReturnCommon();
                /**
                 * 1.审批通过
                 * 2.修改当前环节,结束时间，新增下一环节审批环节数据，
                 * 3.修改自身状态，f_state为人工审批通过，（数字2）
                 */
                //检验是否自动对比
                Hy_Recruit_ProcessOperationEntity processEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.SubProcessId == "3" && t.OperationStatus == 0);
                if (processEntity != null)
                {
                    Hy_Recruit_CandidatesEntity entity = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(t => t.F_UserId == keyValue);
                    Hy_Recruit_WrittenExaminationEntity weEntity = new Hy_Recruit_WrittenExaminationEntity();
                    weEntity.Create();
                    //用户id
                    weEntity.F_CandidatesID = entity.F_UserId;
                    //身份证编号
                    weEntity.F_IDCard = entity.F_IDCard;
                    RWrittenExaminationIBLL weIBLL = new RWrittenExaminationBLL();
                    rc = weIBLL.NodeSaveEntity(db, null, weEntity);

                    //写流程状态表
                    BaseService bsService = new BaseService();
                    Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("自动对比");
                    var data = bsService.GetProcessInfo(hsEntity.ID);
                    ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                    rc = poBLL.SaveNodeInfoEntity(db, data, weEntity.F_CandidatesID, hsEntity.ID, hsEntity.Name);
                    db.Commit();
                    rc.Status = true;
                    rc.Message = "自动对比和人工审批通过";
                    return rc;
                }
                else
                {
                    //查看是否人工审核完成
                    processEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.SubProcessId == "3" && t.OperationStatus == 1);
                    if (processEntity != null)
                    {
                        rc.Status = false;
                        rc.Message = "自动对比已完成,不要重复审核";
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "未找到自动对比操作信息,请联系管理员";
                    }
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
        /// 审批通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon AuditInfoEntity(
                string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                ReturnCommon rc = new ReturnCommon();
                /**
                 * 1.审批通过
                 * 2.修改当前环节,结束时间，新增下一环节审批环节数据，
                 * 3.修改自身状态，f_state为人工审批通过，（数字2）
                 */
                //检查是否已经人工审核
                Hy_Recruit_ProcessOperationEntity processEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.SubProcessId == "4" && t.OperationStatus == 0 );
                if(processEntity != null)
                {
                    Hy_Recruit_CandidatesEntity entity = this.BaseRepository().FindEntity<Hy_Recruit_CandidatesEntity>(t => t.F_UserId == keyValue);
                    Hy_Recruit_WrittenExaminationEntity weEntity = new Hy_Recruit_WrittenExaminationEntity();
                    weEntity.Create();
                    //用户id
                    weEntity.F_CandidatesID = entity.F_UserId;
                    //身份证编号
                    weEntity.F_IDCard = entity.F_IDCard;

                    RWrittenExaminationIBLL weIBLL = new RWrittenExaminationBLL();

                    rc = weIBLL.NodeSaveEntity(db, null, weEntity);

                    //写流程状态表
                    BaseService bsService = new BaseService();
                    Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("人工审核");
                    var data = bsService.GetProcessInfo(hsEntity.ID);
                    ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                    rc = poBLL.SaveNodeInfoEntity(db, data, weEntity.F_CandidatesID, hsEntity.ID, hsEntity.Name);
                    db.Commit();
                    rc.Status = true;
                    rc.Message = "人工审批通过";
                }
                else
                {
                    processEntity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue && t.SubProcessId == "4" && t.OperationStatus == 1);
                    if (processEntity != null )
                    {
                        rc.Status = false;
                        rc.Message = "人工审批已审批通过,请不要重复点审核";
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "没有人工审核操作记录,请联系管理员";
                    }
      
                }
                return rc;
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
        /// 审批不通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public  ReturnCommon UnAuditInfoEntity(string keyValue)
        {
            try
            {
                ReturnCommon rc = new ReturnCommon();
                
                int count = this.BaseRepository().Delete<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId== keyValue);
                if (count > 0)
                {
                    rc.Status = true;
                    rc.Message = "人工审核不通过,状态修改成功";
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "人工审核不通过失败,数据未更新";
                }
                return rc;
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
                this.BaseRepository().Delete<Hr_hy_ComparisonOfIdCardVerificationEntity>(t=>t.F_ID == keyValue);
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
        public void SaveEntity(string keyValue, Hr_hy_ComparisonOfIdCardVerificationEntity entity)
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
