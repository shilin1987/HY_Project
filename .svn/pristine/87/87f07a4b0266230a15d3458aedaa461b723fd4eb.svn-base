using Learun.Util;
using System;
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
    public class RecruitReportNodeApprovalClassBLL : RecruitReportNodeApprovalClassIBLL
    {
        private RecruitReportNodeApprovalClassService recruitReportNodeApprovalClassService = new RecruitReportNodeApprovalClassService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_ReportNodeApprovalDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return recruitReportNodeApprovalClassService.GetPageList(pagination, queryJson);
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
        /// 获取Hy_Recruit_ReportNodeApproval表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_ReportNodeApprovalEntity GetHy_Recruit_ReportNodeApprovalEntity(string keyValue)
        {
            try
            {
                return recruitReportNodeApprovalClassService.GetHy_Recruit_ReportNodeApprovalEntity(keyValue);
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
                recruitReportNodeApprovalClassService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, Hy_Recruit_ReportNodeApprovalEntity entity)
        {
            try
            {
                recruitReportNodeApprovalClassService.SaveEntity(keyValue, entity);
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
        /// 报道通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon AuditInfo(string keyValue)
        {
            try
            {
               return recruitReportNodeApprovalClassService.AuditInfo(keyValue);
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
        /// 报道不通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon UnAuditInfo(string keyValue)
        {
            try
            {
                return recruitReportNodeApprovalClassService.UnAuditInfo(keyValue);
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
        /// 批量审核通过
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon BatchAuditInfo(string keyValue)
        {
            try
            {
                return recruitReportNodeApprovalClassService.BatchAuditInfo(keyValue);
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
        /// 重新上传
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon ResetInfo(string keyValue)
        {
            try
            {
                return recruitReportNodeApprovalClassService.ResetInfo(keyValue);
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

    }
}
