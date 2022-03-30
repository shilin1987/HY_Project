using Learun.Util;
using System.Collections.Generic;
using Learun.Application;
using Learun.Application.TwoDevelopment.ReturnModel;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public interface RecruitmentProcessInformationClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<SR_RecruitmentProcessNodeEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取SR_RecruitmentProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        SR_RecruitmentProcessNodeEntity GetSR_RecruitmentProcessNodeEntity(string keyValue);
        /// <summary>
        /// 获取SR_ProcessNode表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        SR_ProcessNodeEntity GetSR_ProcessNodeEntity(string keyValue);
        /// <summary>
        /// 获取SR_ProcessAttachment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        SR_ProcessAttachmentEntity GetSR_ProcessAttachmentEntity(string keyValue);
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
        void SaveEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity,SR_ProcessNodeEntity sR_ProcessNodeEntity,SR_ProcessAttachmentEntity sR_ProcessAttachmentEntity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <param name="sR_ProcessNodeEntity"></param>
        /// <param name="sR_ProcessAttachmentEntity"></param>
        void SaveListEntity(string keyValue, SR_RecruitmentProcessNodeEntity entity, List<SR_ProcessNodeEntity> sR_ProcessNodeListEntity, List<SR_ProcessAttachmentEntity> sR_ProcessAttachmentListEntity);

        ReturnComment InsertListEntity(string jsonStr,string userId);
        #endregion

    }
}
