using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-18 17:57
    /// 描 述：操作员招聘流程流程环节记录
    /// </summary>
    public class RecordOperatorRecruitmentProcessClassBLL : RecordOperatorRecruitmentProcessClassIBLL
    {
        private RecordOperatorRecruitmentProcessClassService recordOperatorRecruitmentProcessClassService = new RecordOperatorRecruitmentProcessClassService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SR_RecordOperatorRecruitmentProcessEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return recordOperatorRecruitmentProcessClassService.GetPageList(pagination, queryJson);
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
        /// 获取SR_RecordOperatorRecruitmentProcess表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public SR_RecordOperatorRecruitmentProcessEntity GetSR_RecordOperatorRecruitmentProcessEntity(string keyValue)
        {
            try
            {
                return recordOperatorRecruitmentProcessClassService.GetSR_RecordOperatorRecruitmentProcessEntity(keyValue);
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
                recordOperatorRecruitmentProcessClassService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, SR_RecordOperatorRecruitmentProcessEntity entity)
        {
            try
            {
                recordOperatorRecruitmentProcessClassService.SaveEntity(keyValue, entity);
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
        /// <param name="f_UserId"></param>
        /// <param name="f_ProcessId"></param>
        /// <param name="f_SortCode"></param>
        /// <returns></returns>
        public SR_RecordOperatorRecruitmentProcessEntity getRecordOperatorRecruitment(string f_UserId, string f_ProcessId, decimal f_SortCode)
        {
            try
            {
                return recordOperatorRecruitmentProcessClassService.getRecordOperatorRecruitment( f_UserId,  f_ProcessId,f_SortCode);
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
