using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.SalaryGeneration;

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
    public interface SalaryGenerationIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_hr_SalaryGenerationEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hy_hr_SalaryGeneration表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_SalaryGenerationEntity GetHy_hr_SalaryGenerationEntity(string keyValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        IEnumerable<Hy_hr_SalaryGenerationEntity> GetHy_hr_SalaryGenerationEntity(string F_Userid,string yearMonth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        IEnumerable<SalaryGenerationEntityDTO> GetSalaryGenerationEntity(Pagination pagination, string queryJson);

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, Hy_hr_SalaryGenerationEntity entity);


        int SaveEntity(List<Hy_hr_SalaryGenerationEntity> entity);

        ReturnCommon<DataTable> ExcelreportEntity(DataTable data);

        string GetExportList(Pagination paginationobj, string queryJson, string filepath, string url);
        #endregion

    }
}
