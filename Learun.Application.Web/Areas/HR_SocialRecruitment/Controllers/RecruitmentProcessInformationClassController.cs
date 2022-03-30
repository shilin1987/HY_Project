using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.HR_SocialRecruitment.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public class RecruitmentProcessInformationClassController : MvcControllerBase
    {
        private RecruitmentProcessInformationClassIBLL recruitmentProcessInformationClassIBLL = new RecruitmentProcessInformationClassBLL();

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
            var data = recruitmentProcessInformationClassIBLL.GetPageList(paginationobj, queryJson);
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
            var SR_RecruitmentProcessNodeData = recruitmentProcessInformationClassIBLL.GetSR_RecruitmentProcessNodeEntity( keyValue );
            var SR_ProcessNodeData = recruitmentProcessInformationClassIBLL.GetSR_ProcessNodeEntity( SR_RecruitmentProcessNodeData.F_ID );
            var SR_ProcessAttachmentData = recruitmentProcessInformationClassIBLL.GetSR_ProcessAttachmentEntity( SR_RecruitmentProcessNodeData.F_ID );
            var jsonData = new {
                SR_RecruitmentProcessNode = SR_RecruitmentProcessNodeData,
                SR_ProcessNode = SR_ProcessNodeData,
                SR_ProcessAttachment = SR_ProcessAttachmentData,
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
            recruitmentProcessInformationClassIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strsR_ProcessNodeEntity, string strsR_ProcessAttachmentEntity)
        {
            SR_RecruitmentProcessNodeEntity entity = strEntity.ToObject<SR_RecruitmentProcessNodeEntity>();
            SR_ProcessNodeEntity sR_ProcessNodeEntity = strsR_ProcessNodeEntity.ToObject<SR_ProcessNodeEntity>();
            SR_ProcessAttachmentEntity sR_ProcessAttachmentEntity = strsR_ProcessAttachmentEntity.ToObject<SR_ProcessAttachmentEntity>();
            recruitmentProcessInformationClassIBLL.SaveEntity(keyValue,entity,sR_ProcessNodeEntity,sR_ProcessAttachmentEntity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion

    }
}
