using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System;

namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-10 13:48
    /// 描 述：菜价补贴月数据
    /// </summary>
    public class HrvpsmonthdataTabController : MvcControllerBase
    {
        private HrvpsmonthdataTabIBLL hrvpsmonthdataTabIBLL = new HrvpsmonthdataTabBLL();

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
            var data = hrvpsmonthdataTabIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetExportList(string pagination, string queryJson)
        {
            string url ="http://"+ Request.Url.Host+":" + Request.Url.Port+"/Files/";
            Pagination paginationobj = pagination.ToObject<Pagination>();
            string filenamenewpath = hrvpsmonthdataTabIBLL.GetExportList(paginationobj, queryJson, Server.MapPath("~/Files/"), url);
            string filenamenew = url + filenamenewpath;
           // BigFileDownload("1111",filenamenew);

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


        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var Hr_vpsmonthdataData = hrvpsmonthdataTabIBLL.GetHr_vpsmonthdataEntity( keyValue );
            var jsonData = new {
                Hr_vpsmonthdata = Hr_vpsmonthdataData,
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
            hrvpsmonthdataTabIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
       
        #endregion

    }
}
