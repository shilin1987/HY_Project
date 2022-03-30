using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-18 17:57
    /// 描 述：操作员招聘流程流程环节记录
    /// </summary>
    public interface RecordOperatorRecruitmentProcessClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<SR_RecordOperatorRecruitmentProcessEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取SR_RecordOperatorRecruitmentProcess表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        SR_RecordOperatorRecruitmentProcessEntity GetSR_RecordOperatorRecruitmentProcessEntity(string keyValue);
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
        void SaveEntity(string keyValue, SR_RecordOperatorRecruitmentProcessEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f_UserId"></param>
        /// <param name="f_ProcessId"></param>
        /// <param name="f_SortCode"></param>
        /// <returns></returns>
        SR_RecordOperatorRecruitmentProcessEntity getRecordOperatorRecruitment(string f_UserId, string f_ProcessId, decimal f_SortCode);
        #endregion

    }
}
