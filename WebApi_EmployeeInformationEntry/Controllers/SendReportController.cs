using Learun.Util;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi_EmployeeInformationEntry.BLL;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.Controllers
{
    public class SendReportController : BaseApiController
    {
        private readonly RegisteredService registeredService;

        public SendReportController()
        {
            registeredService = new RegisteredService();
        }

        /// <summary>
        /// 发送报到单
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> SetSendReport(ReportModel report)
        {
            var result = await registeredService.SetSendReport(report);
            if (result.code == ResponseCode.success)
            {
                return Success(result.data);
            }
            else
            {
                return Fail(result, "生成验证码并发送到手机", OperationType.Exception, "", result.info);
            }
        }

        [HttpPost]
        public Task<ApiModel> UserImaInfo()
        {
            return null;
            //var result = await registeredService.SetSendReport(report);
            //if (result.code == ResponseCode.success)
            //{
            //    return Success(result, "生成验证码并发送到手机", OperationType.Create, "", result.info);
            //}
            //else
            //{
            //    return Fail(result, "生成验证码并发送到手机", OperationType.Exception, "", result.info);
            //}
        }
    }
}
