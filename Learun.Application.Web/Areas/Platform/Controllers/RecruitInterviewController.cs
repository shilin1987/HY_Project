using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 15:16
    /// 描 述：面试信息
    /// </summary>
    public class RecruitInterviewController : MvcControllerBase
    {
        private RecruitInterviewIBLL recruitInterviewIBLL = new RecruitInterviewBLL();

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
        public ActionResult NoticeForm()
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
            var data = recruitInterviewIBLL.GetList(queryJson);
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
            var data = recruitInterviewIBLL.GetPageList(paginationobj, queryJson);
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
            var data = recruitInterviewIBLL.GetEntity(keyValue);
            return Success(data);
        }
        /// <summary>
        /// 获取用户数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetUserlist(string keyValue)
        {
            CandidateInformationIBLL candidateInformationIBLL = new CandidateInformationBLL();
            var data = candidateInformationIBLL.GetHy_Recruit_CandidatesEntity(keyValue);
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
            ReturnCommon rc= recruitInterviewIBLL.DeleteEntity(keyValue);
            if (!rc.Status)
            { return Success(rc.Message, "应聘者面试信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message + "!!!", "应聘者面试信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
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
        public ActionResult SaveForm(string keyValue, InterviewEntityDTO entity)
        {
            ReturnCommon rc= recruitInterviewIBLL.SaveEntity(keyValue, entity);
            if (rc.Status)
            { return Success(rc.Message, "应聘者面试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3); }
            else
            {
                return Fail(rc.Message, "应聘者面试信息", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
            }
        }
        #endregion
        [HttpPost]
        [AjaxOnly]
        public ActionResult SendDate(SendEntity model)
        {
            SetSendReport(model);
            return Success( "报到通知单发送成功");
        }


        /// <summary>
        /// 发送报告单
        /// </summary>
        /// <param name="registered"></param>
        /// <returns></returns>
        public ActionResult SetSendReport(SendEntity report)
        {
            ReturnCommon rc = new ReturnCommon();
            if (report != null)
            {
                try
                {
                    //发送短信
                    string mobile = report.F_Mobile,
                    content = "【华羿微电】录用通知:" + report.F_RealName + ",恭喜您已被华羿微电录用,请于" + report.F_SendOutDate + "来公司报到。1、携带本人身份证及复印件2、毕业证（复印件）3、1寸免冠照片3张（红底）4、3月内体检报告5、招商银行储蓄卡",
                    account = "109751",
                    password = "X6pkMb",
                    extno = "10690565708 ",
                    url = "https://api.juhedx.com/sms?action=send";
                    byte[] byteArray = Encoding.UTF8.GetBytes("&account=" + account + "&password=" + password + "&mobile=" + mobile + "&content=" + content + "&extno=" + extno + "&rt=json");
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.ContentLength = byteArray.Length;
                    Stream newStream = webRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length);
                    newStream.Close();
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    sr.ReadToEnd();
                    rc.Message = "报到单发送成功";

                }
                catch (Exception ex)
                {
                    rc.Message = "发送失败:" + ex.Message;
                }
                
            }
            return Success(rc.Message);
        }
    }
}
