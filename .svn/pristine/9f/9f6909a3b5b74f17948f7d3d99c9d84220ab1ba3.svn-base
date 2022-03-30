using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using Learun.Util.Operat;
using Newtonsoft.Json;
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
    public class InterviewController : BaseApiController
    {
        private readonly UserService userService;
        private readonly InterviewService InterviewService;
        public InterviewController()
        {
            userService = new UserService();
            InterviewService = new InterviewService();
        }

        // GET: api/User/
        [HttpPost]
        public async Task<ApiModel> SelectInteriewInfo()
        {
            apiModel = await InterviewService.SelectInteriewInfo();
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘者面试面试人员信息初始化", OperationType.Query, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data);
            }
        }

        //员工信息查询
        [HttpPost]
        public async Task<ApiModel> SelectUserInfo(string userid)
        {
            apiModel = await InterviewService.SelectUserInfo(userid);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘者面试信息查询", OperationType.Update, "", apiModel.info);
            }
            else
            {
                //解决自引用问题
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                var strjson = JsonConvert.SerializeObject(apiModel.data, settings);

                return Success(strjson);
            }
        }

        //开始面试
        [HttpPost]
        public ApiModel UserSave(string KeyValue)
        {
            apiModel = InterviewService.UserSave(KeyValue);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘者开始面试", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "应聘者开始面试", OperationType.Update, "", apiModel.info,3);
            }
        }

        //保存面试
        [HttpPost]
        public ApiModel saveInterviewSave(IsDoptModele entity)
        {
            apiModel = InterviewService.saveInterviewSave(entity);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘者面试结果信息保存", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "应聘者面试结果信息保存", OperationType.Update, "", apiModel.info,3);
            }
        }
    }
}
