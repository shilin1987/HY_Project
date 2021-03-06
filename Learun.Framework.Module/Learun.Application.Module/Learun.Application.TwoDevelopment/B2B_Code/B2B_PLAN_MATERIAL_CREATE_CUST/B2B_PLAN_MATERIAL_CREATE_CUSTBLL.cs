using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_PLAN_MATERIAL_CREATE_CUST;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-10 13:46
    /// 描 述：客户端月度来料计划填报
    /// </summary>
    public class B2B_PLAN_MATERIAL_CREATE_CUSTBLL : B2B_PLAN_MATERIAL_CREATE_CUSTIBLL
    {
        private B2B_PLAN_MATERIAL_CREATE_CUSTService b2B_PLAN_MATERIAL_CREATE_CUSTService = new B2B_PLAN_MATERIAL_CREATE_CUSTService();

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
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetPageList(pagination, queryJson);
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
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetB2B_PLAN_INCOMING_MATERIALEntity(keyValue);
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
                b2B_PLAN_MATERIAL_CREATE_CUSTService.DeleteEntity(keyValue);
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
        public void AddSaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity, List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBList, out bool have, out string outmsg, out bool inforerror)
        {
            try
            {
                b2B_PLAN_MATERIAL_CREATE_CUSTService.AddSaveEntity(keyValue, entity, b2B_PLAN_INCOMING_MATERIAL_SUBList, out have, out outmsg, out inforerror);
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

        public void SaveEntity(string keyValue, B2B_PLAN_INCOMING_MATERIALEntity entity, List<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> b2B_PLAN_INCOMING_MATERIAL_SUBEntity,out bool have, out string outmsg, out bool inforerror)
        {
            try
            {
                b2B_PLAN_MATERIAL_CREATE_CUSTService.SaveEntity(keyValue, entity, b2B_PLAN_INCOMING_MATERIAL_SUBEntity,out have, out outmsg, out inforerror);
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
        public IEnumerable<MES_PRODUCT_DATA> GetProuduct(string partid)
        {
            try
            {
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetProuduct(partid);
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

        public  IEnumerable<B2B_PLAN_INCOMING_MATERIAL_SUBEntity> GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(string keyValue)
        {
            try
            {
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetB2B_PLAN_INCOMING_MATERIAL_SUBEntity(keyValue);
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

        public IEnumerable<MES_PRODUCT_DATA> GetPartidData(string custcode, string pRODUCT_MODEL, string pACKAGING_TYPE, string pACKAGE_MODEL, string wAFER_MODEL)
        {
            try
            {
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetPartidData(custcode, pRODUCT_MODEL, pACKAGING_TYPE, pACKAGE_MODEL, wAFER_MODEL);
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
                return b2B_PLAN_MATERIAL_CREATE_CUSTService.GetPageListSub(keyValue);
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
