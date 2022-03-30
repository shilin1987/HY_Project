using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Learun.Application.TwoDevelopment.HR_WorkPermitModule
{
    public class WorkPermitModuleCreateOABLL<T> : WorkPermitModuleCreateOAIBLL<T> where T : class
    {
        public ReturnComment crateOAandHRForm(T t) 
        {   
            try
            {
                WorkingCertificateService wcs = new WorkingCertificateService();
                Wl_ChangeShiftsIBLL wc = new Wl_ChangeShiftsBLL();
                WL_NormalShiftIBLL wn = new WL_NormalShiftBLL();
                // Wl_ChangeShiftsIBLL wc = new Wl_ChangeShiftsBLL();
                ReturnComment rc = new ReturnComment();
                JObject json = new JObject();
                UserIBLL userInfo = new UserBLL(); ;
                Dictionary<string, string> dr = new Dictionary<string, string>();
                Dictionary<string, decimal> drOther = new Dictionary<string, decimal>();
                Type t1 = typeof(T);
                HEADER head = new HEADER();
                dynamic dynamicEnity = t;
                if ("Hy_Wl_NormalShiftEntity".Equals(t1.Name))
                {
                    if ("生产作业类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "0";
                    }
                    else if ("品质检验类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "1";
                    }
                    else if ("倒班工程类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "2";
                    }
                    else if ("研发类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "3";
                    }
                    else if("其他".Equals(dynamicEnity.F_PersonnelCategory)){
                        head.F_PersonnelCategory = "4";
                    }
                    else
                    {
                        head.F_PersonnelCategory = "";
                    }

                    UserEntity user1
                         = userInfo.GetEntityByUserId(dynamicEnity.F_UserID);
           
                    head.F_UserID = user1.F_Account;
                    string deptname = wcs.getDeptInfo(user1.F_FourLevelOrganization);
                    head.F_FourLevelOrganization = string.IsNullOrEmpty(deptname)? "": deptname;
                    head.F_Education = string.IsNullOrEmpty(user1.F_Education) || "null".Equals(user1.F_Education) ? "" : user1.F_Education;
                   // head.F_PersonnelCategory = string.IsNullOrEmpty(dynamicEnity.F_PersonnelCategory) || "null".Equals(dynamicEnity.F_PersonnelCategory) ? "" : dynamicEnity.F_PersonnelCategory;
                    head.F_Entrydate = string.IsNullOrEmpty(dynamicEnity.F_AppointmentDate) || "null".Equals(dynamicEnity.F_AppointmentDate) ? "" : dynamicEnity.F_AppointmentDate;
                    head.F_ProbationPeriod = string.IsNullOrEmpty(dynamicEnity.F_ProbationPeriod) || "null".Equals(dynamicEnity.F_ProbationPeriod) ? "" : dynamicEnity.F_ProbationPeriod;
                    head.F_writtenExamination = dynamicEnity.F_writtenExamination;
                    head.F_OperationCapability = dynamicEnity.F_OperationCapability;
                    head.F_workingAttitude = dynamicEnity.F_workingAttitude;
                    head.F_Responsibility = dynamicEnity.F_Responsibility;
                    head.F_SUM = dynamicEnity.F_SUM;
                    head.F_OperationDirector = string.IsNullOrEmpty(dynamicEnity.F_OperationDirector) || "null".Equals(dynamicEnity.F_OperationDirector) ? "" : dynamicEnity.F_OperationDirector;
                    head.F_OperationCharge = string.IsNullOrEmpty(dynamicEnity.F_OperationCharge) || "null".Equals(dynamicEnity.F_OperationCharge) ? "" : dynamicEnity.F_OperationCharge;
                    head.F_QualityManagement = string.IsNullOrEmpty(dynamicEnity.F_QualityManagement) || "null".Equals(dynamicEnity.F_QualityManagement) ? "" : dynamicEnity.F_QualityManagement;
                    head.F_HumanResources = string.IsNullOrEmpty(dynamicEnity.F_HumanResources) || "null".Equals(dynamicEnity.F_HumanResources) ? "" : dynamicEnity.F_HumanResources;
                    head.F_NO = string.IsNullOrEmpty(dynamicEnity.F_NO) || "null".Equals(dynamicEnity.F_NO) ? "" : dynamicEnity.F_NO;
                    head.xm = string.IsNullOrEmpty(user1.F_RealName) || "null".Equals(user1.F_RealName) ? "" : user1.F_RealName;
                    head.xb = user1.F_Gender == 1 ? "男" : "女";
                    string deptBmName = wcs.getDeptInfo(user1.F_SecondaryOrganization);
                    head.bm = string.IsNullOrEmpty(deptBmName) ? "" : deptBmName;
                    string postName = wcs.getPostInfo(user1.F_PostId);
                    head.F_PostID = string.IsNullOrEmpty(postName) ? "" : postName;
                    head.F_OperationBPM = "";
                    head.F_AssessmentResults = "-1";
                    head.F_ReasonDescription = "";
                    //考核日期
                    head.F_AssessmentDate = "-1";
                    head.F_OneAssessmentResults = "-1";
                    head.F_TwoAssessmentResults = "-1";
                    head.F_ThreeAssessmentResults = "-1";
                    head.F_FourAssessmentResults = "-1";
                    head.F_FiveAssessmentResults = "-1";
                    head.F_SixAssessmentResults = "-1";
                    head.F_OneReasonDescription = "";
                    head.F_TwoReasonDescription = "";
                    head.F_ThreeReasonDescription = "";
                    head.F_FourReasonDescription = "";
                    head.F_FiveReasonDescription = "";
                    head.F_SixReasonDescription = "";

                }
                else
                {
                    if ("生产作业类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "0";
                    }
                    else if ("品质检验类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "1";
                    }
                    else if ("倒班工程类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "2";
                    }
                    else if ("研发类".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "3";
                    }
                    else if ("其他".Equals(dynamicEnity.F_PersonnelCategory))
                    {
                        head.F_PersonnelCategory = "4";
                    }
                    else
                    {
                        head.F_PersonnelCategory = "";
                    }
                    UserEntity user1
                         = userInfo.GetEntityByUserId(dynamicEnity.F_UserID);
                    //IEnumerable<UserEntityDTO> user = wc.GetUserList(user1.F_Account);
                    //UserEntityDTO userEntiy = user.ToList()[0];
                    head.F_UserID = user1.F_Account;

                    string deptname = wcs.getDeptInfo(user1.F_FourLevelOrganization);
                    head.F_FourLevelOrganization = string.IsNullOrEmpty(deptname) ? "" : deptname;
                    head.F_Education = string.IsNullOrEmpty(user1.F_Education) || "null".Equals(user1.F_Education) ? "" : user1.F_Education;
                   // head.F_PersonnelCategory = string.IsNullOrEmpty(user1.F_PersonnelCategory) || "null".Equals(dynamicEnity.F_PersonnelCategory) ? "" : dynamicEnity.F_PersonnelCategory;
                    head.F_Entrydate = dynamicEnity.F_TrialDate;
                    head.F_ProbationPeriod = "";
                    head.F_writtenExamination = dynamicEnity.F_writtenExamination;
                    head.F_OperationCapability = dynamicEnity.F_OperationCapability;
                    head.F_workingAttitude = dynamicEnity.F_workingAttitude;
                    head.F_Responsibility = dynamicEnity.F_Responsibility;
                    head.F_SUM = dynamicEnity.F_SUM;
                    head.F_OperationDirector = string.IsNullOrEmpty(dynamicEnity.F_OperationDirector) || "null".Equals(dynamicEnity.F_OperationDirector) ? "" : dynamicEnity.F_OperationDirector;
                    head.F_OperationCharge = string.IsNullOrEmpty(dynamicEnity.F_OperationCharge) || "null".Equals(dynamicEnity.F_OperationCharge) ? "" : dynamicEnity.F_OperationCharge;
                    head.F_QualityManagement = string.IsNullOrEmpty(dynamicEnity.F_QualityManagement) || "null".Equals(dynamicEnity.F_QualityManagement) ? "" : dynamicEnity.F_QualityManagement;
                    head.F_HumanResources = string.IsNullOrEmpty(dynamicEnity.F_HumanResources) || "null".Equals(dynamicEnity.F_HumanResources) ? "" : dynamicEnity.F_HumanResources;
                    head.F_NO = string.IsNullOrEmpty(dynamicEnity.F_NO) || "null".Equals(dynamicEnity.F_NO) ? "" : dynamicEnity.F_NO;
                    head.xm = string.IsNullOrEmpty(user1.F_RealName) || "null".Equals(user1.F_RealName) ? "" : user1.F_RealName;
                    head.xb = user1.F_Gender == 1 ? "男" : "女";
                    string deptBmName = wcs.getDeptInfo(user1.F_SecondaryOrganization);
                    head.bm = string.IsNullOrEmpty(deptBmName) ? "" : deptBmName;
                    string postName = wcs.getPostInfo(user1.F_PostId);
                    head.F_PostID = string.IsNullOrEmpty(postName) ? "" : postName;
                    head.F_AssessmentDate = dynamicEnity.F_AssessmentDate.ToString("yyyy-MM-dd");
                    head.F_AssessmentResults = "-1";
                    head.F_ReasonDescription = "";
                    head.F_OperationBPM = "";
                    head.F_OneAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_OneAssessmentResults) || "null".Equals(dynamicEnity.F_OneAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0":"1");
                    head.F_TwoAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_TwoAssessmentResults) || "null".Equals(dynamicEnity.F_TwoAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0" : "1");
                    head.F_ThreeAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_ThreeAssessmentResults) || "null".Equals(dynamicEnity.F_ThreeAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0" : "1");
                    head.F_FourAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_FourAssessmentResults) || "null".Equals(dynamicEnity.F_FourAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0" : "1");
                    head.F_FiveAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_FiveAssessmentResults) || "null".Equals(dynamicEnity.F_FiveAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0" : "1");
                    head.F_SixAssessmentResults = string.IsNullOrEmpty(dynamicEnity.F_SixAssessmentResults) || "null".Equals(dynamicEnity.F_SixAssessmentResults) ? "-1" : ("是".Equals(dynamicEnity.F_OneAssessmentResults) ? "0" : "1");
                    head.F_OneReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_OneReasonDescription) || "null".Equals(dynamicEnity.F_OneReasonDescription) ? "" : dynamicEnity.F_OneReasonDescription;
                    head.F_TwoReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_TwoReasonDescription) || "null".Equals(dynamicEnity.F_TwoReasonDescription) ? "" : dynamicEnity.F_TwoReasonDescription;
                    head.F_ThreeReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_ThreeReasonDescription) || "null".Equals(dynamicEnity.F_ThreeReasonDescription) ? "" : dynamicEnity.F_ThreeReasonDescription;
                    head.F_FourReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_FourReasonDescription) || "null".Equals(dynamicEnity.F_FourReasonDescription) ? "" : dynamicEnity.F_FourReasonDescription;
                    head.F_FiveReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_FiveReasonDescription) || "null".Equals(dynamicEnity.F_FiveReasonDescription) ? "" : dynamicEnity.F_FiveReasonDescription;
                    head.F_SixReasonDescription = string.IsNullOrEmpty(dynamicEnity.F_SixReasonDescription) || "null".Equals(dynamicEnity.F_SixReasonDescription) ? "" : dynamicEnity.F_SixReasonDescription;

                }
                json.Add("HEADER", JToken.FromObject(head));
                json.Add("DETAILS", JToken.FromObject(new object()));

                string url = ConfigurationManager.AppSettings["webServiceurlgenProduct"];

                string jsonStr = JsonNewtonsoft.ToJSON(json).ToString();
                string soap = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:htk=\"http://localhost/htkjjt.webservice.general\">\r\n" +
                "<soapenv:Header/>\r\n" +
                "<soapenv:Body>\r\n" +
                   "<htk:TriggerOaFlow>\r\n" +
                      "<htk:oAContent>"+json+"</htk:oAContent>\r\n" +
                      "<htk:workCode>HYHR_AutoRequest</htk:workCode>\r\n" +
                      "<htk:Caller>HY_HR</htk:Caller>\r\n" +
                      "<htk:Company>华羿</htk:Company>\r\n" +
                      "<htk:FlowCode>35151</htk:FlowCode>\r\n" +
                      "<htk:isNext>true</htk:isNext>\r\n" +
                   "</htk:TriggerOaFlow>\r\n" +
                "</soapenv:Body>\r\n" +
                "</soapenv:Envelope>\r\n" ;
        

                ///获取请求数据拼接请求json体
               // string url = m_WebServiceUrl;
                string result = HttpHelper.Helper.GetSOAPReSource(url, soap);
                //var doc = new XmlDocument();

                if (string.IsNullOrEmpty(result))
                {
                    rc.State = "F";
                    rc.Mes = "创建OA流程失败";
                    dynamicEnity.F_Status = "E";
                    dynamicEnity.F_Mes = "创建OA流程失败";
                    dynamicEnity.F_Description = jsonStr;
                    if ("Hy_Wl_NormalShiftEntity".Equals(t1.Name))
                    {
                        wn.UpdateEntity(dynamicEnity);
                    }
                    else
                    {
                        wc.UpdateEntity(dynamicEnity);
                    }
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(result);//Load加载XML文件，LoadXML加载XML字符串
                    string status = xmlDoc.DocumentElement["soap:Body"]["ns1:TriggerOaFlowResponse"]["ns1:ReturnIfo"]["isSuccess"].InnerXml;
                    string mes = xmlDoc.DocumentElement["soap:Body"]["ns1:TriggerOaFlowResponse"]["ns1:ReturnIfo"]["message"].InnerXml;
                    dynamicEnity.F_Status = status;
                    dynamicEnity.F_Mes = mes;
                    dynamicEnity.F_RequerstDescriptionInfo = soap;
                    if ("Hy_Wl_NormalShiftEntity".Equals(t1.Name))
                    {
                        wn.UpdateEntity((Hy_Wl_NormalShiftEntity)dynamicEnity);
                    }
                    else
                    {
                        wc.UpdateEntity((Hy_Wl_ChangeShiftsEntity)dynamicEnity);
                    }
                    if ("S".Equals(status))
                    {
                        rc.State = "S";
                        rc.Mes = mes;
                    }
                    else
                    {
                        rc.State = "F";
                        rc.Mes = mes;
                    }
                }
                return rc;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
    }
}
