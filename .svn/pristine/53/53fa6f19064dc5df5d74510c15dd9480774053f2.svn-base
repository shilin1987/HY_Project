using IdentityAuthentication.Database;
using IdentityAuthentication.Models;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace IdentityAuthenticationController.Controllers
{
    public class BaseApiController : ApiController
    {
      
        internal ApiModel apiModel;
        public BaseApiController()
        {
            apiModel = new ApiModel();
            returnCommon = new ReturnCommon();
            if (hYDatabase == null)
            {
                hYDatabase = new HYDatabaseEntities();
            }
        }

        public ReturnCommon returnCommon { get; set; }
        public HYDatabaseEntities hYDatabase { get; set; }

        /// <summary>
        /// 简单返回结果
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected ApiModel Success(string content)
        {
            apiModel.code = ResponseCode.success;
            apiModel.info = content;
            return apiModel;
        }

        /// <summary>
        ///请求成功
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected ApiModel Success(Object data, string title, OperationType type, string keyValue, string content)
        {
            var logEntity = new lr_base_log()
            {
                F_LogId = Guid.NewGuid().ToString(),
                F_CategoryId = 3,
                F_OperateTypeId = ((int)type).ToString(),
                F_OperateType = EnumAttribute.GetDescription(type),
                F_OperateAccount = "",
                F_OperateUserId = keyValue,
                F_Module = title,
                F_ExecuteResult = 1,
                F_ExecuteResultJson = "访问地址：" + (string)WebHelper.GetHttpItems("currentUrl"),
                F_SourceObjectId = keyValue,
                F_SourceContentJson = content,
            };
            hYDatabase.lr_base_log.Add(logEntity);
            var logExist = hYDatabase.SaveChanges();

            apiModel.code = ResponseCode.success;
            apiModel.info = content;

            return apiModel;
        }

        /// <summary>
        /// 简单返回结果
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected ApiModel Fail(string content)
        {
            ApiModel res = new ApiModel { code = ResponseCode.fail, info = content };
            return res;
        }

        /// <summary>
        /// 请求失败
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
            };
            hYDatabase.lr_base_log.Add(logEntity);
            hYDatabase.SaveChanges();

            apiModel.code = ResponseCode.fail;
            apiModel.info = content;

            return apiModel;
        }
    }
}
