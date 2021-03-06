using Learun.Application.Organization;
using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.HR_WorkPermitModule

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-02 11:02
    /// 描 述：OA上岗证打印明细表
    /// </summary>
    public class Hy_Wl_OaReturnInfo_itemEntity 
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
        [Column("F_NO")]
        public string F_No { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_NONUM")]
        public int? F_NoNum { get; set; }
        /// <summary>
        /// 审批节点名称
        /// </summary>
        /// <returns></returns>
        [Column("F_CHECKPOINTNAME")]
        public string F_CheckpointName { get; set; }
        /// <summary>
        /// 节点审批时间
        /// </summary>
        /// <returns></returns>
        [Column("F_APPROVALTIME")]
        public DateTime? F_ApprovalTime { get; set; }
        /// <summary>
        /// 审批意见
        /// </summary>
        /// <returns></returns>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        /// <returns></returns>
        [Column("F_THEAPPROVER")]
        public string F_TheApprover { get; set; }
        /// <summary>
        /// 是否审批通过
        /// </summary>
        /// <returns></returns>
        [Column("F_WHETHERTHROUGH")]
        public string F_WhetherThrough { get; set; }
        /// <summary>
        /// 是否审批通过
        /// </summary>
        /// <returns></returns>
        [Column("F_RealName")]
        public string F_RealName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        public void Create(string userId, string hrOrderNumber)
        {
            UserIBLL user = new UserBLL();
            UserEntity ue = user.GetEntityByAccount(userId);
            this.F_No = hrOrderNumber;
            this.F_CreateDate = DateTime.Now;
            //UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = ue.F_UserId;
            this.F_CreateUserName = ue.F_RealName;
            this.F_Description = "上岗证流程接口数据";
        }
        #endregion
    }
}

