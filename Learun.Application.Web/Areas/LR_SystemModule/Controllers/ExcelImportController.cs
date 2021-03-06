using Learun.Application.Excel;
using System.Collections.Generic;
using System.Web.Mvc;
using Learun.Util;
using System.Data;
using Learun.Application.Base.SystemModule;
using System;
using System.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Learun.Application.Excel.Export;

namespace Learun.Application.Web.Areas.LR_SystemModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：Excel导入管理
    /// </summary>
    public class ExcelImportController : MvcControllerBase
    {
        private ExcelImportIBLL excelImportIBLL = new ExcelImportBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        #region 视图功能
        /// <summary>
        /// 导入模板管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 导入模板管理表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 设置字段属性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SetFieldForm()
        {
            return View();
        }

        /// <summary>
        /// 导入页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ImportForm()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = excelImportIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="moduleId">功能模块主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string moduleId)
        {
            var data = excelImportIBLL.GetList(moduleId);
            return Success(data);
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
            ExcelImportEntity entity = excelImportIBLL.GetEntity(keyValue);
            IEnumerable<ExcelImportFieldEntity> list = excelImportIBLL.GetFieldList(keyValue);
            var data = new
            {
                entity = entity,
                list = list
            };
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity, string strList)
        {
            ExcelImportEntity entity = strEntity.ToObject<ExcelImportEntity>();
            List<ExcelImportFieldEntity> filedList = strList.ToObject<List<ExcelImportFieldEntity>>();
            excelImportIBLL.SaveEntity(keyValue, entity, filedList);
            return Success("保存成功！");
        }
        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            excelImportIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 更新表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UpdateForm(string keyValue, ExcelImportEntity entity)
        {
            excelImportIBLL.UpdateEntity(keyValue, entity);
            return Success("操作成功！");
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void DownSchemeFile(string keyValue)
        {
            ExcelImportEntity templateInfo = excelImportIBLL.GetEntity(keyValue);
            IEnumerable<ExcelImportFieldEntity> fileds = excelImportIBLL.GetFieldList(keyValue);

            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.FileName = Server.UrlDecode(templateInfo.F_Name) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnModel>();
            //表头
            DataTable dt = new DataTable();
            foreach (var col in fileds)
            {
                if (col.F_RelationType != 1 && col.F_RelationType != 4 && col.F_RelationType != 5 && col.F_RelationType != 6 && col.F_RelationType != 7)
                {
                    excelconfig.ColumnEntity.Add(new ColumnModel()
                    {
                        Column = col.F_Name,
                        ExcelColumn = col.F_ColName,
                        Alignment = "center",
                    });
                    dt.Columns.Add(col.F_ColName, typeof(string));
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void DownTemplateExcelFile(TemplateFiled templateFiled)
        {
            /**
             * 1.根据传过来字段换成要导出模板字段
             * 2.如果为空就默认导出所有
             * 3.如果传了就按模板选择的导出对应模板
             * 4.导入方法修改,需要传入字段
             */
            ExcelImportEntity templateInfo = excelImportIBLL.GetEntity(templateFiled.id);
            IEnumerable<ExcelImportFieldEntity> fileds = null;
            var filedArray = templateFiled.fileds.Split(',');
            if (filedArray.Length > 0)
            {
                fileds = excelImportIBLL.GetModelFieldList(templateFiled.id, filedArray);
            }
            else
            {
                fileds = excelImportIBLL.GetFieldList(templateFiled.id);
            }


            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.FileName = Server.UrlDecode(templateInfo.F_Name) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnModel>();
            //表头
            DataTable dt = new DataTable();
            foreach (var col in fileds)
            {
                if (col.F_RelationType != 1 && col.F_RelationType != 4 && col.F_RelationType != 5 && col.F_RelationType != 6 && col.F_RelationType != 7)
                {
                    excelconfig.ColumnEntity.Add(new ColumnModel()
                    {
                        Column = col.F_Name,
                        ExcelColumn = col.F_ColName,
                        Alignment = "center",
                    });
                    dt.Columns.Add(col.F_ColName, typeof(string));
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
        }

        /// <summary>
        /// excel文件导入（通用）
        /// </summary>
        /// <param name="templateId">模板Id</param>
        /// <param name="fileId">文件主键</param>
        /// <param name="chunks">分片数</param>
        /// <param name="ext">文件扩展名</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteImportExcel(string templateId, string fileId, int chunks,string ext )
        {

            Util.UserInfo userInfo = LoginUserInfo.Get();
            string path = annexesFileIBLL.SaveAnnexes(fileId, fileId + "."+ ext, chunks, userInfo);
            if (!string.IsNullOrEmpty(path))
            {
                DataTable dt = ExcelHelper.ExcelImport(path);
                string res = excelImportIBLL.ImportTable(templateId, fileId, dt);
                var data = new
                {
                    Success = res.Split('|')[0],
                    Fail = res.Split('|')[1]
                };
                return Success(data);
            }
            else
            {
                return Fail("导入数据失败!");
            }
        }
        /// <summary>
        /// excel文件导入（通用）
        /// </summary>
        /// <param name="templateId">模板Id</param>
        /// <param name="fileId">文件主键</param>
        /// <param name="chunks">分片数</param>
        /// <param name="ext">文件扩展名</param>
        /// <param name="fileds">导入字段名称</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteUserImportExcel(string templateId, string fileId, int chunks, string ext, string fileds)
        {

            var filedArray = fileds.Split(',');

            Util.UserInfo userInfo = LoginUserInfo.Get();
            string path = annexesFileIBLL.SaveAnnexes(fileId, fileId + "." + ext, chunks, userInfo);
            if (!string.IsNullOrEmpty(path))
            {
                DataTable dt = ExcelHelper.ExcelImport(path);
                string res = excelImportIBLL.ImportUserTable(templateId, fileId, dt, filedArray);
                var data = new
                {
                    Success = res.Split('|')[0],
                    Fail = res.Split('|')[1]
                };
                return Success(data);
            }
            else
            {
                return Fail("导入数据失败!");
            }
        }

        /// <summary>
        /// 下载文件(导入文件未被导入的数据)
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void DownImportErrorFile(string fileId,string fileName)
        {
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.FileName = Server.UrlDecode("未导入错误数据【" + fileName + "】") + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnModel>();
            //表头
            DataTable dt = excelImportIBLL.GetImportError(fileId);
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "导入错误")
                {
                    excelconfig.ColumnEntity.Add(new ColumnModel()
                    {
                        Column = col.ColumnName,
                        ExcelColumn = col.ColumnName,
                        Alignment = "center",
                        Background = System.Drawing.Color.Red
                    });
                }
                else
                {
                    excelconfig.ColumnEntity.Add(new ColumnModel()
                    {
                        Column = col.ColumnName,
                        ExcelColumn = col.ColumnName,
                        Alignment = "center",
                    });
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
        }
        #endregion
    }
}