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
    /// 日 期：2021-11-02 16:41
    /// 描 述：客户月度来料计划合并功能
    /// </summary>
    public class B2B_PLAN_MATERIAL_ＭERGE_CREATEBLL : B2B_PLAN_MATERIAL_ＭERGE_CREATEIBLL
    {
        private B2B_PLAN_MATERIAL_ＭERGE_CREATEService b2B_PLAN_MATERIAL_ＭERGE_CREATEService = new B2B_PLAN_MATERIAL_ＭERGE_CREATEService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ＭERGE_CREATEService.GetPageList(pagination, queryJson);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetB2B_PLAN_MATERIAL_MERGE_SUBList(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ＭERGE_CREATEService.GetB2B_PLAN_MATERIAL_MERGE_SUBList(keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_MERGE_SUBEntity GetB2B_PLAN_MATERIAL_MERGE_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ＭERGE_CREATEService.GetB2B_PLAN_MATERIAL_MERGE_SUBEntity(keyValue);
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
        /// 获取B2B_PLAN_MATERIAL_MERGE表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_MATERIAL_MERGEEntity GetB2B_PLAN_MATERIAL_MERGEEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ＭERGE_CREATEService.GetB2B_PLAN_MATERIAL_MERGEEntity(keyValue);
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
                b2B_PLAN_MATERIAL_ＭERGE_CREATEService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, B2B_PLAN_MATERIAL_MERGEEntity entity,List<B2B_PLAN_MATERIAL_MERGE_SUBEntity> b2B_PLAN_MATERIAL_MERGE_SUBList)
        {
            try
            {
                b2B_PLAN_MATERIAL_ＭERGE_CREATEService.SaveEntity(keyValue, entity,b2B_PLAN_MATERIAL_MERGE_SUBList);
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

        public IEnumerable<B2B_PLAN_MATERIAL_MERGE_SUBEntity> GetPlanData(string moth)
        {
            try
            {
                return b2B_PLAN_MATERIAL_ＭERGE_CREATEService.GetPlanData(moth);
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
