﻿using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform.WL_BaseService;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.Hy_Recruit_ProcessOperation
{
    public class ProcessOperationInfoBLL : ProcessOperationInfoIBLL
    {
        private ProcessOperationInfoService processOperationInfoService = new ProcessOperationInfoService();


        #region 查询操作流程信息功能
        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Hy_Recruit_ProcessOperationEntity GetHy_Recruit_ProcessOperationEntity(string keyValue)
        {
            try
            {
                return processOperationInfoService.GetHy_Recruit_ProcessOperationEntity(keyValue);
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
        /// 根据查询条件查询所有
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_ProcessOperationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return processOperationInfoService.GetPageList(pagination, queryJson);
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
        
        #region 新增流程操作信息功能
        /// <summary>
        /// 新增或者保存信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string key, Hy_Recruit_ProcessOperationEntity entity)
        {
            try
            {
                return processOperationInfoService.SaveEntity(key, entity);
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
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ReturnCommon DeleteEntity(string UserId)
        {
            try
            {
                return processOperationInfoService.DeleteEntity(UserId);
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

        public ReturnCommon SaveNodeInfoEntity(IRepository db, ReturnCommon<OutPutProcessModel> data,string userId,string currentProcessNode ,string currentProcessNodeName)
        {
            try
            {
                return processOperationInfoService.SaveNodeInfoEntity(db, data, userId, currentProcessNode, currentProcessNodeName);
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
