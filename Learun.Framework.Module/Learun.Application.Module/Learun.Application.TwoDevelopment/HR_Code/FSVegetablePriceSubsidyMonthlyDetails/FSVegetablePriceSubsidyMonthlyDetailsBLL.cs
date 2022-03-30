using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 21:11
    /// 描 述：菜价补贴月明细数据
    /// </summary>
    public class FSVegetablePriceSubsidyMonthlyDetailsBLL : FSVegetablePriceSubsidyMonthlyDetailsIBLL
    {
        private FSVegetablePriceSubsidyMonthlyDetailsService fSVegetablePriceSubsidyMonthlyDetailsService = new FSVegetablePriceSubsidyMonthlyDetailsService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePriceSubsidyMonthlyDetailsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return fSVegetablePriceSubsidyMonthlyDetailsService.GetPageList(pagination, queryJson);
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
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FS_VegetablePriceSubsidyMonthlyDetailsEntity> GetAllList(string year, string month)
        {
            try
            {
                return fSVegetablePriceSubsidyMonthlyDetailsService.GetAllList(year, month);
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
        /// 获取FS_VegetablePriceSubsidyMonthlyDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public FS_VegetablePriceSubsidyMonthlyDetailsEntity GetFS_VegetablePriceSubsidyMonthlyDetailsEntity(string keyValue)
        {
            try
            {
                return fSVegetablePriceSubsidyMonthlyDetailsService.GetFS_VegetablePriceSubsidyMonthlyDetailsEntity(keyValue);
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
                fSVegetablePriceSubsidyMonthlyDetailsService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, FS_VegetablePriceSubsidyMonthlyDetailsEntity entity)
        {
            try
            {
                fSVegetablePriceSubsidyMonthlyDetailsService.SaveEntity(keyValue, entity);
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
