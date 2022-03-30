using LaoQinAndHRDataBasicsWService.Database;
using LaoQinAndHRDataBasicsWService.DatabaseHelper;
using LaoQinAndHRDataBasicsWService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Learun.Util.DataTableListMutualTransformation.MutualTransformation;

namespace LaoQinAndHRDataBasicsWService.Service
{
    public class HRDataMigrationService
    {
        /// <summary>
        /// 劳勤数据迁移到HR平台
        /// </summary>
        /// <returns></returns>
        public string DataMigration()
        {
            var result = string.Empty;
            try
            {
                //获取劳勤和HR员工信息
                var hrListToUser = GetHRUserInfo().Result;
                var wtsListToUser = GetWTSUserInfo().Result;

                //取劳勤员工信息差集并插入到HR员工表中
                List<lr_base_user> exceptList = wtsListToUser.Except(hrListToUser, new CnMemoEqualityComparer()).ToList<lr_base_user>();
                if (exceptList.Count() > 0)
                {
                    exceptList.ForEach(a =>
                    {
                        a.F_UserId = Guid.NewGuid().ToString();
                        a.F_Account = a.F_EnCode;
                        a.F_Password = "0c0fc129b390b87d95f43d43c7a643f3";
                        a.F_Secretkey = "5e3970562b56ad8a";
                        a.F_CreateDate = DateTime.Now;
                        a.F_CreateUserName = "劳勤数据添加";
                    });
                    DatabaseOperation.BulkCopy<lr_base_user>(exceptList, "lr_base_user");
                }

                //取劳勤员工交集数据更新HR员工信息表
                var newWtsListToUser = wtsListToUser.Where(h => hrListToUser.Exists(w => h.F_IDCard.Equals(w.F_IDCard))).ToList();
                if (newWtsListToUser.Count() > 0)
                {
                    //给userid赋值
                    foreach (var item in newWtsListToUser)
                    {
                        var hruser = hrListToUser.Where(h => h.F_IDCard == item.F_IDCard);
                        if (hruser.Count() > 0)
                        {
                            if (item.F_IDCard == hruser.FirstOrDefault().F_IDCard)
                            {
                                item.F_UserId = hruser.FirstOrDefault().F_UserId;
                            }
                        }
                    }

                    //需要修改的字段
                    var useField = new List<string>();
                    useField.Add("F_EnCode");
                    useField.Add("F_RealName");
                    useField.Add("F_Gender");
                    useField.Add("F_Mobile");
                    useField.Add("F_Entrydate");
                    useField.Add("F_UserState");
                    useField.Add("F_Birthday");
                    useField.Add("F_DepartureDate");
                    useField.Add("F_AttendanceDeadline");
                    useField.Add("F_ModifyDate");
                    useField.Add("F_ModifyUserName");

                    result = DatabaseOperation.BatchUpdate<lr_base_user>(newWtsListToUser, "F_IDCard", "lr_base_user", null, useField);
                    result = result == "1" ? "迁移成功(" + result + ")!" : "迁移失败或没有需要迁移的数据("+ result + ")";
                }
            }
            catch (Exception ex)
            {
                result = "迁移失败:" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 获取劳勤员工信息
        /// </summary>
        /// <returns></returns>
        private async Task<List<lr_base_user>> GetWTSUserInfo()
        {
            using (WTS_HTEntities wTS_HT = new WTS_HTEntities())
            {
                var wtssql = @"select user_code F_EnCode,user_name F_RealName,CAST(REPLACE(sex,'2','0') as int) F_Gender,zjhm F_IDCard,
                               mobiletelephone F_Mobile,case user_status when '1' then '在职' when '3' then '离职申请' when '4' then'离职' when '5' then '无效' else '' end F_UserState,
                               birthday F_Birthday,join_date F_Entrydate, fire_date F_DepartureDate, CAST(user_def4 as datetime) F_AttendanceDeadline ,'劳勤数据更新' F_ModifyUserName,GETDATE() F_ModifyDate 
							   from pub_user where comp_id='9f89cb39-cd0b-4c2e-85b2-0a01f550bcce'";
                var wtsUserList = await wTS_HT.Database.SqlQuery<lr_base_user>(wtssql).ToListAsync();

                return wtsUserList;
            }
        }

        /// <summary>
        /// 获取HR平台员工信息
        /// </summary>
        /// <returns></returns>
        private async Task<List<lr_base_user>> GetHRUserInfo()
        {
            using (HRDatabaseEntities hRDatabase = new HRDatabaseEntities())
            {
                var hrsql = @"SELECT [F_UserId],[F_EnCode],[F_Account],[F_Password],[F_Secretkey],[F_RealName],[F_NickName],[F_HeadIcon],[F_QuickQuery]
                                  ,[F_SimpleSpelling],[F_Gender],[F_Birthday],[F_Mobile],[F_Telephone],[F_Email],[F_OICQ],[F_WeChat],[F_MSN],[F_CompanyId]
                                  ,[F_DepartmentId],[F_SecurityLevel],[F_OpenId],[F_Question],[F_AnswerQuestion],[F_CheckOnLine],[F_AllowStartTime]
                                  ,[F_AllowEndTime],[F_LockStartDate],[F_LockEndDate],[F_SortCode],[F_DeleteMark],[F_EnabledMark],[F_Description],[F_CreateDate]
                                  ,[F_CreateUserId],[F_CreateUserName],[F_ModifyDate],[F_ModifyUserId],[F_ModifyUserName],[F_IDCard],[F_PrimaryOrganization]
                                  ,[F_SecondaryOrganization],[F_TertiaryOrganization],[F_FourLevelOrganization],[F_FiveLevelOrganization],[F_SixLevelOrganization]
                                  ,[F_RecruitmentChannels],[F_Entrydate],[F_ConfirmationDate],[F_DepartureDate],[F_Education],[F_SalaryMethod],[F_PayModel],[F_WorkingSystem]
                                  ,[F_BankCardNumber],[F_BankDeposit],[F_DateHoldingPost],[F_IsTrainingAgreement],[F_StartDateService],[F_EndDateService],[F_EmployeeNature]
                                  ,[F_EmployeeNatureChangeDate],[F_PieceworkType],[F_TimeBecomeRegular],[F_TimeShiftWorkSystem],[F_TypesResignation],[F_MakeUpTime]
                                  ,[F_PostId],[F_SalaryCalculation],[F_Age],[F_DocumentType],[F_NationAlity],[F_Nation],[F_RRNature],[F_PoliticalOutlook],[F_MaritalStatus]
                                  ,[F_NativePlace],[F_OnJobStatus],[F_IDCardStartDate],[F_IDCardEndDate],[F_OneCardNumber],[F_SalaryStructureType],[F_SalaryType],[F_PersonnelCategory]
                                  ,[F_JoiningGroupDate],[F_EntryChannel],[F_OfflineDate],[F_InternalCode],[F_InternalName],[F_InternalCompany],[F_LaborRecruitmentDate]
                                  ,[F_RecruitmentCompany],[F_GraduationUniversitie],[F_MajorStudied],[F_EducationStartDate],[F_EducationEndDate],[F_EducationalMode]
                                  ,[F_ForeignLanguageLevel],[F_IsQualified],[F_QualificationName],[F_GetTime],[F_InternalTitleType],[F_InternalTitle],[F_InternalTitleDate]
                                  ,[F_SocialTitleType],[F_SocialTitle],[F_SocialTitleDate],[F_IDCardAddress],[F_PermanentAddress],[F_ResidentialAddress],[F_CurrentAddress]
                                  ,[F_EmergencyContact],[F_EContactRelationship],[F_EContactNumber],[F_ContactAddress],[F_laborContractStartDate],[F_laborContractEndDate]
                                  ,[F_LaborContractStatus],[F_AttendanceDeadline],[F_IsEsignationCertificate],[F_Depreciation],[F_UserState]
                               FROM [HYDatabase].[dbo].[lr_base_user]";
                var wtsUserList = await hRDatabase.Database.SqlQuery<lr_base_user>(hrsql).ToListAsync();

                return wtsUserList;
            }
        }
    }
}
