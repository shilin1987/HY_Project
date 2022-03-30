using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HY_Logistics;
using Learun.Application.TwoDevelopment.HR_Code.FSConsumptionRecord;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 15:35
    /// 描 述：人员消费记录查询
    /// </summary>
    public class FSConsumptionRecordBLL : FSConsumptionRecordIBLL
    {
        private FSConsumptionRecordService fSConsumptionRecordService = new FSConsumptionRecordService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<hr_MonthlyconsumptiondataEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return fSConsumptionRecordService.GetPageList(pagination, queryJson);
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
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthConsumptionList(string year, string month)
        {
            try
            {
                return fSConsumptionRecordService.GetOneMonthConsumptionList(year, month);
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
        /// <param name="userId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthConsumptionPersonList(string userId, string year, string month)
        {
            try
            {
                return fSConsumptionRecordService.GetOneMonthConsumptionPersonList(userId, year, month);
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
        /// 获取hr_Monthlyconsumptiondata表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public hr_MonthlyconsumptiondataEntity Gethr_MonthlyconsumptiondataEntity(string keyValue)
        {
            try
            {
                return fSConsumptionRecordService.Gethr_MonthlyconsumptiondataEntity(keyValue);
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
        /// <param name="userid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="rq"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthlyconsumptiondataEntity(string userid, string year, string month, string rq, Hr_MealAllowanceStandardEntity entity, string type)
        {
            try
            {
                return fSConsumptionRecordService.GetOneMonthlyconsumptiondataEntity(userid, year, month, rq, entity, type);
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
        /// <param name="userId"></param>
        /// <param name="rq"></param>
        /// <param name="breakfastBegan"></param>
        /// <param name="breakfastEnd"></param>
        /// <param name="LunchBegan"></param>
        /// <param name="LunchEnd"></param>
        /// <param name="dinnerBegan"></param>
        /// <param name="dinnerEnd"></param>
        /// <param name="nightBegan"></param>
        /// <param name="nightEnd"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsConsumptionDTO> GetMonthlyconsumptiondataList(string userId, string rq, string breakfastBegan, string breakfastEnd,
           string LunchBegan, string LunchEnd, string dinnerBegan, string dinnerEnd, string nightBegan, string nightEnd)
        {
            try
            {
                return fSConsumptionRecordService.GetMonthlyconsumptiondataList( userId,  rq,  breakfastBegan,  breakfastEnd,
                LunchBegan,  LunchEnd,  dinnerBegan,  dinnerEnd,  nightBegan,  nightEnd);
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
                fSConsumptionRecordService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, hr_MonthlyconsumptiondataEntity entity)
        {
            try
            {
                fSConsumptionRecordService.SaveEntity(keyValue, entity);
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
