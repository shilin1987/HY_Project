﻿using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.B2B_Code;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Learun.Application.Base.SystemModule;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE;

namespace Learun.Application.Web.Areas.B2B_Code.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：B2B_Account
    /// 日 期：2021-10-28 15:35
    /// 描 述：来料计划填报
    /// </summary>
    public class B2B_PLAN_CREATEController : MvcControllerBase
    {
        private B2B_PLAN_CREATEIBLL b2B_PLAN_CREATEIBLL = new B2B_PLAN_CREATEBLL();
        
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
        [HttpGet]
        public ActionResult ImportExcel()
        {
            return View("ImportExcel");
        }
        [HttpGet]
        public ActionResult GetDataTable(string Fcustom)
        {
            ViewBag.cust = Fcustom;
            return View("Showproudct");
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
            var data = b2B_PLAN_CREATEIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetPartidData(string custcode)
        {
            var data = b2B_PLAN_CREATEIBLL.GetPartidData(custcode,"","","","");
            var jsonData = new
            {
                B2B_PLAN_INCOMING_MATERIAL_SUB = data
            };
            return Success(jsonData);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult FindPartidData(string custcode,string PRODUCT_MODEL,string PACKAGING_TYPE,string PACKAGE_MODEL,string WAFER_MODEL)
        {
            var data = b2B_PLAN_CREATEIBLL.GetPartidData(custcode, PRODUCT_MODEL, PACKAGING_TYPE, PACKAGE_MODEL, WAFER_MODEL);
            var jsonData = new
            {
                mesdata = data
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
            var B2B_PLAN_INCOMING_MATERIALData = b2B_PLAN_CREATEIBLL.GetB2B_PLAN_INCOMING_MATERIALEntity( keyValue );
            var B2B_PLAN_INCOMING_MATERIAL_SUBData = b2B_PLAN_CREATEIBLL.GetB2B_PLAN_INCOMING_MATERIAL_SUBList( B2B_PLAN_INCOMING_MATERIALData.F_GUID );
            var jsonData = new {
                B2B_PLAN_INCOMING_MATERIAL_SUB = B2B_PLAN_INCOMING_MATERIAL_SUBData,
                B2B_PLAN_INCOMING_MATERIAL = B2B_PLAN_INCOMING_MATERIALData,
            };
            return Success(jsonData);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageListSub(string keyValue)
        {
            var data = b2B_PLAN_CREATEIBLL.GetPageListSub(keyValue);
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
            b2B_PLAN_CREATEIBLL.DeleteEntity(keyValue,out bool have);
            if (have == false)
            {
                return Success("删除成功！");
            }
            else
            {
                return Success("因计划已被进行合并不能删除！");
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strEntitysub)
        {
            B2B_PLAN_INCOMING_MATERIALEntity entity = strEntity.ToObject<B2B_PLAN_INCOMING_MATERIALEntity>();

            List<ExcelParam> execdata = strEntitysub.ToList<ExcelParam>();
                      
            List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> entitysub = new List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity>();

               
            ///判断前三个月的数据不能为空和零。
            foreach (var item in execdata)
            {
                if (item.Column13 == null )
                {
                    return Success("产品型号为："+item.Column13 + "对应的第一月份不能为空！");
                }
                if (item.Column14 == null)
                {
                    return Success("产品型号为：" + item.Column14 + "对应的第二月份不能为空！");
                }
                if (item.Column15 == null)
                {
                    return Success("产品型号为：" + item.Column15 + "对应的第三月份不能为空！");
                }

                entitysub.Add(new B2B_PLAN_INCOMING_MATERIAL_SUBEntity
                {
                    PARTID = item.Column2,//PARTID
                    F_PRODUCT_MODEL = item.Column3,//产品型号
                    F_PACKAGE_MODEL = item.Column4,//封装外形
                    F_PRODUCT_LEVEL = item.Column5,//封装等级
                    F_WAFER_MODEL = item.Column6,//芯片型号
                    F_WAFER_SIZE = item.Column7,//晶圆尺寸
                    F_PACKAGING_TYPE = item.Column8,//包装方式
                    F_WIRE_SOLDER_CODE = item.Column9,//焊线编号
                    F_WIRE_SOLDER_NAME = item.Column10,//焊线描述
                    F_SHELL_FRAM_CODE = item.Column11,//框架编号
                    F_SHELL_FRAM_NAME = item.Column12,//框架描述
                    F_MONTH_ONE = item.Column13,//月份一
                    F_MONTH_TWO = item.Column14,//月份二
                    F_MONTH_THREE = item.Column15,//月份三
                    F_MONTH_FOUR = item.Column16,//月份四
                    F_MONTH_FIVE = item.Column17,//月份五
                    F_MONTH_SIX = item.Column18,//月份六
                    F_REMARK = item.Column19,//备注
                });
            }

            b2B_PLAN_CREATEIBLL.SaveEntity(keyValue,entity, entitysub, out bool have,out string msg,out bool err);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            if (have==false && err==false)
            {
                return Success("保存成功！");
            }
            else
            {
                if (err==true)              
                {
                  
                    return Fail(msg);
                }
                else if (have==true)
                {
                    return Fail("因本月已对填报的计划进行了合并,不能再进行填报！");
                }
                else
                {
                    return Fail("系统异常！不能再进行填报！");
                }
            }            
        }
        #endregion

        #region 上传数据
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <returns></returns>
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

            for (int i = (sheet.FirstRowNum+2); i <= sheet.LastRowNum; i++)
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
