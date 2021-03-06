
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-31 10:54
    /// 描 述：RWrittenExamination
    /// </summary>
    public class RWrittenExaminationController : MvcControllerBase
    {
        private RWrittenExaminationIBLL rWrittenExaminationIBLL = new RWrittenExaminationBLL();

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
            var data = rWrittenExaminationIBLL.GetList(queryJson);
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
            var data = rWrittenExaminationIBLL.GetPageList(paginationobj, queryJson);
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
            var data = rWrittenExaminationIBLL.GetEntity(keyValue);
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
            
            ReturnCommon rc = rWrittenExaminationIBLL.DeleteEntity(keyValue);
            if (rc.Status)
            { return Success(rc.Message, "应聘者笔试信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "应聘者笔试信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult Resetinfo(string keyValue)
        {

            ReturnCommon rc = rWrittenExaminationIBLL.ResetInfo(keyValue);
            if (rc.Status)
            { return Success(rc.Message, "重置笔试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "重置笔试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
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
        public ActionResult SaveForm(string keyValue, WrittenExaminationEntityDTO entity)
        {
            ReturnCommon rc = rWrittenExaminationIBLL.SaveEntity(keyValue, entity);
            if (rc.Status)
            { return Success(rc.Message, "应聘者笔试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else 
            {
                return Fail(rc.Message, "应聘者笔试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
            
        }
       
       #endregion

    }
}
