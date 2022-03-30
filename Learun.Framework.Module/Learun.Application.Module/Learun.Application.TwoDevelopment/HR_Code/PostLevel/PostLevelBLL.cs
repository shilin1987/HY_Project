﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-28 14:04
    /// 描 述：岗级工资和基本工资维护
    /// </summary>
    public class PostLevelBLL : PostLevelIBLL
    {
        private PostLevelService postLevelService = new PostLevelService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_PostLevelEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return postLevelService.GetPageList(pagination, queryJson);
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
        /// <param name="PostLevelNumber"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_PostLevelEntity> GetPostLevelEntityList(string PostLevelNumber)
        {
            try
            {
                return postLevelService.GetPostLevelEntityList(PostLevelNumber);
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
        /// 获取Hy_hr_PostLevel表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_PostLevelEntity GetHy_hr_PostLevelEntity(string keyValue)
        {
            try
            {
                return postLevelService.GetHy_hr_PostLevelEntity(keyValue);
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
            return postLevelService.DeleteEntity(keyValue);
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_PostLevelEntity entity)
        {
            return postLevelService.SaveEntity(keyValue, entity);
        }


        #endregion

    }
}
