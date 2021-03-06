using Learun.Application.Base.SystemModule;
using Learun.Application.Organization.ReturnModel;
using Learun.Application.Organization.User;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;

namespace Learun.Application.Organization
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.04
    /// 描 述：用户模块数据操作服务类
    /// </summary>
    public class UserService : RepositoryFactory
    {
        #region 属性 构造函数
        private string fieldSql;
        public UserService()
        {
            fieldSql = @" 
                      t.[F_UserId]
                      ,t.[F_EnCode]
                      ,t.[F_Account]
                      ,t.[F_Password]
                      ,t.[F_Secretkey]
                      ,t.[F_RealName]
                      ,t.[F_NickName]
                      ,t.[F_HeadIcon]
                      ,t.[F_QuickQuery]
                      ,t.[F_SimpleSpelling]
                      ,t.[F_Gender]
                      ,CONVERT(varchar(12) , t.[F_Birthday], 111 ) as F_Birthday
                      ,t.[F_Mobile]
                      ,t.[F_Telephone]
                      ,t.[F_Email]
                      ,t.[F_OICQ]
                      ,t.[F_WeChat]
                      ,t.[F_MSN]
                      ,t.[F_CompanyId]
                      ,t.[F_DepartmentId]
                      ,t.[F_SecurityLevel]
                      ,t.[F_OpenId]
                      ,t.[F_Question]
                      ,t.[F_AnswerQuestion]
                      ,t.[F_CheckOnLine]
                      ,CONVERT(varchar(12) , t.[F_AllowStartTime], 111 ) as F_AllowStartTime
                      ,CONVERT(varchar(12) , t.[F_AllowEndTime], 111 ) as F_AllowEndTime
                      ,CONVERT(varchar(12) , t.[F_LockStartDate], 111 ) as F_LockStartDate
                      ,CONVERT(varchar(12) , t.[F_LockEndDate], 111 ) as F_LockEndDate
                      ,t.[F_SortCode]
                      ,t.[F_DeleteMark]
                      ,t.[F_EnabledMark]
                      ,t.[F_Description]
                      ,CONVERT(varchar(12) , t.[F_CreateDate], 111 ) as F_CreateDate
                      ,t.[F_CreateUserId]
                      ,t.[F_CreateUserName]
                      ,CONVERT(varchar(12) , t.[F_ModifyDate], 111 ) as F_ModifyDate
                      ,t.[F_ModifyUserId]
                      ,t.[F_ModifyUserName]
                      ,t.[F_IDCard]
                      ,t.[F_PrimaryOrganization]
                      ,isnull(t.[F_SecondaryOrganization],'') F_SecondaryOrganization
                      ,isnull(t.[F_TertiaryOrganization],'') F_TertiaryOrganization
                      ,isnull(t.[F_FourLevelOrganization],'') F_FourLevelOrganization
                      ,isnull(t.[F_FiveLevelOrganization],'') F_FiveLevelOrganization
                      ,isnull(t.[F_SixLevelOrganization],'') F_SixLevelOrganization
                      ,t.[F_RecruitmentChannels]
                      ,CONVERT(varchar(12) , t.[F_Entrydate], 111 ) as F_Entrydate
                      ,CONVERT(varchar(12) , t.[F_ConfirmationDate], 111 ) as F_ConfirmationDate 
                      ,CONVERT(varchar(12) , t.[F_DepartureDate], 111 ) as F_DepartureDate
                      ,t.[F_Education]
                      ,t.[F_SalaryMethod]
                      ,t.[F_PayModel]
                      ,t.[F_WorkingSystem]
                      ,t.[F_BankCardNumber]
                      ,t.[F_BankDeposit]
                      ,CONVERT(varchar(12) , t.[F_DateHoldingPost], 111 ) as F_DateHoldingPost 
                      ,t.[F_IsTrainingAgreement]
                      ,CONVERT(varchar(12) , t.[F_StartDateService], 111 ) as F_StartDateService
                      ,CONVERT(varchar(12) , t.[F_EndDateService], 111 ) as F_EndDateService
                      ,t.[F_EmployeeNature]
                      ,CONVERT(varchar(12) , t.[F_EmployeeNatureChangeDate], 111 ) as F_EmployeeNatureChangeDate
                      ,t.[F_PieceworkType]
                      ,t.[F_TimeBecomeRegular]
                      ,t.[F_TimeShiftWorkSystem]
                      ,t.[F_TypesResignation]
                      ,t.[F_MakeUpTime]
                      ,t.[F_PostId]
                      ,t.[F_SalaryCalculation]
                      ,t.[F_Age]
                      ,t.[F_DocumentType]
                      ,t.[F_NationAlity]
                      ,t.[F_Nation]
                      ,t.[F_RRNature]
                      ,t.[F_PoliticalOutlook]
                      ,t.[F_MaritalStatus]
                      ,t.[F_NativePlace]
                      ,isnull(t.[F_OnJobStatus],'') OnJobStatus
                      ,CONVERT(varchar(12) , t.[F_IDCardStartDate], 111 ) AS F_IDCardStartDate
                      ,CONVERT(varchar(12) , t.[F_IDCardEndDate], 111 ) AS F_IDCardEndDate
                      ,isnull(t.[F_OneCardNumber],'') F_OneCardNumber
                      ,t.[F_SalaryStructureType]
                      ,t.[F_SalaryType]
                      ,t.[F_PersonnelCategory]
                      ,CONVERT(varchar(12) , t.[F_JoiningGroupDate], 111 ) AS F_JoiningGroupDate
                      ,t.[F_EntryChannel]
                      ,CONVERT(varchar(12) , t.[F_OfflineDate], 111 ) AS F_OfflineDate
                      ,t.[F_InternalCode]
                      ,t.[F_InternalName]
                      ,t.[F_InternalCompany]
                      ,CONVERT(varchar(12) , t.[F_LaborRecruitmentDate], 111 ) AS F_LaborRecruitmentDate
                      ,t.[F_RecruitmentCompany]
                      ,t.[F_GraduationUniversitie]
                      ,t.[F_MajorStudied]
                      ,CONVERT(varchar(12) , t.[F_EducationStartDate], 111 ) AS F_EducationStartDate
                      ,CONVERT(varchar(12) , t.[F_EducationEndDate], 111 ) AS F_EducationEndDate
                      ,t.[F_EducationalMode]
                      ,t.[F_ForeignLanguageLevel]
                      ,t.[F_IsQualified]
                      ,t.[F_QualificationName]
                      ,t.[F_GetTime]
                      ,t.[F_InternalTitleType]
                      ,t.[F_InternalTitle]
                      ,CONVERT(varchar(12) , t.[F_InternalTitleDate], 111 ) AS F_InternalTitleDate
                      ,t.[F_SocialTitleType]
                      ,t.[F_SocialTitle]
                      ,CONVERT(varchar(12) , t.[F_SocialTitleDate], 111 ) AS  F_SocialTitleDate
                      ,t.[F_IDCardAddress]
                      ,t.[F_PermanentAddress]
                      ,t.[F_ResidentialAddress]
                      ,t.[F_CurrentAddress]
                      ,t.[F_EmergencyContact]
                      ,t.[F_EContactRelationship]
                      ,t.[F_EContactNumber]
                      ,t.[F_ContactAddress]
                      ,CONVERT(varchar(12) ,t.[F_laborContractStartDate], 111 ) AS F_laborContractStartDate
                      ,CONVERT(varchar(12) , t.[F_laborContractEndDate], 111 ) AS F_laborContractEndDate
                      ,t.[F_LaborContractStatus]
                      ,CONVERT(varchar(12) , t.[F_AttendanceDeadline], 111 ) AS F_AttendanceDeadline
                      ,t.[F_IsEsignationCertificate]
                      ,t.[F_Depreciation]
                      ,d.F_FullName department
                      ,case when t.[F_DepartureDate] is null then '在职' else (case when t.[F_DepartureDate]='1900-01-01 00:00:00' then '在职' else '离职'  end) end userState
                      ,case t.F_FourLevelOrganization when '无' then (case t.F_TertiaryOrganization 
                       when '无' then t.F_SecondaryOrganization else t.F_TertiaryOrganization end) 
					   else t.F_FourLevelOrganization end minDepartment";
        }

        public IEnumerable<DataSourDTO> GetFiledList()
        {
            try
            {
                DataSourceEntity entity = this.BaseRepository().FindEntity<DataSourceEntity>(e => e.F_Code == "importuser");
                if (entity != null)
                {
                    string strSql = entity.F_Sql;

                    //可以根据 entity.F_DbId查找数据库信息传入信息值
                    string dbName = this.BaseRepository().FindEntity<DatabaseLinkEntity>(e => e.F_DatabaseLinkId == entity.F_DbId).F_DBName;

                    return this.BaseRepository().FindList<DataSourDTO>(strSql.ToString());

                }
                else
                {
                    return null;
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
        /// 获取导出excel的数据
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<UserEntityDTO> GetModelPageList(string companyId, string departmentId, Pagination pagination, string keyword, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND (t.F_TypesResignation=''  or t.F_TypesResignation is null)  and (t.F_CompanyId=@companyId or F_PrimaryOrganization=@companyId or F_SecondaryOrganization = @companyId or F_TertiaryOrganization = @companyId or F_FourLevelOrganization = @companyId)");

                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(companyId))
                {
                    dp.Add("companyId", companyId, DbType.String);
                }
                if (!queryParam["F_Account"].IsEmpty())
                {
                    dp.Add("F_Account", "%" + queryParam["F_Account"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Account Like @F_Account ");
                }
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", "%" + queryParam["F_RealName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_RealName ");
                }
                if (!queryParam["F_UserState"].IsEmpty())
                {
                    dp.Add("F_UserState", "%" + queryParam["F_UserState"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserState Like @F_UserState ");
                }
                if (!queryParam["F_OnJobStatus"].IsEmpty())
                {
                    dp.Add("F_OnJobStatus", "%" + queryParam["F_OnJobStatus"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OnJobStatus Like @F_OnJobStatus ");
                }
                if (!string.IsNullOrEmpty(departmentId))
                {
                    dp.Add("departmentId", departmentId, DbType.String);
                    strSql.Append(" AND t.F_SecondaryOrganization = @departmentId ");
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    dp.Add("F_UserState", "%" + keyword + "%", DbType.String);
                    strSql.Append(" AND( t.F_Account like @keyword or t.F_RealName like @keyword  or t.F_Mobile like @keyword  ) ");
                }
                var userModel = this.BaseRepository().FindList<UserEntity>(strSql.ToString(), dp, pagination);
                var departmentModel = this.BaseRepository().FindList<DepartmentEntity>("select * from lr_base_department");
                var newUserModel = from u in userModel
                                   select new UserEntityDTO
                                   {
                                       F_UserId = u.F_EnCode,
                                       F_EnCode = u.F_EnCode,
                                       F_Account = u.F_Account,
                                       F_RealName = u.F_RealName,
                                       F_Age = u.F_Age,
                                       F_Gender = u.F_Gender == 1 ? "男" : "女",
                                       F_DocumentType = u.F_DocumentType,
                                       F_IDCard = u.F_IDCard,
                                       F_Birthday = u.F_Birthday,
                                       F_NationAlity = u.F_NationAlity,
                                       F_Nation = u.F_Nation,
                                       F_RRNature = u.F_RRNature,
                                       F_Mobile = u.F_Mobile,
                                       F_PoliticalOutlook = u.F_PoliticalOutlook,
                                       F_MaritalStatus = u.F_MaritalStatus,
                                       F_NativePlace = u.F_NativePlace,
                                       F_UserState = u.F_UserState,
                                       F_OnJobStatus = u.F_OnJobStatus,
                                       F_IDCardStartDate = u.F_IDCardStartDate,
                                       F_IDCardEndDate = u.F_IDCardEndDate,
                                       F_BankDeposit = u.F_BankDeposit,
                                       F_BankCardNumber = u.F_BankCardNumber,
                                       F_OneCardNumber = u.F_OneCardNumber,
                                       F_SecondaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_TertiaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_FourLevelOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).FirstOrDefault().F_FullName : "",
                                       F_FiveLevelOrganization = u.F_FiveLevelOrganization,
                                       F_SixLevelOrganization = u.F_SixLevelOrganization,
                                       F_PostId = u.F_PostId,
                                       F_DateHoldingPost = u.F_DateHoldingPost,
                                       F_WorkingSystem = u.F_WorkingSystem,
                                       F_SalaryStructureType = u.F_SalaryStructureType,
                                       F_SalaryMethod = u.F_SalaryMethod,
                                       F_PayModel = u.F_PayModel,
                                       F_SalaryType = u.F_SalaryType,
                                       F_PersonnelCategory = u.F_PersonnelCategory,
                                       F_Entrydate = u.F_Entrydate,
                                       F_JoiningGroupDate = u.F_JoiningGroupDate,
                                       F_EntryChannel = u.F_EntryChannel,
                                       F_OfflineDate = u.F_OfflineDate,
                                       F_ConfirmationDate = u.F_ConfirmationDate,
                                       F_InternalCode = u.F_InternalCode,
                                       F_InternalName = u.F_InternalName,
                                       F_InternalCompany = u.F_InternalCompany,
                                       F_LaborRecruitmentDate = u.F_LaborRecruitmentDate,
                                       F_RecruitmentCompany = u.F_RecruitmentCompany,
                                       F_Education = u.F_Education,
                                       F_GraduationUniversitie = u.F_GraduationUniversitie,
                                       F_MajorStudied = u.F_MajorStudied,
                                       F_EducationStartDate = u.F_EducationStartDate,
                                       F_EducationEndDate = u.F_EducationEndDate,
                                       F_EducationalMode = u.F_EducationalMode,
                                       F_ForeignLanguageLevel = u.F_ForeignLanguageLevel,
                                       F_IsQualified = u.F_IsQualified == 0 ? "否" : "是",
                                       F_QualificationName = u.F_QualificationName,
                                       F_GetTime = u.F_GetTime,
                                       F_IDCardAddress = u.F_IDCardAddress,
                                       F_PermanentAddress = u.F_PermanentAddress,
                                       F_ResidentialAddress = u.F_ResidentialAddress,
                                       F_CurrentAddress = u.F_CurrentAddress,
                                       F_EmergencyContact = u.F_EmergencyContact,
                                       F_EContactRelationship = u.F_EContactRelationship,
                                       F_EContactNumber = u.F_EContactNumber,
                                       F_ContactAddress = u.F_ContactAddress,
                                       F_laborContractStartDate = u.F_laborContractStartDate,
                                       F_laborContractEndDate = u.F_laborContractEndDate,
                                       F_LaborContractStatus = u.F_LaborContractStatus,
                                       F_IsTrainingAgreement = u.F_IsTrainingAgreement == 0 ? "否" : "是",
                                       F_StartDateService = u.F_StartDateService,
                                       F_EndDateService = u.F_EndDateService,
                                       F_DepartureDate = u.F_DepartureDate,
                                       F_AttendanceDeadline = u.F_AttendanceDeadline,
                                       F_TypesResignation = u.F_TypesResignation,
                                       F_IsEsignationCertificate = u.F_IsEsignationCertificate,
                                       F_Depreciation = u.F_Depreciation,
                                   };
                return newUserModel;
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

        #region 获取数据
        /// <summary>
        /// 获取实体,通过用户账号
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        public UserEntity GetEntityByAccount(string account)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId");
                strSql.Append(" WHERE t.F_Account = @account AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null)  and (t.F_TypesResignation=''  or t.F_TypesResignation is null)");
                var userModel = this.BaseRepository().FindEntity<UserEntity>(strSql.ToString(), new { account = account });
                if (userModel != null)
                {
                    if (userModel.minDepartment != null)
                    {
                        userModel.minDepartment = this.BaseRepository().FindEntity<DepartmentEntity>(e => e.F_DepartmentId == userModel.minDepartment).F_FullName;
                    }
                }

                return userModel;
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
        /// 获取实体,通过手机用户账号
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        public ReturnCommon<UserEntity> GetEntityByPhone(string phone)
        {
            var msg = new ReturnCommon<UserEntity>();
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_Base_User t ");
                strSql.Append(" WHERE t.F_Mobile = @mobile AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null)  and (t.F_TypesResignation=''  or t.F_TypesResignation is null)");
                msg.Data = this.BaseRepository().FindEntity<UserEntity>(strSql.ToString(), new { mobile = phone });
                msg.Status = true;
            }
            catch (Exception ex)
            {
                msg.Status = false;
                msg.Message = ex.Message;
            }

            return msg;
        }

        /// <summary>
        /// 获取实体,通过用户ID
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        public ReturnCommon<UserEntity> GetEntityByuserId(string userId)
        {
            var msg = new ReturnCommon<UserEntity>();
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_Base_User t ");
                strSql.Append(" WHERE t.F_UserId = @userId AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null)  and (t.F_TypesResignation=''  or t.F_TypesResignation is null)");
                msg.Data = this.BaseRepository().FindEntity<UserEntity>(strSql.ToString(), new { userId = userId });
                msg.Status = true;
            }
            catch (Exception ex)
            {
                msg.Status = false;
                msg.Message = ex.Message;
            }

            return msg;
        }

        /// <summary>
        /// 用户列表(根据公司主键)
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetList(string companyId)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) and (t.F_TypesResignation=''  or t.F_TypesResignation is null)  AND t.F_PrimaryOrganization = @companyId ORDER BY t.F_DepartmentId,t.F_RealName ");
                return this.BaseRepository().FindList<UserEntity>(strSql.ToString(), new { companyId = companyId });
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
        /// 用户列表(根据部门主键)
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetListDepartmentId(string departmentId)
        {
            try
            {
                var strSql = new StringBuilder();
                var sql = "select F_FullName from  lr_base_department where F_ParentId='" + departmentId + "'";
                var list = this.BaseRepository().FindList<DepartmentEntity>(sql);
                List<String> listname = new List<string>();
                List<String> namelist = new List<string>();
                foreach (var item in list)
                {
                    listname.Add(item.F_FullName);
                }
                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                if (listname.Count > 0)
                {
                    int i = 1;
                    strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND (t.F_TypesResignation=''  or t.F_TypesResignation is null)  and ");
                    foreach (var item in listname)
                    {
                        strSql.Append("F_TertiaryOrganization='" + item.ToString() + "' or F_FourLevelOrganization = '" + item.ToString() + "'");
                        if (i < listname.Count)
                        {
                            strSql.Append(" or ");
                        }
                        i++;
                    }
                }
                else
                {
                    strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND  (t.F_TypesResignation=''  or t.F_TypesResignation is null)  and ");
                    string sql1 = "select f_fullname from lr_base_department where F_DepartmentId ='" + departmentId + "'";
                    var list1 = this.BaseRepository().FindList<DepartmentEntity>(sql1);
                    int a = 1;
                    foreach (var item in list1)
                    {
                        namelist.Add(item.F_FullName);
                    }
                    foreach (var item in namelist)
                    {
                        strSql.Append("F_TertiaryOrganization='" + item.ToString() + "' or F_FourLevelOrganization = '" + item.ToString() + "'");
                        if (a < listname.Count)
                        {
                            strSql.Append(" or ");
                        }
                        a++;
                    }
                }
                if (listname.Count > 0 || namelist.Count > 0)
                { strSql.Append("  or  F_PrimaryOrganization=@departmentId  or F_SecondaryOrganization=@departmentId "); }
                else
                { strSql.Append(" F_PrimaryOrganization=@departmentId  or F_SecondaryOrganization=@departmentId "); }

                return this.BaseRepository().FindList<UserEntity>(strSql.ToString(), new { departmentId = departmentId });
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
        /// 用户列表(根据公司主键)(分页)
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(string companyId, string departmentId, Pagination pagination, string keyword)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND (t.F_TypesResignation=''  or t.F_TypesResignation is null)  and (t.F_CompanyId=@companyId or F_PrimaryOrganization=@companyId or F_SecondaryOrganization = @companyId or F_TertiaryOrganization = @companyId or F_FourLevelOrganization = @companyId)");

                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(companyId))
                {
                    dp.Add("companyId", companyId, DbType.String);
                }
                if (!string.IsNullOrEmpty(departmentId))
                {
                    dp.Add("departmentId", departmentId, DbType.String);
                    strSql.Append(" AND t.F_SecondaryOrganization = @departmentId ");
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    dp.Add("F_UserState", "%" + keyword + "%", DbType.String);
                    strSql.Append(" AND( t.F_Account like @keyword or t.F_RealName like @keyword  or t.F_Mobile like @keyword  ) ");
                }
                return this.BaseRepository().FindList<UserEntity>(strSql.ToString(), dp, pagination);
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
        /// 用户列表(根据公司主键)(分页)
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(string companyId, string departmentId, Pagination pagination, string keyword, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND (t.F_TypesResignation=''  or t.F_TypesResignation is null)  and (t.F_CompanyId=@companyId or F_PrimaryOrganization=@companyId or F_SecondaryOrganization = @companyId or F_TertiaryOrganization = @companyId or F_FourLevelOrganization = @companyId)");

                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(companyId))
                {
                    dp.Add("companyId", companyId, DbType.String);
                }
                if (!queryParam["F_Account"].IsEmpty())
                {
                    dp.Add("F_Account", "%" + queryParam["F_Account"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Account Like @F_Account ");
                }
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", "%" + queryParam["F_RealName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_RealName ");
                }
                if (!queryParam["F_UserState"].IsEmpty())
                {
                    dp.Add("F_UserState", "%" + queryParam["F_UserState"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UserState Like @F_UserState ");
                }
                if (!queryParam["F_OnJobStatus"].IsEmpty())
                {
                    dp.Add("F_OnJobStatus", "%" + queryParam["F_OnJobStatus"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OnJobStatus Like @F_OnJobStatus ");
                }
                if (!string.IsNullOrEmpty(departmentId))
                {
                    dp.Add("departmentId",departmentId, DbType.String);
                    strSql.Append(" AND t.F_SecondaryOrganization = @departmentId ");
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    dp.Add("F_UserState", "%" + keyword + "%", DbType.String);
                    strSql.Append(" AND( t.F_Account like @keyword or t.F_RealName like @keyword  or t.F_Mobile like @keyword  ) ");
                }
                return this.BaseRepository().FindList<UserEntity>(strSql.ToString(),dp, pagination);
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
        /// 用户列表,全部
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetAllList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql.Replace("t.F_Password,", "").Replace("t.F_Secretkey,", ""));
                strSql.Append(" FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE t.F_DeleteMark = 0  and (t.F_TypesResignation=''  or t.F_TypesResignation is null)   ORDER BY t.F_CompanyId,t.F_DepartmentId,t.F_RealName ");
                return this.BaseRepository().FindList<UserEntity>(strSql.ToString());
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
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public Hy_Login_VCodeEntity GetVCode(string phone)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT top 1  F_VCode FROM  Hy_Login_VCode where F_Phone=@phone and F_CreateDate>=@createtime order by F_CreateDate desc");
                return this.BaseRepository().FindEntity<Hy_Login_VCodeEntity>(strSql.ToString(), new { phone = phone, createtime = DateTime.Now.AddMinutes(-5) });
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
        /// 用户列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
            try
            {
                var strSql = new StringBuilder();
                
                strSql.Append("SELECT ");
                strSql.Append("t.F_EnCode,t.F_Account,F_RealName,F_Age,F_Gender,F_DocumentType,F_IDCard,CONVERT(varchar(12) , t.[F_Birthday], 111 ) as F_Birthday,F_NationAlity,F_Nation,F_RRNature,F_Mobile,F_PoliticalOutlook,F_MaritalStatus,F_NativePlace,F_UserState,F_OnJobStatus,CONVERT(varchar(12) , t.[F_IDCardStartDate], 111 ) AS F_IDCardStartDate,CONVERT(varchar(12) , t.[F_IDCardEndDate], 111 ) AS F_IDCardEndDate,F_BankDeposit,F_BankCardNumber,F_OneCardNumber, F_SecondaryOrganization,  F_TertiaryOrganization , F_FourLevelOrganization ,F_FiveLevelOrganization,F_SixLevelOrganization,p.F_Name as F_PostId,CONVERT(varchar(12) , t.[F_DateHoldingPost], 111 ) as F_DateHoldingPost ,F_WorkingSystem,F_SalaryStructureType,F_SalaryMethod,F_PayModel,F_SalaryType,F_PersonnelCategory,CONVERT(varchar(12) , t.[F_Entrydate], 111 ) as F_Entrydate,CONVERT(varchar(12) , t.[F_JoiningGroupDate], 111 ) AS F_JoiningGroupDate,F_EntryChannel,CONVERT(varchar(12) , t.[F_OfflineDate], 111 ) AS F_OfflineDate,CONVERT(varchar(12) , t.[F_ConfirmationDate], 111 ) as F_ConfirmationDate,F_InternalCode,F_InternalName,F_InternalCompany,CONVERT(varchar(12) , t.[F_LaborRecruitmentDate], 111 ) AS F_LaborRecruitmentDate,F_RecruitmentCompany,F_Education,F_GraduationUniversitie,F_MajorStudied,CONVERT(varchar(12) , t.[F_EducationStartDate], 111 ) AS F_EducationStartDate,CONVERT(varchar(12) , t.[F_EducationEndDate], 111 ) AS F_EducationEndDate,F_EducationalMode,F_ForeignLanguageLevel,F_IsQualified,F_QualificationName,F_GetTime,F_IDCardAddress,F_PermanentAddress,F_ResidentialAddress,F_CurrentAddress,F_EmergencyContact,F_EContactRelationship,F_EContactNumber,F_ContactAddress,F_laborContractStartDate,F_laborContractEndDate,F_LaborContractStatus,F_IsTrainingAgreement,F_StartDateService,F_EndDateService,F_DepartureDate,CONVERT(varchar(12) , t.[F_AttendanceDeadline], 111 ) AS F_AttendanceDeadline,F_TypesResignation,F_IsEsignationCertificate,F_Depreciation   ");
                strSql.Append(" FROM LR_Base_User t  left join lr_base_post p on t.F_PostId=p.F_PostId WHERE  (t.F_DeleteMark = 0 or t.F_DeleteMark is null)  and (t.F_UserState = '在职') and t.F_Account='HY004699' ");
                var userModel= this.BaseRepository().FindList<UserEntity>(strSql.ToString());
                var departmentModel= this.BaseRepository().FindList<DepartmentEntity>("select * from lr_base_department");
                var newUserModel = from u in userModel select new  UserEntityDTO
                {
                    F_UserId = u.F_EnCode,
                    F_EnCode=u.F_EnCode,
                    F_Account=u.F_Account,
                    F_RealName =u.F_RealName,
                    F_Age=u.F_Age,
                    F_Gender=u.F_Gender==1?"男":"女",
                    F_DocumentType=u.F_DocumentType,
                    F_IDCard=u.F_IDCard,
                    F_Birthday=u.F_Birthday,
                    F_NationAlity=u.F_NationAlity,
                    F_Nation=u.F_Nation,
                    F_RRNature=u.F_RRNature,
                    F_Mobile=u.F_Mobile,
                    F_PoliticalOutlook=u.F_PoliticalOutlook,
                    F_MaritalStatus=u.F_MaritalStatus,
                    F_NativePlace=u.F_NativePlace,
                    F_UserState=u.F_UserState,
                    F_OnJobStatus=u.F_OnJobStatus,
                    F_IDCardStartDate=u.F_IDCardStartDate,
                    F_IDCardEndDate=u.F_IDCardEndDate,
                    F_BankDeposit=u.F_BankDeposit,
                    F_BankCardNumber=u.F_BankCardNumber,
                    F_OneCardNumber=u.F_OneCardNumber,
                    F_SecondaryOrganization = departmentModel.Where(e=>e.F_DepartmentId== u.F_SecondaryOrganization).Count()>0? departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).FirstOrDefault().F_FullName:"",
                    F_TertiaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).FirstOrDefault().F_FullName : "",
                    F_FourLevelOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).FirstOrDefault().F_FullName : "",
                    F_FiveLevelOrganization=u.F_FiveLevelOrganization,
                    F_SixLevelOrganization=u.F_SixLevelOrganization,
                    F_PostId=u.F_PostId,
                    F_DateHoldingPost=u.F_DateHoldingPost,
                    F_WorkingSystem=u.F_WorkingSystem,
                    F_SalaryStructureType=u.F_SalaryStructureType,
                    F_SalaryMethod=u.F_SalaryMethod,
                    F_PayModel=u.F_PayModel,
                    F_SalaryType=u.F_SalaryType,
                    F_PersonnelCategory=u.F_PersonnelCategory,
                    F_Entrydate=u.F_Entrydate,
                    F_JoiningGroupDate=u.F_JoiningGroupDate,
                    F_EntryChannel=u.F_EntryChannel,
                    F_OfflineDate=u.F_OfflineDate,
                    F_ConfirmationDate=u.F_ConfirmationDate,
                    F_InternalCode=u.F_InternalCode,
                    F_InternalName=u.F_InternalName,
                    F_InternalCompany=u.F_InternalCompany,
                    F_LaborRecruitmentDate=u.F_LaborRecruitmentDate,
                    F_RecruitmentCompany=u.F_RecruitmentCompany,
                    F_Education=u.F_Education,
                    F_GraduationUniversitie=u.F_GraduationUniversitie,
                    F_MajorStudied=u.F_MajorStudied,
                    F_EducationStartDate=u.F_EducationStartDate,
                    F_EducationEndDate=u.F_EducationEndDate,
                    F_EducationalMode=u.F_EducationalMode,
                    F_ForeignLanguageLevel=u.F_ForeignLanguageLevel,
                    F_IsQualified=u.F_IsQualified==0?"否":"是",
                    F_QualificationName=u.F_QualificationName,
                    F_GetTime=u.F_GetTime,
                    F_IDCardAddress=u.F_IDCardAddress,
                    F_PermanentAddress=u.F_PermanentAddress,
                    F_ResidentialAddress=u.F_ResidentialAddress,
                    F_CurrentAddress=u.F_CurrentAddress,
                    F_EmergencyContact=u.F_EmergencyContact,
                    F_EContactRelationship=u.F_EContactRelationship,
                    F_EContactNumber=u.F_EContactNumber,
                    F_ContactAddress=u.F_ContactAddress,
                    F_laborContractStartDate=u.F_laborContractStartDate,
                    F_laborContractEndDate=u.F_laborContractEndDate,
                    F_LaborContractStatus=u.F_LaborContractStatus,
                    F_IsTrainingAgreement=u.F_IsTrainingAgreement==0?"否":"是",
                    F_StartDateService=u.F_StartDateService,
                    F_EndDateService=u.F_EndDateService,
                    F_DepartureDate=u.F_DepartureDate,
                    F_AttendanceDeadline=u.F_AttendanceDeadline,
                    F_TypesResignation=u.F_TypesResignation,
                    F_IsEsignationCertificate=u.F_IsEsignationCertificate,
                    F_Depreciation=u.F_Depreciation,
                };
                DataTable dt = new DataTable();
                if (newUserModel.Count()>0)
                {
                    PropertyInfo[] oProps = null;
                    foreach (UserEntityDTO  rec in newUserModel)
                    {
                        if (oProps == null)
                        {
                            oProps = ((Type)rec.GetType()).GetProperties();
                            foreach (PropertyInfo pi in oProps)
                            {
                                Type colType = pi.PropertyType;
                                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                                {
                                    colType = colType.GetGenericArguments()[0];
                                }
                                dt.Columns.Add(new DataColumn(pi.Name, colType));
                            }
                        }
                        DataRow dr = dt.NewRow();
                        foreach (PropertyInfo pi in oProps)
                        {
                            dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                            (rec, null);
                        }
                        dt.Rows.Add(dr);
                    }

                }
                return dt;
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
        /// 用户实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public UserEntity GetEntity(string keyValue)
        {
            try
            {
                var userModel = this.BaseRepository().FindEntity<UserEntity>(t => t.F_UserId == keyValue && (t.F_DeleteMark == 0 || t.F_DeleteMark == null));
                return userModel;
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
        /// 获取超级管理员用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetAdminList()
        {
            try
            {
                return this.BaseRepository().FindList<UserEntity>(t => t.F_SecurityLevel == 1);
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
        /// 转为DataTable
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public DataTable ConverDataTable(List<UserEntity> dataList)
        {
            try
            {
                return null;
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

        #region 验证数据
        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            try
            {
                var expression = LinqExtensions.True<UserEntity>();
                expression = expression.And(t => t.F_Account == account);
                if (!string.IsNullOrEmpty(keyValue))
                {
                    expression = expression.And(t => t.F_UserId != keyValue);
                }
                return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
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
        /// 虚拟删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            //try
            //{
            //    UserEntity entity = new UserEntity()
            //    {
            //        F_UserId = keyValue,
            //        F_DeleteMark = 1
            //    };
            //    this.BaseRepository().Update(entity);
            //}
            //catch (Exception ex)
            //{
            //    if (ex is ExceptionEx)
            //    {
            //        throw;
            //    }
            //    else
            //    {
            //        throw ExceptionEx.ThrowServiceException(ex);
            //    }
            //}
            DeleteEntity(keyValue);
        }

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<UserEntity>(t => t.F_UserId == keyValue);
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
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, UserEntity userEntity)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    userEntity.Create();
                    userEntity.F_Secretkey = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower();
                    userEntity.F_Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(userEntity.F_Password, userEntity.F_Secretkey).ToLower(), 32).ToLower();
                    this.BaseRepository().Insert(userEntity);
                }
                else
                {
                    userEntity.Modify(keyValue);
                    userEntity.F_Secretkey = null;
                    userEntity.F_Password = null;
                    this.BaseRepository().Update(userEntity);
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
        /// 修改保存用户表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public ReturnCommon SaveEntity(UserEntity userEntity)
        {
            var msg = new ReturnCommon();
            try
            {
                var isSuccess=this.BaseRepository().Update(userEntity);
                if (isSuccess>0)
                {
                    msg.Status = true;
                    msg.Message = "修改成功";
                }
                else 
                {
                    msg.Status = false;
                    msg.Message = "修改失败";
                }
            }
            catch (Exception ex)
            {
                msg.Status = false;
                msg.Message = "修改失败:"+ex.Message;
            }

            return msg;
        }

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        public void RevisePassword(string keyValue, string password)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Modify(keyValue);
                userEntity.F_Secretkey = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower();
                userEntity.F_Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(password, userEntity.F_Secretkey).ToLower(), 32).ToLower();
                this.BaseRepository().Update(userEntity);
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
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Modify(keyValue);
                userEntity.F_EnabledMark = state;
                this.BaseRepository().Update(userEntity);
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
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateEntity(UserEntity userEntity)
        {
            try
            {
                this.BaseRepository().Update(userEntity);
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
        /// 根据部门ID获取用户列表
        /// </summary>
        /// <param name="DepId"></param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserListByDepId(string DepId)
        {
            try
            {
                return this.BaseRepository().FindList<UserEntity>(t => t.F_DepartmentId == DepId && (t.F_DeleteMark == null || t.F_DeleteMark == 0));
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
