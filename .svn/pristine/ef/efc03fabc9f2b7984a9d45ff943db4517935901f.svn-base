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
    /// 日 期：2022-01-24 14:32
    /// 描 述：晶圆清单导入
    /// </summary>
    public class B2B_WAFER_LISTBLL : B2B_WAFER_LISTIBLL
    {
        private B2B_WAFER_LISTService b2B_WAFER_LISTService = new B2B_WAFER_LISTService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_WAFER_LISTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return b2B_WAFER_LISTService.GetPageList(pagination, queryJson);
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
        /// 获取B2B_WAFER_LIST表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_WAFER_LISTEntity GetB2B_WAFER_LISTEntity(string keyValue)
        {
            try
            {
                return b2B_WAFER_LISTService.GetB2B_WAFER_LISTEntity(keyValue);
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
        /// 获取B2B_WAFER_LIST_SUB表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public B2B_WAFER_LIST_SUBEntity GetB2B_WAFER_LIST_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_WAFER_LISTService.GetB2B_WAFER_LIST_SUBEntity(keyValue);
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
                b2B_WAFER_LISTService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, B2B_WAFER_LIST_SUBEntity entity,B2B_WAFER_LISTEntity b2B_WAFER_LISTEntity)
        {
            try
            {
                b2B_WAFER_LISTService.SaveEntity(keyValue, entity,b2B_WAFER_LISTEntity);
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

        public void Saveupload(B2B_WAFER_LISTEntity entity, List<B2B_WAFER_LIST_SUBEntity> entitysub)
        {
            try
            {
                b2B_WAFER_LISTService.Saveupload(entity, entitysub);
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

        public IEnumerable<B2B_WAFER_LIST_SUBEntity> GetPageListSub(string keyValue)
        {
            try
            {
                return b2B_WAFER_LISTService.GetPageListSub(keyValue);
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
