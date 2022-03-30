﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-12 09:36
    /// 描 述：通知单管理
    /// </summary>
    public interface RecruitReportNoticeIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_Recruit_ReportNoticeEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取Hy_Recruit_ReportNotice表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Recruit_ReportNoticeEntity GetHy_Recruit_ReportNoticeEntity(string keyValue);

        Hy_Recruit_ReportNoticeEntity GetPageListData(string subid);
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
        ReturnCommon SaveEntity(string subid, Hy_Recruit_ReportNoticeEntity entity);
        ReturnCommon SaveEntityList(string subid, Hy_Recruit_ReportNoticeEntity entity);
        #endregion

    }
}
