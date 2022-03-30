using Dapper;
using Learun.Application.TwoDevelopment.ReturnModel;
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
    /// 日 期：2022-01-13 09:14
    /// 描 述：面试题库
    /// </summary>
    public class RecruitInterviewQuestionBankService : RepositoryFactory
    {
        #region 构造函数和属性
        ReturnCommon _return;
        private string fieldSql;
        public RecruitInterviewQuestionBankService()
        {
            fieldSql= @"
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
                t.F_ID,
                t.F_Question,
                t.F_Answer,
                t.F_Fraction
            ";
            _return = new ReturnCommon();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_InterviewQuestionBankEntity> GetList( string queryJson )
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
                strSql.Append(" FROM Hy_Recruit_InterviewQuestionBank t ");
                return this.BaseRepository().FindList<Hy_Recruit_InterviewQuestionBankEntity>(strSql.ToString());
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
        public IEnumerable<Hy_Recruit_InterviewQuestionBankEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Recruit_InterviewQuestionBank t ");
                strSql.Append("  WHERE 1=1  ");
                var dp = new DynamicParameters(new { });
                if (!queryParam["keyword"].IsEmpty())
                {
                    dp.Add("F_Question", "%" + queryParam["keyword"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Question Like @F_Question ");
                }
                return this.BaseRepository().FindList<Hy_Recruit_InterviewQuestionBankEntity>(strSql.ToString(),dp, pagination);
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
        public Hy_Recruit_InterviewQuestionBankEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_InterviewQuestionBankEntity>(keyValue);
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
              var  isDel=this.BaseRepository().Delete<Hy_Recruit_InterviewQuestionBankEntity>(t=>t.F_ID == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_InterviewQuestionBankEntity entity)
        {
            try
            {
                if (Convert.ToInt32(entity.F_Fraction) < 0 || Convert.ToInt32(entity.F_Fraction) > 100)
                {
                    _return.Status = false;
                    _return.Message = "分数规则不正确";
                    return _return;
                }

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
                _return.Status = true;
                _return.Message = "操作成功";
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
