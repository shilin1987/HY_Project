using Learun.Application.TwoDevelopment.Platform;
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
    /// 日 期：2022-01-13 09:14
    /// 描 述：面试题库
    /// </summary>
    public class RecruitInterviewQuestionBankController : MvcControllerBase
    {
        private RecruitInterviewQuestionBankIBLL recruitInterviewQuestionBankIBLL = new RecruitInterviewQuestionBankBLL();

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
            var data = recruitInterviewQuestionBankIBLL.GetList(queryJson);
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
            var data = recruitInterviewQuestionBankIBLL.GetPageList(paginationobj, queryJson);
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
            var data = recruitInterviewQuestionBankIBLL.GetEntity(keyValue);
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
            ReturnCommon rc= recruitInterviewQuestionBankIBLL.DeleteEntity(keyValue);
            if (rc.Status)
            { return Success(rc.Message, "应聘者面试题库（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "应聘者面试题库（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
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
        public ActionResult SaveForm(string keyValue,Hy_Recruit_InterviewQuestionBankEntity entity)
        {
            ReturnCommon rc= recruitInterviewQuestionBankIBLL.SaveEntity(keyValue, entity);
            if (rc.Status)
            { return Success(rc.Message, "应聘者面试题库（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "应聘者面试题库（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        #endregion

    }
}
