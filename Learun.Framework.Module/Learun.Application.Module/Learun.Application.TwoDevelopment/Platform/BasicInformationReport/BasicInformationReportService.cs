﻿using Dapper;
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
    /// 日 期：2022-02-23 14:41
    /// 描 述：应聘者基础信息报表
    /// </summary>
    public class BasicInformationReportService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public BasicInformationReportService()
        {
            fieldSql= @"
                t.F_UserId,
                t.F_RealName,
                t.F_Mobile,
                t.F_IDCard,
                t.F_RecruitmentChannels,
                t.F_Education,
                t.F_DocumentType,
                t.F_NationAlity,
                t.F_Nation,
                t.F_RRNature,
                t.F_NativePlace,
                t.F_IDCardStartDate,
                t.F_IDCardEndDate,
                t.F_OneCardNumber,
                t.F_EntryChannel,
                t.F_InternalCode,
                t.F_InternalName,
                t.F_InternalCompany,
                t.F_LaborRecruitmentDate,
                t.F_RecruitmentCompany,
                t.F_IDCardAddress,
                t.F_ExpectedentryDate,
                t.F_PWD,
                t.F_Gender,
                t.F_Dormitory,
                t.F_HeadIcon,
                t.F_EnCode,
                t.F_DepartmentNmae,
                t.F_Entrydate,
                t.F_MaritalStatus,
                t.F_Birthday,
                t.F_ResidentialAddress,
                t.F_CurrentAddress,
                t.F_PostName,
                t.F_EducationStartDate,
                t.F_EducationEndDate,
                t.F_GraduationUniversitie,
                t.F_MajorStudied,
                t.F_ForeignLanguageLevel,
                t.F_BankDeposit,
                t.F_BankCardNumber,
                t.F_PoliticalOutlook,
                t.F_EmergencyContact,
                t.F_EContactRelationship,
                t.F_EContactNumber,
                t.F_OneWorkexperience,
                t.F_TwoWorkexperience,
                i.F_CreateUserName 
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<CandidatesEntity> GetList( string queryJson )
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
                strSql.Append(" FROM Hy_Recruit_Candidates t left  join dbo.Hy_Recruit_Interview i  on  t.f_userid=i.F_CandidatesID");
                return this.BaseRepository().FindList<CandidatesEntity>(strSql.ToString());
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
        public IEnumerable<CandidatesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Recruit_Candidates t  left  join dbo.Hy_Recruit_Interview i  on  t.f_userid=i.F_CandidatesID");
                if (!queryParam["SubProcessId"].IsEmpty())
                {
                    strSql.Append(" left  join dbo.Hy_Recruit_ProcessOperation p on t.F_UserId=p.CandidatesId");
                }
                strSql.Append(" where 1=1");
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
                if (!queryParam["SubProcessId"].IsEmpty())
                {
                    dp.Add("SubProcessId", queryParam["SubProcessId"].ToString(), DbType.String);
                    strSql.Append(" AND p.SubProcessId = @SubProcessId and p.OperationStatus=1 ");

                    if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                    {
                        dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                        dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                        strSql.Append(" AND ( p.OperationTime >= @startTime AND p.OperationTime <= @endTime ) ");
                    }
                }
                else 
                {
                    if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                    {
                        dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                        dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                        strSql.Append(" AND (t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                    }
                }
                //if (!queryParam["F_InternalCompany"].IsEmpty())
                //{
                //    dp.Add("F_InternalCompany", "%" + queryParam["F_InternalCompany"].ToString() + "%", DbType.String);
                //    strSql.Append(" AND t.F_InternalCompany Like @F_InternalCompany ");
                //}
                //if (!queryParam["F_RecruitmentCompany"].IsEmpty())
                //{
                //    dp.Add("F_RecruitmentCompany", "%" + queryParam["F_RecruitmentCompany"].ToString() + "%", DbType.String);
                //    strSql.Append(" AND t.F_RecruitmentCompany Like @F_RecruitmentCompany ");
                //}
                return this.BaseRepository().FindList<CandidatesEntity>(strSql.ToString(),dp,pagination);
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
        public CandidatesEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<CandidatesEntity>(keyValue);
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
                this.BaseRepository().Delete<CandidatesEntity>(t=>t.F_UserId == keyValue);
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
        public void SaveEntity(string keyValue, CandidatesEntity entity)
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
