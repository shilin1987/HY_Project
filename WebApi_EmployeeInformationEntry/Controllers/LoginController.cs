﻿using Learun.Util;
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
    public class LoginController : BaseApiController
    {
        private readonly LoginService loginService;
        public LoginController()
        {
            loginService = new LoginService();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel Login(LoginModel login)
        {
            apiModel = loginService.Login(login);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "作业员招聘面试官登录", OperationType.AppLogin, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "作业员招聘面试官登录", OperationType.AppLogin, "", apiModel.info,2);
            }
        }

        /// <summary>
        /// 应聘者登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> CandidateLogin(LoginModel login)
        {
            if (login != null)
            {
                apiModel =await loginService.CandidateLogin(login);
                if (apiModel.code == ResponseCode.fail)
                {
                    return Fail(null, "作业员招聘应聘者登录", OperationType.AppLogin, "", apiModel.info);
                }
                else
                {
                    return Success(apiModel, "作业员招聘应聘者登录", OperationType.AppLogin, "", apiModel.info,2);
                }
            }
            else {
                return Fail(null, "作业员招聘应聘者登录", OperationType.AppLogin, "", "请输入登录账号密码");
            }
        }
    }
}