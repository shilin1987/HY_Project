using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.Platform;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.Platform.RecruitReportNodeApprovalClass;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-27 18:33
    /// 描 述：报道节点审批维护
    /// </summary>
    public class RecruitReportNodeApprovalClassController : MvcControllerBase
    {
        private RecruitReportNodeApprovalClassIBLL recruitReportNodeApprovalClassIBLL = new RecruitReportNodeApprovalClassBLL();

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
        /// <summary>
        /// 设置宿舍页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DormitoryForm()
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
            var data = recruitReportNodeApprovalClassIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_Recruit_ReportNodeApprovalData = recruitReportNodeApprovalClassIBLL.GetHy_Recruit_ReportNodeApprovalEntity( keyValue );
            var jsonData = new {
                Hy_Recruit_ReportNodeApproval = Hy_Recruit_ReportNodeApprovalData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult getDormitoryForm(string keyValue)
        {
            CandidateInformationIBLL candidateInformationIBLL = new CandidateInformationBLL();
            var data = candidateInformationIBLL.GetICardEntity(keyValue);
            return Success(data);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// data
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            recruitReportNodeApprovalClassIBLL.DeleteEntity(keyValue);
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

            Hy_Recruit_ReportNodeApprovalEntity entity = strEntity.ToObject<Hy_Recruit_ReportNodeApprovalEntity>();
            recruitReportNodeApprovalClassIBLL.SaveEntity(keyValue,entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult SavDormitory(DormitoryDTO model)
        {
            ReturnCommon rc = new ReturnCommon();
            CandidateInformationIBLL candidateInformationIBLL = new CandidateInformationBLL();
            rc = candidateInformationIBLL.SavDormitory(model);
            if (rc.Status)
            {
                return Success("证件照审核完成");
            }
            else
            {
                return Fail(rc.Message + "!!!", "证件照审核失败", Util.Operat.OperationType.Create, model.F_CardId, rc.Message.ToString());
            }
        }
        /// <summary>
        /// 报道通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult AuditInfo(string keyValue)
        {
            ReturnCommon rc = new ReturnCommon();
            rc = recruitReportNodeApprovalClassIBLL.AuditInfo(keyValue);
            if (rc.Status)
            {
                return Success("报道通过设置完成！");
            }
            else
            {
                return Fail(rc.Message + "!!!", "报道通过设置未完成", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }

        /// <summary>
        /// 重新上传
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ResetInfo(string keyValue)
        {
            ReturnCommon rc = new ReturnCommon();
            rc = recruitReportNodeApprovalClassIBLL.ResetInfo(keyValue);
            if (rc.Status)
            {
                return Success("重新上传设置完成！");
            }
            else
            {
                return Fail(rc.Message + "!!!", "重新上传设置未完成", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }

        /// <summary>
        /// 报道不通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UnAuditInfo(string keyValue)
        {
            ReturnCommon rc = new ReturnCommon();
            rc = recruitReportNodeApprovalClassIBLL.UnAuditInfo(keyValue);
            if (rc.Status)
            {
                return Success("报道不通过设置完成！");
            }
            else
            {
                return Fail(rc.Message + "!!!", "报道不通过设置未完成", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }

        /// <summary>
        /// 报道批量审批
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult BatchAuditInfo(string keyValue)
        {
            ReturnCommon rc = new ReturnCommon();
            rc = recruitReportNodeApprovalClassIBLL.BatchAuditInfo(keyValue);
            if (rc.Status)
            {
                return Success("批量审批成功！");
            }
            else
            {
                return Fail(rc.Message + "!!!", "报道节点批量审批失败", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        #endregion

    }
}
