using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.NewVegetablePrices;
using Learun.Application.TwoDevelopment.ReturnModel;

namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 21:11
    /// 描 述：菜价补贴月明细数据
    /// </summary>
    public class FSVegetablePriceSubsidyMonthlyDetailsController : MvcControllerBase
    {
        private FSVegetablePriceSubsidyMonthlyDetailsIBLL fSVegetablePriceSubsidyMonthlyDetailsIBLL = new FSVegetablePriceSubsidyMonthlyDetailsBLL();

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
            var data = fSVegetablePriceSubsidyMonthlyDetailsIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CalculateRerust()
        {
            VegetablePricesIBLL vpIBLL = new VegetablePricesBLL();
            ReturnCommon rc = vpIBLL.CalculateVegetablePriceDetil();
            //ReturnCommon rc = vpIBLL.CalculateVegetablePriceDetil();
            if (rc.Status)
            {
                return Success("菜价补贴计算成功！");
            }
            else
            {
                return Fail(rc.Message + "!!!", "菜价补贴", Util.Operat.OperationType.Create, "菜价补贴", rc.Message.ToString());
            }
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var FS_VegetablePriceSubsidyMonthlyDetailsData = fSVegetablePriceSubsidyMonthlyDetailsIBLL.GetFS_VegetablePriceSubsidyMonthlyDetailsEntity( keyValue );
            var jsonData = new {
                FS_VegetablePriceSubsidyMonthlyDetails = FS_VegetablePriceSubsidyMonthlyDetailsData,
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
            fSVegetablePriceSubsidyMonthlyDetailsIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity)
        {
            FS_VegetablePriceSubsidyMonthlyDetailsEntity entity = strEntity.ToObject<FS_VegetablePriceSubsidyMonthlyDetailsEntity>();
            fSVegetablePriceSubsidyMonthlyDetailsIBLL.SaveEntity(keyValue,entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion

    }
}
