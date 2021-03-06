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
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.Controllers
{
    public class RegisteredController : BaseApiController
    {
        private readonly RegisteredService registeredService;

        public RegisteredController() 
        {
            registeredService = new RegisteredService();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> GetVerificationCode(VCodeModel phone)
        {
            var result =await registeredService.GetVerificationCode(phone.Phone);
            if (result.code == ResponseCode.success)
            {
                return Success(result);
            }
            else
            {
                return Fail(result, "生成验证码并发送到手机", OperationType.Exception, "", result.info);
            }
        }

        /// <summary>
        /// 根据身份证获取基础信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> InitializationUser(Registered registered)
        {
            if (registered.IdCard != null)
            {
              var userEntity =await  registeredService.InitializationUser(registered.IdCard);
              return  Success(userEntity.data);
            }
            else
            {
                return Fail(null, "根据身份证初始化注册信息", OperationType.Exception, "", "传入参数身份证为空(null)");
            }
        }

        /// <summary>
        /// 保存注册信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel SaveForm(RegisteredViewModel registered)
        {
            if (registered != null)
            {
                var isSuccess = registeredService.SaveForm(registered);
                if (isSuccess.code== ResponseCode.success)
                {
                    return Success(isSuccess, "保存作业员注册信息", OperationType.Create, "", isSuccess.info,3);
                }
                else
                {
                    return Fail(isSuccess, "保存作业员注册信息", OperationType.Exception, "", isSuccess.info);
                }
            }
            else
            {
                return Fail(null, "请输入作业员注册信息", OperationType.Exception, "", "注册传入参数为null");
            }
        }
    }
}
