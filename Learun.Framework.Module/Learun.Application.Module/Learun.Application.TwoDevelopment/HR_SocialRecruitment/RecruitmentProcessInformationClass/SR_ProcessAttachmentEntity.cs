﻿using Learun.Application.Organization;
using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-08 19:00
    /// 描 述：招聘流程功能
    /// </summary>
    public class SR_ProcessAttachmentEntity 
    {
        #region 实体成员
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 是主键
        /// </summary>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// 是主键
        /// </summary>
        [Column("F_SUBITEM")]
        public int? F_SubItem { get; set; }
        /// <summary>
        /// 附件名称
        /// </summary>
        [Column("F_FILENAME")]
        public string F_fileName { get; set; }
        /// <summary>
        /// 附件base64
        /// </summary>
        [Column("F_FILE")]
        public string F_file { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        [Column("F_STATE")]
        public string F_State { get; set; }
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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void Create(string userId)
        {
            UserIBLL user = new UserBLL();
            UserEntity ue = user.GetEntityByAccount(userId);
            this.F_ID = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            //UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = ue.F_UserId;
            this.F_CreateUserName = ue.F_RealName;
            this.F_Description = "招聘流程接口数据";
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

