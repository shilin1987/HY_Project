using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-05 18:05
    /// 描 述：餐台维护
    /// </summary>
    public interface FSCounterTheWindowsillClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<FS_CounterTheWindowsillEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取FS_CounterTheWindowsill表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        FS_CounterTheWindowsillEntity GetFS_CounterTheWindowsillEntity(string keyValue);
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
        void SaveEntity(string keyValue, FS_CounterTheWindowsillEntity entity);
        #endregion

    }
}
