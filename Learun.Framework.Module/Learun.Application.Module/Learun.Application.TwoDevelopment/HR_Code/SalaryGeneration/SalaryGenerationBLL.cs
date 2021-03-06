using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.SalaryGeneration;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NPOI.SS.Util;
using System.Web.UI.WebControls;
using System.Web;
using Learun.Application.TwoDevelopment.ReturnModel;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 10:51
    /// 描 述：最终工资结算展示
    /// </summary>
    public class SalaryGenerationBLL : SalaryGenerationIBLL
    {

        ReturnCommon<DataTable> _return;
        public SalaryGenerationBLL()
        {
            _return = new ReturnCommon<DataTable>();
        }
        private SalaryGenerationService salaryGenerationService = new SalaryGenerationService();
        private FiveInsurancesOneFundIBLL fiveInsurancesOneFundBLL = new FiveInsurancesOneFundBLL();


        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_SalaryGenerationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return salaryGenerationService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取Hy_hr_SalaryGeneration表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_SalaryGenerationEntity GetHy_hr_SalaryGenerationEntity(string keyValue)
        {
            try
            {
                return salaryGenerationService.GetHy_hr_SalaryGenerationEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="F_Userid"></param>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_SalaryGenerationEntity> GetHy_hr_SalaryGenerationEntity(string F_Userid, string yearMonth)
        {
            try
            {
                return salaryGenerationService.GetHy_hr_SalaryGenerationEntity(F_Userid, yearMonth);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="F_Userid"></param>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public IEnumerable<SalaryGenerationEntityDTO> GetSalaryGenerationEntity(Pagination pagination, string queryJson)
        {
            try
            {
                /*
                IEnumerable<SalaryGenerationEntityDTO> lists = salaryGenerationService.GetSalaryGenerationEntityList(pagination, queryJson);
                foreach (var list in lists)
                {
                    MyProperty myProperty = new MyProperty();
                    IEnumerable<Hy_hr_FiveInsurancesOneFundEntity> fiveIsoList = fiveInsurancesOneFundBLL.GetFiveInsurancesOneFundListFirst(list.F_UserId, list.F_WagesYearMonth+"");
                    myProperty.F_HousingAccumulationFund = fiveIsoList.ToList()[0].F_SocialInsurance;
                    myProperty.F_SocialInsurance = fiveIsoList.ToList()[0].F_HousingAccumulationFund;
                    list.myProperty = myProperty;
                }
                */
                return salaryGenerationService.GetSalaryGenerationEntityList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                salaryGenerationService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, Hy_hr_SalaryGenerationEntity entity)
        {
            try
            {
                salaryGenerationService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 传入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(List<Hy_hr_SalaryGenerationEntity> entity)
        {
            try
            {
                return salaryGenerationService.SaveListEntity(entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }

            }
        }

        public ReturnCommon<DataTable> ExcelreportEntity(DataTable data)
        {

           DataTable dt = salaryGenerationService.ExcelreportEntity(null,null);
            if (_return.Status)
            {
                var isSuccess = DTableToExcel(_return.Data,true);
                if (isSuccess.Length>0 || string.IsNullOrEmpty(isSuccess))
                {
                    _return.Status = true;
                    _return.Message = isSuccess;
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "导出失败:" + isSuccess;
                }
            }
            return _return;
        }
        private static string DTableToExcel(DataTable data ,bool isnotheder)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            string name = "月工资结算清单";
            string result = string.Empty;
            ISheet sheet = null;
            string fileName = "月工资结算.xlsx";
            string DefaultPath = ConfigurationManager.AppSettings["CommonExcelPath"];
            string Path = DefaultPath + DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;//文件路径
            ////合并单元格
            //sheet.AddMergedRegion(new CellRangeAddress(0, 1, 28, 29));
            try
            {
                NPOI.SS.UserModel.IWorkbook workbook = null;//操作Excel2007的版本，扩展名是.xlsx
                FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();

                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(name);
                }
                else
                {
                    result = "创建Excel的Sheet页失败";
                }
                if (isnotheder == true)
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }
                //TableCell[] header = new TableCell[35];
                //for (int h = 0; h < header.Length; h++)
                //{
                //    header[h] = new TableHeaderCell();
                //}
                //header[0].Text = "序号";
                //header[1].Text = "月份";
                //header[2].Text = "类别";
                //header[3].Text = "岗级";
                //header[4].Text = "员工编号";
                //header[5].Text = "姓名";
                //header[6].Text = "部门";
                //header[7].Text = "岗位";
                //header[8].Text = "入职时间";
                //header[9].Text = "员工状态";
                //header[10].Text = "离职时间";
                //header[11].Text = "工资标准";
                //header[12].Text = "基本工资";
                //header[13].Text = "绩效工资";
                //header[14].Text = "技能工资";
                //header[15].Text = "住房补贴";
                //header[16].Text = "交通补贴";
                //header[17].Text = "值班补贴";
                //header[18].Text = "全勤奖（应发）";
                //header[19].Text = "缺勤扣款";
                //header[20].Text = "奖惩补贴";
                //header[21].Text = "法定节假日加班工资";
                //header[22].Text = "通讯补贴";
                //header[23].Text = "工龄工资（倒班）";
                //header[24].Text = "延时工资（倒班）";
                //header[25].Text = "夜班津贴（倒班）";
                //header[26].Text = "应发工资";
                //header[27].Text = "社会保险";
                //header[28].Text = "住房公积金</th></tr><tr>";

                //header[29].Text = "个税缴纳";
                //header[30].Text = "房费";
                //header[31].Text = "电费";
                //header[32].Text = "党费";
                //header[33].Text = "财务扣款";
                //header[34].Text = "实发工资";
                //header[35].Text = "备注";

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)

                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel

                //转为字节数组  
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();
                result = Path;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(Path, System.Text.Encoding.UTF8));
                HttpContext.Current.Response.BinaryWrite(buf);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                result= ex.Message;
            }

            return result;
        }




        public string GetExportList(Pagination pagination, string queryJson, string filefull, string url)
        {
            string filenamenew = "";
            try
            {
                //取出数据源
                DataTable exportTable = salaryGenerationService.ExcelreportEntity(pagination, queryJson);
                //设置导出格式
                ExcelConfig excelconfig = new ExcelConfig();
                excelconfig.Title = "月工资结算导出";
                excelconfig.TitleFont = "微软雅黑";
                excelconfig.TitlePoint = 25;
                excelconfig.FileName = "月工资结算数据.xls";
                excelconfig.IsAllSizeColumn = true;
                //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
                excelconfig.ColumnEntity = new List<ColumnModel>();
                ExcelHelper ex = new ExcelHelper();
                //调用导出方法
                filenamenew = ex.ExportFileToExcel(excelconfig,
                                             filefull,
                                             exportTable, url);


            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
            return filenamenew;
        }
        #endregion

    }
}
