using ClosedXML.Excel;
using Learun.Application.CRM;
using Learun.Application.Excel;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Learun.Application.Web.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2018.06.17
    /// 描 述：模板导出
    /// </summary>
    public class SocialRecruitmentController : MvcControllerBase
    {

        private CrmOrderIBLL crmOrderIBLL = new CrmOrderBLL();
        private CrmCustomerIBLL crmCustomerIBLL = new CrmCustomerBLL();
        private ModuleExportIBLL moduleExportIBLL = new ModuleExportBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        private SR_RecruitmentIBLL recruitmentIBLL = new SR_RecruitmentBLL();
        /// <summary>
        /// 管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  获取数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件函数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var orderData = crmOrderIBLL.GetCrmOrderEntity(keyValue);
            var customerData = crmCustomerIBLL.GetEntity(orderData.F_CustomerId);
            var orderProductData = crmOrderIBLL.GetCrmOrderProductEntity(keyValue);
            var departmentDate  = departmentIBLL.GetEntity(keyValue);
            var jsonData = new
            {
                orderData = orderData,
                orderProductData = orderProductData,
                customerData = customerData,
                departmentDate= departmentDate
            };
            return Success(jsonData);
        }

        #region 扩展：导出
        /// <summary>
        /// 导出(Word)
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="requestInfo">数据</param>
        public void ExportWord(string keyValue, string orderInfo)
        {

            //XWPFParagraph p1 = doc.CreateParagraph();//向新文档中添加段落
            //p1.Alignment = ParagraphAlignment.CENTER;//段落对其方式为居中
            //XWPFRun r1 = p1.CreateRun();                //向该段落中添加文字
            //r1.SetText("华羿微电子股份有限公司");
            //r1.IsBold = true;//设置粗体
            //r1.FontSize = 28;//设置字体大小

            //XWPFParagraph p2 = doc.CreateParagraph();
            //p2.Alignment = ParagraphAlignment.CENTER;
            //XWPFRun r2 = p2.CreateRun();
            //r2.SetText("西安市未央区草滩九路创新花园弘业一路");
            //r2.FontSize = 12;//设置字体大小
            //r2.FontFamily = "宋体";

            //XWPFParagraph p3 = doc.CreateParagraph();
            //p3.Alignment = ParagraphAlignment.CENTER;
            //XWPFRun r3 = p3.CreateRun();
            //r3.SetText("电话：029-86685706");
            //r3.FontSize = 12;//设置字体大小
            //r3.FontFamily = "宋体";

            //XWPFParagraph p1 = doc.CreateParagraph();
           // p1.Alignment = ParagraphAlignment.CENTER;
           // XWPFRun r1 = p1.CreateRun();
            //r1.SetText("华羿微电招聘需求申请表");
            //r1.IsBold = true;//设置粗体
            //r1.FontSize = 12;//设置字体大小

            //XWPFParagraph p2 = doc.CreateParagraph();
            //p2.Alignment = ParagraphAlignment.CENTER;
            //XWPFRun r2 = p2.CreateRun();
            //r2.SetText("基本信息");
            //r2.IsBold = true;//设置粗体
            //r2.FontSize = 12;//设置字体大小

            //XWPFParagraph p3 = doc.CreateParagraph();
            //XWPFRun r3_1 = p3.CreateRun();
            //r3_1.SetText("需求部门：");
            //r3_1.FontSize = 12;//设置字体大小
            //r3_1.FontFamily = "宋体";

            //XWPFRun r3_2 = p3.CreateRun();
            //r3_2.SetText("需求岗位名称");
            //r3_2.FontSize = 12;//设置字体大小
            //r3_2.SetUnderline(UnderlinePatterns.Single);
            //r3_2.FontFamily = "宋体";

            //XWPFRun r3_3 = p3.CreateRun();
            //r3_3.SetText("岗位编制人数");
            //r3_3.FontSize = 12;//设置字体大小
            //r3_3.FontFamily = "宋体";

            //XWPFRun r3_4 = p3.CreateRun();
            //r3_4.SetText("岗位现有人数:");
            //r3_4.FontSize = 12;//设置字体大小
            //r3_4.SetUnderline(UnderlinePatterns.Single);
            //r3_4.FontFamily = "宋体";

            //XWPFTable table = doc.CreateTable(26, 8);//创建表格
            //table.Width = 500 * 8;
            //table.SetColumnWidth(0, 500);/* 设置列宽 */
            //table.SetColumnWidth(1, 500);/* 设置列宽 */
            //table.SetColumnWidth(2, 500);/* 设置列宽 */
            //table.SetColumnWidth(3, 500);/* 设置列宽 */
            //table.SetColumnWidth(4, 500);/* 设置列宽 */
            //table.SetColumnWidth(5, 500);/* 设置列宽 */
            //table.SetColumnWidth(6, 500);/* 设置列宽 */
            //table.SetColumnWidth(7, 500);/* 设置列宽 */

            //table.GetRow(0).GetCell(0).SetText("file://D/华羿/HY_Project/Learun.Application.Web/Files/untitled.png");
            //table.GetRow(0).MergeCells(0, 7);

            //table.GetRow(0).GetCell(0).SetText("岗位需求申请表");
            //table.GetRow(0).MergeCells(0, 7);

            //table.GetRow(1).GetCell(7).SetText("机密等级：一般");
            //table.GetRow(1).MergeCells(0, 6);

            //table.GetRow(2).GetCell(0).SetText("基本信息");
            //table.GetRow(2).MergeCells(0, 7);

            //table.GetRow(3).GetCell(0).SetText("需求部门");
            //table.GetRow(3).GetCell(1).SetText("需求部门");
            //table.GetRow(3).GetCell(2).SetText("需求岗位名称");
            //table.GetRow(3).GetCell(3).SetText("需求岗位名称");
            //table.GetRow(3).GetCell(4).SetText("岗位编制人数");
            //table.GetRow(3).GetCell(5).SetText("");
            //table.GetRow(3).GetCell(6).SetText("岗位现有人数");
            //table.GetRow(3).GetCell(7).SetText("");

            //table.GetRow(4).GetCell(0).SetText("部门编制人数");
            //table.GetRow(4).GetCell(1).SetText("");
            //table.GetRow(4).GetCell(2).SetText("部门现有人数");
            //table.GetRow(4).GetCell(3).SetText("");
            //table.GetRow(4).GetCell(4).SetText("申请招聘人数");
            //table.GetRow(4).GetCell(5).SetText("");
            //table.GetRow(4).GetCell(6).SetText("紧急程度");
            //table.GetRow(4).GetCell(7).SetText("");

            //table.GetRow(5).GetCell(0).SetText("需求类型");
            //table.GetRow(5).GetCell(1).SetText("");
            //table.GetRow(5).GetCell(4).SetText("需求原因说明");
            //table.GetRow(5).GetCell(5).SetText("");

            //table.GetRow(6).GetCell(0).SetText("岗级");
            //table.GetRow(6).GetCell(1).SetText("");
            //table.GetRow(6).GetCell(2).SetText("岗位类别");
            //table.GetRow(6).GetCell(3).SetText("");
            //table.GetRow(6).GetCell(4).SetText("建议薪酬区间");
            //table.GetRow(6).GetCell(5).SetText("");

            //table.GetRow(7).GetCell(0).SetText("招聘渠道");
            //table.GetRow(7).GetCell(1).SetText("");
            //table.GetRow(7).GetCell(4).SetText("期望到岗日期");
            //table.GetRow(7).GetCell(5).SetText("");
            //table.GetRow(7).GetCell(6).SetText("申请日期");
            //table.GetRow(7).GetCell(7).SetText("");

            //table.GetRow(8).GetCell(0).SetText("部门需求清单");
            //table.GetRow(8).MergeCells(0, 7);

            //table.GetRow(9).GetCell(0).SetText("岗位描述");
            //table.GetRow(9).GetCell(1).SetText("");
            //table.GetRow(9).MergeCells(1, 7);

            //table.GetRow(10).GetCell(0).SetText("主要职责");
            //table.GetRow(10).GetCell(1).SetText("");
            //table.GetRow(10).MergeCells(1, 7);

            //table.GetRow(11).GetCell(0).SetText("基本条件");
            //table.GetRow(11).GetCell(1).SetText("");
            //table.GetRow(11).MergeCells(1, 7);

            



            //MemoryStream ms = new MemoryStream();
            //doc.Write(ms);
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名   
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.doc", "招聘需求申请表"));
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            // 指定返回的是一个不能被客户端读取的流，必须被下载   
            Response.ContentType = "application/ms-word";
            // 把文件流发送到客户端 
            //Response.BinaryWrite(ms.ToArray());
           // doc = null;
           // ms.Close();
           // ms.Dispose();
        }


        /// <summary>
        /// 导出(Excel)
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="requestInfo">数据</param>
        public void ExportExcel(string keyValue, string orderInfo)
        {
            var departmentDate = departmentIBLL.GetEntity(keyValue);//获取部门信息
            //var customerData = crmCustomerIBLL.GetEntity(departmentDate.F_DepartmentId);//获取部门信息
            //var goodsList = crmOrderIBLL.GetCrmOrderProductEntity(keyValue);//获取相应部门
            //List<CrmOrderProductEntity> list = goodsList.ToList();
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("华羿微电招聘需求申请表");//shift名称
            //ws.Cell("A1").Value = "华羿微电子股份有限公司";//表格标题A1代表表格第一行的内容
            //ws.Cell("A2").Value = "西安市未央区草滩九路创新花园弘业一路";//表格标题A2代表表格第一行的内容
            //ws.Range(2, 1, 2, 8).Merge();
            //ws.Range(2, 1, 2, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell("A2").Style.Font.FontSize = 10;
            //ws.Cell("A3").Value = "电话：029-86685706";//表格标题A3代表表格第一行的内容
            //ws.Range(3, 1, 3, 8).Merge();
            //ws.Range(3, 1, 3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell("A3").Style.Font.FontSize = 10;
            ws.Cell("A1").Value = "招聘需求申请表";//表格标题A4代表表格第一行的内容
            ws.Range(2, 1, 4, 8).Merge();
            ws.Range(2, 1, 4, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(2, 1, 4, 8).Style.Font.Bold = true;
            //申请表信息
            ws.Cell("A5").Value = "需 求 部 门";
            ws.Cell("B5").Value = departmentDate.F_FullName;
            ws.Cell("B5").DataType = 0;
            ws.Range(5, 2, 5, 8).Merge();
            ws.Range(5, 2, 5, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("C5").Value = "需求岗位名称";
            ws.Cell("D5").Value = "";
            ws.Cell("D5").DataType = 0;
            ws.Range(5, 8, 5, 8).Merge();
            ws.Range(5, 8, 5, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            ws.Cell("E5").Value = "岗位编制人数";
            ws.Cell("F5").Value = "";
            ws.Cell("F5").DataType = 0;
            ws.Range(6, 2, 6, 8).Merge();
            ws.Range(6, 2, 6, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("G5").Value = "岗位现有人数";
            ws.Cell("H5").Value = "";
            ws.Cell("H5").DataType = 0;
            ws.Range(6, 8, 6, 8).Merge();
            ws.Range(6, 8, 6, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            ws.Cell("A6").Value = "部门编制人数";
            ws.Cell("B6").Value = "";
            ws.Cell("B6").DataType = 0;
            ws.Range(7, 2, 7, 8).Merge();
            ws.Range(7, 2, 7, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("C6").Value = "部门现有人数";
            ws.Cell("D6").Value = "";
            ws.Cell("D6").DataType = 0;
            ws.Range(7, 8, 7, 8).Merge();
            ws.Range(7, 8, 7, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            ws.Cell("E6").Value = "申请招聘人数";
            ws.Cell("F6").Value = "";
            ws.Cell("F6").DataType = 0;
            ws.Range(8, 2, 8, 8).Merge();
            ws.Range(8, 2, 8, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("G6").Value = "紧 急 程 度";
            ws.Cell("H6").Value = "";
            ws.Cell("H6").DataType = 0;
            ws.Range(8, 8, 8, 8).Merge();
            ws.Range(8, 8, 8, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            ws.Cell("A7").Value = "需求类型";
            ws.Cell("B7").Value = "";
            ws.Cell("B6").DataType = 0;
            ws.Range(9, 3, 9, 8).Merge();
            ws.Range(9, 3, 9, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("E7").Value = "需求原因说明";
            ws.Cell("F7").Value = "";
            ws.Cell("F6").DataType = 0;
            ws.Range(9, 3, 9, 8).Merge();
            ws.Range(9, 3, 9, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            ws.Cell("A8").Value = "岗级";
            ws.Cell("B8").Value = "";
            ws.Cell("B8").DataType = 0;
            ws.Range(10, 3, 10, 8).Merge();
            ws.Range(10, 3, 10, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("C8").Value = "岗位类别";
            ws.Cell("D8").Value = "";
            ws.Cell("D8").DataType = 0;
            ws.Range(10, 3, 10, 8).Merge();
            ws.Range(10, 3, 10, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell("E8").Value = "建议薪酬区间";
            ws.Cell("F8").Value = "";
            ws.Cell("F8").DataType = 0;
            ws.Range(10, 3, 10, 8).Merge();
            ws.Range(10, 3, 10, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;




            ////表格表头处理
            //ws.Cell("A10").Value = "编号";
            //ws.Cell("B10").Value = "品名";
            //ws.Range(9, 2, 9, 4).Merge();
            //ws.Range(9, 2, 9, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //ws.Cell("E9").Value = "规格";
            //ws.Cell("F9").Value = "数量";
            //ws.Cell("G9").Value = "单位";
            //ws.Cell("H9").Value = "单价";
            //ws.Cell("I9").Value = "金额";
            //ws.Cell("J9").Value = "备注";
            //ws.Range(9, 10, 9, 12).Merge();
            //ws.Range(9, 10, 9, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //////循环添加表格内容
            //for (int i = 0; i < list.Count; i++)
            //{
            //    ws.Cell(i + 10, 1).Value = i + 1;
            //    ws.Cell(i + 10, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //    ws.Cell(i + 10, 2).Value = list[i].F_ProductName;
            //    ws.Range(i + 10, 2, i + 10, 4).Merge();
            //    ws.Range(i + 10, 2, i + 10, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //    ws.Cell(i + 10, 5).Value = "定制";
            //    ws.Cell(i + 10, 6).Value = list[i].F_Qty;
            //    ws.Cell(i + 10, 7).Value = "套";
            //    ws.Cell(i + 10, 8).Value = list[i].F_Amount;
            //    ws.Cell(i + 10, 9).Value = list[i].F_Amount * list[i].F_Qty;
            //    ws.Cell(i + 10, 10).Value = "";//备注
            //    ws.Range(i + 10, 10, i + 10, 12).Merge();
            //    ws.Range(i + 10, 10, i + 10, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //}
            //ws.Cell(13, 1).Value = list.Count + 1;
            //ws.Cell(13, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell(13, 2).Value = "服务器硬件";
            //ws.Range(13, 2, 13, 4).Merge();
            //ws.Range(13, 2, 13, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //ws.Cell(13, 5).Value = "联想";
            //ws.Cell(13, 6).Value = 5;
            //ws.Cell(13, 7).Value = "台";
            //ws.Cell(13, 8).Value = 20000.00;
            //ws.Cell(13, 9).Value = 100000.00;
            //ws.Cell(13, 10).Value = "";//备注
            //ws.Range(13, 10, 13, 12).Merge();
            //ws.Range(13, 10, 13, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //ws.Cell(14, 1).Value = list.Count + 2;
            //ws.Cell(14, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell(14, 2).Value = "数据库正版";
            //ws.Range(14, 2, 14, 4).Merge();
            //ws.Range(14, 2, 14, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //ws.Cell(14, 5).Value = "SQLServer";
            //ws.Cell(14, 6).Value = 5;
            //ws.Cell(14, 7).Value = "套";
            //ws.Cell(14, 8).Value = 9998.00;
            //ws.Cell(14, 9).Value = 49990.00;
            //ws.Cell(14, 10).Value = "";//备注
            //ws.Range(14, 10, 14, 12).Merge();
            //ws.Range(14, 10, 14, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //ws.Cell(15, 1).Value = list.Count + 3;
            //ws.Cell(15, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell(15, 2).Value = "服务费";
            //ws.Range(15, 2, 15, 4).Merge();
            //ws.Range(15, 2, 15, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //ws.Cell(15, 5).Value = "";
            //ws.Cell(15, 6).Value = 1;
            //ws.Cell(15, 7).Value = "年";
            //ws.Cell(15, 8).Value = 80000.00;
            //ws.Cell(15, 9).Value = 80000.00;
            //ws.Cell(15, 10).Value = "";//备注
            //ws.Range(15, 10, 15, 12).Merge();
            //ws.Range(15, 10, 15, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //ws.Cell(16, 1).Value = list.Count + 4;
            //ws.Cell(16, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell(16, 2).Value = "差旅费用";
            //ws.Range(16, 2, 16, 4).Merge();
            //ws.Range(16, 2, 16, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //ws.Cell(16, 5).Value = "";
            //ws.Cell(16, 6).Value = 1;
            //ws.Cell(16, 7).Value = "年";
            //ws.Cell(16, 8).Value = 60000.00;
            //ws.Cell(16, 9).Value = 60000.00;
            //ws.Cell(16, 10).Value = "";//备注
            //ws.Range(16, 10, 16, 12).Merge();
            //ws.Range(16, 10, 16, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //ws.Cell("A17").Value = "币种:";
            //ws.Cell("B17").Value = "人民币";
            //ws.Cell("C17").Value = "总计:";
            //ws.Cell("D17").Value = "343323.00";
            //ws.Cell("A18").Value = "备注";
            //ws.Cell("B18").Value = "";
            //ws.Range(18, 2, 18, 12).Merge();
            //ws.Range(18, 2, 18, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            //表格添加边框
            //列
            //ws.Range(9, 1,16,1).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 1, 16, 1).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 2, 16, 2).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 2, 16, 2).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 5, 16, 5).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 5, 16, 5).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 6, 16, 6).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 6, 16, 6).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 7, 16, 7).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 7, 16, 7).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 8, 16, 8).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 8, 16, 8).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 9, 16, 9).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 9, 16, 9).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 10, 16, 10).Style.Border.LeftBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 10, 16, 10).Style.Border.LeftBorderColor = XLColor.Black;

            //ws.Range(9, 12, 16, 12).Style.Border.RightBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 12, 16, 12).Style.Border.RightBorderColor = XLColor.Black;

            ////行
            //ws.Range(9, 1, 9, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(9, 1, 9, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(10, 1, 10, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(10, 1, 10, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(11, 1, 11, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(11, 1, 11, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(12, 1, 12, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(12, 1, 12, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(13, 1, 13, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(13, 1, 13, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(14, 1, 14, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(14, 1, 14, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(15, 1, 15, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(15, 1, 15, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(16, 1, 16, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(16, 1, 16, 12).Style.Border.TopBorderColor = XLColor.Black;

            //ws.Range(17, 1, 17, 12).Style.Border.TopBorder = XLBorderStyleValues.Hair;
            //ws.Range(17, 1, 17, 12).Style.Border.TopBorderColor = XLColor.Black;
            /////////
            var rngTable = ws.Range("A1:L1");
            var rngHeaders = rngTable.Range("A1:L1");
            ws.Row(1).Height = 20;
            rngHeaders.FirstCell().Style
             .Font.SetBold()
             .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            rngHeaders.FirstRow().Merge();
            ws.Columns().AdjustToContents();
            var col1 = ws.Column("D");
            col1.Width = 15;
            MemoryStream ms = new MemoryStream();
            wb.SaveAs(ms);
            ms.Flush();
            ms.Position = 0;

            byte[] oByte = null;
            oByte = ms.ToArray();

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel.sheet.binary.macroEnabled.12";
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + departmentDate.F_FullName + "招聘需求申请表" + ".xlsx");
            System.Web.HttpContext.Current.Response.BinaryWrite(oByte);
            //清除缓存  
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            //关闭缓冲区  
            ms.Close();
        }

        /// <summary>
        /// 导出pdf
        /// </summary>
        public void ExportPDF()
        {
            moduleExportIBLL.ExportPDF("<!DOCTYPE html><html><head></head><body><h1 align=\"center\">上海力软信息技术有限公司</h1><p align=\"center\">上海市浦东新区世纪大道108号</p><p align=\"center\">电话：021-8888888 传真：021-8888888 </p><h1 align=\"center\"> 报 价 单 </h1><p align=\"center\"> 公 司：捷敏电子 联系人：陈齐 </p><p align=\"center\">电 话：0592 - 88888886 传 真：0592 - 88888886 </p><p align=\"center\"> 邮 箱：捷敏电子 地 址：北京市海淀区西直门北大街42号 </p><p align=\"center\"> 报价人：捷敏电子 日 期：2016-05-23 11:18:29 </p><table align=\"center\" border=\"1\"  cellspacing=\"0\" cellpadding=\"0\"><tr><th>编号</th><th>品名</th><th>规格</th><th>数量</th><th>单位</th><th>单价</th><th>金额</th><th>备注</th></tr><tr align=\"center\"><td>1</td><td>敏捷开发框架-个人开发版</td><td>定制</td><td>1</td><td>套</td><td>11111</td><td>11111</td><td></td></tr><tr align=\"center\"><td>2</td><td>敏捷开发框架-个人尊享版</td><td>定制</td><td>1</td><td>套</td><td>22222</td><td>22222</td><td></td></tr><tr align=\"center\"><td>3</td><td>敏捷开发框架-企业旗舰版</td><td>定制</td><td>1</td><td>套</td><td>100000</td><td>100000</td><td></td></tr><tr align=\"center\"><td>4</td><td>服务器硬件</td><td>联想</td><td>5</td><td>台</td><td>20000.00</td><td>100000.00</td><td></td></tr><tr align=\"center\"><td>5</td><td>数据库正版</td><td>SQLServer</td><td>5</td><td>套</td><td>9998.00</td><td>49990.00</td><td></td></tr><tr align=\"center\"><td>6</td><td>服务费</td><td></td><td>1</td><td>年</td><td>80000.00</td><td>80000.00</td><td></td></tr><tr align=\"center\"><td>7</td><td>差旅费用</td><td></td><td>1</td><td>年</td><td>60000.00</td><td>80000.00</td><td></td></tr><tr align=\"center\"><td colspan=\"8\">币种：人民币    总计：323323.00</td></tr><tr><td>备注</td><td colspan=\"7\"></td></tr></table><p>日 期：</p><p>签 字：</p></body></html>");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AjaxOnly, ValidateInput(false)]
        public ActionResult SaveForm(SR_RecruitmentEntity entity)
        {
            recruitmentIBLL.SaveEntity(entity);
            return Success("保存成功！");
        }

        #endregion
    }

}