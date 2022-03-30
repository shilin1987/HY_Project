using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 14:53
    /// 描 述：新菜价补贴计算
    /// </summary>
    public class FSVegetablePricesCalculationBLL : FSVegetablePricesCalculationIBLL
    {
        private FSVegetablePricesCalculationService fSVegetablePricesCalculationService = new FSVegetablePricesCalculationService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePricesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return fSVegetablePricesCalculationService.GetPageList(pagination, queryJson);
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
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePricesEntity> GetList(string year, string month)
        {
            try
            {
                return fSVegetablePricesCalculationService.GetList(year, month);
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
        /// 获取FS_VegetablePrices表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public FS_VegetablePricesEntity GetFS_VegetablePricesEntity(string keyValue)
        {
            try
            {
                return fSVegetablePricesCalculationService.GetFS_VegetablePricesEntity(keyValue);
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
                fSVegetablePricesCalculationService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, FS_VegetablePricesEntity entity)
        {
            try
            {
                fSVegetablePricesCalculationService.SaveEntity(keyValue, entity);
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

        public string GetExportList(Pagination paginationobj, string queryJson, string v, string url)
        {
            string filenamenew = "";
            try
            {
                //取出数据源
                DataTable exportTable = fSVegetablePricesCalculationService.GetExportList(paginationobj, queryJson);
                //设置导出格式
                ExcelConfig excelconfig = new ExcelConfig();
                excelconfig.Title = "菜价补贴数据导出";
                excelconfig.TitleFont = "微软雅黑";
                excelconfig.TitlePoint = 25;
                excelconfig.FileName = "菜价补贴月数据.xls";
                excelconfig.IsAllSizeColumn = true;
                //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
                excelconfig.ColumnEntity = new List<ColumnModel>();

                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_UserId", ExcelColumn = "员工编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_UserName", ExcelColumn = "员工姓名" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_DeptId", ExcelColumn = "部门编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_DeptName", ExcelColumn = "部门名称" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_MonBreakfastTogether", ExcelColumn = "月早餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_MonLunchTogether", ExcelColumn = "月午餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_MonDinnerTogether", ExcelColumn = "月晚餐次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_MonSupperTogether", ExcelColumn = "月夜宵次数合计" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CountMoney", ExcelColumn = "月补贴金额" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Year", ExcelColumn = "年" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Month", ExcelColumn = "月" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CostCenterno", ExcelColumn = "成本中心编号" });
                excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CostCenterName", ExcelColumn = "成本中心名称" });

                ExcelHelper ex = new ExcelHelper();
                //调用导出方法
                filenamenew = ex.ExportFileToExcel(excelconfig,
                                             v,
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
