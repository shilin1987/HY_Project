using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using Learun.Application.TwoDevelopment.ReturnModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface
{
    public class HeterogeneousHrToOABLL : HeterogeneousHrToOAIBLL
    {
        ReturnCommon  _return;
      

        #region 构造方法
        public HeterogeneousHrToOABLL()
        {
            _return = new ReturnCommon();
        }
        #endregion

        #region 调用OA接口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ojb"></param>
        /// <returns></returns>
        public ReturnCommon crateOAandHRForm(SR_RecruitmentEntity entity)
        {
            try
            {
                SR_RecruitmentIBLL sr = new  SR_RecruitmentBLL();
          
                //1.查询对应对应实体数据

                ReturnCommon rc = new ReturnCommon();
                DepartmentIBLL dept = new DepartmentBLL();
                UserIBLL user = new UserBLL();
                UserEntity ue = user.GetEntityByUserId(entity.F_CreateUserId);
                JObject json = new JObject();
                Dictionary<string, string> dr = new Dictionary<string, string>();

                Dictionary<string, string> drAttachment = new Dictionary<string, string>();
                //string deptName = dept.GetEntity(entity.F_Department).F_FullName;

                if ("一般".Equals(entity.F_DegreeOfEmergency)) {
                    entity.F_DegreeOfEmergency = "0";
                }
                else if ("紧急".Equals(entity.F_DegreeOfEmergency)) {
                    entity.F_DegreeOfEmergency = "1"; 
                }
                else if ("非常紧急".Equals(entity.F_DegreeOfEmergency)) { 
                    entity.F_DegreeOfEmergency = "2"; 
                }
                else if (string.IsNullOrEmpty(entity.F_DegreeOfEmergency + "") || "null".Equals(entity.F_DegreeOfEmergency + "")) { 
                    entity.F_DegreeOfEmergency = "-1"; 
                }
     

                if ("新增人员".Equals(entity.F_RequirementTypes)) 
                { 
                    entity.F_RequirementTypes = "0"; 
                }
                else if ("离职补缺".Equals(entity.F_RequirementTypes)) {
                    entity.F_RequirementTypes = "1"; 
                }
                else if ("其他".Equals(entity.F_RequirementTypes)) { 
                    entity.F_RequirementTypes = "2"; 
                }
                else { 
                    entity.F_RequirementTypes = "-1"; 
                }
       
                if ("I".Equals(entity.F_JobType)) {
                    entity.F_JobType = "0";
                }
                else if ("Ⅱ".Equals(entity.F_JobType)) {
                    entity.F_JobType = "1"; 
                }
                else if ("Ⅲ".Equals(entity.F_JobType)) { 
                    entity.F_JobType = "2"; 
                }
                else if ("T".Equals(entity.F_JobType)) { 
                    entity.F_JobType = "3"; 
                }
                else { 
                    entity.F_JobType = "-1"; 
                }
         

                if ("社会招聘".Equals(entity.F_RecruitmentChannels)) { 
                    entity.F_RecruitmentChannels = "0"; 
                }
                else if ("内部招聘".Equals(entity.F_RecruitmentChannels)) { 
                    entity.F_RecruitmentChannels = "1"; 
                }
                else if ("其他".Equals(entity.F_RecruitmentChannels)) { 
                    entity.F_RecruitmentChannels = "2";
                }
                else { 
                    entity.F_RecruitmentChannels = "-1"; 
                }
                //string.IsNullOrEmpty
                dr.Add("F_Department", entity.F_Department);
                dr.Add("F_JobName", string.IsNullOrEmpty(entity.F_JobName) || "null".Equals(entity.F_JobName) ? "" : entity.F_JobName);
                dr.Add("F_JoNum", string.IsNullOrEmpty(entity.F_JonNum + "") || "null".Equals(entity.F_JonNum + "") ? "" : entity.F_JonNum + "");
                dr.Add("F_DeptMentJonNum", string.IsNullOrEmpty(entity.F_DeptMentJonNum + "") || "null".Equals(entity.F_DeptMentJonNum + "") ? "" : entity.F_DeptMentJonNum + "");
                dr.Add("F_CurrentDeptMentJonNum", string.IsNullOrEmpty(entity.F_CurrentDeptMentJonNum + "") || "null".Equals(entity.F_CurrentDeptMentJonNum + "") ? "" : entity.F_CurrentDeptMentJonNum + "");
                dr.Add("F_CurrentJobName", string.IsNullOrEmpty(entity.F_CurrentJobName + "") || "null".Equals(entity.F_CurrentJobName + "") ? "" : entity.F_CurrentJobName + "");
                dr.Add("F_ApplyRecruitNum", string.IsNullOrEmpty(entity.F_ApplyRecruitNum + "") || "null".Equals(entity.F_ApplyRecruitNum + "") ? "" : entity.F_ApplyRecruitNum + "");
                dr.Add("F_DegreeOfEmergency", string.IsNullOrEmpty(entity.F_DegreeOfEmergency) || "null".Equals(entity.F_DegreeOfEmergency) ? "" : entity.F_DegreeOfEmergency);
                dr.Add("F_RequirementTypes", string.IsNullOrEmpty(entity.F_RequirementTypes) || "null".Equals(entity.F_RequirementTypes) ? "" : entity.F_RequirementTypes);
                dr.Add("F_DemandReasonStatement", string.IsNullOrEmpty(entity.F_DemandReasonStatement) || "null".Equals(entity.F_DemandReasonStatement) ? "" : entity.F_DemandReasonStatement);
                dr.Add("F_JobRank", string.IsNullOrEmpty(entity.F_JobRank) || "null".Equals(entity.F_JobRank) ? "" : entity.F_JobRank);
                dr.Add("F_JobType", string.IsNullOrEmpty(entity.F_JobType) || "null".Equals(entity.F_JobType) ? "" : entity.F_JobType);
                dr.Add("F_RecommendedSalaryRange", string.IsNullOrEmpty(entity.F_RecommendedSalaryRange) || "null".Equals(entity.F_RecommendedSalaryRange) ? "" : entity.F_RecommendedSalaryRange);
                dr.Add("F_RecruitmentChannels", string.IsNullOrEmpty(entity.F_RecruitmentChannels) || "null".Equals(entity.F_RecruitmentChannels) ? "" : entity.F_RecruitmentChannels);
                dr.Add("F_ExpectedArrivalDate", string.IsNullOrEmpty(entity.F_ExpectedArrivalDate) || "null".Equals(entity.F_ExpectedArrivalDate) ? "" : entity.F_ExpectedArrivalDate);
                dr.Add("F_TheSystemTime", string.IsNullOrEmpty(entity.F_TheSystemTime) || "null".Equals(entity.F_TheSystemTime) ? "" : entity.F_TheSystemTime);
                dr.Add("F_JobDescriptions", string.IsNullOrEmpty(entity.F_JobDescriptions) || "null".Equals(entity.F_JobDescriptions) ? "" : entity.F_JobDescriptions);
                dr.Add("F_MainDuties", string.IsNullOrEmpty(entity.F_MainDuties) || "null".Equals(entity.F_MainDuties) ? "" : entity.F_MainDuties);
                dr.Add("F_BasicConditions", string.IsNullOrEmpty(entity.F_BasicConditions) || "null".Equals(entity.F_BasicConditions) ? "" : entity.F_BasicConditions);
                dr.Add("F_SupposedToKnow", string.IsNullOrEmpty(entity.F_SupposedToKnow) || "null".Equals(entity.F_SupposedToKnow) ? "" : entity.F_SupposedToKnow);
                dr.Add("F_EssentialSkill", string.IsNullOrEmpty(entity.F_EssentialSkill) || "null".Equals(entity.F_EssentialSkill) ? "" : entity.F_EssentialSkill);
                dr.Add("F_CapacityRequirements", string.IsNullOrEmpty(entity.F_CapacityRequirements) || "null".Equals(entity.F_CapacityRequirements) ? "" : entity.F_CapacityRequirements);
                dr.Add("F_ExperienceRequirements", string.IsNullOrEmpty(entity.F_ExperienceRequirements) || "null".Equals(entity.F_ExperienceRequirements) ? "" : entity.F_ExperienceRequirements);
                dr.Add("F_SpecialRequirements", string.IsNullOrEmpty(entity.F_SpecialRequirements) || "null".Equals(entity.F_SpecialRequirements) ? "" : entity.F_SpecialRequirements);
                dr.Add("F_DepartmentOfOpinion", string.IsNullOrEmpty(entity.F_DepartmentOfOpinion) || "null".Equals(entity.F_DepartmentOfOpinion) ? "" : entity.F_DepartmentOfOpinion);
                dr.Add("F_DepartmentOfOpinionOne", string.IsNullOrEmpty(entity.F_DepartmentOfOpinionOne) || "null".Equals(entity.F_DepartmentOfOpinionOne) ? "" : entity.F_DepartmentOfOpinionOne);
                dr.Add("F_DepartmentOfOpinionT", string.IsNullOrEmpty(entity.F_DepartmentOfOpinionT) || "null".Equals(entity.F_DepartmentOfOpinionT) ? "" : entity.F_DepartmentOfOpinionT);
                dr.Add("F_HumanResources", string.IsNullOrEmpty(entity.F_HumanResources) || "null".Equals(entity.F_HumanResources) ? "" : entity.F_HumanResources);
                dr.Add("F_HumanResourcesOne", string.IsNullOrEmpty(entity.F_HumanResourcesOne) || "null".Equals(entity.F_HumanResourcesOne) ? "" : entity.F_HumanResourcesOne);
                dr.Add("F_HumanResourcesT", string.IsNullOrEmpty(entity.F_HumanResourcesT) || "null".Equals(entity.F_HumanResourcesT) ? "" : entity.F_HumanResourcesT);
                dr.Add("F_HrIndicatesOrderNumber", string.IsNullOrEmpty(entity.F_HrIndicatesOrderNumber) || "null".Equals(entity.F_HrIndicatesOrderNumber) ? "" : entity.F_HrIndicatesOrderNumber);

                json.Add("HEADER", JToken.FromObject(dr));

                drAttachment.Add("F_Attachment01", string.IsNullOrEmpty(entity.F_Attachment01) || "null".Equals(entity.F_Attachment01) ? "" : entity.F_Attachment01Name);
                drAttachment.Add("F_AttachmentVal01", entity.F_Attachment01);
                drAttachment.Add("F_Attachment02", string.IsNullOrEmpty(entity.F_Attachment02) || "null".Equals(entity.F_Attachment02) ? "" : entity.F_Attachment02Name);
                drAttachment.Add("F_AttachmentVal02", entity.F_Attachment02);
                drAttachment.Add("F_Attachment03", string.IsNullOrEmpty(entity.F_Attachment03) || "null".Equals(entity.F_Attachment03) ? "" : entity.F_Attachment03Name);
                drAttachment.Add("F_AttachmentVal03", entity.F_Attachment03);

                json.Add("ATTACHMENT", JToken.FromObject(drAttachment));
                //拼json字符串完成
                // UserBLL ue = new UserIBLL();
                //请求wsdl路径
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();

                string url = ConfigurationManager.AppSettings["webServiceurlProduct"];
                //string url = ConfigurationManager.AppSettings["webServiceurlunProduct"];

                //string m_WebServiceUrl = "http://192.168.98.150:8088//services/HyRecruitingService?wsdl/SendOa";

                string jsonStr = JsonNewtonsoft.ToJSON(json).ToString();

                string soap = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:hy=\"http://localhost/hy.webservice.hr.HyRecruitingService\">\r\n" +
                  "<soapenv:Header/>\r\n" +
                    "<soapenv:Body>\r\n" +
                       "<hy:SendOa>\r\n" +
                          "<hy:strJson>" + jsonStr + "</hy:strJson>\r\n" +
                          "<hy:workcode>"+ ue.F_Account + "</hy:workcode>\r\n" +
                       "</hy:SendOa>\r\n" +
                    "</soapenv:Body>\r\n" +
                 "</soapenv:Envelope>\r\n";


                ///获取请求数据拼接请求json体

                string result = HttpHelper.Helper.GetSOAPReSource(url, soap);
                //var doc = new XmlDocument();

                if (string.IsNullOrEmpty(result))
                {
                    rc.Status = false;
                    rc.Message = "创建OA流程失败";
                    entity.F_Status = "E";
                    entity.F_Mes = "创建OA流程失败";
                    entity.F_Description = jsonStr;
                    sr.UpdateEntity(entity);
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(result);//Load加载XML文件，LoadXML加载XML字符串
                    string status = xmlDoc.DocumentElement["soap:Body"]["ns1:SendOaResponse"]["ns1:ReturnIfo"]["isSuccess"].InnerXml;
                    string mes = xmlDoc.DocumentElement["soap:Body"]["ns1:SendOaResponse"]["ns1:ReturnIfo"]["message"].InnerXml;
                    entity.F_Status = status;
                    entity.F_Mes = mes;
                    entity.F_Description = jsonStr;
                    sr.UpdateEntity(entity);
                    if ("S".Equals(status))
                    {
                        rc.Status = true;
                        rc.Message = mes;
                    }
                    else
                    {
                        rc.Status = false;
                        rc.Message = mes;
                    }
                }
                _return = rc;
                return _return;
            } catch (Exception e) {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
