using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.Web
{
    /// <summary>
    /// 二维码信息完善
    /// </summary>
  public  class UserInformationPerfectionModel
    {
        public string F_UserId { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int F_Age { get; set; }
        public int F_Gender { get; set; }
        public string F_DocumentType { get; set; }
        public string F_IDCard { get; set; }
        /// <summary>
        /// 证件开始时间
        /// </summary>
        public DateTime F_IDCardStartDate { get; set; }
        /// <summary>
        /// 证件结束时间
        /// </summary>
        public DateTime F_IDCardEndDate { get; set; }
        public string F_NationAlity { get; set; }
        public string F_Nation { get; set; }
        public string F_RRNature { get; set; }
        public string F_Mobile { get; set; }
        public string F_PoliticalOutlook { get; set; }
        public string F_MaritalStatus { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string F_NativePlace { get; set; }
        public string F_BankCardNumber { get; set; }
        public string F_BankDeposit { get; set; }
        /// <summary>
        /// 岗位ID
        /// </summary>
        public string F_PostId { get; set; }
        public DateTime F_Entrydate { get; set; }
        public DateTime F_JoiningGroupDate { get; set; }
        /// <summary>
        /// 入职渠道
        /// </summary>
        public string F_EntryChannel { get; set; }
        public string F_Education { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string F_GraduationUniversitie { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string F_MajorStudied { get; set; }
        /// <summary>
        /// 最高学历入学时间
        /// </summary>
        public DateTime F_EducationStartDate { get; set; }
        /// <summary>
        /// 毕业时间
        /// </summary>
        public DateTime F_EducationEndDate { get; set; }
        /// <summary>
        /// 教育方式
        /// </summary>
        public string F_EducationalMode { get; set; }
        /// <summary>
        /// 外语水平
        /// </summary>
        public string F_ForeignLanguageLevel { get; set; }
        /// <summary>
        /// 是否获取资格证书
        /// </summary>
        public int F_IsQualified { get; set; }
        /// <summary>
        /// 身份证地址
        /// </summary>
        public string F_IDCardAddress { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string F_PermanentAddress { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        public string F_ResidentialAddress { get; set; }
        /// <summary>
        /// 现住地址
        /// </summary>
        public string F_CurrentAddress { get; set; }
        /// <summary>
        /// 紧急联系人
        /// </summary>
        public string F_EmergencyContact { get; set; }
        /// <summary>
        /// 和紧急联系人关系
        /// </summary>
        public string F_EContactRelationship { get; set; }
        /// <summary>
        /// 紧急联系人电话
        /// </summary>
        public string F_EContactNumber { get; set; }
        /// <summary>
        /// 紧急联系地址
        /// </summary>
        public string F_ContactAddress { get; set; }
    }
}
