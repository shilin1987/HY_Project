﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcessInformationClass;
using Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface;
using System.Linq;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public class RecruitmentProcessInformationClassBLL : RecruitmentProcessInformationClassIBLL
    {
        private RecruitmentProcessInformationClassService recruitmentProcessInformationClassService = new RecruitmentProcessInformationClassService();

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
                return recruitmentProcessInformationClassService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取SR_RecruitmentProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_RecruitmentProcessNodeEntity GetSR_RecruitmentProcessNodeEntity(string keyValue)
        {
            try
            {
                return recruitmentProcessInformationClassService.GetSR_RecruitmentProcessNodeEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取SR_ProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_ProcessNodeEntity GetSR_ProcessNodeEntity(string keyValue)
        {
            try
            {
                return recruitmentProcessInformationClassService.GetSR_ProcessNodeEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取SR_ProcessAttachment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_ProcessAttachmentEntity GetSR_ProcessAttachmentEntity(string keyValue)
        {
            try
            {
                return recruitmentProcessInformationClassService.GetSR_ProcessAttachmentEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                recruitmentProcessInformationClassService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity,SR_ProcessNodeEntity sR_ProcessNodeEntity,SR_ProcessAttachmentEntity sR_ProcessAttachmentEntity)
        {
            try
            {
               // recruitmentProcessInformationClassService.SaveEntity(keyValue, entity,sR_ProcessNodeEntity,sR_ProcessAttachmentEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public void SaveListEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity, List<SR_ProcessNodeEntity> sR_ProcessNodeListEntity, List<SR_ProcessAttachmentEntity> sR_ProcessAttachmentListEntity)
        {
            try
            {
                //recruitmentProcessInformationClassService.SaveListEntity(keyValue, entity, sR_ProcessNodeListEntity, sR_ProcessAttachmentListEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public ReturnComment InsertListEntity(string jsonStr, string userId)
        {
            try
            {
                    
                userId = "System";
                OaProssInfoDTO stobj = (OaProssInfoDTO)JsonNewtonsoft.FromJSON<OaProssInfoDTO>(jsonStr);
                if (string.IsNullOrEmpty(stobj.F_OaFlowNumber))
                {
                    ReturnComment rc = new ReturnComment();
                    rc.State = "F";
                    rc.Mes = "OA单号为空不允许请检查回传数据";
                    return rc;
                }
                SR_RecruitmentProcessNodeEntity entity = new SR_RecruitmentProcessNodeEntity();
                List<SR_ProcessNodeEntity> sR_ProcessNodeListEntity = new List<SR_ProcessNodeEntity>();
                List<SR_ProcessAttachmentEntity> sR_ProcessAttachmentListEntity = new List<SR_ProcessAttachmentEntity>();
     
                IEnumerable<SR_RecruitmentProcessNodeEntity> srmodel =  recruitmentProcessInformationClassService.GetEntiyCountList(stobj.F_OaFlowNumber);
                var srdata = srmodel.ToList();
                if (srdata.Count >0 )
                {
                    ReturnComment rc = new ReturnComment();
                    rc.State = "F";
                    rc.Mes = "此OA单号已经回传,不需要重复回传";
                    return rc;
                }
                string format = "yyyy-MM-dd HH:mm:ss";
                entity.Create(userId);
                entity.F_HrIndicatesOrderNumber = stobj.F_HrIndicatesOrderNumber;
                entity.F_OaFlowNumber = stobj.F_OaFlowNumber;
                entity.F_Requestid = stobj.F_Requestid;
                entity.F_WhetherThrough = stobj.F_State;
                entity.F_ProcessTheOrder = stobj.F_ProcessTheOrder;
                if (stobj.F_ProcessTheOrder == 1)
                {
                    entity.F_ProcessName = "社招流程";
                }
                else if (stobj.F_ProcessTheOrder == 2)
                {
                    entity.F_ProcessName = "简历分发流程";
                }
                else if (stobj.F_ProcessTheOrder == 3)
                {
                    entity.F_ProcessName = "面试流程";
                }
                else
                {
                    entity.F_ProcessName = "录用流程";
                }

                if (stobj.F_ArchiveTime is null)
                {
                    //DateTime dtValue = new DateTime();
                    entity.F_ArchiveTime = DateTime.Now.ToString(format);
                }
                else
                {
                    //IFormatProvider cultureInfo = new CultureInfo("zh-CN");
       
                    DateTime dt = (DateTime)stobj.F_ArchiveTime; // 得到日期字符串

                    entity.F_ArchiveTime = dt.ToString(format);
                }
                int i = 0, j = 0;
                if (stobj.processNode.Count > 0)
                {
                    foreach (var data in  stobj.processNode)
                    {
                        SR_ProcessNodeEntity proceNode = new SR_ProcessNodeEntity();
                        proceNode.Create(userId);
                        proceNode.F_ID = entity.F_ID;
                        proceNode.F_SubID = i;
                        proceNode.F_CheckpointName = data.F_CheckpointName;
                        proceNode.F_TheApprover = data.F_ApprovalTime.ToString();
                        proceNode.F_ApprovalTime = data.F_ApprovalTime;
                        proceNode.F_TheApprover = data.F_TheApprover;
                        proceNode.F_IfTimeout = data.F_IfTimeout;
                        proceNode.F_WhetherThrough = data.F_WhetherThrough;
                        proceNode.F_Opinion = data.F_Opinion;
                        sR_ProcessNodeListEntity.Add(proceNode);
                        i++;
                    }
                }
                if (stobj.files.Count > 0)
                {
                    foreach (var data in stobj.files)
                    {
                        SR_ProcessAttachmentEntity file = new SR_ProcessAttachmentEntity();
                        file.Create(userId);
                        file.F_ID = entity.F_ID;
                        file.F_file = data.F_file;
                        file.F_fileName = data.F_fileName;
                        file.F_State = data.State;
                        file.F_SubItem = j;
                        file.F_Description = data.F_Description;
                        sR_ProcessAttachmentListEntity.Add(file);
                        j++;
                    }
                }

                return recruitmentProcessInformationClassService.SaveListEntity("", entity, sR_ProcessNodeListEntity, sR_ProcessAttachmentListEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

    }
}
