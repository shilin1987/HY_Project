using Learun.Application.Organization;
using Learun.Util;
using Learun.Util.Model;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class LoginService : BaseService
    {
        /// <summary>
        /// 暂时用来面试官登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public ApiModel Login(LoginModel login)
        {
            #region 内部账户验证
            try
            {
                //判断是否是面试官
                var isExis = from r in hYDatabase.lr_base_role
                             join ru in hYDatabase.lr_base_userrelation
                             on r.F_RoleId equals ru.F_ObjectId
                             join u in hYDatabase.lr_base_user
                             on ru.F_UserId equals u.F_UserId
                             where r.F_FullName == "面试官" 
                             && u.F_EnCode == login.username
                             select r;
                if (isExis.Count()==0) {
                    result.info = "您不是面试官!";
                    return result;
                }

                var sql = string.Format(@"SELECT  t.[F_UserId],t.[F_EnCode],t.[F_Account],t.[F_Password],t.[F_Secretkey],t.[F_RealName],t.[F_NickName]
                                        ,t.[F_HeadIcon],t.[F_QuickQuery],t.[F_SimpleSpelling],t.[F_Gender],t.[F_Birthday],t.[F_Mobile],t.[F_Telephone]
                                        ,t.[F_Email],t.[F_OICQ],t.[F_WeChat],t.[F_MSN],t.[F_CompanyId],t.[F_DepartmentId],t.[F_SecurityLevel]
                                        ,t.[F_OpenId],t.[F_Question],t.[F_AnswerQuestion],t.[F_CheckOnLine],t.[F_AllowStartTime],t.[F_AllowEndTime]
                                        ,t.[F_LockStartDate],t.[F_LockEndDate],t.[F_SortCode],t.[F_DeleteMark],t.[F_EnabledMark],t.[F_Description]
                                        ,t.[F_CreateDate],t.[F_CreateUserId],t.[F_CreateUserName],t.[F_ModifyDate],t.[F_ModifyUserId],t.[F_ModifyUserName]
                                        ,t.[F_IDCard],t.[F_PrimaryOrganization],isnull(t.[F_SecondaryOrganization],'') F_SecondaryOrganization
                                        ,isnull(t.[F_TertiaryOrganization],'') F_TertiaryOrganization,isnull(t.[F_FourLevelOrganization],'') F_FourLevelOrganization
                                        ,isnull(t.[F_FiveLevelOrganization],'') F_FiveLevelOrganization,isnull(t.[F_SixLevelOrganization],'') F_SixLevelOrganization
                                        ,t.[F_RecruitmentChannels],t.[F_Entrydate],t.[F_ConfirmationDate],t.[F_DepartureDate],t.[F_Education],t.[F_SalaryMethod]
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
                                        ,F_UserState userState
                                        ,case t.F_FourLevelOrganization when '无' then (case t.F_TertiaryOrganization 
                                         when '无' then t.F_SecondaryOrganization else t.F_TertiaryOrganization end) else t.F_FourLevelOrganization end minDepartment 
		                                FROM LR_Base_User t left join lr_base_department d on t.F_SecondaryOrganization=d.F_DepartmentId
	                                    WHERE t.F_Account = '{0}'  AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null)  and (t.F_TypesResignation=''  or t.F_TypesResignation is null)", login.username, login.password);

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
                        //string token = OperatorHelper.Instance.AddLoginUser(login.username, "HY-app", login.loginMark, false);//写入缓存信息
                        var token = Guid.NewGuid().ToString();

                        var userInfo = new Learun.Util.UserInfo();
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

                        userInfo.loadTime = DateTime.Now;

                        var jsonData = new
                        {
                            baseinfo = userInfo,
                            //post = postIBLL.GetListByPostIds(userInfo.postIds),
                            //role = roleIBLL.GetListByRoleIds(userInfo.roleIds)
                        };

                        result.code = ResponseCode.success;
                        result.info = "登录成功";
                        result.data = jsonData;

                        return result;
                    }
                    else
                    {
                        result.info = "登录失败:密码不正确";
                    }
                }
                else
                {
                    result.info = "登录失败:此用户不存在";
                }
            }
            catch (Exception ex)
            {
                result.info = "登录异常,请联系工作人员处理(" + ex.InnerException.Message + ")";
            }

            return result;
            #endregion
        }

        /// <summary>
        /// 应聘者登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<ApiModel> CandidateLogin(LoginModel login)
        {
            try
            {
                var pwd = HttpUtility.UrlDecode(login.password);
                var isExistForIdCard = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_Mobile == login.username);
                if (isExistForIdCard.Count() == 1)
                {
                    if (isExistForIdCard.FirstOrDefault().F_Register == 1)
                    {
                        if (isExistForIdCard.FirstOrDefault().F_PWD == login.password)
                        {
                            result.code = ResponseCode.success;
                            result.data = isExistForIdCard.FirstOrDefault().F_UserId;

                            //查询当前操作流程
                            //var processEntity = hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == isExistForIdCard.FirstOrDefault().F_UserId);
                            //if (processEntity.Count() > 0)
                            //{
                            //    if (processEntity.Where(e => e.OperationStatus == 0).Count() > 0)
                            //    {
                            //        result.info = "您当前在[" + processEntity.Where(e => e.OperationStatus == 0).FirstOrDefault().OperationContent + "]流程中";
                            //        result.AuxiliaryField = "1";
                            //    }
                            //    else if (processEntity.Where(e => e.OperationStatus == -1).Count() > 0)
                            //    {
                            //        result.info = "您当前在[" + processEntity.Where(e => e.OperationStatus == -1).FirstOrDefault().OperationContent + "]不通过流程中";
                            //        result.AuxiliaryField = "-1";
                            //    }
                            //}
                            //else
                            //{
                            //    result.info = "您已通过应聘！欢迎加入华羿微电大家庭!";
                            //}
                        }
                        else {
                            result.info = "请输入正确登录密码!";
                        }
                    }
                    else {
                        result.info = "请先完成应聘者注册!";
                    }
                }
                else if (isExistForIdCard.Count() > 1)
                {
                    result.info = "此手机号被多人使用,请联系工作人员处理";
                }
                else if (isExistForIdCard.Count() == 0 || isExistForIdCard == null)
                {
                    result.info = "此手机号未注册或密码有误";
                }
            }
            catch (Exception ex)
            {
                result.info = "登录异常,请联系工作人员处理(" + ex.Message + ")";
            }

            return result;
        }
    }
}