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
    public class MenuController : BaseApiController
    {
        readonly MenuService menuService;
        public MenuController()
        {
            menuService = new MenuService();
        }
        /// <summary>
        /// 应聘者登录查询菜单信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> ProcessLoad(LoginModel login)
        {
            if (login != null)
            {
                apiModel = await menuService.GetProcess(login);
                if (apiModel.code == ResponseCode.fail)
                {
                    return Fail(null, "查询应聘者菜单信息", OperationType.Query, "", apiModel.info);
                }
                else
                {
                    return Success(apiModel);
                }
            }
            else
            {
                return Fail(null, "查询应聘者菜单信息", OperationType.Query, "", "应聘者信息未提供.");
            }
        }
    }
}
