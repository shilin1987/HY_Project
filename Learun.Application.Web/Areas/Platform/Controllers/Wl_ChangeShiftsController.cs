using AutoMapper;
using Learun.Application.TwoDevelopment.HR_Code.BatchPrintChangePDF;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.Web.Areas.Platform.ViewModel;
using Learun.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 16:49
    /// 描 述：Wl_ChangeShifts
    /// </summary>
    public class Wl_ChangeShiftsController : MvcControllerBase
    {
        private Wl_ChangeShiftsIBLL wl_ChangeShiftsIBLL = new Wl_ChangeShiftsBLL();
        private BatchPrintPDFIBLL batchPrintPDFIBLL = new BatchPrintPDFBLL();

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
        public ActionResult GetList(string queryJson)
        {
            var data = wl_ChangeShiftsIBLL.GetList(queryJson);
            return Success(data);
        }

        /// <summary>
        /// 根据员工账号查询员工信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserInfoForAccoount(string account)
        {
            var data = wl_ChangeShiftsIBLL.GetUserInfoForAccoount(account);
            return data.Status == true ? Success(data.Data) : Fail(data.Message);
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
            var data = wl_ChangeShiftsIBLL.GetPageList(paginationobj, queryJson);
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
            var data = wl_ChangeShiftsIBLL.GetEntity(keyValue);
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
            var data = wl_ChangeShiftsIBLL.GetSubList(fno);
            return Success(data);
        }


        /// <summary>
        /// 获取员工的字段数据
        /// </summary>
        /// <param name="F_EnCode">主表fno</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetUserList(string F_UserId)
        {
            var data = wl_ChangeShiftsIBLL.GetUserList(F_UserId);
            return Success(data);
        }

        /// <summary>
        /// 获取字段数据
        /// </summary>
        /// <param name="F_EnCode">主表fno</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserChangeShiftsList(string fid)
        {
            var data = wl_ChangeShiftsIBLL.GetUserChangeShiftsList(fid);
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
            wl_ChangeShiftsIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, Hy_Wl_ChangeShiftsEntity entity)
        {
            ReturnComment rc = wl_ChangeShiftsIBLL.SaveEntity(keyValue, entity);
            if ("S".Equals(rc.State))
            {
                return Success("上岗证" + rc.Mes);
            }
            else
            {
                return Fail(rc.Mes + "!!!", "上岗证倒班", Util.Operat.OperationType.Create, keyValue, rc.Mes.ToString());
            }
        }

        /// <summary>
        /// 保存需要生成的PDF文件
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public FileResult SetDownloadPDF(string jsondata)
        {
            try
            {
                if (!string.IsNullOrEmpty(jsondata))
                {
                    var data = JsonConvert.DeserializeObject<List<DownLoadPDFInfo>>(jsondata);
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DownLoadPDFInfo, BothSidesOfWorkPermitDTO>()
                        .ForMember(s => s.positive, opts => opts.MapFrom(source => source.canvasBase64Above))
                        .ForMember(s => s.reverse, opts => opts.MapFrom(source => source.canvasBase64Below));
                    });

                    IMapper iMapper = config.CreateMapper();
                    var destination = iMapper.Map<List<DownLoadPDFInfo>, List<BothSidesOfWorkPermitDTO>>(data);
                    var result = batchPrintPDFIBLL.getBatchPrintPdf(destination);

                    var filename = "PDF" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    return File(result, "application/pdf", filename + ".pdf");

                }
                else
                {
                    // return Fail("请选择需要生成上岗证人员", "保存需要生成的PDF文件", Util.Operat.OperationType.Create, "",jsondata);
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception("保存需要生成的PDF文件出错:" + ex.Message);
                // return Fail(ex.Message, "保存需要生成的PDF文件", Util.Operat.OperationType.Create, "", jsondata);
            }

            return null;
        }

        #endregion

    }
}
