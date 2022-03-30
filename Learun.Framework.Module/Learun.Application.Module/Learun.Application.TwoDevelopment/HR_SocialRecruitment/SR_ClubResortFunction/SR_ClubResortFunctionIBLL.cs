﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-11 17:52
    /// 描 述：招聘流程流程节点维护
    /// </summary>
    public interface SR_ClubResortFunctionIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<SR_ClubResortFunctionEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取SR_ClubResortFunction表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        SR_ClubResortFunctionEntity GetSR_ClubResortFunctionEntity(string keyValue);
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();
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
        void SaveEntity(string keyValue, SR_ClubResortFunctionEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f_ProcessId"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        SR_ClubResortFunctionEntity GetSR_ClubResortNextNodeEntity(string f_ProcessId, decimal v);
        #endregion

    }
}
