using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;
using WebApi_EmployeeInformationEntry.BLL;

namespace webAPI.Controllers
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
        public ApiModel GetVerificationCode(string phone)
        {
            if (phone != null)
            {
                var userEntity = hYDatabase.lr_base_user.Where(e => e.F_UserId == phone);
                if (userEntity != null && userEntity.Count() > 0)
                {
                    return Success(userEntity, "初始化用户信息", OperationType.Update, "", "初始化用户信息成功");
                }
                else
                {
                    return Fail(userEntity, "初始化用户信息", OperationType.Exception, "", "初始化用户信息失败");
                }
            }
            else
            {
                return Fail(null, "请输入手机号码", OperationType.Exception, "", "传入参数为null");
            }
        }

        /// <summary>
        /// 根据身份证获取基础信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel InitializationUser(string idCard)
        {
            if (idCard != null)
            {
              var userEntity =   registeredService.InitializationUser(idCard);
              return  Success(userEntity, "根据身份证初始化注册信息", OperationType.Update, "", "根据身份证初始化注册信息成功");
            }
            else
            {
                return Fail(null, "根据身份证初始化注册信息", OperationType.Exception, "", "传入参数身份证为空(null)");
            }
        }

        /// <summary>
        /// 根据身份证获取基础信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel SaveForm(string idCard)
        {
            if (idCard != null)
            {
                var userEntity = hYDatabase.lr_base_user.Where(e => e.F_UserId == idCard);
                if (userEntity != null && userEntity.Count() > 0)
                {
                    return Success(userEntity, "初始化用户信息", OperationType.Update, "", "初始化用户信息成功");
                }
                else
                {
                    return Fail(userEntity, "初始化用户信息", OperationType.Exception, "", "初始化用户信息失败");
                }
            }
            else
            {
                return Fail(null, "请输入手机号码", OperationType.Exception, "", "传入参数为null");
            }
        }
    }
}
