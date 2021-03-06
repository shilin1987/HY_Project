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
    /// 日 期：2022-01-28 09:22
    /// 描 述：作业员笔试题库
    /// </summary>
    public class RecruitExaminationQuestionBankService : RepositoryFactory
    {
        ReturnCommon _return;
        public RecruitExaminationQuestionBankService()
        {
            _return = new ReturnCommon();
        }
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_WrittenExaminationQuestionBankEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Id,
                t.F_TestPaperName,
                t.F_Description,
                t.F_MinimumScore,
                t.F_CreateDate,
                t.F_ModifyUserName
                ");
                strSql.Append("  FROM Hy_Recruit_WrittenExaminationQuestionBank t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_TestPaperName"].IsEmpty())
                {
                    dp.Add("F_TestPaperName", "%" + queryParam["F_TestPaperName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TestPaperName Like @F_TestPaperName ");
                }
                if (!queryParam["F_Description"].IsEmpty())
                {
                    dp.Add("F_Description", "%" + queryParam["F_Description"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Description Like @F_Description ");
                }
                return this.BaseRepository().FindList<Hy_Recruit_WrittenExaminationQuestionBankEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Hy_Recruit_WrittenExaminationQuestionBank表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_WrittenExaminationQuestionBankEntity GetHy_Recruit_WrittenExaminationQuestionBankEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionBankEntity>(keyValue);
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
                this.BaseRepository().Delete<Hy_Recruit_WrittenExaminationQuestionBankEntity>(t=>t.F_Id == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_WrittenExaminationQuestionBankEntity entity)
        {
            try
            {
                var isExistItem = this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionBankEntity>(t => t.F_TestPaperName == entity.F_TestPaperName);
               
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var isnotnull = this.BaseRepository().FindEntity<Hy_Recruit_WrittenExaminationQuestionBankEntity>(t => t.F_TestPaperName == entity.F_TestPaperName && t.F_Id!=keyValue);
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
                    else { 
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
