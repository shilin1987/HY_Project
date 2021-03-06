using Learun.Application.Organization;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;
using UserInfo = WebApi_EmployeeInformationEntry.Models.UserInfo;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class UserService : BaseService
    {
        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

                            newUser.FirstOrDefault().F_Age = userModel.F_Age;
                            newUser.FirstOrDefault().F_Gender = userModel.F_Gender;
                            newUser.FirstOrDefault().F_DocumentType = userModel.F_DocumentType;
                            newUser.FirstOrDefault().F_IDCard = userModel.F_IDCard;
                            newUser.FirstOrDefault().F_IDCardStartDate = userModel.F_IDCardStartDate;
                            newUser.FirstOrDefault().F_IDCardStartDate = userModel.F_IDCardStartDate;
                            newUser.FirstOrDefault().F_IDCardEndDate = userModel.F_IDCardEndDate;
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

                            var isSave = hYDatabase.SaveChanges();
                            if (isSave > 0)
                            {
                                result.code = ResponseCode.success;
                                result.info = "保存成功";
                            }
                            else
                            {
                                result.info = "用户信息保存失败";
                            }
                        }
                        else
                        {
                            result.info = "保存失败:未找到此用户信息";
                        }
                    }
                    catch (Exception ex)
                    {
                        result.info = "保存出现异常:" + ex.Message;
                    }
                }
                else
                {
                    result.info = "保存失败:用户信息为空";
                }
            }
            else
            {
                result.info = "保存失败:请求参数为空";
            }

            return result;
        }
        /// <summary>
        /// 保存银行卡号和证件照尾号信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal ApiModel saveIma(Hy_Recruit_Candidates entity)
        {
            var tran = hYDatabase.Database.BeginTransaction();
            try
            {
                hYDatabase.Entry(entity).State = EntityState.Modified;
                //更改操作表
                Hy_Recruit_ProcessOperation prentity =  hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == entity.F_UserId && e.OperationContent== "上传证件照等信息" && e.OperationStatus == 0).FirstOrDefault();
                if (prentity != null)
                {
                    prentity.OperationStatus = 1;
                    prentity.OperationTime = DateTime.Now;
                    prentity.Operator = entity.F_UserId;
                    hYDatabase.Entry(prentity).State = EntityState.Modified;

                    Hy_Recruit_ProcessOperation nextNode = new Hy_Recruit_ProcessOperation();
                    nextNode.ID = Guid.NewGuid().ToString();
                    nextNode.OperationStatus = 0;
                    nextNode.OperationTime = DateTime.Now;
                    nextNode.SubProcessId = "8";
                    nextNode.OperationContent = "上传信息审核";
                    nextNode.CandidatesId = entity.F_UserId;
                    hYDatabase.Hy_Recruit_ProcessOperation.Add(nextNode);
                    hYDatabase.SaveChanges();
                    tran.Commit();
                    result.code = ResponseCode.success;
                    result.info = "信息保存成功";

                }
                else
                {
                    result.code = ResponseCode.fail;
                    result.info = "信息保存失败,系统未查到该人员上传证件照等信息节点信息";
                }
            }
            catch (Exception e)
            {

                tran.Rollback();
                result.code = ResponseCode.fail;
                result.info = "信息保存失败,"+e.Message;
            }
            return result;
        }

        public ApiModel SaveInformation(UserViewGenModele user)
        {
            try
            {
                if (user != null)
                {
                    if (user.data != null)
                    {
                        var userModel = user.data;
                        var newUser = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_IDCard == userModel.F_IDCard);
                        if (newUser.Count() > 0)
                        {
                            var newUserEntity = newUser.FirstOrDefault();
                            newUser.FirstOrDefault().F_Gender = (int)userModel.F_Gender;
                            newUser.FirstOrDefault().F_DocumentType = userModel.F_DocumentType;
                            newUser.FirstOrDefault().F_IDCard = userModel.F_IDCard;
                            newUser.FirstOrDefault().F_Birthday = userModel.F_Birthday;
                            newUser.FirstOrDefault().F_IDCardStartDate = userModel.F_IDCardStartDate;
                            newUser.FirstOrDefault().F_IDCardEndDate = userModel.F_IDCardEndDate;
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

                            //newUser.FirstOrDefault().F_EntryChannel = userModel.F_EntryChannel;
                            newUser.FirstOrDefault().F_Education = userModel.F_Education;
                            newUser.FirstOrDefault().F_GraduationUniversitie = userModel.F_GraduationUniversitie;
                            newUser.FirstOrDefault().F_MajorStudied = userModel.F_MajorStudied;
                            newUser.FirstOrDefault().F_EducationStartDate = userModel.F_EducationStartDate;
                            newUser.FirstOrDefault().F_EducationEndDate = userModel.F_EducationEndDate;

                            newUser.FirstOrDefault().F_ForeignLanguageLevel = userModel.F_ForeignLanguageLevel;
                            // newUser.FirstOrDefault().F_IsQualified = userModel.F_IsQualified;
                            // newUser.FirstOrDefault().F_QualificationName = userModel.F_QualificationName;
                            newUser.FirstOrDefault().F_IDCardAddress = userModel.F_IDCardAddress;
                            // newUser.FirstOrDefault().F_PermanentAddress = userModel.F_PermanentAddress;
                            newUser.FirstOrDefault().F_ResidentialAddress = userModel.F_ResidentialAddress;
                            newUser.FirstOrDefault().F_CurrentAddress = userModel.F_CurrentAddress;
                            newUser.FirstOrDefault().F_EmergencyContact = userModel.F_EmergencyContact;
                            newUser.FirstOrDefault().F_EContactRelationship = userModel.F_EContactRelationship;
                            newUser.FirstOrDefault().F_EContactNumber = userModel.F_EContactNumber;
                            // newUser.FirstOrDefault().F_ContactAddress = userModel.F_ContactAddress;
                            //newUser.FirstOrDefault().F_InternalCode = userModel.F_InternalCode;
                            //newUser.FirstOrDefault().F_InternalName = userModel.F_InternalName;
                            //newUser.FirstOrDefault().F_InternalCompany = userModel.F_InternalCompany;
                            newUser.FirstOrDefault().F_RecruitmentCompany = userModel.F_RecruitmentCompany;
                            newUser.FirstOrDefault().F_OneWorkexperience = userModel.F_OneWorkexperience;
                            newUser.FirstOrDefault().F_TwoWorkexperience = userModel.F_TwoWorkexperience;
                            // hYDatabase.Hy_Recruit_Candidates.u
                            var isSave = hYDatabase.SaveChanges();
                            if (isSave > 0)
                            {
                                result.code = ResponseCode.success;
                                result.info = "保存成功";
                            }
                            else
                            {
                                result.info = "信息保存失败";
                            }
                        }
                        else
                        {
                            result.info = "保存失败:未找到此用户信息";
                        }
                    }

                }
                else
                {
                    result.info = "保存失败:用户信息为空";
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("用户信息保存错误" + e.Message);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="revisePassword"></param>
        /// <returns></returns>
        public ApiModel RevisePassword(RevisePasswordModel revisePassword)
        {
            var userEntity = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_UserId == revisePassword.userId);

            if (userEntity != null && userEntity.Count() > 0)
            {
                //revisePassword.oldpassword = userEntity.FirstOrDefault().F_PWD;
                //string oldPasswordByEncrypt = Md5Helper.Encrypt(DESEncrypt.Encrypt(revisePassword.oldpassword, userEntity.FirstOrDefault().F_Secretkey).ToLower(), 32).ToLower();
                if (userEntity.FirstOrDefault().F_PWD == revisePassword.oldpassword)
                {
                    //    userEntity.FirstOrDefault().F_Secretkey = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower();
                    //    userEntity.FirstOrDefault().F_Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(revisePassword.newpassword, userEntity.FirstOrDefault().F_Secretkey).ToLower(), 32).ToLower();
                    userEntity.FirstOrDefault().F_PWD = revisePassword.newpassword;
                    var isSave = hYDatabase.SaveChanges();
                    if (isSave > 0)
                    {
                        result.code = ResponseCode.success;
                        result.info = "密码修改成功";
                    }
                    else
                    {
                        result.info = "密码修改失败/无修改";
                    }
                }
                else
                {
                    result.info = "旧密码输入有误";
                }
            }
            else
            {
                result.info = "未找到当前登录用户信息";
            }
            return result;
        }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="revisePassword"></param>
    /// <returns></returns>
    public ApiModel getPersonnelInformation(PersonInfoPartDTO userDTO)
    {
        // var userEntity = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_Mobile == userDTO.F_Mobile);

        var sql = @"select t.F_RealName,
                        t.F_DepartmentNmae,
                        t.F_Entrydate,
                        t.F_DocumentType,
                        t.F_IDCard,
                        t.F_MaritalStatus,
                        t.F_Birthday,
                        t.F_Gender,
                        t.F_NativePlace,
                        t.F_ResidentialAddress,
                        t.F_Mobile,
                        t.F_CurrentAddress,
                        t.F_IDCardAddress,
                        t.F_PostName,
                        t.F_RRNature,
                        t.F_Nation,
                        t.F_EducationStartDate,
                        t.F_EducationEndDate,
                        t.F_Education,
                        t.F_GraduationUniversitie,
                        t.F_MajorStudied,
                        t.F_ForeignLanguageLevel,
                        t.F_BankDeposit,
                        t.F_BankCardNumber,
                        t.F_InternalCompany,
                        t.F_InternalCode,
                        t.F_InternalName,
                        t.F_IDCardStartDate,
                        t.F_IDCardEndDate,
                        t.F_PoliticalOutlook,
                        t.F_EmergencyContact,
                        t.F_EContactRelationship,
                        t.F_EContactNumber,
                        t.F_RecruitmentChannels,
                        t.F_OneWorkexperience,
                        t.F_TwoWorkexperience
                     from Hy_Recruit_Candidates t where t.F_Mobile = '" + userDTO.F_Mobile + "' ";

        var list = hYDatabase.Database.SqlQuery<Person>(sql);
        if (list != null && list.Count() > 0)
        {
            result.data = list.FirstOrDefault();
            result.info = "人员信息获取成功";
            result.code = ResponseCode.success;
        }
        else
        {
            result.data = null;
            result.code = ResponseCode.fail;
            result.info = "手机号不存在,请确定是否注册";
        }

        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mobile"></param>
    /// <returns></returns>
    public Hy_Recruit_Candidates getHyEntityInformation(string mobile)
    {
        try
        {
            var entity = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_Mobile == mobile);
            return entity.FirstOrDefault();
        }
        catch (Exception e)
        {
            throw new Exception("根据手机号查询错误！！！,原因" + e.Message);
        }
    }
}
}