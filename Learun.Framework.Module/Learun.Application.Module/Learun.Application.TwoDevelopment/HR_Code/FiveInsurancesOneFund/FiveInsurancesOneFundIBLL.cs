using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 13:52
    /// 描 述：五险一金结算
    /// </summary>
    public interface FiveInsurancesOneFundIBLL
    {
        #region 获取数据


        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_hr_FiveInsurancesOneFundEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="F_UserId"></param>
        /// <param name="F_SettlementYearMonth"></param>
        /// <returns></returns>
        IEnumerable<Hy_hr_FiveInsurancesOneFundEntity> GetFiveInsurancesOneFundListFirst(string F_UserId, string F_SettlementYearMonth);
        /// <summary>
        /// 获取Hy_hr_FiveInsurancesOneFund表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_FiveInsurancesOneFundEntity GetHy_hr_FiveInsurancesOneFundEntity(string keyValue);
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
        void SaveEntity(string keyValue, Hy_hr_FiveInsurancesOneFundEntity entity);
        #endregion

    }
}
