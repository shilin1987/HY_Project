using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-16 14:11
    /// 描 述：来料计划产能分配
    /// </summary>
    public class B2B_PLAN_MATERIAL_ALLOTController : MvcControllerBase
    {
        private B2B_PLAN_MATERIAL_ALLOTIBLL b2B_PLAN_MATERIAL_ALLOTIBLL = new B2B_PLAN_MATERIAL_ALLOTBLL();

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
        [HttpGet]
        public ActionResult ImportExcel()
        {
            return View("ImportExcel");
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
            var data = b2B_PLAN_MATERIAL_ALLOTIBLL.GetPageList(paginationobj, queryJson);
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
        /// 获取合并月份的数据
        public ActionResult GetPlanData(string month)
        {
            var data = b2B_PLAN_MATERIAL_ALLOTIBLL.GetPlanData(month);
            var jsonData = new
            {
                B2B_PLAN_MATERIAL_ALLOT_SUB = data,               
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
            var B2B_PLAN_MATERIAL_ALLOTData = b2B_PLAN_MATERIAL_ALLOTIBLL.GetB2B_PLAN_MATERIAL_ALLOTEntity( keyValue );
            var B2B_PLAN_MATERIAL_ALLOT_SUBData = b2B_PLAN_MATERIAL_ALLOTIBLL.GetB2B_PLAN_MATERIAL_ALLOT_SUBList( B2B_PLAN_MATERIAL_ALLOTData.F_GUID );
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
            b2B_PLAN_MATERIAL_ALLOTIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strb2B_PLAN_MATERIAL_ALLOT_SUBList)
        {
            B2B_PLAN_MATERIAL_ALLOTEntity entity = strEntity.ToObject<B2B_PLAN_MATERIAL_ALLOTEntity>();
            List<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> b2B_PLAN_MATERIAL_ALLOT_SUBList = strb2B_PLAN_MATERIAL_ALLOT_SUBList.ToObject<List<B2B_PLAN_MATERIAL_ALLOT_SUBEntity>>();
            b2B_PLAN_MATERIAL_ALLOTIBLL.SaveEntity(keyValue,entity,b2B_PLAN_MATERIAL_ALLOT_SUBList);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }

        [HttpPost]
        public ActionResult UploadFile(string Tile)
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }

            string FileEextension = Path.GetExtension(files[0].FileName);
            string fileHeadImg = Config.GetValue("fileLogoImg");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, "importfile", FileEextension);
            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);

            DataTable execldata = ExcelHelper.ExcelImport(fullFileName);

            return Success(execldata);
        }
        #endregion

    }
}
