using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.HrvpsmonthdataTab;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-10 13:48
    /// 描 述：菜价补贴月数据
    /// </summary>
    public class HrvpsmonthdataTabBLL : HrvpsmonthdataTabIBLL
    {
        private HrvpsmonthdataTabService hrvpsmonthdataTabService = new HrvpsmonthdataTabService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HrVpsMonthDataDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return hrvpsmonthdataTabService.GetPageList(pagination, queryJson);
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
        /// 获取Hr_vpsmonthdata表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_vpsmonthdataEntity GetHr_vpsmonthdataEntity(string keyValue)
        {
            try
            {
                return hrvpsmonthdataTabService.GetHr_vpsmonthdataEntity(keyValue);
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
                hrvpsmonthdataTabService.DeleteEntity(keyValue);
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


        public string  GetExportList(Pagination pagination, string queryJson,string filefull,string url)
        {
            string filenamenew = "";
            try
            {
                //取出数据源
                DataTable exportTable = hrvpsmonthdataTabService.GetExportList(pagination, queryJson);
                //设置导出格式
                ExcelConfig excelconfig = new ExcelConfig();
                excelconfig.Title = "菜价补贴数据导出";
                excelconfig.TitleFont = "微软雅黑";
                excelconfig.TitlePoint = 25;
                excelconfig.FileName = "菜价补贴月数据.xls";
                excelconfig.IsAllSizeColumn = true;
                //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
                excelconfig.ColumnEntity = new List<ColumnModel>();
                /**
                 *                t.oid,
                t.user_code,
                t.user_name,
                t.deptid,
                t.deptname,
                t.monBreakfastTogether,
                t.monLunchTogether,
                t.monDinnerTogether,
                t.monSupperTogether,
                t.cost_centerno,
                t.cost_center,
                t.countMoney,
                t.yearno,
                t.monthno
                 */
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "oid", ExcelColumn = "系统id" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "user_code", ExcelColumn = "员工编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "user_name", ExcelColumn = "员工姓名" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "deptid", ExcelColumn = "部门编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "deptname", ExcelColumn = "部门名称" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "monBreakfastTogether", ExcelColumn = "月早餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "monLunchTogether", ExcelColumn = "月午餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "monDinnerTogether", ExcelColumn = "月晚餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "monSupperTogether", ExcelColumn = "月夜宵次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "countMoney", ExcelColumn = "月补贴金额" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "yearno", ExcelColumn = "年" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "monthno", ExcelColumn = "月" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "cost_centerno", ExcelColumn = "成本中心编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "cost_center", ExcelColumn = "成本中心名称" });

                ExcelHelper ex = new ExcelHelper();
                //调用导出方法
                 filenamenew = ex.ExportFileToExcel(excelconfig,
                                              filefull,
                                              exportTable,url);


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
