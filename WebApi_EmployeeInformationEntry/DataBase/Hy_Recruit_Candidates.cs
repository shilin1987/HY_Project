//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi_EmployeeInformationEntry.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hy_Recruit_Candidates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hy_Recruit_Candidates()
        {
            this.Hy_Recruit_ProcessOperation = new HashSet<Hy_Recruit_ProcessOperation>();
        }
    
        public string F_UserId { get; set; }
        public string F_RealName { get; set; }
        public string F_Mobile { get; set; }
        public string F_Description { get; set; }
        public Nullable<System.DateTime> F_CreateDate { get; set; }
        public string F_CreateUserName { get; set; }
        public Nullable<System.DateTime> F_ModifyDate { get; set; }
        public string F_ModifyUserName { get; set; }
        public string F_IDCard { get; set; }
        public string F_RecruitmentChannels { get; set; }
        public string F_Education { get; set; }
        public string F_DocumentType { get; set; }
        public string F_NationAlity { get; set; }
        public string F_Nation { get; set; }
        public string F_RRNature { get; set; }
        public string F_NativePlace { get; set; }
        public string F_IDCardStartDate { get; set; }
        public string F_IDCardEndDate { get; set; }
        public string F_OneCardNumber { get; set; }
        public string F_EntryChannel { get; set; }
        public string F_InternalCode { get; set; }
        public string F_InternalName { get; set; }
        public string F_InternalCompany { get; set; }
        public string F_LaborRecruitmentDate { get; set; }
        public string F_RecruitmentCompany { get; set; }
        public string F_IDCardAddress { get; set; }
        public string F_ExpectedentryDate { get; set; }
        public string F_PWD { get; set; }
        public Nullable<int> F_Gender { get; set; }
        public string F_Dormitory { get; set; }
        public string F_HeadIcon { get; set; }
        public string F_EnCode { get; set; }
        public string F_DepartmentNmae { get; set; }
        public Nullable<System.DateTime> F_Entrydate { get; set; }
        public string F_MaritalStatus { get; set; }
        public Nullable<System.DateTime> F_Birthday { get; set; }
        public string F_ResidentialAddress { get; set; }
        public string F_CurrentAddress { get; set; }
        public string F_PostName { get; set; }
        public Nullable<System.DateTime> F_EducationStartDate { get; set; }
        public Nullable<System.DateTime> F_EducationEndDate { get; set; }
        public string F_GraduationUniversitie { get; set; }
        public string F_MajorStudied { get; set; }
        public string F_ForeignLanguageLevel { get; set; }
        public string F_BankDeposit { get; set; }
        public string F_BankCardNumber { get; set; }
        public string F_PoliticalOutlook { get; set; }
        public string F_EmergencyContact { get; set; }
        public string F_EContactRelationship { get; set; }
        public string F_EContactNumber { get; set; }
        public string F_OneWorkexperience { get; set; }
        public string F_TwoWorkexperience { get; set; }
        public Nullable<int> F_Register { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hy_Recruit_ProcessOperation> Hy_Recruit_ProcessOperation { get; set; }
    }
}