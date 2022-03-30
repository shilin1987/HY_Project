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
    /// 日 期：2021-11-16 14:11
    /// 描 述：来料计划产能分配
    /// </summary>
    public class B2B_PLAN_MATERIAL_ALLOTBLL : B2B_PLAN_MATERIAL_ALLOTIBLL
    {
        private B2B_PLAN_MATERIAL_ALLOTService b2B_PLAN_MATERIAL_ALLOTService = new B2B_PLAN_MATERIAL_ALLOTService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_ALLOTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ALLOTService.GetPageList(pagination, queryJson);
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
        /// 获取B2B_PLAN_MATERIAL_ALLOT_SUB表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> GetB2B_PLAN_MATERIAL_ALLOT_SUBList(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ALLOTService.GetB2B_PLAN_MATERIAL_ALLOT_SUBList(keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_ALLOT_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_ALLOT_SUBEntity GetB2B_PLAN_MATERIAL_ALLOT_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ALLOTService.GetB2B_PLAN_MATERIAL_ALLOT_SUBEntity(keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_ALLOT表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_ALLOTEntity GetB2B_PLAN_MATERIAL_ALLOTEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ALLOTService.GetB2B_PLAN_MATERIAL_ALLOTEntity(keyValue);
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
                b2B_PLAN_MATERIAL_ALLOTService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_ALLOTEntity entity,List<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> b2B_PLAN_MATERIAL_ALLOT_SUBList)
        {
            try
            {
                b2B_PLAN_MATERIAL_ALLOTService.SaveEntity(keyValue, entity,b2B_PLAN_MATERIAL_ALLOT_SUBList);
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
        /// 获取合并月份的数据
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_ALLOT_SUBEntity> GetPlanData(string month)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ALLOTService.GetPlanData(month);
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
