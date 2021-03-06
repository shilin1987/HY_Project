using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_CUST_ORDER_CHECK;

namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 16:29
    /// 描 述：客户订单审核
    /// </summary>
    public class B2B_CUST_ORDER_CHECKController : MvcControllerBase
    {
        private B2B_CUST_ORDER_CHECKIBLL b2B_CUST_ORDER_CHECKIBLL = new B2B_CUST_ORDER_CHECKBLL();

        #region 视图功能

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
             return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
             return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = b2B_CUST_ORDER_CHECKIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageListSub(string keyValue)
        {
            var data = b2B_CUST_ORDER_CHECKIBLL.GetPageListSub(keyValue);
            return Success(data);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetParamtListSub(string keyValue, string partId)
        {
            var data = b2B_CUST_ORDER_CHECKIBLL.GetParamtListSub(keyValue, partId);
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var B2B_CUST_ORDER_SUBData = b2B_CUST_ORDER_CHECKIBLL.GetB2B_CUST_ORDER_SUBEntity( keyValue );         
            var B2B_CUST_ORDERData = b2B_CUST_ORDER_CHECKIBLL.GetB2B_CUST_ORDEREntity(keyValue);
            var jsonData = new {
                B2B_CUST_ORDER = B2B_CUST_ORDERData,             
                B2B_CUST_ORDER_SUB = B2B_CUST_ORDER_SUBData,
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            b2B_CUST_ORDER_CHECKIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 审核数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CheckForm(string keyValue)
        {
            string msg = "";
            var result = b2B_CUST_ORDER_CHECKIBLL.CheckEntity(keyValue, out string msgbox);
            foreach (var item in result)
            {
                msg += "BR为：" + item.BR + ";详细内容为：" + item.MSG + ";状态：" + item.ORDER_STATUS;
            }
            if (msgbox== "true")
            {            
                return Success("订单审核成功！具体信息如："+msg);
            }
            else
            {
                return Success("订单审核不成功！具体信息如：" + msg);
            }    
        }   
        #endregion

    }
}
