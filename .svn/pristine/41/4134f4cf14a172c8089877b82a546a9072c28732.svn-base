using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-18 17:04
    /// 描 述：员工手册后台管理
    /// </summary>
    public class Hy_Recruit_TheEmployeeHandbookBLL : Hy_Recruit_TheEmployeeHandbookIBLL
    {
        private Hy_Recruit_TheEmployeeHandbookService hy_Recruit_TheEmployeeHandbookService = new Hy_Recruit_TheEmployeeHandbookService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_TheEmployeeHandbookEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return hy_Recruit_TheEmployeeHandbookService.GetPageList(pagination, queryJson);
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
        /// 获取Hy_Recruit_TheEmployeeHandbook表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_TheEmployeeHandbookEntity GetHy_Recruit_TheEmployeeHandbookEntity(string keyValue)
        {
            try
            {
                return hy_Recruit_TheEmployeeHandbookService.GetHy_Recruit_TheEmployeeHandbookEntity(keyValue);
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
                hy_Recruit_TheEmployeeHandbookService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, Hy_Recruit_TheEmployeeHandbookEntity entity)
        {
            try
            {
                hy_Recruit_TheEmployeeHandbookService.SaveEntity(keyValue, entity);
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
