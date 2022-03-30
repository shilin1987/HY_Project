using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-22 09:14
    /// 描 述：节点信息查询
    /// </summary>
    public interface NodeInformationIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<NodeInformationEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hy_Recruit_Candidates表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        NodeInformationEntity GetHy_Recruit_CandidatesEntity(string keyValue);
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
        void SaveEntity(string keyValue, NodeInformationEntity entity);
        #endregion

    }
}
