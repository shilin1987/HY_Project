using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webAPI.DataBase;

namespace webAPI.Controllers
{
    public class lr_base_userController : Controller
    {
        private HYDatabaseEntities db = new HYDatabaseEntities();

        // GET: lr_base_user
        public ActionResult Index()
        {
            return View(db.lr_base_user.ToList());
        }

        // GET: lr_base_user/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lr_base_user lr_base_user = db.lr_base_user.Find(id);
            if (lr_base_user == null)
            {
                return HttpNotFound();
            }
            return View(lr_base_user);
        }

        // GET: lr_base_user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lr_base_user/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "F_UserId,F_EnCode,F_Account,F_Password,F_Secretkey,F_RealName,F_NickName,F_HeadIcon,F_QuickQuery,F_SimpleSpelling,F_Gender,F_Birthday,F_Mobile,F_Telephone,F_Email,F_OICQ,F_WeChat,F_MSN,F_CompanyId,F_DepartmentId,F_SecurityLevel,F_OpenId,F_Question,F_AnswerQuestion,F_CheckOnLine,F_AllowStartTime,F_AllowEndTime,F_LockStartDate,F_LockEndDate,F_SortCode,F_DeleteMark,F_EnabledMark,F_Description,F_CreateDate,F_CreateUserId,F_CreateUserName,F_ModifyDate,F_ModifyUserId,F_ModifyUserName,F_IDCard,F_PrimaryOrganization,F_SecondaryOrganization,F_TertiaryOrganization,F_FourLevelOrganization,F_FiveLevelOrganization,F_SixLevelOrganization,F_RecruitmentChannels,F_Entrydate,F_ConfirmationDate,F_DepartureDate,F_Education,F_SalaryMethod,F_PayModel,F_WorkingSystem,F_BankCardNumber,F_BankDeposit,F_DateHoldingPost,F_IsTrainingAgreement,F_StartDateService,F_EndDateService,F_EmployeeNature,F_EmployeeNatureChangeDate,F_PieceworkType,F_TimeBecomeRegular,F_TimeShiftWorkSystem,F_TypesResignation,F_MakeUpTime,F_PostId,F_SalaryCalculation,F_Age,F_DocumentType,F_NationAlity,F_Nation,F_RRNature,F_PoliticalOutlook,F_MaritalStatus,F_NativePlace,F_OnJobStatus,F_IDCardStartDate,F_IDCardEndDate,F_OneCardNumber,F_SalaryStructureType,F_SalaryType,F_PersonnelCategory,F_JoiningGroupDate,F_EntryChannel,F_OfflineDate,F_InternalCode,F_InternalName,F_InternalCompany,F_LaborRecruitmentDate,F_RecruitmentCompany,F_GraduationUniversitie,F_MajorStudied,F_EducationStartDate,F_EducationEndDate,F_EducationalMode,F_ForeignLanguageLevel,F_IsQualified,F_QualificationName,F_GetTime,F_InternalTitleType,F_InternalTitle,F_InternalTitleDate,F_SocialTitleType,F_SocialTitle,F_SocialTitleDate,F_IDCardAddress,F_PermanentAddress,F_ResidentialAddress,F_CurrentAddress,F_EmergencyContact,F_EContactRelationship,F_EContactNumber,F_ContactAddress,F_laborContractStartDate,F_laborContractEndDate,F_LaborContractStatus,F_AttendanceDeadline,F_IsEsignationCertificate,F_Depreciation,F_UserState")] lr_base_user lr_base_user)
        {
            if (ModelState.IsValid)
            {
                db.lr_base_user.Add(lr_base_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lr_base_user);
        }

        // GET: lr_base_user/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lr_base_user lr_base_user = db.lr_base_user.Find(id);
            if (lr_base_user == null)
            {
                return HttpNotFound();
            }
            return View(lr_base_user);
        }

        // POST: lr_base_user/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "F_UserId,F_EnCode,F_Account,F_Password,F_Secretkey,F_RealName,F_NickName,F_HeadIcon,F_QuickQuery,F_SimpleSpelling,F_Gender,F_Birthday,F_Mobile,F_Telephone,F_Email,F_OICQ,F_WeChat,F_MSN,F_CompanyId,F_DepartmentId,F_SecurityLevel,F_OpenId,F_Question,F_AnswerQuestion,F_CheckOnLine,F_AllowStartTime,F_AllowEndTime,F_LockStartDate,F_LockEndDate,F_SortCode,F_DeleteMark,F_EnabledMark,F_Description,F_CreateDate,F_CreateUserId,F_CreateUserName,F_ModifyDate,F_ModifyUserId,F_ModifyUserName,F_IDCard,F_PrimaryOrganization,F_SecondaryOrganization,F_TertiaryOrganization,F_FourLevelOrganization,F_FiveLevelOrganization,F_SixLevelOrganization,F_RecruitmentChannels,F_Entrydate,F_ConfirmationDate,F_DepartureDate,F_Education,F_SalaryMethod,F_PayModel,F_WorkingSystem,F_BankCardNumber,F_BankDeposit,F_DateHoldingPost,F_IsTrainingAgreement,F_StartDateService,F_EndDateService,F_EmployeeNature,F_EmployeeNatureChangeDate,F_PieceworkType,F_TimeBecomeRegular,F_TimeShiftWorkSystem,F_TypesResignation,F_MakeUpTime,F_PostId,F_SalaryCalculation,F_Age,F_DocumentType,F_NationAlity,F_Nation,F_RRNature,F_PoliticalOutlook,F_MaritalStatus,F_NativePlace,F_OnJobStatus,F_IDCardStartDate,F_IDCardEndDate,F_OneCardNumber,F_SalaryStructureType,F_SalaryType,F_PersonnelCategory,F_JoiningGroupDate,F_EntryChannel,F_OfflineDate,F_InternalCode,F_InternalName,F_InternalCompany,F_LaborRecruitmentDate,F_RecruitmentCompany,F_GraduationUniversitie,F_MajorStudied,F_EducationStartDate,F_EducationEndDate,F_EducationalMode,F_ForeignLanguageLevel,F_IsQualified,F_QualificationName,F_GetTime,F_InternalTitleType,F_InternalTitle,F_InternalTitleDate,F_SocialTitleType,F_SocialTitle,F_SocialTitleDate,F_IDCardAddress,F_PermanentAddress,F_ResidentialAddress,F_CurrentAddress,F_EmergencyContact,F_EContactRelationship,F_EContactNumber,F_ContactAddress,F_laborContractStartDate,F_laborContractEndDate,F_LaborContractStatus,F_AttendanceDeadline,F_IsEsignationCertificate,F_Depreciation,F_UserState")] lr_base_user lr_base_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lr_base_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lr_base_user);
        }

        // GET: lr_base_user/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lr_base_user lr_base_user = db.lr_base_user.Find(id);
            if (lr_base_user == null)
            {
                return HttpNotFound();
            }
            return View(lr_base_user);
        }

        // POST: lr_base_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lr_base_user lr_base_user = db.lr_base_user.Find(id);
            db.lr_base_user.Remove(lr_base_user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
