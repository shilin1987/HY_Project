using Learun.Util;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_EmployeeInformationEntry.BLL;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.Controllers
{
    public class BaseApiController : ApiController
    {
        internal readonly LogService  saveLog;
        internal ApiModel apiModel;
        public BaseApiController()
        {
            apiModel = new ApiModel();
            saveLog = new LogService();
        }

        /// <summary>
        /// 带操作日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected ApiModel Success(Object data)
        {
            ApiModel res = new ApiModel { code = ResponseCode.success, info = "", data = data };

            return res;
        }

        /// <summary>
        /// 带操作日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected ApiModel Success(Object data, string title, OperationType type, string keyValue, string content,int CategoryId)
        {
            var logEntity = new lr_base_log()
            {
                F_LogId = Guid.NewGuid().ToString(),
                F_CategoryId = CategoryId,
                F_OperateTypeId = ((int)type).ToString(),
                F_OperateType = EnumAttribute.GetDescription(type),
                F_OperateAccount = "",
                F_OperateUserId = keyValue,
                F_Module = title,
                F_ExecuteResult = 1,
                F_ExecuteResultJson = "访问地址：" + (string)WebHelper.GetHttpItems("currentUrl"),
                F_SourceObjectId = keyValue,
                F_SourceContentJson = content,
                F_OperateTime=DateTime.Now
            };
            saveLog.SaveLog(logEntity);

             ApiModel res = new ApiModel { code = ResponseCode.success, info = content, data = data };

            return res;
        }

        /// <summary>
        /// 带操作日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected ApiModel Fail(Object data, string title, OperationType type, string keyValue, string content)
        {
            var logEntity = new lr_base_log()
            {
                F_LogId = Guid.NewGuid().ToString(),
                F_CategoryId = 4,
                F_OperateTypeId = ((int)type).ToString(),
                F_OperateType = EnumAttribute.GetDescription(type),
                F_OperateAccount = "",
                F_OperateUserId = keyValue,
                F_Module = title,
                F_ExecuteResult = 1,
                F_ExecuteResultJson = "访问地址：" + (string)WebHelper.GetHttpItems("currentUrl"),
                F_SourceObjectId = keyValue,
                F_SourceContentJson = content,
                F_OperateTime = DateTime.Now
            };
            saveLog.SaveLog(logEntity);

            ApiModel res = new ApiModel { code = ResponseCode.fail, info = content, data = data };

            return res;
        }

    }
}
