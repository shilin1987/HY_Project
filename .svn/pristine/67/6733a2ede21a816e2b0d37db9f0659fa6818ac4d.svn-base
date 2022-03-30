using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-24 09:07
    /// 描 述：来料计划产能分配报表
    /// </summary>
    public class B2B_PLAN_MATERIAL_ALLOT_REPORTController : MvcControllerBase
    {
        private B2B_PLAN_MATERIAL_ALLOT_REPORTIBLL b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL = new B2B_PLAN_MATERIAL_ALLOT_REPORTBLL();

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
            var data = b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL.GetPageList(paginationobj, queryJson);
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
            var B2B_PLAN_MATERIAL_ALLOTData = b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL.GetB2B_PLAN_MATERIAL_ALLOTEntity( keyValue );
            var B2B_PLAN_MATERIAL_ALLOT_SUBData = b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL.GetB2B_PLAN_MATERIAL_ALLOT_SUBEntity( B2B_PLAN_MATERIAL_ALLOTData.F_GUID );
            var jsonData = new {
                B2B_PLAN_MATERIAL_ALLOT_SUB = B2B_PLAN_MATERIAL_ALLOT_SUBData,
                B2B_PLAN_MATERIAL_ALLOT = B2B_PLAN_MATERIAL_ALLOTData,
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
            b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strb2B_PLAN_MATERIAL_ALLOT_SUBEntity)
        {
            B2B_PLAN_MATERIAL_ALLOTEntity entity = strEntity.ToObject<B2B_PLAN_MATERIAL_ALLOTEntity>();
            B2B_PLAN_MATERIAL_ALLOT_SUBEntity b2B_PLAN_MATERIAL_ALLOT_SUBEntity = strb2B_PLAN_MATERIAL_ALLOT_SUBEntity.ToObject<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>();
            b2B_PLAN_MATERIAL_ALLOT_REPORTIBLL.SaveEntity(keyValue,entity,b2B_PLAN_MATERIAL_ALLOT_SUBEntity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion

    }
}
