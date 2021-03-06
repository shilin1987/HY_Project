using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EmployeeInformationEntry.Models
{
    public class Person
    {
        public string F_RealName { get; set; }
        public string F_DepartmentNmae { get; set; }
        public DateTime? F_Entrydate { get; set; }
        public string F_DocumentType { get; set; }
        public string F_IDCard { get; set; }
        public string F_MaritalStatus { get; set; }
        public DateTime? F_Birthday { get; set; }
        public int? F_Gender { get; set; }
        public string F_NativePlace { get; set; }
        public string F_ResidentialAddress { get; set; }
        public string F_Mobile { get; set; }
        public string F_CurrentAddress { get; set; }
        public string F_IDCardAddress { get; set; }
        public string F_PostName { get; set; }
        public string F_RRNature { get; set; }
        public string F_Nation { get; set; }
        public DateTime? F_EducationStartDate { get; set; }
        public DateTime? F_EducationEndDate { get; set; }
        public string F_Education { get; set; }
        public string F_GraduationUniversitie { get; set; }
        public string F_MajorStudied { get; set; }
        public string F_ForeignLanguageLevel { get; set; }
        public string F_BankDeposit { get; set; }
        public string F_BankCardNumber { get; set; }
        public string F_InternalCompany { get; set; }
        public string F_InternalCode { get; set; }
        public string F_InternalName { get; set; }
        public string F_IDCardStartDate { get; set; }
        public string F_IDCardEndDate { get; set; }
        public string F_PoliticalOutlook { get; set; }
        public string F_EmergencyContact { get; set; }
        public string F_EContactRelationship { get; set; }
        public string F_EContactNumber { get; set; }
        public string F_RecruitmentChannels { get; set; }
        public string F_OneWorkexperience { get; set; }
        public string F_TwoWorkexperience { get; set; }
    }
}