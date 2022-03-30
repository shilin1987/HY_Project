using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-22 17:11
    /// 描 述：计划与实际来料完成情况推送提醒功能
    /// </summary>
    public class B2B_CUST_PLAN_CONTRAST_WARNBLL : B2B_CUST_PLAN_CONTRAST_WARNIBLL
    {
        private B2B_CUST_PLAN_CONTRAST_WARNService b2B_CUST_PLAN_CONTRAST_WARNService = new B2B_CUST_PLAN_CONTRAST_WARNService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_CUST_PLAN_CONTRAST_WARNEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_CUST_PLAN_CONTRAST_WARNService.GetPageList(pagination, queryJson);
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
        /// 获取B2B_CUST_PLAN_CONTRAST_WARN表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_CUST_PLAN_CONTRAST_WARNEntity GetB2B_CUST_PLAN_CONTRAST_WARNEntity(string keyValue)
        {
            try
            {
                return b2B_CUST_PLAN_CONTRAST_WARNService.GetB2B_CUST_PLAN_CONTRAST_WARNEntity(keyValue);
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
                b2B_CUST_PLAN_CONTRAST_WARNService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, B2B_CUST_PLAN_CONTRAST_WARNEntity entity)
        {
            try
            {
                b2B_CUST_PLAN_CONTRAST_WARNService.SaveEntity(keyValue, entity);
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
