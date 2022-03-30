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
    public class WrittenExaminationController : BaseApiController
    {
        private readonly WrittenExaminationService writtenExaminationService;
        public WrittenExaminationController()
        {
            writtenExaminationService = new WrittenExaminationService();
        }
        /// <summary>
        /// 获取笔试题
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiModel> GetWrittenExaminationQuestions()
        {
            apiModel = await writtenExaminationService.GetWrittenExaminationQuestions();
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘端获取笔试题", OperationType.Query, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data);
            }
        }

        /// <summary>
        /// 保存笔试结果
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiModel> SaveResult(WrittenExaminationResult writtenExaminationResult)
        {
            apiModel =await  writtenExaminationService.SetSaveResult(writtenExaminationResult);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "应聘者笔试结果保存", OperationType.Create, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "应聘者笔试结果保存", OperationType.Create, "", apiModel.info,3);
            }
        }
    }
}
