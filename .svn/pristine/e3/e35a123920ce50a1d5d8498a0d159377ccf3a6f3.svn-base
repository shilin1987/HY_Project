using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;

namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 14:32
    /// 描 述：晶圆清单导入
    /// </summary>
    public class B2B_WAFER_LISTController : MvcControllerBase
    {
        private B2B_WAFER_LISTIBLL b2B_WAFER_LISTIBLL = new B2B_WAFER_LISTBLL();

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
            var data = b2B_WAFER_LISTIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetPageListSub(string keyValue)     
        {
          
            var data = b2B_WAFER_LISTIBLL.GetPageListSub(keyValue);          
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
            var B2B_WAFER_LIST_SUBData = b2B_WAFER_LISTIBLL.GetB2B_WAFER_LIST_SUBEntity(keyValue);
            var B2B_WAFER_LISTData = b2B_WAFER_LISTIBLL.GetB2B_WAFER_LISTEntity(B2B_WAFER_LIST_SUBData.FGUID);
            var jsonData = new
            {
                B2B_WAFER_LIST = B2B_WAFER_LISTData,
                B2B_WAFER_LIST_SUB = B2B_WAFER_LIST_SUBData,
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
            b2B_WAFER_LISTIBLL.DeleteEntity(keyValue);
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
        public ActionResult Saveupload(string strEntity, string strEntitySub)
        {
            List<B2B_WAFER_LIST_SUBEntity> entitysub = new List<B2B_WAFER_LIST_SUBEntity>();
            B2B_WAFER_LISTEntity entity = strEntity.ToObject<B2B_WAFER_LISTEntity>();

            List<ExcelParam> execdata = strEntitySub.ToList<ExcelParam>();

            foreach (var item in execdata)
            {
                if (item.Column1 !=string.Empty && item.Column1.Length>0 && item.Column2 != string.Empty && item.Column2.Length > 0)
                {
                    entitysub.Add(new B2B_WAFER_LIST_SUBEntity
                    {
                        FWAFER_TYPE = item.Column1,//芯片型号
                        FWAFER_BATCH = item.Column2,//批号
                        FWAFER_QTY = item.Column3,//片数
                        FWAFER_DIE = item.Column4,//片号
                        FWAFER_NUMBER = item.Column5,//数量
                        FPARAMETER_01 = item.Column6,//发货日期
                        FPARAMETER_02 = item.Column7//快递方式/单号
                    });
                }
            }
            b2B_WAFER_LISTIBLL.Saveupload(entity, entitysub);
            return Success("保存成功！");
        }

        [HttpPost]
        public ActionResult UploadFile(string Tile)
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }

            string FileEextension = Path.GetExtension(files[0].FileName);
            string fileHeadImg = Config.GetValue("fileLogoImg");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, "importfile", FileEextension);
            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);

            DataTable execldata = ExcelImport(fullFileName);

            return Success(execldata);
        }
        public static DataTable ExcelImport(string strFileName)
        {
            DataTable dt = new DataTable();

            ISheet sheet = null;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (strFileName.IndexOf(".xlsx") == -1)//2003
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
                    sheet = hssfworkbook.GetSheetAt(0);
                }
                else//2007
                {
                    XSSFWorkbook xssfworkbook = new XSSFWorkbook(file);
                    sheet = xssfworkbook.GetSheetAt(0);
                }
            }

            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 4); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        #endregion
    }
}
