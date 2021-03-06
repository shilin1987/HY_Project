using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.Platform.ComparisonOfIdCardVerificationClass;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-22 14:41
    /// 描 述：身份证信息读取对比
    /// </summary>
    public interface ComparisonOfIdCardVerificationClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hr_hy_ComparisonOfIdCardVerificationDTO> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hr_hy_ComparisonOfIdCardVerification表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hr_hy_ComparisonOfIdCardVerificationEntity GetHr_hy_ComparisonOfIdCardVerificationEntity(string keyValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Hr_hy_ComparisonOfIdCardVerificationEntity GetOneEntity(string keyValue);
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
        void SaveEntity(string keyValue, Hr_hy_ComparisonOfIdCardVerificationEntity entity);
        /// <summary>
        /// 认证审查接口
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        void SaveKeepIdCard(string jsonStr);
        /// <summary>
        /// 人工审批不通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon UnAuditInfoEntity(string keyValue);
        /// <summary>
        /// 人工审批通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon AuditInfoEntity(string keyValue);
        /// <summary>
        /// 验证身份证信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon VerifyIDCard(string keyValue);
        /// <summary>
        /// 外部请求服务器数据
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        ReturnCommon VerifyIDCardAjxaData(string jsonStr);
        #endregion

    }
}
