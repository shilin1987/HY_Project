using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.TwoDevelopment.HR_WorkPermitModule;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.Platform.Wl_ChangeShifts;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 16:49
    /// 描 述：Wl_ChangeShifts
    /// </summary>
    public class Wl_ChangeShiftsBLL : Wl_ChangeShiftsIBLL
    {
        private Wl_ChangeShiftsService wl_ChangeShiftsService = new Wl_ChangeShiftsService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Wl_ChangeShiftsEntity> GetList(string queryJson)
        {
            try
            {
                return wl_ChangeShiftsService.GetList(queryJson);
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<ChangeShiftsEntityDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return wl_ChangeShiftsService.GetPageList(pagination, queryJson);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Wl_ChangeShiftsEntity GetEntity(string keyValue)
        {
            try
            {
                return wl_ChangeShiftsService.GetEntity(keyValue);
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
        /// 获取子表显示列表数据
        /// <summary>
        /// <param name="fno">主表主键单号</param>
        /// <returns></returns>
        public IEnumerable<Hy_Wl_OaReturnInfo_itemEntity> GetSubList(string fno)
        {
            try
            {
                return wl_ChangeShiftsService.GetSubList(fno);
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
        /// 获取用户信息显示列表数据
        /// <summary>
        /// <param name="F_EnCode">主表主键单号</param>
        /// <returns></returns>
        public IEnumerable<UserEntityDTO> GetUserList(string F_UserId)
        {
            try
            {
                return wl_ChangeShiftsService.GetUserList(F_UserId);
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
        /// 获取信息显示
        /// <summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public IEnumerable<UserChangeShiftsEntityDTO> GetUserChangeShiftsList(string fid)
        {
            try
            {
                return wl_ChangeShiftsService.GetUserChangeShiftsList(fid);
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
        /// 查询人员信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public ReturnCommon<IEnumerable<ChangeShiftForAccountDTO>> GetUserInfoForAccoount(string account)
        {
            return wl_ChangeShiftsService.GetUserInfoForAccoount(account);
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
                wl_ChangeShiftsService.DeleteEntity(keyValue);
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
        public ReturnComment SaveEntity(string keyValue, Hy_Wl_ChangeShiftsEntity entity)
        {
            try
            {
               return wl_ChangeShiftsService.SaveEntity(keyValue, entity);
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

        public ReturnComment UpdateEntity(Hy_Wl_ChangeShiftsEntity entity)
        {
            try
            {
                return wl_ChangeShiftsService.UpdateEntity(entity);
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
