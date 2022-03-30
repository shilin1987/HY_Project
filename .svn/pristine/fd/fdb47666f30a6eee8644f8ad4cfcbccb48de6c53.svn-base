using Learun.Util;
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
    public interface FSVegetablePricesCalculationIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<FS_VegetablePricesEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        IEnumerable<FS_VegetablePricesEntity> GetList(string year,string  month);
        /// <summary>
        /// 获取FS_VegetablePrices表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        FS_VegetablePricesEntity GetFS_VegetablePricesEntity(string keyValue);
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
        void SaveEntity(string keyValue, FS_VegetablePricesEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paginationobj"></param>
        /// <param name="queryJson"></param>
        /// <param name="v"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        string GetExportList(Pagination paginationobj, string queryJson, string v, string url);
        #endregion

    }
}
