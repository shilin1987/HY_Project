using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-04 15:55
    /// 描 述：薪酬计算财务扣款
    /// </summary>
    public interface FinancialDeductionsClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hr_FinancialDeductionsEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="F_Userid"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        IEnumerable<Hr_FinancialDeductionsEntity> GetList(string F_Userid,string F_month);
        /// <summary>
        /// 获取Hr_FinancialDeductions表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hr_FinancialDeductionsEntity GetHr_FinancialDeductionsEntity(string keyValue);
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
        void SaveEntity(string keyValue, Hr_FinancialDeductionsEntity entity);
        #endregion

    }
}
