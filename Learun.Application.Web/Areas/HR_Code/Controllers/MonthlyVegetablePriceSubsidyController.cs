using Learun.Application.TwoDevelopment.HR_Code;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    /// <summary>
    /// 菜价补贴查看数据视图
    /// </summary>
    public class MonthlyVegetablePriceSubsidyController : MvcControllerBase
    {
        private MonthlyVegetablePriceSubsidyIBLL monthlyAttendanceDataAutoClassIBLL = new MonthlyVegetablePriceSubsidyBLL();
        #region 视图功能
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
            var data = monthlyAttendanceDataAutoClassIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        #endregion

    }
}