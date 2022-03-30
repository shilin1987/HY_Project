﻿using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_Code;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 15:10
    /// 描 述：个税结算
    /// </summary>
    public class PersonalIncomeTaxController : MvcControllerBase
    {
        private PersonalIncomeTaxIBLL personalIncomeTaxIBLL = new PersonalIncomeTaxBLL();

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
            var data = personalIncomeTaxIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_hr_PersonalIncomeTaxData = personalIncomeTaxIBLL.GetHy_hr_PersonalIncomeTaxEntity( keyValue );
            var jsonData = new {
                Hy_hr_PersonalIncomeTax = Hy_hr_PersonalIncomeTaxData,
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
            personalIncomeTaxIBLL.DeleteEntity(keyValue);
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
            Hy_hr_PersonalIncomeTaxEntity entity = strEntity.ToObject<Hy_hr_PersonalIncomeTaxEntity>();
            personalIncomeTaxIBLL.SaveEntity(keyValue,entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion

    }
}
