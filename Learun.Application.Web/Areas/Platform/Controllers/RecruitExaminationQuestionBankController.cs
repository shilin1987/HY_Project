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
    /// 日 期：2022-01-26 10:09
    /// 描 述：应聘者笔试题库
    /// </summary>
    public class RecruitExaminationQuestionBankController : MvcControllerBase
    {
        private RecruitExaminationQuestionBankIBLL recruitExaminationQuestionBankIBLL = new RecruitExaminationQuestionBankBLL();

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
            var data = recruitExaminationQuestionBankIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_Recruit_WrittenExaminationQuestionBankData = recruitExaminationQuestionBankIBLL.GetHy_Recruit_WrittenExaminationQuestionBankEntity( keyValue );
            var jsonData = new {
                Hy_Recruit_WrittenExaminationQuestionBank = Hy_Recruit_WrittenExaminationQuestionBankData,
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
            recruitExaminationQuestionBankIBLL.DeleteEntity(keyValue);
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
            Hy_Recruit_WrittenExaminationQuestionBankEntity entity = strEntity.ToObject<Hy_Recruit_WrittenExaminationQuestionBankEntity>();
            ReturnCommon rc= recruitExaminationQuestionBankIBLL.SaveEntity(keyValue,entity);
            if (rc.Status)
            { return Success(rc.Message, "笔试题库（新增成功）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message, "笔试题库（新增失败）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        #endregion

    }
}
