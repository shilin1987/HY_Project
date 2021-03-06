using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcess;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-28 10:05
    /// 描 述：简历审批结果查询
    /// </summary>
    public class RecruitmentProcessBLL : RecruitmentProcessIBLL
    {
        private RecruitmentProcessService recruitmentProcessService = new RecruitmentProcessService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SR_RecruitmentProcessNodeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return recruitmentProcessService.GetPageList(pagination, queryJson);
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
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SRProcessExportDataDTO> GetExportProcessInfo( string queryJson)
        {
            try
            {
                return recruitmentProcessService.GetExportProcessInfo(queryJson);
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
        /// 获取SR_RecruitmentProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_RecruitmentProcessNodeEntity GetSR_RecruitmentProcessNodeEntity(string keyValue)
        {
            try
            {
                return recruitmentProcessService.GetSR_RecruitmentProcessNodeEntity(keyValue);
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
        /// 获取子表显示列表数据
        /// <summary>
        /// <param name="fid">主表主键id</param>
        /// <returns></returns>
        public IEnumerable<SR_ApprovalProcessEntity> GetSubList(string fid)
        {
            try
            {
                return recruitmentProcessService.GetSubList(fid);
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
        /// <summary>
        /// <param name="fid">主表主键id</param>
        /// <returns></returns>
        public IEnumerable<SR_RecruitmentProcessNodeEntity> GetList(string fid)
        {
            try
            {
                return recruitmentProcessService.GetList(fid);
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
                recruitmentProcessService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity)
        {
            try
            {
                recruitmentProcessService.SaveEntity(keyValue, entity);
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
