using Dapper;
using Learun.Application.Organization.ReturnModel;
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
    /// 日 期：2022-02-15 10:56
    /// 描 述：笔试题目
    /// </summary>
    public class RQuestionsService : RepositoryFactory
    {
        ReturnCommon _return;
       
           
        #region 构造函数和属性

        private string fieldSql;
        public RQuestionsService()
        {
            fieldSql=@"
                t.F_EnabledMark,
                t.F_CreateUserId,
                t.F_ModifyUserName,
                t.F_ModifyUserId,
                t.F_DeleteMark,
                t.F_SortCode,
                t.F_ModifyDate,
                t.F_CreateUserName,
                t.F_CreateDate,
                t.F_Description,
                t.Questions,
                t.F_ID,
                t.F_QuestionsType,
                t.F_AnswerContent,
                t.F_Answer,
                t.F_Score,
                t.F_QuestionsBankID
            ";
            _return = new ReturnCommon();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_WrittenExaminationQuestionsEntity> GetList( string queryJson )
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
                strSql.Append(" FROM Hy_Recruit_WrittenExaminationQuestions t ");
                return this.BaseRepository().FindList<Hy_Recruit_WrittenExaminationQuestionsEntity>(strSql.ToString());
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
        public IEnumerable<Hy_Recruit_WrittenExaminationQuestionsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Recruit_WrittenExaminationQuestions t ");
                return this.BaseRepository().FindList<Hy_Recruit_WrittenExaminationQuestionsEntity>(strSql.ToString(), pagination);
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
        public Hy_Recruit_WrittenExaminationQuestionsEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionsEntity>(keyValue);
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
                this.BaseRepository().Delete<Hy_Recruit_WrittenExaminationQuestionsEntity>(t=>t.F_ID == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_WrittenExaminationQuestionsEntity entity)
        {
            try
            {
                var isExistItem = this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionsEntity>(t => t.Questions == entity.Questions && t.F_QuestionsBankID == entity.F_QuestionsBankID);
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var isnotnull = this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionsEntity>(t => t.F_ID!=keyValue && t.Questions == entity.Questions  && t.F_QuestionsBankID == entity.F_QuestionsBankID );
                    if (isnotnull == null)
                    {
                        entity.Modify(keyValue);
                        this.BaseRepository().Update(entity);
                        _return.Status = true;
                        _return.Message = "操作成功";
                    }
                    else
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                    }
                }
                else
                {
                    if (isExistItem != null)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";

                    }
                    else
                    {
                        entity.Create();
                        this.BaseRepository().Insert(entity);
                        _return.Status = true;
                        _return.Message = "操作成功";
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
            return _return;
        }

        #endregion

    }
}
