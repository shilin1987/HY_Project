using IdentityAuthentication.BLL;
using IdentityAuthentication.Models;
using IdentityAuthenticationController.Controllers;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityAuthentication.Controllers
{
    public class IdentityAuthenticationController : BaseApiController
    {

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiModel test()
        {
            return Success("测试成功");
        }

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiModel test(int  id)
        {
            return Success("测试成功:"+id);
        }

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel test(IdCardModel idCard)
        {
            if (idCard.IdCard != null)
            {
                return Success("测试成功");
            }
            else
            {
                return Fail("测试传入参数身份证为空(null)");
            }
        }

        /// <summary>
        /// 业务变更：添加报到刷身份证信息
        /// 根据身份证获取基础信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel IdentityAuthentication(IdCardModel idCard)
        {
            if (idCard != null)
            {
                var cbll = new ComparisonOfIdCardVerificationClassBLL();
                returnCommon = cbll.VerifyIDCardAjxaData(idCard);
                if (returnCommon.Status)
                {
                    return Success(null, "身份证自动对比", OperationType.Query, "", returnCommon.Message);
                }
                else
                {
                    return Fail(null, "身份证自动对比", OperationType.Query, "", returnCommon.Message);
                }
            }
            else
            {
                return Fail(null, "身份证自动对比", OperationType.Query, "", "传入参数身份证为空(null)");
            }
        }
    }
}
