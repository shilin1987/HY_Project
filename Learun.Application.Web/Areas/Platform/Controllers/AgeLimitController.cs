using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.Platform;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-09-27 10:31
    /// 描 述：入职年龄规则设置
    /// </summary>
    public class AgeLimitController : MvcControllerBase
    {
        private AgeLimitIBLL ageLimitIBLL = new AgeLimitBLL();

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
            var data = ageLimitIBLL.GetPageList(paginationobj, queryJson);
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
            var Platform_AgeLimitData = ageLimitIBLL.GetPlatform_AgeLimitEntity( keyValue );
            var jsonData = new {
                Platform_AgeLimit = Platform_AgeLimitData,
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
            ReturnCommon rc = ageLimitIBLL.DeleteEntity(keyValue);
            if (rc.Status)
            { return Success(rc.Message, "年龄规则设置（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(),3); }
            else
            {
                return Fail(rc.Message + "!!!", "年龄规则设置（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
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
            Platform_AgeLimitEntity entity = strEntity.ToObject<Platform_AgeLimitEntity>();
            ReturnCommon rc =  ageLimitIBLL.SaveEntity(keyValue,entity);
            if (rc.Status)
            { return Success(rc.Message, "年龄规则设置", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(),3); } 
            else { 
            return Fail(rc.Message + "!!!", "年龄规则设置", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        #endregion

    }
}
