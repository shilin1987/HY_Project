﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：B2B_Account
    /// 日 期：2021-10-28 15:35
    /// 描 述：来料计划填报
    /// </summary>
    public class B2B_PLAN_CREATEBLL : B2B_PLAN_CREATEIBLL
    {
        private B2B_PLAN_CREATEService b2B_PLAN_CREATEService = new B2B_PLAN_CREATEService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_INCOMING_MATERIALEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetPageList(pagination, queryJson);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetB2B_PLAN_INCOMING_MATERIAL_SUBList(string keyValue)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetB2B_PLAN_INCOMING_MATERIAL_SUBList(keyValue);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_INCOMING_MATERIAL_SUBEntity GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(keyValue);
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
        /// 获取B2B_PLAN_INCOMING_MATERIAL表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_PLAN_INCOMING_MATERIALEntity GetB2B_PLAN_INCOMING_MATERIALEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
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
        public void DeleteEntity(string keyValue,out bool have)
        {
            try
            {
                b2B_PLAN_CREATEService.DeleteEntity(keyValue,out have);
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
        public void SaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity,List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBList,out bool have,out string outmsg,out bool inforerror)
        {
            try
            {
                b2B_PLAN_CREATEService.SaveEntity(keyValue, entity,b2B_PLAN_INCOMING_MATERIAL_SUBList,out have,out outmsg,out inforerror);
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

        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetPartidData(string custcode, string PRODUCT_MODEL, string PACKAGING_TYPE, string PACKAGE_MODEL, string WAFER_MODEL)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetPartidData(custcode,PRODUCT_MODEL, PACKAGING_TYPE, PACKAGE_MODEL, WAFER_MODEL);
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

        public IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetPageListSub(string keyValue)
        {
            try
            {
                return b2B_PLAN_CREATEService.GetPageListSub(keyValue);
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
