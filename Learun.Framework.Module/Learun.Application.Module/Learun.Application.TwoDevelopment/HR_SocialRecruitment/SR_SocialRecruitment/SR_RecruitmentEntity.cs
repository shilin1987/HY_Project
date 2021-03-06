using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-21 11:01
    /// 描 述：SR_SocialRecruitment
    /// </summary>
    public class SR_RecruitmentEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_EnabledMark
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// F_CreateUserId
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// F_ModifyUserName
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// F_ModifyUserId
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// F_DeleteMark
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// F_SortCode
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// F_ModifyDate
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// F_CreateUserName
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// F_CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// F_Description
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// F_ID
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// F_Department
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENT")]
        public string F_Department { get; set; }
        /// <summary>
        /// F_JobName
        /// </summary>
        /// <returns></returns>
        [Column("F_JOBNAME")]
        public string F_JobName { get; set; }
        /// <summary>
        /// F_JonNum
        /// </summary>
        /// <returns></returns>
        [Column("F_JONNUM")]
        public int? F_JonNum { get; set; }
        /// <summary>
        /// F_CurrentJobName
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTJOBNAME")]
        public int? F_CurrentJobName { get; set; }
        /// <summary>
        /// F_DeptMentJonNum
        /// </summary>
        /// <returns></returns>
        [Column("F_DeptMentJonNum")]
        public int? F_DeptMentJonNum { get; set; }
        /// <summary>
        /// F_CurrentDeptMentJonNum
        /// </summary>
        /// <returns></returns>
        [Column("F_CurrentDeptMentJonNum")]
        public int? F_CurrentDeptMentJonNum { get; set; }

        /// <summary>
        /// F_ApplyRecruitNum
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLYRECRUITNUM")]
        public int? F_ApplyRecruitNum { get; set; }
        /// <summary>
        /// F_DegreeOfEmergency
        /// </summary>
        /// <returns></returns>
        [Column("F_DEGREEOFEMERGENCY")]
        public string F_DegreeOfEmergency { get; set; }
        /// <summary>
        /// F_RequirementTypes
        /// </summary>
        /// <returns></returns>
        [Column("F_REQUIREMENTTYPES")]
        public string F_RequirementTypes { get; set; }
        /// <summary>
        /// F_DemandReasonStatement
        /// </summary>
        /// <returns></returns>
        [Column("F_DEMANDREASONSTATEMENT")]
        public string F_DemandReasonStatement { get; set; }
        /// <summary>
        /// F_JobRank
        /// </summary>
        /// <returns></returns>
        [Column("F_JOBRANK")]
        public string F_JobRank { get; set; }
        /// <summary>
        /// F_JobType
        /// </summary>
        /// <returns></returns>
        [Column("F_JOBTYPE")]
        public string F_JobType { get; set; }
        /// <summary>
        /// F_RecommendedSalaryRange
        /// </summary>
        /// <returns></returns>
        [Column("F_RECOMMENDEDSALARYRANGE")]
        public string F_RecommendedSalaryRange { get; set; }
        /// <summary>
        /// F_RecruitmentChannels
        /// </summary>
        /// <returns></returns>
        [Column("F_RECRUITMENTCHANNELS")]
        public string F_RecruitmentChannels { get; set; }
        /// <summary>
        /// F_ExpectedArrivalDate
        /// </summary>
        /// <returns></returns>
        [Column("F_EXPECTEDARRIVALDATE")]
        public string F_ExpectedArrivalDate { get; set; }
        /// <summary>
        /// F_TheSystemTime
        /// </summary>
        /// <returns></returns>
        [Column("F_THESYSTEMTIME")]
        public string F_TheSystemTime { get; set; }
        /// <summary>
        /// F_JobDescriptions
        /// </summary>
        /// <returns></returns>
        [Column("F_JOBDESCRIPTIONS")]
        public string F_JobDescriptions { get; set; }
        /// <summary>
        /// F_MainDuties
        /// </summary>
        /// <returns></returns>
        [Column("F_MAINDUTIES")]
        public string F_MainDuties { get; set; }
        /// <summary>
        /// F_BasicConditions
        /// </summary>
        /// <returns></returns>
        [Column("F_BASICCONDITIONS")]
        public string F_BasicConditions { get; set; }
        /// <summary>
        /// F_SupposedToKnow
        /// </summary>
        /// <returns></returns>
        [Column("F_SUPPOSEDTOKNOW")]
        public string F_SupposedToKnow { get; set; }
        /// <summary>
        /// F_EssentialSkill
        /// </summary>
        /// <returns></returns>
        [Column("F_ESSENTIALSKILL")]
        public string F_EssentialSkill { get; set; }
        /// <summary>
        /// F_CapacityRequirements
        /// </summary>
        /// <returns></returns>
        [Column("F_CAPACITYREQUIREMENTS")]
        public string F_CapacityRequirements { get; set; }
        /// <summary>
        /// F_ExperienceRequirements
        /// </summary>
        /// <returns></returns>
        [Column("F_EXPERIENCEREQUIREMENTS")]
        public string F_ExperienceRequirements { get; set; }
        /// <summary>
        /// F_SpecialRequirements
        /// </summary>
        /// <returns></returns>
        [Column("F_SPECIALREQUIREMENTS")]
        public string F_SpecialRequirements { get; set; }
        /// <summary>
        /// F_DepartmentOfOpinion
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTOFOPINION")]
        public string F_DepartmentOfOpinion { get; set; }
        /// <summary>
        /// F_DepartmentOfOpinionOne
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTOFOPINIONONE")]
        public string F_DepartmentOfOpinionOne { get; set; }
        /// <summary>
        /// F_DepartmentOfOpinionT
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTOFOPINIONT")]
        public string F_DepartmentOfOpinionT { get; set; }
        /// <summary>
        /// F_HumanResources
        /// </summary>
        /// <returns></returns>
        [Column("F_HUMANRESOURCES")]
        public string F_HumanResources { get; set; }
        /// <summary>
        /// F_HumanResourcesOne
        /// </summary>
        /// <returns></returns>
        [Column("F_HUMANRESOURCESONE")]
        public string F_HumanResourcesOne { get; set; }
        /// <summary>
        /// F_HumanResourcesT
        /// </summary>
        /// <returns></returns>
        [Column("F_HUMANRESOURCEST")]
        public string F_HumanResourcesT { get; set; }
        /// <summary>
        /// F_TheSignature_01
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_01")]
        public string F_TheSignature_01 { get; set; }
        /// <summary>
        /// F_TheSignature_02
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_02")]
        public string F_TheSignature_02 { get; set; }
        /// <summary>
        /// F_TheSignature_03
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_03")]
        public string F_TheSignature_03 { get; set; }
        /// <summary>
        /// F_TheSignature_04
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_04")]
        public string F_TheSignature_04 { get; set; }
        /// <summary>
        /// F_TheSignature_05
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_05")]
        public string F_TheSignature_05 { get; set; }
        /// <summary>
        /// F_TheSignature_06
        /// </summary>
        /// <returns></returns>
        [Column("F_THESIGNATURE_06")]
        public string F_TheSignature_06 { get; set; }
        /// <summary>
        /// F_Attachment01
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT01")]
        public string F_Attachment01 { get; set; }
        /// <summary>
        /// F_Attachment02
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT02")]
        public string F_Attachment02 { get; set; }
        /// <summary>
        /// F_Attachment03
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT03")]
        public string F_Attachment03 { get; set; }

        /// <summary>
        /// F_ATTACHMENT01NAME
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT01NAME")]
        public string F_Attachment01Name { get; set; }
        /// <summary>
        /// F_ATTACHMENT02NAME
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT02NAME")]
        public string F_Attachment02Name { get; set; }
        /// <summary>
        /// F_ATTACHMENT03NAME
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENT03NAME")]
        public string F_Attachment03Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("F_Status")]
        public string F_Status { get; set; }
        /// <summary>
        /// F_Mes
        /// </summary>
        /// <returns></returns>
        [Column("F_Mes")]
        public string F_Mes { get; set; }

        /// <summary>
        /// F_HrIndicatesOrderNumber
        /// </summary>
        /// <returns></returns>
        [Column("F_HrIndicatesOrderNumber")]
        public string F_HrIndicatesOrderNumber { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ID = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_ID = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

