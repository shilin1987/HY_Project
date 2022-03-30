using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_Code;
using System.Web.Mvc;
using Learun.Application.TwoDevelopment.HR_Code.MonthlySettlements;
using Learun.Application.TwoDevelopment.ReturnModel;
using System.IO;
using System;
using System.Web;

namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 10:51
    /// 描 述：最终工资结算展示
    /// </summary>
    public class SalaryGenerationController : MvcControllerBase
    {
        private SalaryGenerationIBLL salaryGenerationIBLL = new SalaryGenerationBLL();


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
            var data = salaryGenerationIBLL.GetSalaryGenerationEntity(paginationobj, queryJson);
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
            var Hy_hr_SalaryGenerationData = salaryGenerationIBLL.GetHy_hr_SalaryGenerationEntity(keyValue);
            var jsonData = new
            {
                Hy_hr_SalaryGeneration = Hy_hr_SalaryGenerationData,
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
            salaryGenerationIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult CalculateMonthlySettlement()
        {
            MonthlySettlementsIBLL monthlySettlementsIBLL = new MonthlySettlementsIBLLImpl();
            ReturnCommon rs = monthlySettlementsIBLL.monthlyCalculation("202108");
            if (rs.Status)
            {
                return Success("计算成功！");
            }
            else
            {
                return Fail(rs.Message + "计算失败！");
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
            Hy_hr_SalaryGenerationEntity entity = strEntity.ToObject<Hy_hr_SalaryGenerationEntity>();
            salaryGenerationIBLL.SaveEntity(keyValue, entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult Excelreport(DataTable data)
        {
            var result = salaryGenerationIBLL.ExcelreportEntity(data);
            return Success(result.Message);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetExportList(string pagination, string queryJson)
        {
            string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/Files/";
            Pagination paginationobj = pagination.ToObject<Pagination>();
            string filenamenewpath = salaryGenerationIBLL.GetExportList(paginationobj, queryJson, Server.MapPath("~/Files/"), url);
            string filenamenew = url + filenamenewpath;
            return Success(filenamenew);
        }
        /// 文件下载 
        /// </summary> 
        /// <param name="FileName">下载后的文件名</param> 
        /// <param name="FilePath">需要下载文件的server.path路径</param> 
        public void BigFileDownload(string FileName, string FilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    //以字符流的形式下载文件

                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    // wb.Write(fs);
                    //开始调用html页面下载窗
                    Response.ContentType = "application/octet-stream;charset=gb2321";
                    //通知浏览器下载文件而不是打开;对中文名称进行编码
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                    fs.Close();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Response.Flush();
                Response.End();
            }
        }
    }
    #endregion


}
