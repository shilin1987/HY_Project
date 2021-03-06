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
    /// 日 期：2021-06-15 10:19
    /// 描 述：个人标准工资维护
    /// </summary>
    public class EverybodyStandardWageController : MvcControllerBase
    {
        private EverybodyStandardWageIBLL everybodyStandardWageIBLL = new EverybodyStandardWageBLL();

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
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SubForm()
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
            var data = everybodyStandardWageIBLL.GetPageList(paginationobj, queryJson);
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
        /// 获取表的字段数据
        /// </summary>
        /// <param name="databaseLinkId">连接串Id</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSubList(string fid, decimal fcost)
        {
            var data = everybodyStandardWageIBLL.GetSubList(fid, fcost);
          
            return Success(data);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var Hy_hr_EverybodyStandardWageData = everybodyStandardWageIBLL.GetHy_hr_EverybodyStandardWageEntity( keyValue );
            var jsonData = new {
                Hy_hr_EverybodyStandardWage = Hy_hr_EverybodyStandardWageData,
            };
            return Success(jsonData);
        }

        /// <summary>
        ///  获取岗级和基本工资数据
        /// </summary>
        /// <param name="keyValue">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormInitData(string userId)
        {
            var Hy_hr_PostLevelEntityData = everybodyStandardWageIBLL.GetHy_hr_PostLevelEntityEntity(userId);
            var jsonData = new
            {
                minimum= Hy_hr_PostLevelEntityData.F_PostSalaryMinimum,
                maxmum = Hy_hr_PostLevelEntityData.F_PostSalaryMaximum,
                basepay= Hy_hr_PostLevelEntityData.F_BasePay,
                PostLevelId= Hy_hr_PostLevelEntityData.F_ID
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSubFormData(string keyValue)
        {
            var Hy_hr_EverybodyStandardWageData = everybodyStandardWageIBLL.GetHy_hr_EverybodyStandardWageSubEntity(keyValue);
            var jsonData = new
            {
                Hy_hr_EverybodyStandardWageSub = Hy_hr_EverybodyStandardWageData,
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
            var result = everybodyStandardWageIBLL.DeleteEntity(keyValue);
           
            if (!result.Status)
            {
                return Fail(result.Message, "个人标准工资维护(删除父项)", Util.Operat.OperationType.Delete,keyValue, result.ToString());
            }
            else
            {
                return Success(result.Message, "个人标准工资维护(删除父项)", Util.Operat.OperationType.Delete, keyValue, result.ToString(),3);
            }
        }

        /// <summary>
        /// 删除子项实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteFormSub(string keyValue)
        {
            var result = everybodyStandardWageIBLL.DeleteSubEntity(keyValue);
            if (!result.Status)
            {
                return Fail(result.Message, "个人标准工资维护(删除子项)", Util.Operat.OperationType.Delete, keyValue, result.ToString());
            }
            else
            {
                return Success(result.Message, "个人标准工资维护(删除子项)", Util.Operat.OperationType.Delete, keyValue, result.ToString(),3);
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <param name="basePay">基本工资</param>
        /// <param name="strEntity"></param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue,string basePay, string strEntity)
        {
            Hy_hr_EverybodyStandardWageEntity entity = strEntity.ToObject<Hy_hr_EverybodyStandardWageEntity>();
            var result = everybodyStandardWageIBLL.SaveEntity(keyValue, basePay, entity);
            if (!result.Status)
            {
                return Fail(result.Message, "个人标准工资维护(新增、修改)", Util.Operat.OperationType.Create, keyValue, result.ToString());
            }
            else
            {
                return Success(result.Message, "个人标准工资维护(新增、修改)", Util.Operat.OperationType.Create, keyValue, result.ToString(),3);
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
        public ActionResult SaveSubForm(string subId, string parentId, string strEntity)
        {
            Hy_hr_EverybodyStandardWageSubEntity entity = strEntity.ToObject<Hy_hr_EverybodyStandardWageSubEntity>();
            if(string.IsNullOrEmpty(entity.F_ItemId) || entity.F_Cost==null)
            {
                return  Fail("请输入子项和子项金额.");
            }
            var result = everybodyStandardWageIBLL.SaveSubEntity(subId, parentId, entity);
            if (!result.Status)
            {
                return Fail(result.Message, "个人标准工资维护(子项新增、修改)", Util.Operat.OperationType.Create, subId, result.ToString());
            }
            else
            {
                return Success(result.Message, "个人标准工资维护(子项新增、修改)", Util.Operat.OperationType.Create, subId, result.ToString(),3);
            }
        }
        #endregion

    }
}
