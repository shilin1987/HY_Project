using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class PostApi : BaseApi
    {
       
        public PostApi()
        : base("/learun/adms/post")
        {
            Get["/postlist"] = GetPostList;// 获取岗位数据映射表
        }

        private PostIBLL postIBLL = new PostBLL();

        /// <summary>
        /// 获取岗位列表接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetPostList(dynamic _)
        {
            var data = postIBLL.GetPostList();

            return Success(data.Data, "岗位列表接口", OperationType.Query, "", "查询岗位下拉KEY/VALUE数据:"+data.Message);
        }
    }
}