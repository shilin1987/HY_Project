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
    public interface ProcessOperationInfoIBLL
    {
        #region 查询日志数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_Recruit_ProcessOperationEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hy_hr_Interview表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Recruit_ProcessOperationEntity GetHy_Recruit_ProcessOperationEntity(string keyValue);
        #endregion

        #region 修改日志信息
        /// <summary>
        /// 修改或者新增流程节点操作信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnCommon SaveEntity(string key,Hy_Recruit_ProcessOperationEntity entity);
        /// <summary>
        /// 删除操作流程信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ReturnCommon DeleteEntity(string UserId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ReturnCommon SaveNodeInfoEntity(IRepository db, ReturnCommon<OutPutProcessModel> data,string userId,string currentProcessNode ,string currentProcessNodeName);

        #endregion
    }
}
