using Dapper;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public class RecruitmentProcessInformationClassService : RepositoryFactory
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
                t.F_HrIndicatesOrderNumber
                ");
                strSql.Append("  FROM SR_RecruitmentProcessNode t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oanum"></param>
        /// <returns></returns>
        public IEnumerable<SR_RecruitmentProcessNodeEntity> GetEntiyCountList(string oanum)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_HrIndicatesOrderNumber
                ");
                strSql.Append("  FROM SR_RecruitmentProcessNode t ");
                strSql.Append("  WHERE 1=1 and  F_OaFlowNumber = '"+ oanum + "' ");
  
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
        /// 获取SR_ProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_ProcessNodeEntity GetSR_ProcessNodeEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("SRDB").FindEntity<SR_ProcessNodeEntity>(t=>t.F_ID == keyValue);
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
        /// 获取SR_ProcessAttachment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_ProcessAttachmentEntity GetSR_ProcessAttachmentEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("SRDB").FindEntity<SR_ProcessAttachmentEntity>(t=>t.F_ID == keyValue);
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
            var db = this.BaseRepository("SRDB").BeginTrans();
            try
            {
                var sR_RecruitmentProcessNodeEntity = GetSR_RecruitmentProcessNodeEntity(keyValue); 
                db.Delete<SR_RecruitmentProcessNodeEntity>(t=>t.F_ID == keyValue);
                db.Delete<SR_ProcessNodeEntity>(t=>t.F_ID == sR_RecruitmentProcessNodeEntity.F_ID);
                db.Delete<SR_ProcessAttachmentEntity>(t=>t.F_ID == sR_RecruitmentProcessNodeEntity.F_ID);
                db.Commit();
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
        public void SaveEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity,SR_ProcessNodeEntity sR_ProcessNodeEntity,SR_ProcessAttachmentEntity sR_ProcessAttachmentEntity)
        {
            var db = this.BaseRepository("SRDB").BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var sR_RecruitmentProcessNodeEntityTmp = GetSR_RecruitmentProcessNodeEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<SR_ProcessNodeEntity>(t=>t.F_ID == sR_RecruitmentProcessNodeEntityTmp.F_ID);
                    sR_ProcessNodeEntity.Create();
                    sR_ProcessNodeEntity.F_ID = sR_RecruitmentProcessNodeEntityTmp.F_ID;
                    db.Insert(sR_ProcessNodeEntity);
                    db.Delete<SR_ProcessAttachmentEntity>(t=>t.F_ID == sR_RecruitmentProcessNodeEntityTmp.F_ID);
                    sR_ProcessAttachmentEntity.Create();
                    sR_ProcessAttachmentEntity.F_ID = sR_RecruitmentProcessNodeEntityTmp.F_ID;
                    db.Insert(sR_ProcessAttachmentEntity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    sR_ProcessNodeEntity.Create();
                    sR_ProcessNodeEntity.F_ID = entity.F_ID;
                    db.Insert(sR_ProcessNodeEntity);
                    sR_ProcessAttachmentEntity.Create();
                    sR_ProcessAttachmentEntity.F_ID = entity.F_ID;
                    db.Insert(sR_ProcessAttachmentEntity);
                }
                db.Commit();
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
        /// <param name="entity"></param>
        /// <param name="sR_ProcessNodeListEntity"></param>
        /// <param name="sR_ProcessAttachmentListEntity"></param>
        public ReturnComment SaveListEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity, List<SR_ProcessNodeEntity> sR_ProcessNodeListEntity, List<SR_ProcessAttachmentEntity> sR_ProcessAttachmentListEntity)
        { 

            ReturnComment rc = new ReturnComment();
            var db = this.BaseRepository("SRDB").BeginTrans();
            try
            {
                db.Insert(entity);
                if (sR_ProcessNodeListEntity.Count > 0)
                {
                    foreach (var sR_ProcessNode in sR_ProcessNodeListEntity)
                    {
                        SR_ProcessNodeEntity sr = new SR_ProcessNodeEntity();
                        sr = sR_ProcessNode;
                        db.Insert(sr);
                    }
                }
          
                if (sR_ProcessAttachmentListEntity.Count > 0)
                {
                    foreach (var sR_ProcessAttachment in sR_ProcessAttachmentListEntity)
                    {
                        SR_ProcessAttachmentEntity srp = new SR_ProcessAttachmentEntity();
                        srp = sR_ProcessAttachment;
                        db.Insert(srp);
                    }
                }
    
                db.Commit();

                rc.State = "S";
                rc.Mes = "社招流程信息插入成功";
            }
            catch (Exception ex)
            {
                db.Rollback();
                rc.State = "F";
                rc.Mes = "报错信息为:" + ex.Message;
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
         
            return rc;
        }

        #endregion

    }
}
