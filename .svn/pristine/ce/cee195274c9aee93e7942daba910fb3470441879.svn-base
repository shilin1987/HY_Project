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
    /// 日 期：2021-09-27 09:59
    /// 描 述：黑名单永不录用
    /// </summary>
    public class BlacklistController : MvcControllerBase
    {
        private BlacklistIBLL blacklistIBLL = new BlacklistBLL();

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
            var data = blacklistIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_Platform_BlacklistData = blacklistIBLL.GetHy_Platform_BlacklistEntity(keyValue);
            var jsonData = new
            {
                Hy_Platform_Blacklist = Hy_Platform_BlacklistData,
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
            ReturnCommon rc = blacklistIBLL.DeleteEntity(keyValue);
            if (!rc.Status)
            { return Success(rc.Message, "黑名单设置（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "黑名单设置（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
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
            Hy_Platform_BlacklistEntity entity = strEntity.ToObject<Hy_Platform_BlacklistEntity>();
            ReturnCommon rc = blacklistIBLL.SaveEntity(keyValue, entity);
            if (rc.Status)
            {
                return Success(rc.Message, "黑名单设置", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3);
            }
            else
            {
                return Fail(rc.Message, "黑名单设置", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }

        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UpdateState(string keyValue, int state)
        {
            blacklistIBLL.UpdateState(keyValue, state);
            if (state == 0)
            {
                return Success("停用成功！");
            }
            else
            {
                return Success("启用成功");
            }
        }
        #endregion

    }
}
