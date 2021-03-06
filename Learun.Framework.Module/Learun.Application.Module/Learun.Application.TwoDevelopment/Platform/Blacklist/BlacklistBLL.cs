using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-09-27 09:59
    /// 描 述：黑名单永不录用
    /// </summary>
    public class BlacklistBLL : BlacklistIBLL
    {
        private BlacklistService blacklistService = new BlacklistService();
        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_department_"; // +加公司主键
        #endregion
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Platform_BlacklistEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return blacklistService.GetPageList(pagination, queryJson);
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
        /// 获取Hy_Platform_Blacklist表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Platform_BlacklistEntity GetHy_Platform_BlacklistEntity(string keyValue)
        {
            try
            {
                return blacklistService.GetHy_Platform_BlacklistEntity(keyValue);
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
        public ReturnCommon DeleteEntity(string keyValue)
        {
            try
            {
             return   blacklistService.DeleteEntity(keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_Platform_BlacklistEntity entity)
        {
            //try
            //{
            //    blacklistService.SaveEntity(keyValue, entity);
            //}
            //catch (Exception ex)
            //{
            //    if (ex is ExceptionEx)
            //    {
            //        throw;
            //    }
            //    else
            //    {
            //        throw ExceptionEx.ThrowBusinessException(ex);
            //    }
            //}
            return blacklistService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Hy_Platform_BlacklistEntity closefinancial = GetHy_Platform_BlacklistEntity(keyValue);
                cache.Remove(cacheKey + closefinancial.F_ID);
                cache.Remove(cacheKey + "dic", CacheId.department);
                blacklistService.UpdateState(keyValue, state);
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
