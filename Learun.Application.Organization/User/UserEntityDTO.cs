using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.Organization
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.04
    /// 描 述：用户数据库实体类
    /// </summary>
    public class UserEntityDTO
    {
        #region 实体成员 
        /// <summary> 
        /// 用户主键 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary> 
        /// 工号 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary> 
        /// 登录账户 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ACCOUNT")]
        public string F_Account { get; set; }
        /// <summary> 
        /// 登录密码 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PASSWORD")]
        public string F_Password { get; set; }
        /// <summary> 
        /// 密码秘钥 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SECRETKEY")]
        public string F_Secretkey { get; set; }
        /// <summary> 
        /// 真实姓名 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 工号
        /// </summary>	
        [Column("F_AGE")]
        public int? F_Age { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>	
        [Column("F_NICKNAME")]
        public string F_NickName { get; set; }
        /// <summary> 
        /// 头像 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_HEADICON")]
        public string F_HeadIcon { get; set; }
        /// <summary> 
        /// 快速查询 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_QUICKQUERY")]
        public string F_QuickQuery { get; set; }
        /// <summary> 
        /// 简拼 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SIMPLESPELLING")]
        public string F_SimpleSpelling { get; set; }
        /// <summary> 
        /// 性别 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_GENDER")]
        public string F_Gender { get; set; }
        /// <summary> 
        /// 生日 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_BIRTHDAY")]
        public DateTime? F_Birthday { get; set; }
        /// <summary> 
        /// 手机 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        /// <summary> 
        /// 电话 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TELEPHONE")]
        public string F_Telephone { get; set; }
        /// <summary> 
        /// 电子邮件 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EMAIL")]
        public string F_Email { get; set; }
        /// <summary> 
        /// QQ号 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OICQ")]
        public string F_OICQ { get; set; }
        /// <summary> 
        /// 微信号 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_WECHAT")]
        public string F_WeChat { get; set; }
        /// <summary> 
        /// MSN 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MSN")]
        public string F_MSN { get; set; }
        /// <summary> 
        /// 机构主键 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary> 
        /// 部门主键   重复去掉该字段 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary> 
        /// 安全级别 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SECURITYLEVEL")]
        public int? F_SecurityLevel { get; set; }
        /// <summary> 
        /// 单点登录标识 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OPENID")]
        public int? F_OpenId { get; set; }
        /// <summary> 
        /// 密码提示问题 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_QUESTION")]
        public string F_Question { get; set; }
        /// <summary> 
        /// 密码提示答案 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ANSWERQUESTION")]
        public string F_AnswerQuestion { get; set; }
        /// <summary> 
        /// 允许多用户同时登录 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CHECKONLINE")]
        public int? F_CheckOnLine { get; set; }
        /// <summary> 
        /// 允许登录时间开始 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ALLOWSTARTTIME")]
        public DateTime? F_AllowStartTime { get; set; }
        /// <summary> 
        /// 允许登录时间结束 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ALLOWENDTIME")]
        public DateTime? F_AllowEndTime { get; set; }
        /// <summary> 
        /// 暂停用户开始日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LOCKSTARTDATE")]
        public DateTime? F_LockStartDate { get; set; }
        /// <summary> 
        /// 暂停用户结束日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LOCKENDDATE")]
        public DateTime? F_LockEndDate { get; set; }
        /// <summary> 
        /// 排序码 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary> 
        /// 删除标记 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary> 
        /// 有效标志 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary> 
        /// 备注 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary> 
        /// 创建日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary> 
        /// 创建用户主键 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary> 
        /// 创建用户 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary> 
        /// 修改日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary> 
        /// 修改用户主键 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary> 
        /// 修改用户 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary> 
        /// 证件号码 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_IDCARD")]
        public string F_IDCard { get; set; }
        /// <summary> 
        /// 一级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PRIMARYORGANIZATION")]
        public string F_PrimaryOrganization { get; set; }
        /// <summary> 
        /// 二级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SECONDARYORGANIZATION")]
        public string F_SecondaryOrganization { get; set; }
        /// <summary> 
        /// 三级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TERTIARYORGANIZATION")]
        public string F_TertiaryOrganization { get; set; }
        /// <summary> 
        /// 四级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_FOURLEVELORGANIZATION")]
        public string F_FourLevelOrganization { get; set; }
        /// <summary> 
        /// 五级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_FIVELEVELORGANIZATION")]
        public string F_FiveLevelOrganization { get; set; }
        /// <summary> 
        /// 六级组织 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SIXLEVELORGANIZATION")]
        public string F_SixLevelOrganization { get; set; }
        /// <summary> 
        /// 招聘渠道 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_RECRUITMENTCHANNELS")]
        public string F_RecruitmentChannels { get; set; }
        /// <summary> 
        /// 入职日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ENTRYDATE")]
        public DateTime? F_Entrydate { get; set; }
        /// <summary> 
        /// 转正日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CONFIRMATIONDATE")]
        public DateTime? F_ConfirmationDate { get; set; }
        /// <summary> 
        /// 离职日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DEPARTUREDATE")]
        public DateTime? F_DepartureDate { get; set; }
        /// <summary> 
        /// 学历 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EDUCATION")]
        public string F_Education { get; set; }
        /// <summary> 
        /// 岗级 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SALARYMETHOD")]
        public string F_SalaryMethod { get; set; }
        /// <summary> 
        /// 岗类 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PAYMODEL")]
        public string F_PayModel { get; set; }
        /// <summary> 
        /// 上班制度 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_WORKINGSYSTEM")]
        public string F_WorkingSystem { get; set; }
        /// <summary> 
        /// 银行卡卡号 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_BANKCARDNUMBER")]
        public string F_BankCardNumber { get; set; }
        /// <summary> 
        /// 银行卡开户行 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_BANKDEPOSIT")]
        public string F_BankDeposit { get; set; }
        /// <summary> 
        /// 担任本岗位日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DATEHOLDINGPOST")]
        public DateTime? F_DateHoldingPost { get; set; }
        /// <summary> 
        /// 是否有培训协议 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ISTRAININGAGREEMENT")]
        public string F_IsTrainingAgreement { get; set; }
        /// <summary> 
        /// 服务期开始时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_STARTDATESERVICE")]
        public DateTime? F_StartDateService { get; set; }
        public DateTime? F_EndDateService { get; set; }
        /// <summary> 
        /// 员工性质 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EMPLOYEENATURE")]
        public string F_EmployeeNature { get; set; }
        /// <summary> 
        /// 员工性质变化时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EMPLOYEENATURECHANGEDATE")]
        public DateTime? F_EmployeeNatureChangeDate { get; set; }
        /// <summary> 
        /// 计件类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PIECEWORKTYPE")]
        public string F_PieceworkType { get; set; }
        /// <summary> 
        /// 转正时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TIMEBECOMEREGULAR")]
        public DateTime? F_TimeBecomeRegular { get; set; }
        /// <summary> 
        /// 上班制度转换时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TIMESHIFTWORKSYSTEM")]
        public DateTime? F_TimeShiftWorkSystem { get; set; }
        /// <summary> 
        /// 离职类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TYPESRESIGNATION")]
        public string F_TypesResignation { get; set; }
        /// <summary> 
        /// 补办离职手续时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MAKEUPTIME")]
        public DateTime? F_MakeUpTime { get; set; }
        /// <summary> 
        /// 岗位 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_POSTID")]
        public string F_PostId { get; set; }
        /// <summary> 
        /// 薪资计算方式 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SALARYCALCULATION")]
        public string F_SalaryCalculation { get; set; }
       
        /// <summary> 
        /// 证件类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DOCUMENTTYPE")]
        public string F_DocumentType { get; set; }
        /// <summary> 
        /// 国籍 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_NATIONALITY")]
        public string F_NationAlity { get; set; }
        /// <summary> 
        /// 民族 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_NATION")]
        public string F_Nation { get; set; }
        /// <summary> 
        /// 户籍性质 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_RRNATURE")]
        public string F_RRNature { get; set; }
        /// <summary> 
        /// 政治面貌 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_POLITICALOUTLOOK")]
        public string F_PoliticalOutlook { get; set; }
        /// <summary> 
        /// 婚姻状况 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MARITALSTATUS")]
        public string F_MaritalStatus { get; set; }
        /// <summary> 
        /// 籍贯 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_NATIVEPLACE")]
        public string F_NativePlace { get; set; }
        /// <summary> 
        /// 在职状态 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ONJOBSTATUS")]
        public string F_OnJobStatus { get; set; }
        /// <summary> 
        /// 证件开始日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_IDCARDSTARTDATE")]
        public DateTime? F_IDCardStartDate { get; set; }
        /// <summary> 
        /// 证件结束日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_IDCARDENDDATE")]
        public DateTime? F_IDCardEndDate { get; set; }
        /// <summary> 
        /// 一卡通卡号 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ONECARDNUMBER")]

        public string F_OneCardNumber { get; set; }
        /// <summary> 
        /// 薪酬结构类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SALARYSTRUCTURETYPE")]
        public string F_SalaryStructureType { get; set; }
        /// <summary> 
        /// 薪酬类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SALARYTYPE")]
        public string F_SalaryType { get; set; }
        /// <summary> 
        /// 人员类别 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PERSONNELCATEGORY")]
        public string F_PersonnelCategory { get; set; }
        /// <summary> 
        /// 入职集团日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_JOININGGROUPDATE")]
        public DateTime? F_JoiningGroupDate { get; set; }
        /// <summary> 
        /// 入职渠道 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ENTRYCHANNEL")]
        public string F_EntryChannel { get; set; }
        /// <summary> 
        /// 下线日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OFFLINEDATE")]
        public string F_OfflineDate { get; set; }
        /// <summary> 
        /// 内部推荐人编码 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALCODE")]
        public string F_InternalCode { get; set; }
        /// <summary> 
        /// 内部推荐人姓名 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALNAME")]
        public string F_InternalName { get; set; }
        /// <summary> 
        /// 内部推荐人公司 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALCOMPANY")]
        public string F_InternalCompany { get; set; }
        /// <summary> 
        /// 劳务转自招日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LABORRECRUITMENTDATE")]
        public DateTime? F_LaborRecruitmentDate { get; set; }
        /// <summary> 
        /// 代招公司 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_RECRUITMENTCOMPANY")]
        public string F_RecruitmentCompany { get; set; }
        /// <summary> 
        /// 毕业院校 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_GRADUATIONUNIVERSITIE")]
        public string F_GraduationUniversitie { get; set; }
        /// <summary> 
        /// 所学专业 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MAJORSTUDIED")]
        public string F_MajorStudied { get; set; }
        /// <summary> 
        /// 最高学历开始日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EDUCATIONSTARTDATE")]
        public DateTime? F_EducationStartDate { get; set; }
        /// <summary> 
        /// 最高学历结束日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EDUCATIONENDDATE")]
        public DateTime? F_EducationEndDate { get; set; }
        /// <summary> 
        /// 教育方式 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EDUCATIONALMODE")]
        public string F_EducationalMode { get; set; }
        /// <summary> 
        /// 外语水平 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_FOREIGNLANGUAGELEVEL")]
        public string F_ForeignLanguageLevel { get; set; }
        /// <summary> 
        /// 是否获取职业资格认证 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ISQUALIFIED")]
        public string F_IsQualified { get; set; }
        /// <summary> 
        /// 获取职业资格认证名称 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_QUALIFICATIONNAME")]
        public string F_QualificationName { get; set; }
        /// <summary> 
        /// 获取（职业资格认证）日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_GETTIME")]
        public string F_GetTime { get; set; }
        /// <summary> 
        /// 内部职称类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALTITLETYPE")]
        public string F_InternalTitleType { get; set; }
        /// <summary> 
        /// 内部职称 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALTITLE")]
        public string F_InternalTitle { get; set; }
        /// <summary> 
        /// 内部职称获取时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_INTERNALTITLEDATE")]
        public DateTime? F_InternalTitleDate { get; set; }
        /// <summary> 
        /// 社会职称类型 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SOCIALTITLETYPE")]
        public string F_SocialTitleType { get; set; }
        /// <summary> 
        /// 社会职称 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SOCIALTITLE")]
        public string F_SocialTitle { get; set; }
        /// <summary> 
        /// 社会职称获取时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SOCIALTITLEDATE")]
        public DateTime? F_SocialTitleDate { get; set; }
        /// <summary> 
        /// 身份证地址 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_IDCARDADDRESS")]
        public string F_IDCardAddress { get; set; }
        /// <summary> 
        /// 户籍地址 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PERMANENTADDRESS")]
        public string F_PermanentAddress { get; set; }
        /// <summary> 
        /// 居住地址 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_RESIDENTIALADDRESS")]
        public string F_ResidentialAddress { get; set; }
        /// <summary> 
        /// 现住地址 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CURRENTADDRESS")]
        public string F_CurrentAddress { get; set; }
        /// <summary> 
        /// 紧急联系人 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EMERGENCYCONTACT")]
        public string F_EmergencyContact { get; set; }
        /// <summary> 
        /// 紧急联系人关系 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ECONTACTRELATIONSHIP")]
        public string F_EContactRelationship { get; set; }
        /// <summary> 
        /// 紧急联系人电话 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ECONTACTNUMBER")]
        public string F_EContactNumber { get; set; }
        /// <summary> 
        /// 联系地址 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CONTACTADDRESS")]
        public string F_ContactAddress { get; set; }
        /// <summary> 
        /// 劳动合同开始时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LABORCONTRACTSTARTDATE")]
        public DateTime? F_laborContractStartDate { get; set; }
        /// <summary> 
        /// 劳动合同结束时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LABORCONTRACTENDDATE")]
        public DateTime? F_laborContractEndDate { get; set; }
        /// <summary> 
        /// 劳动合同状态 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LABORCONTRACTSTATUS")]
        public string F_LaborContractStatus { get; set; }
        /// <summary> 
        /// 考勤截止日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ATTENDANCEDEADLINE")]
        public DateTime? F_AttendanceDeadline { get; set; }
        /// <summary> 
        /// 离职证明是否开具 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ISESIGNATIONCERTIFICATE")]
        public string F_IsEsignationCertificate { get; set; }
        /// <summary> 
        /// 折旧处理 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DEPRECIATION")]
        public string F_Depreciation { get; set; }
        /// <summary> 
        /// 人员状态
        /// </summary> 
        /// <returns></returns> 
        [Column("F_USERSTATE")]
        public string F_UserState { get; set; }
        #endregion


        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;

            this.F_UserId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_DeleteMark = 0;
            this.F_EnabledMark = 1;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void Modify(string keyValue)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;

            this.F_UserId = keyValue;
            this.F_ModifyDate = DateTime.Now;
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 登录信息
        /// </summary>
        [NotMapped]
        public string LoginMsg { get; set; }
        /// <summary>
        /// 登录状态
        /// </summary>
        [NotMapped]
        public bool LoginOk { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [NotMapped]
        public string department { get; set; }
        /// <summary>
        /// 最小组织
        /// </summary>
        [NotMapped]
        public string minDepartment { get; set; }
        /// <summary>
        /// 人员状态
        /// </summary>
        [NotMapped]
        public string userState { get; set; }
        /// 在职状态
        /// </summary>
        [NotMapped]
        public string OnJobStatus { get; set; }
        #endregion
    }
}
