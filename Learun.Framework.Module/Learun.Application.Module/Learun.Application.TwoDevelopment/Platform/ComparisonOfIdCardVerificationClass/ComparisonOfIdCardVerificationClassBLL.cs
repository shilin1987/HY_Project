using Learun.Util;
using System;
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
    public class ComparisonOfIdCardVerificationClassBLL : ComparisonOfIdCardVerificationClassIBLL
    {
        private ComparisonOfIdCardVerificationClassService comparisonOfIdCardVerificationClassService = new ComparisonOfIdCardVerificationClassService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_hy_ComparisonOfIdCardVerificationDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.GetPageList(pagination, queryJson);
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
        public Hr_hy_ComparisonOfIdCardVerificationEntity GetOneEntity(string keyValue)
        {
            try
            {
      
                return comparisonOfIdCardVerificationClassService.GetOneEntity(keyValue);
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
        /// 获取Hr_hy_ComparisonOfIdCardVerification表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_hy_ComparisonOfIdCardVerificationEntity GetHr_hy_ComparisonOfIdCardVerificationEntity(string keyValue)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.GetHr_hy_ComparisonOfIdCardVerificationEntity(keyValue);
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
                comparisonOfIdCardVerificationClassService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, Hr_hy_ComparisonOfIdCardVerificationEntity entity)
        {
            try
            {
                comparisonOfIdCardVerificationClassService.SaveEntity(keyValue, entity);
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

        public void SaveKeepIdCard(string jsonStr)
        {
            try
            {
                comparisonOfIdCardVerificationClassService.SaveKeepIdCard(jsonStr);
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
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon UnAuditInfoEntity(string keyValue)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.UnAuditInfoEntity(keyValue);
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
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon AuditInfoEntity(string keyValue)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.AuditInfoEntity(keyValue);
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
        /// 身份证信息对比
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ReturnCommon VerifyIDCard(string keyValue)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.VerifyIDCard(keyValue);
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

        public ReturnCommon VerifyIDCardAjxaData(string jsonStr)
        {
            try
            {
                return comparisonOfIdCardVerificationClassService.VerifyIDCardAjxaData(jsonStr);
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
