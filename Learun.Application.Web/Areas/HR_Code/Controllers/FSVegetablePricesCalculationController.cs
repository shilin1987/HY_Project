﻿using Learun.Util;
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
    /// 日 期：2022-01-10 14:53
    /// 描 述：新菜价补贴计算
    /// </summary>
    public class FSVegetablePricesCalculationController : MvcControllerBase
    {
        private FSVegetablePricesCalculationIBLL fSVegetablePricesCalculationIBLL = new FSVegetablePricesCalculationBLL();
       

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
            var data = fSVegetablePricesCalculationIBLL.GetPageList(paginationobj, queryJson);
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
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var FS_VegetablePricesData = fSVegetablePricesCalculationIBLL.GetFS_VegetablePricesEntity( keyValue );
            var jsonData = new {
                FS_VegetablePrices = FS_VegetablePricesData,
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
            fSVegetablePricesCalculationIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }

        [HttpPost]
        public ActionResult CalculateRerust()
        {
            VegetablePricesIBLL vpIBLL = new VegetablePricesBLL();
            ReturnCommon rc = vpIBLL.CalculateVegetablePrice();
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

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetExportList(string pagination, string queryJson)
        {
            string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/Files/";
            Pagination paginationobj = pagination.ToObject<Pagination>();
            string filenamenewpath = fSVegetablePricesCalculationIBLL.GetExportList(paginationobj, queryJson, Server.MapPath("~/Files/"), url);
            string filenamenew = url + filenamenewpath;
            // BigFileDownload("1111",filenamenew);

            return Success(filenamenew);
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
            FS_VegetablePricesEntity entity = strEntity.ToObject<FS_VegetablePricesEntity>();
            fSVegetablePricesCalculationIBLL.SaveEntity(keyValue,entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion

    }
}
