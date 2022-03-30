using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform.WL_BaseService;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.Hy_Recruit_ProcessOperation
{
    public class ProcessOperationInfoService : RepositoryFactory
    {
        #region 获取信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Hy_Recruit_ProcessOperationEntity GetHy_Recruit_ProcessOperationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(keyValue);
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
        public IEnumerable<Hy_Recruit_ProcessOperationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 新增修改删除信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string key, Hy_Recruit_ProcessOperationEntity entity)
        {
            try
            {
                int count = 0;
                ReturnCommon rc = new ReturnCommon();
                if (string.IsNullOrEmpty(key))
                {
                    entity.Create();
                    count = this.BaseRepository().Insert<Hy_Recruit_ProcessOperationEntity>(entity);
                    if (count > 0)
                    {
                        rc.Status = true;
                        rc.Message = "新增流程操作节点成功";
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "新增流程操作节点失败";
                    }
                }
                else
                {
                    entity.Modify(key);
                    count = this.BaseRepository().Update<Hy_Recruit_ProcessOperationEntity>(entity);
                    if (count > 0)
                    {
                        rc.Status = true;
                        rc.Message = "修改流程操作节点成功";
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "修改流程操作节点失败";
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
        /// 删除操作日志
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ReturnCommon DeleteEntity(string userId)
        {
            try
            {
                int count = 0;
                ReturnCommon rc = new ReturnCommon();
                count = this.BaseRepository().Delete<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == userId);
                if (count > 0)
                {
                    rc.Status = true;
                    rc.Message = "删除流程操作节点成功";
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "删除流程操作节点失败";
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
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ReturnCommon SaveNodeInfoEntity(IRepository db, ReturnCommon<OutPutProcessModel> data,string userId, string currentProcessNode, string currentProcessNodeName)
        {
           // var db = this.BaseRepository().BeginTrans();
            try
            {
            
                ReturnCommon rc = new ReturnCommon();
                Hy_Recruit_ProcessOperationEntity entity = this.BaseRepository().FindEntity<Hy_Recruit_ProcessOperationEntity>(t => t.SubProcessId == currentProcessNode && t.CandidatesId == userId);
               
                if (entity != null)
                {
                    if ("自动对比".Equals(currentProcessNodeName))
                    {
                        if (data.Status == false)
                        {
                            //自动对比不通过
                            entity.OperationStatus = 1;
                            entity.OperationTime = DateTime.Now;
                            entity.OperationContent = currentProcessNodeName;
                            db.Update(entity);
                            if (data.Data == null)
                            {
                                //表示已经到最后节点不需要操作

                            }
                            else
                            {
                                Hy_Recruit_ProcessOperationEntity nextEntity = new Hy_Recruit_ProcessOperationEntity();
                                nextEntity.Create();
                                nextEntity.OperationStatus = 0;
                                //跳过人工审核环节
                                nextEntity.SubProcessId = data.Data.NextProcessId  + "";
                                nextEntity.CandidatesId = entity.CandidatesId;
                                db.Insert(nextEntity);
                            }
                        }
                        else
                        {
                            //自动对比通过,直接跳过人工审核,进入笔试节点
                            entity.OperationStatus = 1;
                            entity.OperationTime = DateTime.Now;
                            entity.OperationContent = currentProcessNodeName;
                            db.Update(entity);
                            if (data.Data == null)
                            {
                                //表示已经到最后节点不需要操作
                            }
                            else
                            {
                                //人工审核
                                Hy_Recruit_ProcessOperationEntity nextEntity = new Hy_Recruit_ProcessOperationEntity();
                                nextEntity.Create();
                                nextEntity.OperationStatus = 1;
                                //跳过人工审核环节
                                nextEntity.SubProcessId = data.Data.NextProcessId + "";
                                nextEntity.OperationContent = "人工审核";
                                nextEntity.CandidatesId = entity.CandidatesId;
                                db.Insert(nextEntity);

                                //笔试
                                Hy_Recruit_ProcessOperationEntity nextTowEntity = new Hy_Recruit_ProcessOperationEntity();
                                nextTowEntity.Create();
                                nextTowEntity.OperationStatus = 0;
                                //跳过人工审核环节
                                nextTowEntity.SubProcessId = data.Data.NextProcessId + 1 + "";
                                nextTowEntity.OperationContent = "笔试";
                                nextTowEntity.CandidatesId = entity.CandidatesId;
                                db.Insert(nextTowEntity);
                            }
                        }
                    }
                    else
                    {
                        entity.OperationStatus = 1;
                        entity.OperationTime = DateTime.Now;
                        entity.OperationContent = currentProcessNodeName;
                        db.Update(entity);
                        if (data.Data.NextProcessId == 0)
                        {
                            //表示已经到最后节点不需要操作
                        }
                        else
                        {
                            Hy_Recruit_ProcessOperationEntity nextEntity = new Hy_Recruit_ProcessOperationEntity();
                            nextEntity.Create();
                            nextEntity.OperationStatus = 0;
                            nextEntity.SubProcessId = data.Data.NextProcessId + "";
                            nextEntity.OperationContent = data.Data.NextProcessName;
                            nextEntity.CandidatesId = entity.CandidatesId;
                            db.Insert(nextEntity);
                        }
                    }
                 
                    rc.Status = true;
                    rc.Message = "流程操作信息更新成功,下一节点信息生成";
                }
                else 
                {
                    if (currentProcessNode == "1")
                    {
                        Hy_Recruit_ProcessOperationEntity nextEntity = new Hy_Recruit_ProcessOperationEntity();
                        nextEntity.Create();
                        nextEntity.SubProcessId = "1";
                        nextEntity.OperationStatus = 1;
                        nextEntity.OperationContent = "应聘者注册";
                        nextEntity.CandidatesId = userId;
                        db.Insert(nextEntity);

                        Hy_Recruit_ProcessOperationEntity NnextEntity = new Hy_Recruit_ProcessOperationEntity();
                        NnextEntity.Create();
                        NnextEntity.SubProcessId = "2";
                        NnextEntity.OperationStatus = 1;
                        NnextEntity.OperationContent = "应聘信息完善";
                        NnextEntity.CandidatesId = userId;
                        db.Insert(NnextEntity);

                        Hy_Recruit_ProcessOperationEntity NextEntity = new Hy_Recruit_ProcessOperationEntity();
                        NextEntity.Create();
                        NextEntity.SubProcessId = "3";
                        NextEntity.OperationStatus = 0;
                        NextEntity.OperationContent = "自动对比";
                        NextEntity.CandidatesId = userId;
                        db.Insert(NextEntity);

                        rc.Status = true;
                        rc.Message = "流程操作信息更新成功";
                    }
                    else { 
                        rc.Status = false;
                        rc.Message = "未查到流程节点操作表信息,不能记录信息";
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
        #endregion
    }
}
