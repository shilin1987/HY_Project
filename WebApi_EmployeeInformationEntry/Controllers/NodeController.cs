using Learun.Util;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_EmployeeInformationEntry.BLL;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.Controllers
{
    public class NodeController : BaseApiController
    {
        private readonly NodeService nodeService;
     
        public NodeController()
        {
            nodeService = new NodeService();
        }

        // GET: api/Node
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取当前节点
        /// </summary>
        /// <param name="LoginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel GetCurrentNode(LoginModel login)
        {
            apiModel = nodeService.CurrentNodeInfo(login);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(apiModel.data, "查询应聘流程节点", OperationType.Query, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data);
            }
        }

        // GET: api/Node/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Node
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Node/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Node/5
        public void Delete(int id)
        {
        }
    }
}
