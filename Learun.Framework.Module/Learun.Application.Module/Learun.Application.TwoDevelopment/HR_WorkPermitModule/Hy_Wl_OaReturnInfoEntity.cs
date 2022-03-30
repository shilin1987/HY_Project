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
    /// 日 期：2021-12-02 10:58
    /// 描 述：OA上岗证打印主表
    /// </summary>
    public class Hy_Wl_OaReturnInfoEntity 
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
        /// 流程中文名称
        /// </summary>
        /// <returns></returns>
        [Column("F_FLOWNAME")]
        public string F_FlowName { get; set; }
        /// <summary>
        /// OA单号
        /// </summary>
        /// <returns></returns>
        [Column("F_OAFLOWNUMBER")]
        public string F_OaFlowNumber { get; set; }
        /// <summary>
        /// OArequestid
        /// </summary>
        /// <returns></returns>
        [Column("F_REQUESTID")]
        public string F_Requestid { get; set; }
        /// <summary>
        /// 归档时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CLOSINGTIME")]
        public DateTime? F_ClosingTime { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        /// <returns></returns>
        [Column("F_TYPE")]
        public int? F_Type { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        /// <returns></returns>
        [Column("F_STATE")]
        public string F_State { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_No = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        public void Create(string userId,string hrOrderNumber)
        {
            UserIBLL user = new UserBLL();
            UserEntity ue = user.GetEntityByAccount(userId);
            this.F_No = hrOrderNumber;
            this.F_CreateDate = DateTime.Now;
            //UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = ue.F_UserId;
            this.F_CreateUserName = ue.F_RealName;
            this.F_Description = "上岗证打印流程接口数据";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_No = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

