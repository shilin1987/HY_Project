﻿using Learun.Util;
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
    public interface Wl_ChangeShiftsIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<Hy_Wl_ChangeShiftsEntity> GetList( string queryJson );

        /// <summary>
        /// 根据员工账号查询员工信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        ReturnCommon<IEnumerable<ChangeShiftForAccountDTO>> GetUserInfoForAccoount(string account);
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<ChangeShiftsEntityDTO> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Wl_ChangeShiftsEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取子表显示列表数据
        /// <summary>
        /// <param name="fno">主表主键单号</param>
        /// <returns></returns>
        IEnumerable<Hy_Wl_OaReturnInfo_itemEntity> GetSubList(string fno);
        /// <summary>
        /// 人员
        /// <summary>
        /// <param name="F_EnCode">主表主键单号</param>
        /// <returns></returns>
        IEnumerable<UserEntityDTO> GetUserList(string F_UserId);
        /// <summary>
        /// 
        /// <summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        IEnumerable<UserChangeShiftsEntityDTO> GetUserChangeShiftsList(string fid);
        
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnComment SaveEntity(string keyValue, Hy_Wl_ChangeShiftsEntity entity);

        ReturnComment UpdateEntity(Hy_Wl_ChangeShiftsEntity entity);
        #endregion

    }
}
