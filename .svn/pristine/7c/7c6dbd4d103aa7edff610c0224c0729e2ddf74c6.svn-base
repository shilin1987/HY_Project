using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Reflection;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcess;
using System.IO;
using System;
using NPOI.SS.UserModel;
using Learun.Util.Excel;

namespace Learun.Application.Web.Areas.HR_SocialRecruitment.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-28 10:05
    /// 描 述：简历审批结果查询
    /// </summary>
    public class RecruitmentProcessController : MvcControllerBase
    {
        private RecruitmentProcessIBLL recruitmentProcessIBLL = new RecruitmentProcessBLL();

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
            var data = recruitmentProcessIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }

        [HttpPost]
        public FileResult ExportExsel(string queryJson)
        {
            try
            {
                var data = recruitmentProcessIBLL.GetExportProcessInfo(queryJson);
                DataTable exportTables = ToDataTable<SRProcessExportDataDTO>(data.ToList(),null);
                ExcelConfig excelconfig = new ExcelConfig();
                excelconfig.Title = "社招流程报表数据";
                excelconfig.TitleFont = "微软雅黑";
                excelconfig.TitlePoint = 25;
                excelconfig.FileName = "社招流程报表.xls";
                excelconfig.IsAllSizeColumn = true;
                //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
                excelconfig.ColumnEntity = new List<Learun.Util.ColumnModel>();
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_HrIndicatesOrderNumber", ExcelColumn = "社招申请单号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_ResumeName", ExcelColumn = "简历名称" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_WhetherThrough ", ExcelColumn = "审批结果" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_ProcessTheOrder", ExcelColumn = "审批流程" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_OaFlowNumber", ExcelColumn = "审批流程OA单号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CheckpointName", ExcelColumn = "审批流程节点" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Approver", ExcelColumn = "审批人" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_ApprovalDate", ExcelColumn = "流程节点审批时间" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_ApprovalResults", ExcelColumn = "审批日期" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_ApprovalComments", ExcelColumn = "审批意见" });
 
                string filename = "社招流程报表数据_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls"; //返回
                IWorkbook wb = ExcelHelper.ExportFileToExcel(exportTables, excelconfig);
                NpoiMemoryStream wbStream = new NpoiMemoryStream();//定义文件流
                wbStream.AllowClose = false;
                wb.Write(wbStream);//将工作薄写入文件流 //输出之前调用Seek（偏移量，游标位置）方法：获取文件流的长度
                wbStream.Seek(0, SeekOrigin.Begin); //输出的文件名称
                wbStream.AllowClose = true;
                return File(wbStream, "application/vnd.ms-excel", filename); // 文件类型/文件名称
            }
            catch (Exception e)
            {
                throw new Exception("导出excel报错,原因如下"+e.Message);
            }
        }

        /// <summary>
        /// 获取子表的字段数据
        /// </summary>
        /// <param name="fid">主表Id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSubList(string fid)
        {
            var data = recruitmentProcessIBLL.GetSubList(fid);
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
            var SR_RecruitmentProcessNodeData = recruitmentProcessIBLL.GetSR_RecruitmentProcessNodeEntity(keyValue);
            var jsonData = new
            {
                SR_RecruitmentProcessNode = SR_RecruitmentProcessNodeData,
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
            recruitmentProcessIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity)
        {
            SR_RecruitmentProcessNodeEntity entity = strEntity.ToObject<SR_RecruitmentProcessNodeEntity>();
            recruitmentProcessIBLL.SaveEntity(keyValue, entity);
            if (string.IsNullOrEmpty(keyValue))
            {
            }
            return Success("保存成功！");
        }
        #endregion
        #region
        /// <summary>
        /// list转datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
  
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
            {
                propertyNameList.AddRange(propertyName);
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        //if (DBNull.Value.Equals(pi.PropertyType))
                        //{
                        //   // pi.PropertyType = DateTime;
                        //}
                        Type colType = pi.PropertyType;
                        if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        result.Columns.Add(pi.Name, colType);
                        //result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                        {
                            result.Columns.Add(pi.Name, pi.PropertyType);
                        }
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        #endregion
    }
}
