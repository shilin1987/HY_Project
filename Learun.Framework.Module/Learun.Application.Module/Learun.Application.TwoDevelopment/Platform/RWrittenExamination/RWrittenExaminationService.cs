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
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-31 10:54
    /// 描 述：RWrittenExamination
    /// </summary>
    public class RWrittenExaminationService : RepositoryFactory
    {
        ReturnCommon _return;
        #region 构造函数和属性

        private string fieldSql;
        public RWrittenExaminationService()
        {
            fieldSql= @"
                t.F_UserId,
                p.OperationTime,
                p.Operator,
                t.F_CreateUserName,
                t.F_CreateDate,
                t.F_Description,
                t.F_RealName,
                t.F_IDCard,
                t.F_Gender,
                t.F_Mobile ,
                t.F_Education,
                p.OperationStatus,
                w.F_WrittenTestQuestionBankId
            ";
            _return = new ReturnCommon();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_WrittenExaminationEntity> GetList( string queryJson )
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
                strSql.Append(" FROM Hy_Recruit_WrittenExamination t ");
                return this.BaseRepository().FindList<Hy_Recruit_WrittenExaminationEntity>(strSql.ToString());
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
        public IEnumerable<WrittenExaminationEntityDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" from  dbo.Hy_Recruit_Candidates  t left join dbo.Hy_Recruit_ProcessOperation p   on t.F_UserId = p.CandidatesId  LEFT join  dbo.Hy_Recruit_WrittenExamination w on t.F_UserId = w.F_CandidatesID ");
                strSql.Append(" where  p.OperationContent='笔试' ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", "%" + queryParam["F_RealName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_RealName ");
                }
                //if (!queryParam["F_Score"].IsEmpty())
                //{
                //    int F_Score;
                //    if (queryParam["F_Score"].ToString() == "通过") { F_Score = 80; dp.Add("F_Score", F_Score, DbType.String);
                //        strSql.Append(" AND t.F_Score >= @F_Score ");
                //    } else { F_Score = 70;
                //        dp.Add("F_Score", F_Score, DbType.String);
                //        strSql.Append(" AND t.F_Score < @F_Score ");
                //    }

                //}
                if (!queryParam["F_IDCard"].IsEmpty())
                {
                    dp.Add("F_IDCard", "%" + queryParam["F_IDCard"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IDCard like @F_IDCard ");
                }
                return this.BaseRepository().FindList<WrittenExaminationEntityDTO>(strSql.ToString(),dp, pagination);
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
        public Hy_Recruit_WrittenExaminationEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationEntity>(keyValue);
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
              var isDel=  this.BaseRepository().Delete<Hy_Recruit_WrittenExaminationEntity>(t=>t.F_Id == keyValue);
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
        public ReturnCommon ResetInfo(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var Sql = new StringBuilder();
                Sql.Append("update Hy_Recruit_ProcessOperation set OperationStatus=0 ");
                Sql.Append(" where CandidatesId='"+keyValue+"'");
                Sql.Append("and OperationContent = '笔试'");
                var i = this.BaseRepository().ExecuteBySql(Sql.ToString());
                if (i > 0)
                {
                    //var strSql = new StringBuilder();
                    //strSql.Append("Update ");
                    //strSql.Append("  Hy_Recruit_WrittenExamination  set f_score = NULL ");
                    //strSql.Append(" where f_id='"+keyValue+"'");
                    //var isDel = this.BaseRepository().ExecuteBySql(strSql.ToString());

                    //if (isDel > 0)
                    //{
                        _return.Status = true;
                        _return.Message = "操作成功";
                    //}
                    //else
                    //{
                        //_return.Status = false;
                        //_return.Message = "操作失败";
                    //}
                    
                }
                else {
                    _return.Status = true;
                    _return.Message = "该员工信息不能重置";
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
            return _return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnCommon NodeSaveEntity(IRepository db, string keyValue, Hy_Recruit_WrittenExaminationEntity entity)
        {

            ReturnCommon rc = new ReturnCommon();
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    Hy_Recruit_WrittenExaminationEntity entityModel = this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationEntity>(t => t.F_IDCard == entity.F_IDCard);
                    if (entityModel == null)
                    {
                        db.Insert(entity);
                        rc.Status = true;
                        rc.Message = "身份验证成功,生成笔试流程节点";
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "身份验证失败,笔试流程节点失败";
                    }
                  
                }
                return rc;
            }
            catch (Exception ex)
            {
                rc.Status = false;
                rc.Message = "生成面试流程节点数据失败";
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
        public ReturnCommon SaveEntity(string keyValue, WrittenExaminationEntityDTO entity)
        {
            var db = this.BaseRepository().BeginTrans();
            ReturnCommon rc = new ReturnCommon();
            try
            {
                var mianshi =this.BaseRepository().FindList<Hy_Recruit_ProcessOperationEntity>(t => t.CandidatesId == keyValue);
                Hy_Recruit_WrittenExaminationEntity ie = new Hy_Recruit_WrittenExaminationEntity();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    UserInfo userInfo = LoginUserInfo.Get();
                    if (entity.OperationStatus == 0)
                    {
                        var sql = @"update dbo.Hy_Recruit_ProcessOperation  set OperationStatus=-1 ,OperationTime='" + DateTime.Now.ToString() + "',Operator='" + userInfo.userId + "' where CandidatesId='" + keyValue + "' and OperationContent='笔试' ";
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
                        var sql = @"update dbo.Hy_Recruit_ProcessOperation  set OperationStatus=1 ,OperationTime='" + DateTime.Now.ToString() + "',Operator='" + userInfo.userId + "' where CandidatesId='" + keyValue + "' and OperationContent='笔试' ";
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
                    ie.F_CandidatesID = keyValue;
                    ie.F_CreateDate = DateTime.Now;
                    ie.F_CreateUserName = entity.Operator;
                    ie.F_WrittenTestQuestionBankId = entity.F_WrittenTestQuestionBankId;
                    WrittenExaminationEntity(keyValue,ie);
                    if (mianshi.Count() < 6)
                    {
                        //写流程状态表
                        BaseService bsService = new BaseService();
                        Hy_Recruit_SubProcessEntity hsEntity = bsService.getHy_Recruit_SubProcessEntity("笔试");
                        var data = bsService.GetProcessInfo(hsEntity.ID);
                        ProcessOperationInfoIBLL poBLL = new ProcessOperationInfoBLL();
                        rc = poBLL.SaveNodeInfoEntity(db, data, keyValue, hsEntity.ID, hsEntity.Name);

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
        public ReturnCommon WrittenExaminationEntity(string keyValue, Hy_Recruit_WrittenExaminationEntity Wentity)
        {
            try
            {
                var isy = this.BaseRepository().FindList<Hy_Recruit_WrittenExaminationEntity>(t => t.F_CandidatesID == keyValue);
                if (isy.Count() == 0)
                {
                    Wentity.Create();
                    this.BaseRepository().Insert(Wentity);
                    _return.Status = true;
                    _return.Message = "操作成功";
                }
                else 
                {
                    Wentity.Modify(isy.First().F_Id);
                    this.BaseRepository().Update(Wentity);
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
