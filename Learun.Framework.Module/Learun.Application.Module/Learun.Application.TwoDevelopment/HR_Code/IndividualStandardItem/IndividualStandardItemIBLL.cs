using Learun.Util;
using System.Data;
using System.Collections.Generic;


namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-11 10:41
    /// 描 述：个人标准工资明细
    /// </summary>
    public interface IndividualStandardItemIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hr_personalStandards_fileEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<Hr_personalStandards_fileEntity> GetList(string f_userid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        void GetHrStandardList(string F_userId,decimal mmoney, decimal f_ps16, decimal f_ps17);
        /// <summary>
        /// 获取Hr_personalStandards_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hr_personalStandards_fileEntity GetHr_personalStandards_fileEntity(string keyValue);
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
        void SaveEntity(string keyValue, Hr_personalStandards_fileEntity entity);
        #endregion

    }
}
