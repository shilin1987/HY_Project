using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.Platform;
using System.Collections.Generic;
using Learun.Application.Organization.ReturnModel;
using System.IO;
using System.Web.Mvc;
using System.Web;

namespace Learun.Application.Web.Areas.Platform.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-30 19:37
    /// 描 述：应聘者信息
    /// </summary>
    public class CandidateInformationController : MvcControllerBase
    {
        private CandidateInformationIBLL candidateInformationIBLL = new CandidateInformationBLL();

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
        public ActionResult HeadForm()
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
            var data = candidateInformationIBLL.GetPageList(paginationobj, queryJson);
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
            var Hy_Recruit_CandidatesData = candidateInformationIBLL.GetHy_Recruit_CandidatesEntity( keyValue );
            var jsonData = new {
                Hy_Recruit_Candidates = Hy_Recruit_CandidatesData,
            };
            return Success(jsonData);
        }

        
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetUserBlackList(string F_IDCard)
        {
            var data = candidateInformationIBLL.GetUserBlackList(F_IDCard);
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
            ReturnCommon rc = candidateInformationIBLL.DeleteEntity(keyValue);
            if (rc.Status)
            {
                return Success(rc.Message, "应聘者信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString(), 3);
            }
            else
            {
                return Fail(rc.Message + "!", "应聘者信息（删除操作）", Util.Operat.OperationType.Create, keyValue, rc.Message.ToString());
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
            Hy_Recruit_CandidatesEntity entity = strEntity.ToObject<Hy_Recruit_CandidatesEntity>();
            var result= candidateInformationIBLL.SaveEntity(keyValue,entity);
            if (result.Status)
            {
                return Success(result.Message, "应聘者信息保存", Util.Operat.OperationType.Create, keyValue, result.Message.ToString(), 3);
            }
            else
            {
                return Fail(result.Message, "应聘者信息保存", Util.Operat.OperationType.Create, keyValue, result.Message.ToString());
            }

        }
        /// <summary>
        /// 获取设置图片
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult GetImg(string keyValue)
        //{
        //    candidateInformationIBLL.GetImg(keyValue);
        //    return Success("获取成功。");
        //}
        /// <summary>
        /// 上传照片
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[AjaxOnly]
        //public ActionResult UploadFile(string keyValue)
        //{
        //    HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
        //    //没有文件上传，直接返回
        //    if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
        //    {
        //        return HttpNotFound();
        //    }
        //    var Hy_Recruit_CandidatesData = candidateInformationIBLL.GetHy_Recruit_CandidatesEntity(keyValue);
        //    string FileEextension = Path.GetExtension(files[0].FileName);
        //    string fileHeadImg = Config.GetValue("fileHeadImg");
        //    string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, Hy_Recruit_CandidatesData.F_RealName, FileEextension);
        //    //创建文件夹，保存文件
        //    string path = Path.GetDirectoryName(fullFileName);
        //    Directory.CreateDirectory(path);
        //    files[0].SaveAs(fullFileName);

        //    Hy_Recruit_CandidatesEntity CandidatesEntity = new Hy_Recruit_CandidatesEntity();
        //    CandidatesEntity.F_HeadIcon = FileEextension;
        //    candidateInformationIBLL.SaveEntity(keyValue, CandidatesEntity);
        //    return Success("上传成功。");
        //}
        #endregion

    }
}
