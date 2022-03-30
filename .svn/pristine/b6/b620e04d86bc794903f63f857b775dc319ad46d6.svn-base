using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.Platform.RecruitReportNodeApprovalClass;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-27 18:33
    /// 描 述：报道节点审批维护
    /// </summary>
    public interface RecruitReportNodeApprovalClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_Recruit_ReportNodeApprovalDTO> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hy_Recruit_ReportNodeApproval表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Recruit_ReportNodeApprovalEntity GetHy_Recruit_ReportNodeApprovalEntity(string keyValue);
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
        void SaveEntity(string keyValue, Hy_Recruit_ReportNodeApprovalEntity entity);
        /// <summary>
        /// 报道通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon AuditInfo(string keyValue);
        /// <summary>
        /// 报道不通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon UnAuditInfo(string keyValue);
        /// <summary>
        /// 批量报道通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon BatchAuditInfo(string keyValue);
        /// <summary>
        /// 重新上传
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ReturnCommon ResetInfo(string keyValue);
        #endregion

    }
}
