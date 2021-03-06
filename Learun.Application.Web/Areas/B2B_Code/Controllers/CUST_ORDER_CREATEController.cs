using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;
using System.Web;
using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;



namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-04 18:21
    /// 描 述：客户订单维护
    /// </summary>
    public class CUST_ORDER_CREATEController : MvcControllerBase
    {
        private CUST_ORDER_CREATEIBLL cUST_ORDER_CREATEIBLL = new CUST_ORDER_CREATEBLL();

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

        [HttpGet]
        public ActionResult ShowList(string parameters)
        {
            string[] param = parameters.Split(',');

            ViewBag.cust = param[0].Substring(param[0].IndexOf("=") + 1);
            ViewBag.wafer = param[1].Substring(param[1].IndexOf("=") + 1);
            ViewBag.product = param[2].Substring(param[2].IndexOf("=") + 1);
            ViewBag.url = param[3].Substring(param[3].IndexOf("=") + 1);
            ViewBag.Colname = param[4].Substring(param[4].IndexOf("=") + 1);

            return View("Frm_List");
        }

        [HttpGet]
        public ActionResult WaferForm()
        {
            return View("Frm_wafer_no");
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
        [HttpGet]
        public ActionResult upload()
        {
            return View("upload");
        }
        #endregion

        #region 获取数据

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult GetListWaferNo()
        {            
            string text = "";
            //foreach (var item in list)
            //{
            //    if (!string.IsNullOrEmpty(text))
            //    {
            //        text += ",";
            //    }
            //    text += item.F_RealName;
            //}
            return SuccessString(text);
        }

        [HttpGet]
        public ActionResult GetDataTable(string Fcustom)
        {
            ViewBag.cust = Fcustom;
            return View("Showproudct");
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var B2B_CUST_ORDERData = cUST_ORDER_CREATEIBLL.GetB2B_CUST_ORDEREntity(keyValue);
            var B2B_CUST_ORDER_PARAMData = cUST_ORDER_CREATEIBLL.GetB2B_CUST_ORDER_PARAMEntity(keyValue);
            var B2B_CUST_ORDER_SUBData = cUST_ORDER_CREATEIBLL.GetB2B_CUST_ORDER_SUBEntity(keyValue);
            var jsonData = new
            {
                B2B_CUST_ORDER = B2B_CUST_ORDERData,
                B2B_CUST_ORDER_PARAM = B2B_CUST_ORDER_PARAMData,
                B2B_CUST_ORDER_SUB = B2B_CUST_ORDER_SUBData,
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = cUST_ORDER_CREATEIBLL.GetPageList(paginationobj, queryJson);
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
            var data = cUST_ORDER_CREATEIBLL.GetPageListSub(keyValue);
             return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetParamtListSub(string keyValue, string partId)
        {
            var data = cUST_ORDER_CREATEIBLL.GetParamtListSub(keyValue,partId);
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
            cUST_ORDER_CREATEIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strEntityParams, string strEntitySub)
        {
           B2B_CUST_ORDEREntity entity = strEntity.ToObject<B2B_CUST_ORDEREntity>();
           
           List<B2B_CUST_ORDER_PARAMEntity> b2B_CUST_ORDER_PARAMEntity = strEntityParams.ToObject<List<B2B_CUST_ORDER_PARAMEntity>>();

           List<B2B_CUST_ORDER_SUBEntity> b2B_CUST_ORDER_SUBEntity = strEntitySub.ToObject<List<B2B_CUST_ORDER_SUBEntity>>();

            cUST_ORDER_CREATEIBLL.SaveEntity(keyValue, entity, b2B_CUST_ORDER_PARAMEntity, b2B_CUST_ORDER_SUBEntity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        /// <summary>
        /// 批导
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult Saveupload(string strEntity, string strEntitySub)
        {
            List<B2B_CUST_ORDER_SUBEntity> entitysub = new List<B2B_CUST_ORDER_SUBEntity>();
            B2B_CUST_ORDEREntity entity = strEntity.ToObject<B2B_CUST_ORDEREntity>();    
            List<ExcelParam> execdata = strEntitySub.ToList<ExcelParam>();
          
            foreach (var item in execdata)
            {
                entitysub.Add(new B2B_CUST_ORDER_SUBEntity
                {
                    FPRODUCT_TYPE = item.Column1,
                    FWAFER_TYPE = item.Column2,
                    FPACKAGE_TYPE = item.Column8,
                    FWAFER_BATCH = item.Column4,
                    FWAFER_NUMBER = item.Column5,
                    FWAFER_NO = item.Column6,
                    FWAFER_QTY = item.Column7,
                    FIS_TEST= item.Column11.Length==0?"否":"是",
                    FTEST_CODE = item.Column11,
                    FIS_PRINT= item.Column13.Length == 0 ? "否" : "是",
                    FPRINT_CODE = item.Column13,
                    FBONDING_CODE= item.Column9,
                    FPACKING_TYPE = item.Column14,
                    FGREEN_LEVE = item.Column15,
                    FBATCH_TYPE = item.Column16,
                    FPACKAGE_LEVE = item.Column17,
                    FGETWAFER_TYPE = item.Column18,
                }) ;
            }
            cUST_ORDER_CREATEIBLL.UploadSaveEntity(entity, entitysub);
             return Success("保存成功！");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetCustDeviceList(string CustCode)
        {
           var data= cUST_ORDER_CREATEIBLL.GetCustDeviceList(CustCode);  
            return Success(data);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetProductList(string CustCode,string CustDevice)
        {
            var data = cUST_ORDER_CREATEIBLL.GetProductList(CustCode, CustDevice);
            return Success(data);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetPackageList(string CustCode, string CustDevice,string InputPart)
        {
            var data = cUST_ORDER_CREATEIBLL.GetProductList(CustCode, CustDevice, InputPart);
            return Success(data);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetOrderParamList(string PARTID)
        {
            var data = cUST_ORDER_CREATEIBLL.GetOrderParamList(PARTID);
            return Success(data);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetOrderAttParamList(int type)
        {
            var data = cUST_ORDER_CREATEIBLL.GetOrderAttParamList(type);
            return Success(data);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetPackingTypeListstring (string CustCode, string CustDevice,string InputPart)
        {
            var data = cUST_ORDER_CREATEIBLL.GetPackingTypeList(CustCode, CustDevice, InputPart);
            return Success(data);
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

            for (int i = (sheet.FirstRowNum + 6); i <= sheet.LastRowNum; i++)
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

        [HttpPost]
        [AjaxOnly]
        public ActionResult FindPartidData(string custcode, string PRODUCT_MODEL, string PACKAGING_TYPE, string PACKAGE_MODEL, string WAFER_MODEL)
        {
            var data = cUST_ORDER_CREATEIBLL.GetPartidData(custcode, PRODUCT_MODEL, PACKAGING_TYPE, PACKAGE_MODEL, WAFER_MODEL);
            var jsonData = new
            {
                mesdata = data

            };
            return Success(jsonData);
        }
        #endregion

    }
}
