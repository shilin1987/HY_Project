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
    /// 日 期：2021-06-03 18:39
    /// 描 述：考勤班次维护
    /// </summary>
    public class AttendanceMaintenanceClassBLL : AttendanceMaintenanceClassIBLL
    {
        private AttendanceMaintenanceClassService attendanceMaintenanceClassService = new AttendanceMaintenanceClassService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_SHIFTTIMETAB_fileEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return attendanceMaintenanceClassService.GetPageList(pagination, queryJson);
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
        /// 获取Hr_SHIFTTIMETAB_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_SHIFTTIMETAB_fileEntity GetHr_SHIFTTIMETAB_fileEntity(string keyValue)
        {
            try
            {
                return attendanceMaintenanceClassService.GetHr_SHIFTTIMETAB_fileEntity(keyValue);
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
        /// 获取Hr_SHIFTTIMETAB_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_SHIFTTIMETAB_fileEntity GetOneSHIFTTIMETAB_fileEntity(string flightNumber)
        {
            try
            {
                return attendanceMaintenanceClassService.GetOneSHIFTTIMETAB_fileEntity(flightNumber);
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
                attendanceMaintenanceClassService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, Hr_SHIFTTIMETAB_fileEntity entity)
        {
            try
            {
                attendanceMaintenanceClassService.SaveEntity(keyValue, entity);
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
