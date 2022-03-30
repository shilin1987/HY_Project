﻿using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.Platform

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-23 14:41
    /// 描 述：应聘者基础信息报表
    /// </summary>
    public class CandidatesEntity
    {
        #region 实体成员
        /// <summary>
        /// 用户主键
        /// </summary>
        /// <returns></returns>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
       
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [Column("F_IDCARD")]
        public string F_IDCard { get; set; }
        /// <summary>
        /// 招聘渠道
        /// </summary>
        /// <returns></returns>
        [Column("F_RECRUITMENTCHANNELS")]
        public string F_RecruitmentChannels { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        /// <returns></returns>
        [Column("F_EDUCATION")]
        public string F_Education { get; set; }
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
        /// 籍贯
        /// </summary>
        /// <returns></returns>
        [Column("F_NATIVEPLACE")]
        public string F_NativePlace { get; set; }
        /// <summary>
        /// 身份证开始日期
        /// </summary>
        /// <returns></returns>
        [Column("F_IDCARDSTARTDATE")]
        public string F_IDCardStartDate { get; set; }
        /// <summary>
        /// 身份证结束日期
        /// </summary>
        /// <returns></returns>
        [Column("F_IDCARDENDDATE")]
        public string F_IDCardEndDate { get; set; }
        /// <summary>
        /// 一卡通卡号
        /// </summary>
        /// <returns></returns>
        [Column("F_ONECARDNUMBER")]
        public string F_OneCardNumber { get; set; }
        /// <summary>
        /// 入职渠道
        /// </summary>
        /// <returns></returns>
        [Column("F_ENTRYCHANNEL")]
        public string F_EntryChannel { get; set; }
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
        public string F_LaborRecruitmentDate { get; set; }
        /// <summary>
        /// 劳务公司
        /// </summary>
        /// <returns></returns>
        [Column("F_RECRUITMENTCOMPANY")]
        public string F_RecruitmentCompany { get; set; }
        /// <summary>
        /// 身份证地址
        /// </summary>
        /// <returns></returns>
        [Column("F_IDCARDADDRESS")]
        public string F_IDCardAddress { get; set; }
        /// <summary>
        /// 期望入职日期
        /// </summary>
        /// <returns></returns>
        [Column("F_EXPECTEDENTRYDATE")]
        public string F_ExpectedentryDate { get; set; }
        /// <summary>
        /// F_PWD
        /// </summary>
        /// <returns></returns>
        [Column("F_PWD")]
        public string F_PWD { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Column("F_GENDER")]
        public int? F_Gender { get; set; }
        /// <summary>
        /// 住宿情况
        /// </summary>
        /// <returns></returns>
        [Column("F_DORMITORY")]
        public string F_Dormitory { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        /// <returns></returns>
        [Column("F_HEADICON")]
        public string F_HeadIcon { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        /// <returns></returns>
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTNMAE")]
        public string F_DepartmentNmae { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        /// <returns></returns>
        [Column("F_ENTRYDATE")]
        public DateTime? F_Entrydate { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        /// <returns></returns>
        [Column("F_MARITALSTATUS")]
        public string F_MaritalStatus { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        [Column("F_BIRTHDAY")]
        public DateTime? F_Birthday { get; set; }
        /// <summary>
        /// 家庭居住地
        /// </summary>
        /// <returns></returns>
        [Column("F_RESIDENTIALADDRESS")]
        public string F_ResidentialAddress { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTADDRESS")]
        public string F_CurrentAddress { get; set; }
        /// <summary>
        /// 职业名称
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTNAME")]
        public string F_PostName { get; set; }
        /// <summary>
        /// 最高学历开始时间
        /// </summary>
        /// <returns></returns>
        [Column("F_EDUCATIONSTARTDATE")]
        public DateTime? F_EducationStartDate { get; set; }
        /// <summary>
        /// 最高学历结束时间
        /// </summary>
        /// <returns></returns>
        [Column("F_EDUCATIONENDDATE")]
        public DateTime? F_EducationEndDate { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        /// <returns></returns>
        [Column("F_GRADUATIONUNIVERSITIE")]
        public string F_GraduationUniversitie { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        [Column("F_MAJORSTUDIED")]
        public string F_MajorStudied { get; set; }
        /// <summary>
        /// 外语水平
        /// </summary>
        /// <returns></returns>
        [Column("F_FOREIGNLANGUAGELEVEL")]
        public string F_ForeignLanguageLevel { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        /// <returns></returns>
        [Column("F_BANKDEPOSIT")]
        public string F_BankDeposit { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <returns></returns>
        [Column("F_BANKCARDNUMBER")]
        public string F_BankCardNumber { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        /// <returns></returns>
        [Column("F_POLITICALOUTLOOK")]
        public string F_PoliticalOutlook { get; set; }
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
        /// 第一工作经历
        /// </summary>
        /// <returns></returns>
        [Column("F_ONEWORKEXPERIENCE")]
        public string F_OneWorkexperience { get; set; }
        /// <summary>
        /// 第二工作经历
        /// </summary>
        /// <returns></returns>
        [Column("F_TWOWORKEXPERIENCE")]
        public string F_TwoWorkexperience { get; set; }
        /// <summary>
        /// 面试官
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
          
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
        }
        #endregion
    }
}

