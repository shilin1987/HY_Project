using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using Learun.Util.Model;
using Learun.Util.Operat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.DataBase;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class UserController : BaseApiController
    {

        private ICache redisCache = CacheFactory.CaChe();
        //private PostIBLL postIBLL = new PostBLL();
        //private RoleIBLL roleIBLL = new RoleBLL();
        //private UserIBLL userIBLL = new UserBLL();

        [HttpPost]
        public ApiModel InitializationUser(UserInitModele userInit)
        {
            if (userInit != null)
            {
                var userEntity = hYDatabase.lr_base_user.Where(e => e.F_UserId == userInit.userId);
                if (userEntity != null && userEntity.Count() > 0)
                {
                    return Success(userEntity, "初始化用户信息", OperationType.Update, "", "初始化用户信息成功");
                }
                else
                {
                    return Fail(userEntity, "初始化用户信息", OperationType.Exception, "", "初始化用户信息失败");
                }
            }
            else 
            {
                return Fail(null, "初始化用户信息", OperationType.Exception, "", "传入参数为null");
            }
        }

            // GET: api/User/
            [HttpGet]
        public ApiModel Map(string token, string data)
        {
            string cacheKey = "learun_adms_department_"; // +加部门主键
            try
            {
                Dictionary<string, DepartmentModel> dic = redisCache.Read<Dictionary<string, DepartmentModel>>(cacheKey + "_dic", CacheId.department);
                if (dic == null)
                {
                    dic = new Dictionary<string, DepartmentModel>();

                    var sql = @"SELECT t.F_DepartmentId,t.F_CompanyId,t.F_ParentId,t.F_EnCode,t.F_FullName,t.F_ShortName,
                     t.F_Nature,t.F_Manager,t.F_OuterPhone,t.F_InnerPhone,t.F_Email,t.F_Fax,t.F_SortCode,
                     t.F_DeleteMark,t.F_EnabledMark,t.F_Description,t.F_CreateDate,t.F_CreateUserId,
                     t.F_CreateUserName,t.F_ModifyDate,t.F_ModifyUserId,t.F_ModifyUserName  FROM LR_Base_Department t
                     WHERE t.F_EnabledMark = 1 AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null) ";

                    var list = hYDatabase.Database.SqlQuery<DepartmentEntity>(sql);
                    if (list.Count() > 0)
                    {
                        foreach (var item in list)
                        {
                            DepartmentModel model = new DepartmentModel()
                            {
                                companyId = item.F_CompanyId,
                                parentId = item.F_ParentId,
                                name = item.F_FullName
                            };
                            dic.Add(item.F_DepartmentId, model);
                            redisCache.Write(cacheKey + "dic", dic, CacheId.department);
                        }
                    }
                }

                string md5 = Md5Helper.Encrypt(dic.ToJson(), 32);
                if (md5 == data)
                {
                    return Success(null, "部门信息更新", OperationType.Update, "", "no update");
                }
                else
                {
                    var jsondata = new
                    {
                        data = dic,
                        ver = md5
                    };
                    return Success(jsondata, "部门信息已更新", OperationType.Update, "", "update");
                }
            }
            catch (Exception ex)
            {
                var jsondata = new
                {
                    data = "",
                    ver = ""
                };
                return Fail(jsondata, "部门信息更新", OperationType.Exception, "", "update fail:" + ex.Message);
            }
        }

        [HttpGet]
        public ApiModel UserMap(string token, string data)
        {
            //string cacheKey = "learun_adms_user_"; // +加公司主键
            //try
            //{
            //    Dictionary<string, UserModel> dic = redisCache.Read<Dictionary<string, UserModel>>(cacheKey + "_dic", CacheId.department);
            //    if (dic == null)
            //    {
            //        dic = new Dictionary<string, UserModel>();

            //        var sql = @"SELECT  t.[F_UserId],t.[F_EnCode],t.[F_Account],t.[F_Password],t.[F_Secretkey],t.[F_RealName],t.[F_NickName]
            //                            ,t.[F_HeadIcon],t.[F_QuickQuery],t.[F_SimpleSpelling],t.[F_Gender],t.[F_Birthday],t.[F_Mobile],t.[F_Telephone]
            //                            ,t.[F_Email],t.[F_OICQ],t.[F_WeChat],t.[F_MSN],t.[F_CompanyId],t.[F_DepartmentId],t.[F_SecurityLevel]
            //                            ,t.[F_OpenId],t.[F_Question],t.[F_AnswerQuestion],t.[F_CheckOnLine],t.[F_AllowStartTime],t.[F_AllowEndTime]
            //                            ,t.[F_LockStartDate],t.[F_LockEndDate],t.[F_SortCode],t.[F_DeleteMark],t.[F_EnabledMark],t.[F_Description]
            //                            ,t.[F_CreateDate],t.[F_CreateUserId],t.[F_CreateUserName],t.[F_ModifyDate],t.[F_ModifyUserId],t.[F_ModifyUserName]
            //                            ,t.[F_IDCard],t.[F_PrimaryOrganization],isnull(t.[F_SecondaryOrganization],'') F_SecondaryOrganization
            //                            ,isnull(t.[F_TertiaryOrganization],'') F_TertiaryOrganization,isnull(t.[F_FourLevelOrganization],'') F_FourLevelOrganization
            //                            ,isnull(t.[F_FiveLevelOrganization],'') F_FiveLevelOrganization,isnull(t.[F_SixLevelOrganization],'') F_SixLevelOrganization
            //                            ,t.[F_RecruitmentChannels],t.[F_Entrydate],t.[F_ConfirmationDate],t.[F_DepartureDate],t.[F_Education],t.[F_SalaryMethod]
            //                            ,t.[F_PayModel],t.[F_WorkingSystem],t.[F_BankCardNumber],t.[F_BankDeposit],t.[F_DateHoldingPost],t.[F_IsTrainingAgreement]
            //                            ,t.[F_StartDateService],t.[F_EndDateService],t.[F_EmployeeNature],t.[F_EmployeeNatureChangeDate],t.[F_PieceworkType]
            //                            ,t.[F_TimeBecomeRegular],t.[F_TimeShiftWorkSystem],t.[F_TypesResignation],t.[F_MakeUpTime],t.[F_PostId],t.[F_SalaryCalculation]
            //                            ,t.[F_Age],t.[F_DocumentType],t.[F_NationAlity],t.[F_Nation],t.[F_RRNature],t.[F_PoliticalOutlook],t.[F_MaritalStatus]
            //                            ,t.[F_NativePlace],isnull(t.[F_OnJobStatus],'') OnJobStatus,t.[F_IDCardStartDate],t.[F_IDCardEndDate],isnull(t.[F_OneCardNumber],'') F_OneCardNumber
            //                            ,t.[F_SalaryStructureType],t.[F_SalaryType],t.[F_PersonnelCategory],t.[F_JoiningGroupDate],t.[F_EntryChannel],t.[F_OfflineDate]
            //                            ,t.[F_InternalCode],t.[F_InternalName],t.[F_InternalCompany],t.[F_LaborRecruitmentDate],t.[F_RecruitmentCompany],t.[F_GraduationUniversitie]
            //                            ,t.[F_MajorStudied],t.[F_EducationStartDate],t.[F_EducationEndDate],t.[F_EducationalMode],t.[F_ForeignLanguageLevel]
            //                            ,t.[F_IsQualified],t.[F_QualificationName],t.[F_GetTime],t.[F_InternalTitleType],t.[F_InternalTitle],t.[F_InternalTitleDate]
            //                            ,t.[F_SocialTitleType],t.[F_SocialTitle],t.[F_SocialTitleDate],t.[F_IDCardAddress],t.[F_PermanentAddress],t.[F_ResidentialAddress]
            //                            ,t.[F_CurrentAddress],t.[F_EmergencyContact],t.[F_EContactRelationship],t.[F_EContactNumber],t.[F_ContactAddress]
            //                            ,t.[F_laborContractStartDate],t.[F_laborContractEndDate],t.[F_LaborContractStatus],t.[F_AttendanceDeadline]
            //                            ,t.[F_IsEsignationCertificate],t.[F_Depreciation],d.F_FullName department
            //                            ,case when t.[F_DepartureDate] is null then '在职' else (case when t.[F_DepartureDate]='1900-01-01 00:00:00.0000000' then '在职' else '离职'  end) end userState
            //                            ,case t.F_FourLevelOrganization when '无' then (case t.F_TertiaryOrganization 
            //                            when '无' then t.F_SecondaryOrganization else t.F_TertiaryOrganization end) else t.F_FourLevelOrganization end minDepartment
            //                            FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId WHERE t.F_DeleteMark = 0  and (t.F_TypesResignation=''  or t.F_TypesResignation is null) 
            //                            ORDER BY t.F_CompanyId,t.F_DepartmentId,t.F_RealName ";

            //        var list = hYDatabase.Database.SqlQuery<UserEntity>(sql);
            //        if (list.Count() > 0)
            //        {
            //            foreach (var item in list)
            //            {
            //                UserModel model = new UserModel()
            //                {
            //                    companyId = item.F_CompanyId,
            //                    departmentId = item.F_DepartmentId,
            //                    name = item.F_RealName,
            //                };
            //                string img = "";
            //                if (!string.IsNullOrEmpty(item.F_HeadIcon))
            //                {
            //                    string fileHeadImg = Config.GetValue("fileHeadImg");
            //                    string fileImg = string.Format("{0}/{1}{2}", fileHeadImg, item.F_UserId, item.F_HeadIcon);
            //                    if (DirFileHelper.IsExistFile(fileImg))
            //                    {
            //                        img = item.F_HeadIcon;
            //                    }
            //                }
            //                if (string.IsNullOrEmpty(img))
            //                {
            //                    if (item.F_Gender == 0)
            //                    {
            //                        img = "0";
            //                    }
            //                    else
            //                    {
            //                        img = "1";
            //                    }
            //                }
            //                model.img = img;
            //                dic.Add(item.F_UserId, model);
            //            }
            //            redisCache.Write(cacheKey + "dic", dic, CacheId.user);
            //        }
            //    }

            //    string md5 = Md5Helper.Encrypt(dic.ToJson(), 32);
            //    if (md5 == data)
            //    {
            //        return Success(null, "用户信息更新", OperationType.Update, "", "no update");
            //    }
            //    else
            //    {
            //        var jsondata = new
            //        {
            //            data = dic,
            //            ver = md5
            //        };
            //        return Success(jsondata, "用户信息已更新", OperationType.Update, "", "update");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    var jsondata = new
            //    {
            //        data = "",
            //        ver = ""
            //    };
            //    return Fail(jsondata, "部门信息更新", OperationType.Exception, "", "update fail:" + ex.Message);
            //}

            return Success(null, "用户信息已更新", OperationType.Update, "", "update");
        }

        [HttpGet]
        public ApiModel CompanyMap(string token, string data)
        {
            return Success(null, "公司信息已更新", OperationType.Update, "", "update");
        }

        // POST: api/User/Login
        [HttpPost]
        public ApiModel Login(LoginModel login)
        {
            #region 内部账户验证

            try
            {
                var sql = string.Format(@"select a.*,case when a.[F_DepartureDate]='' then '在职' else (case when a.[F_DepartureDate]='1900-01-01 00:00:00.0000000' then '在职' else '离职'  end) end userState,case a.F_FourLevelOrganization when  '' then (case a.F_TertiaryOrganization 
                                        when  '' then a.F_SecondaryOrganization else a.F_TertiaryOrganization end) else a.F_FourLevelOrganization end minDepartment  from
                                        (SELECT  t.[F_UserId],t.[F_EnCode],t.[F_Account],t.[F_Password],t.[F_Secretkey],t.[F_RealName],t.[F_NickName]
                                        ,t.[F_HeadIcon],t.[F_QuickQuery],t.[F_SimpleSpelling],t.[F_Gender],t.[F_Birthday],t.[F_Mobile],t.[F_Telephone]
                                        ,t.[F_Email],t.[F_OICQ],t.[F_WeChat],t.[F_MSN],t.[F_CompanyId],t.[F_DepartmentId],t.[F_SecurityLevel]
                                        ,t.[F_OpenId],t.[F_Question],t.[F_AnswerQuestion],t.[F_CheckOnLine],t.[F_AllowStartTime],t.[F_AllowEndTime]
                                        ,t.[F_LockStartDate],t.[F_LockEndDate],t.[F_SortCode],t.[F_DeleteMark],t.[F_EnabledMark],t.[F_Description]
                                        ,t.[F_CreateDate],t.[F_CreateUserId],t.[F_CreateUserName],t.[F_ModifyDate],t.[F_ModifyUserId],t.[F_ModifyUserName]
                                        ,t.[F_IDCard],t.[F_PrimaryOrganization],isnull(t.[F_SecondaryOrganization],'') F_SecondaryOrganization
                                        ,isnull(t.[F_TertiaryOrganization],'') F_TertiaryOrganization,isnull(t.[F_FourLevelOrganization],'') F_FourLevelOrganization
                                        ,isnull(t.[F_FiveLevelOrganization],'') F_FiveLevelOrganization,isnull(t.[F_SixLevelOrganization],'') F_SixLevelOrganization
                                        ,t.[F_RecruitmentChannels],t.[F_Entrydate],t.[F_ConfirmationDate],isnull(t.[F_DepartureDate],'') F_DepartureDate,t.[F_Education],t.[F_SalaryMethod]
                                        ,t.[F_PayModel],t.[F_WorkingSystem],t.[F_BankCardNumber],t.[F_BankDeposit],t.[F_DateHoldingPost],t.[F_IsTrainingAgreement]
                                        ,t.[F_StartDateService],t.[F_EndDateService],t.[F_EmployeeNature],t.[F_EmployeeNatureChangeDate],t.[F_PieceworkType]
                                        ,t.[F_TimeBecomeRegular],t.[F_TimeShiftWorkSystem],t.[F_TypesResignation],t.[F_MakeUpTime],t.[F_PostId],t.[F_SalaryCalculation]
                                        ,t.[F_Age],t.[F_DocumentType],t.[F_NationAlity],t.[F_Nation],t.[F_RRNature],t.[F_PoliticalOutlook],t.[F_MaritalStatus]
                                        ,t.[F_NativePlace],isnull(t.[F_OnJobStatus],'') OnJobStatus,t.[F_IDCardStartDate],t.[F_IDCardEndDate],isnull(t.[F_OneCardNumber],'') F_OneCardNumber
                                        ,t.[F_SalaryStructureType],t.[F_SalaryType],t.[F_PersonnelCategory],t.[F_JoiningGroupDate],t.[F_EntryChannel],t.[F_OfflineDate]
                                        ,t.[F_InternalCode],t.[F_InternalName],t.[F_InternalCompany],t.[F_LaborRecruitmentDate],t.[F_RecruitmentCompany],t.[F_GraduationUniversitie]
                                        ,t.[F_MajorStudied],t.[F_EducationStartDate],t.[F_EducationEndDate],t.[F_EducationalMode],t.[F_ForeignLanguageLevel]
                                        ,t.[F_IsQualified],t.[F_QualificationName],t.[F_GetTime],t.[F_InternalTitleType],t.[F_InternalTitle],t.[F_InternalTitleDate]
                                        ,t.[F_SocialTitleType],t.[F_SocialTitle],t.[F_SocialTitleDate],t.[F_IDCardAddress],t.[F_PermanentAddress],t.[F_ResidentialAddress]
                                        ,t.[F_CurrentAddress],t.[F_EmergencyContact],t.[F_EContactRelationship],t.[F_EContactNumber],t.[F_ContactAddress]
                                        ,t.[F_laborContractStartDate],t.[F_laborContractEndDate],t.[F_LaborContractStatus],t.[F_AttendanceDeadline]
                                        ,t.[F_IsEsignationCertificate],t.[F_Depreciation],d.F_FullName department
		                                FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId) a							
	                                   WHERE a.F_Account = '{0}'  AND (a.F_DeleteMark = 0 or a.F_DeleteMark is null)  and (a.F_TypesResignation=''  or a.F_TypesResignation is null)", login.username);

                var userEntitys = hYDatabase.Database.SqlQuery<UserEntity>(sql);
                if (userEntitys.Count() > 0)
                {
                    var userModelInfo = from u in userEntitys
                                        join m in hYDatabase.lr_base_department
                                        on u.minDepartment equals m.F_DepartmentId
                                        into t
                                        from c in t.DefaultIfEmpty()
                                        select new
                                        {
                                            u,
                                            c.F_FullName
                                        };
                    var userEntity = userModelInfo.FirstOrDefault();
                    var dbPassword = Md5Helper.Encrypt(DESEncrypt.Encrypt(login.password.ToLower(), userEntity.u.F_Secretkey).ToLower(), 32).ToLower();
                    if (dbPassword.Equals(userEntity.u.F_Password))
                    {
                        string token = OperatorHelper.Instance.AddLoginUser(login.username, "HY-app", login.loginMark, false);//写入缓存信息

                        var userInfo = new UserInfo();
                        userInfo.token = token;
                        userInfo.account = userEntity.u.F_Account;
                        userInfo.userId = userEntity.u.F_UserId;
                        userInfo.enCode = userEntity.u.F_EnCode;
                        userInfo.password = userEntity.u.F_Password;
                        userInfo.secretkey = userEntity.u.F_Secretkey;
                        userInfo.realName = userEntity.u.F_RealName;
                        userInfo.nickName = userEntity.u.F_NickName;
                        userInfo.headIcon = userEntity.u.F_HeadIcon;
                        userInfo.gender = userEntity.u.F_Gender;
                        userInfo.mobile = userEntity.u.F_Mobile;
                        userInfo.telephone = userEntity.u.F_Telephone;
                        userInfo.email = userEntity.u.F_Email;
                        userInfo.oICQ = userEntity.u.F_OICQ;
                        userInfo.weChat = userEntity.u.F_WeChat;
                        userInfo.companyId = userEntity.u.F_CompanyId;
                        userInfo.departmentId = userEntity.u.minDepartment;
                        userInfo.department = userEntity.u.F_SecondaryOrganization;
                        userInfo.openId = userEntity.u.F_OpenId;
                        userInfo.isSystem = userEntity.u.F_SecurityLevel == 1 ? true : false;

                        //二维码员工信息补全功能添加
                        userInfo.department = userEntity.u.department;
                        userInfo.minDepartment = userEntity.F_FullName == null ? "" : userEntity.F_FullName;
                        userInfo.onJobStatus = userEntity.u.OnJobStatus;
                        userInfo.userState = userEntity.u.userState;
                        userInfo.oneCardNumber = userEntity.u.F_OneCardNumber;

                        //岗位信息缓存
                        List<APPDropDownListModel> operatorInfo = redisCache.Read<List<APPDropDownListModel>>("_postCacheInfo", CacheId.loginInfo);
                        if (operatorInfo == null)
                        {
                            //加载岗位信息
                            var postSql = string.Format(@"SELECT F_PostId [value],[F_Name] [text] FROM [HYDatabase].[dbo].[lr_base_post]
                                                          where  F_DepartmentId='{0}'", userEntity.u.minDepartment);
                            operatorInfo = hYDatabase.Database.SqlQuery<APPDropDownListModel>(postSql).ToList();

                            redisCache.Write<List<APPDropDownListModel>>(login.username + "_postInfo", operatorInfo, TimeSpan.FromMinutes(5), CacheId.loginInfo);
                        }

                        userInfo.postIds = JsonConvert.SerializeObject(operatorInfo);
                        userInfo.loadTime = DateTime.Now;

                        var jsonData = new
                        {
                            baseinfo = userInfo,
                            //post = postIBLL.GetListByPostIds(userInfo.postIds),
                            //role = roleIBLL.GetListByRoleIds(userInfo.roleIds)
                        };

                        return Success(jsonData, "APP登录", OperationType.AppLogin, "", "登录成功");
                    }
                    else
                    {
                        return Fail(null, "APP登录", OperationType.AppLogin, "", "登录失败:密码不正确");
                    }
                }
                else
                {
                    return Fail(null, "APP登录", OperationType.AppLogin, "", "登录失败:此用户不存在");
                }
            }
            catch (Exception ex)
            {
                apiModel.code = ResponseCode.fail;
                apiModel.info = ex.Message;
            }

            return apiModel;
            #endregion
        }

        [HttpPost]
        public ApiModel RevisePassword(RevisePasswordModel revisePassword) 
        {
            var userEntity = hYDatabase.lr_base_user.Where(e=>e.F_UserId== revisePassword.userId);
            if (userEntity!=null &&  userEntity.Count() > 0)
            {
                string oldPasswordByEncrypt = Md5Helper.Encrypt(DESEncrypt.Encrypt(revisePassword.oldpassword, userEntity.FirstOrDefault().F_Secretkey).ToLower(), 32).ToLower();
                if (oldPasswordByEncrypt == userEntity.FirstOrDefault().F_Password)
                {
                    userEntity.FirstOrDefault().F_Secretkey = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower();
                    userEntity.FirstOrDefault().F_Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(revisePassword.newpassword, userEntity.FirstOrDefault().F_Secretkey).ToLower(), 32).ToLower();
                    var isSuccess=hYDatabase.SaveChanges();
                    if (isSuccess>0)
                    {
                        return Success(null, "修改密码", OperationType.AppLogin, "", "密码修改成功");
                    }
                    else
                    {
                        return Fail(null, "修改密码", OperationType.AppLogin, "", "密码修改失败/无修改");
                    }
                }
                else
                {
                    return Fail(null, "修改密码", OperationType.AppLogin, "", "旧密码输入有误");
                }
            }
            else
            {
                return Fail(null, "修改密码", OperationType.AppLogin, "", "未找到当前登录用户信息");
            }
        }

        /// <summary>
        /// 获取人员头像图标
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiModel Img(string data)
        {
            //userIBLL.GetImg(userId);
            return Success(null, "获取头像图标", OperationType.AppLogin, "", "获取成功");
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel InformationPerfection(UserViewModele user)
        {
            if (user != null)
            {
                if (user.data != null)
                {
                    var userModel = user.data;
                    try
                    {
                        var newUser = hYDatabase.lr_base_user.Where(e => e.F_UserId == userModel.F_UserId);
                        if (newUser.Count() > 0)
                        {
                            var newUserEntity = newUser.FirstOrDefault();

                            //var postId = string.Empty;
                            //var postEntity = hYDatabase.lr_base_post.Where(e=>e.F_DepartmentId== userModel.F_DepartmentId && e.F_Name== userModel.F_PostId);
                            //if (postEntity.Count()>0)
                            //{
                            //    postId = postEntity.FirstOrDefault().F_PostId;
                            //}

                            newUser.FirstOrDefault().F_Age = userModel.F_Age;
                            newUser.FirstOrDefault().F_Gender = userModel.F_Gender;
                            newUser.FirstOrDefault().F_DocumentType = userModel.F_DocumentType;
                            newUser.FirstOrDefault().F_IDCard = userModel.F_IDCard;
                            newUser.FirstOrDefault().F_IDCardStartDate = userModel.F_IDCardStartDate;
                            newUser.FirstOrDefault().F_IDCardStartDate = userModel.F_IDCardStartDate;
                            newUser.FirstOrDefault().F_IDCardEndDate = userModel.F_IDCardEndDate;
                            newUser.FirstOrDefault().F_NationAlity = userModel.F_NationAlity;
                            newUser.FirstOrDefault().F_Nation = userModel.F_Nation;
                            newUser.FirstOrDefault().F_RRNature = userModel.F_RRNature;
                            newUser.FirstOrDefault().F_Mobile = userModel.F_Mobile;
                            newUser.FirstOrDefault().F_PoliticalOutlook = userModel.F_PoliticalOutlook;
                            newUser.FirstOrDefault().F_MaritalStatus = userModel.F_MaritalStatus;
                            newUser.FirstOrDefault().F_NativePlace = userModel.F_NativePlace;
                            newUser.FirstOrDefault().F_BankCardNumber = userModel.F_BankCardNumber;
                            newUser.FirstOrDefault().F_BankDeposit = userModel.F_BankDeposit;
                            //newUser.FirstOrDefault().F_PostId = postId;
                            newUser.FirstOrDefault().F_Entrydate = userModel.F_Entrydate;
                            newUser.FirstOrDefault().F_JoiningGroupDate = userModel.F_JoiningGroupDate;
                            newUser.FirstOrDefault().F_EntryChannel = userModel.F_EntryChannel;
                            newUser.FirstOrDefault().F_Education = userModel.F_Education;
                            newUser.FirstOrDefault().F_GraduationUniversitie = userModel.F_GraduationUniversitie;
                            newUser.FirstOrDefault().F_MajorStudied = userModel.F_MajorStudied;
                            newUser.FirstOrDefault().F_EducationStartDate = userModel.F_EducationStartDate;
                            newUser.FirstOrDefault().F_EducationEndDate = userModel.F_EducationEndDate;
                            newUser.FirstOrDefault().F_EducationalMode = userModel.F_EducationalMode;
                            newUser.FirstOrDefault().F_ForeignLanguageLevel = userModel.F_ForeignLanguageLevel;
                            newUser.FirstOrDefault().F_IsQualified = userModel.F_IsQualified;
                            newUser.FirstOrDefault().F_QualificationName = userModel.F_QualificationName;
                            newUser.FirstOrDefault().F_GetTime = userModel.F_GetTime;
                            newUser.FirstOrDefault().F_IDCardAddress = userModel.F_IDCardAddress;
                            newUser.FirstOrDefault().F_PermanentAddress = userModel.F_PermanentAddress;
                            newUser.FirstOrDefault().F_ResidentialAddress = userModel.F_ResidentialAddress;
                            newUser.FirstOrDefault().F_CurrentAddress = userModel.F_CurrentAddress;
                            newUser.FirstOrDefault().F_EmergencyContact = userModel.F_EmergencyContact;
                            newUser.FirstOrDefault().F_EContactRelationship = userModel.F_EContactRelationship;
                            newUser.FirstOrDefault().F_EContactNumber = userModel.F_EContactNumber;
                            newUser.FirstOrDefault().F_ContactAddress = userModel.F_ContactAddress;
                            newUser.FirstOrDefault().F_InternalCode = userModel.F_InternalCode;
                            newUser.FirstOrDefault().F_InternalName = userModel.F_InternalName;
                            newUser.FirstOrDefault().F_InternalCompany = userModel.F_InternalCompany;
                            newUser.FirstOrDefault().F_RecruitmentCompany = userModel.F_RecruitmentCompany;
                            newUser.FirstOrDefault().F_ModifyUserId = userModel.F_UserId;
                            newUser.FirstOrDefault().F_ModifyDate = DateTime.Now;

                            var isSave = hYDatabase.SaveChanges();
                            //if (isSave > 0)
                            //{
                            //    return Success(null, "保存用户资料", OperationType.AppLogin, "", "保存成功");
                            //}
                            //else {
                            //    return Fail(null, "保存用户资料", OperationType.AppLogin, "", "用户信息保存失败");
                            //}

                            return Success(null, "保存用户资料", OperationType.AppLogin, "", "保存成功");
                        }
                        else
                        {
                            return Fail(null, "保存用户资料", OperationType.AppLogin, "", "保存失败:未找到此用户信息");
                        }
                    }
                    catch (Exception ex)
                    {
                        return Fail(null, "保存用户资料", OperationType.AppLogin, "", "保存出现异常:" + ex.Message);
                    }
                }
                else
                {
                    return Fail(null, "保存用户资料", OperationType.AppLogin, "", "保存失败:用户信息为空");
                }
            }
            else
            {
                return Fail(null, "保存用户资料", OperationType.AppLogin, "", "保存失败:请求参数为空");
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
