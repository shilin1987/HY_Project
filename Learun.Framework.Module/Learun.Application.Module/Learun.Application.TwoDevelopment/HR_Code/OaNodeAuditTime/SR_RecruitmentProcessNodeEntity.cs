using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.HR_Code

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-26 12:07
    /// 描 述：OA节点时间统计
    /// </summary>
    public class SR_RecruitmentProcessNodeEntity 
    {
        #region 实体成员
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// HR招聘流程单号
        /// </summary>
        /// <returns></returns>
        [Column("F_HRINDICATESORDERNUMBER")]
        public string F_HrIndicatesOrderNumber { get; set; }
        /// <summary>
        /// 流程节点创建时间
        /// </summary>
        /// <returns></returns>
        [Column("F_APPROVECREATIONTIME")]
        public DateTime? F_ApproveCreationTime { get; set; }
        /// <summary>
        /// OA流程单号
        /// </summary>
        /// <returns></returns>
        [Column("F_OAFLOWNUMBER")]
        public string F_OaFlowNumber { get; set; }
        /// <summary>
        /// 简历附件
        /// </summary>
        /// <returns></returns>
        [Column("F_RESUMEATTACHMENT")]
        public string F_ResumeAttachment { get; set; }
        /// <summary>
        /// OArequestid
        /// </summary>
        /// <returns></returns>
        [Column("F_REQUESTID")]
        public string F_Requestid { get; set; }
        /// <summary>
        /// OA审批节点名称
        /// </summary>
        /// <returns></returns>
        [Column("F_CHECKPOINTNAME")]
        public string F_CheckpointName { get; set; }
        /// <summary>
        /// 是否超时
        /// </summary>
        /// <returns></returns>
        [Column("F_IFTIMEOUT")]
        public string F_IfTimeout { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        /// <returns></returns>
        [Column("F_WHETHERTHROUGH")]
        public string F_WhetherThrough { get; set; }
        /// <summary>
        /// 归档时间
        /// </summary>
        /// <returns></returns>
        [Column("F_ARCHIVETIME")]
        public string F_ArchiveTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ID = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_ID = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

