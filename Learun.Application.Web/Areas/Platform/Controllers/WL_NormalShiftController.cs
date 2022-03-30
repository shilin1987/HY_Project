﻿using Learun.Application.TwoDevelopment.Platform;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Util;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 09:14
    /// 描 述：上岗资格认证表
    /// </summary>
    public class WL_NormalShiftController : MvcControllerBase
    {
        private WL_NormalShiftIBLL wL_NormalShiftIBLL = new WL_NormalShiftBLL();

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
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList( string queryJson )
        {
            var data = wL_NormalShiftIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = wL_NormalShiftIBLL.GetPageList(paginationobj, queryJson);
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
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var data = wL_NormalShiftIBLL.GetEntity(keyValue);
            return Success(data);
        }
        /// <summary>
        /// 获取子表的字段数据
        /// </summary>
        /// <param name="fno">主表fno</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSubList(string fno)
        {
            var data = wL_NormalShiftIBLL.GetSubList(fno);
            return Success(data);
        }
        /// <summary>
        /// 获取员工的字段数据
        /// </summary>
        /// <param name="F_EnCode">主表fno</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetUserList(string F_EnCode)
        {
            var data = wL_NormalShiftIBLL.GetUserList(F_EnCode);
            return Success(data);
        }
        /// <summary>
        /// 获取字段数据
        /// </summary>
        /// <param name="F_EnCode">主表fno</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserNormalShiftList(string fid)
        {
            var data = wL_NormalShiftIBLL.GetUserNormalShiftList(fid);
            return Success(data);
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
            wL_NormalShiftIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue,Hy_Wl_NormalShiftEntity entity)
        {
            ReturnComment rc = wL_NormalShiftIBLL.SaveEntity(keyValue, entity);

            if ("S".Equals(rc.State))
            {
                return Success("上岗证正常班"+rc.Mes);
            }
            else
            {
                return Fail(rc.Mes + "!!!", "上岗证正常班", Util.Operat.OperationType.Create, keyValue, rc.Mes.ToString());
            }
        }

        /// <summary>
        /// 保存下载PDF
        /// </summary>
        /// <param name="jsondata">表格数据 </param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DownloadPDF(string jsondata)
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
               // demoleaveIBLL.SaveList(jsondata);
            }
            return Success("操作成功。");
        }

        #endregion

    }
}
