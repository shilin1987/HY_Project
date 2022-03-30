using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using Learun.Application.TwoDevelopment.HR_WorkPermitModule;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.Web.Areas.WebServerUtil;
using Learun.Util.Operat;
using System.Web.Services;

namespace Learun.Application.Web
{
    /// <summary>
    /// OAWebservicInfo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class OAWebservicInfo : System.Web.Services.WebService
    {

        public MySoapHeader soapHeader;

        [WebMethod(Description = "SoapHeader验证")]
        [System.Web.Services.Protocols.SoapHeader("soapHeader")]
        public ReturnComment InsertProcessInformation(string jsonStr, string userId)
        {
            ReturnComment rc = new ReturnComment();
            OperateLogModel operationLogModel = new OperateLogModel();
            operationLogModel.type = OperationType.Create;
            operationLogModel.sourceContentJson = jsonStr;
            operationLogModel.title = "社招流程接口返回";
            OperatorHelper.Instance.WriteOperateLogInterfater(operationLogModel,"System");

            RecruitmentProcessInformationClassIBLL rpiBLL = new RecruitmentProcessInformationClassBLL();
            //简单验证用户信息
            //可以通过数据库或其他方式验证
            if ("admin".Equals(soapHeader.UserName) & "admin123".Equals(soapHeader.PassWord))
            {
                if (string.IsNullOrEmpty(jsonStr))
                {
                    rc.State = "F";
                    rc.Mes = "请求jsonStr为空";
                    return rc;
                }
                else
                {
                    rc = rpiBLL.InsertListEntity(jsonStr, userId);
                    if ("S".Equals(rc.State))
                    {
                        rc.State = "S";
                        rc.Mes = "请求成功";
                    }
                    else
                    {
                        rc.State = "F";
                    }

                    return rc;
                }
            }
            else
            {
                rc.Mes = "对不起，您没有访问权限！";
                return rc;
            }
        }

        [WebMethod(Description = "SoapHeader验证")]
        [System.Web.Services.Protocols.SoapHeader("soapHeader")]
        public ReturnComment WorkPermitProcess(string jsonStr, string userId)
        {
            ReturnComment rc = new ReturnComment();
            OperateLogModel operationLogModel = new OperateLogModel();
            operationLogModel.type = OperationType.Create;
            operationLogModel.sourceContentJson = jsonStr;
            operationLogModel.title = "上岗证流程接口返回";
            OperatorHelper.Instance.WriteOperateLogInterfater(operationLogModel, "System");

            WorkingCertificateIBLL wcBLL = new WorkingCertificateBLL();
            //简单验证用户信息
            //可以通过数据库或其他方式验证
            if ("admin".Equals(soapHeader.UserName) & "admin123".Equals(soapHeader.PassWord))
            {
                if (string.IsNullOrEmpty(jsonStr))
                {
                    rc.State = "F";
                    rc.Mes = "请求jsonStr为空";
                    return rc;
                }
                else
                {
                    rc = wcBLL.InsertListEntity(jsonStr, userId);
                    if ("S".Equals(rc.State))
                    {
                        rc.State = "S";
                        rc.Mes = "请求成功";
                    }
                    else
                    {
                        rc.State = "F";
                    }

                    return rc;
                }
            }
            else
            {
                rc.Mes = "对不起，您没有访问权限！";
                return rc;
            }
        }
    }
}
