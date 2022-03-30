using Learun.Util;
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
    /// 日 期：2021-07-05 16:13
    /// 描 述：奖惩费用维护
    /// </summary>
    public class RewardsPunishmentsController : MvcControllerBase
    {
        private RewardsPunishmentsIBLL rewardsPunishmentsIBLL = new RewardsPunishmentsBLL();

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
            var data = rewardsPunishmentsIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_hr_RewardPunishmentData = rewardsPunishmentsIBLL.GetHy_hr_RewardPunishmentEntity( keyValue );
            var jsonData = new {
                Hy_hr_RewardPunishment = Hy_hr_RewardPunishmentData,
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
            var result = rewardsPunishmentsIBLL.DeleteEntity(keyValue);
            if (!result.Status)
            {
                return Fail(result.Message);
            }
            else
            {
                return Success(result.Message);
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
            Hy_hr_RewardPunishmentEntity entity = strEntity.ToObject<Hy_hr_RewardPunishmentEntity>();
            var result = rewardsPunishmentsIBLL.SaveEntity(keyValue,entity);
            if (!result.Status)
            {
                return Fail(result.Message);
            }
            else
            {
                return Success(result.Message);
            }
        }
        #endregion

    }
}
