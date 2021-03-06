using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.TwoDevelopment.HR_WorkPermitModule;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 09:14
    /// 描 述：上岗资格认证表
    /// </summary>
    public interface WL_NormalShiftIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<Hy_Wl_NormalShiftEntity> GetList( string queryJson );
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<NormalShiftEntityDTO> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Wl_NormalShiftEntity GetEntity(string keyValue);
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
        IEnumerable<UserEntityDTO> GetUserList(string fno);

        IEnumerable<UserNormalShiftEntityDTO> GetUserNormalShiftList(string fid);
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
        ReturnComment SaveEntity(string keyValue, Hy_Wl_NormalShiftEntity entity);

        ReturnComment UpdateEntity(Hy_Wl_NormalShiftEntity entity);
        #endregion

    }
}
