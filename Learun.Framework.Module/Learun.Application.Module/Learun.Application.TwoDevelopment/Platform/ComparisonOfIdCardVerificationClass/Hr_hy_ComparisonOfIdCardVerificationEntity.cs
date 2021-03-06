using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-22 14:41
    /// 描 述：身份证信息读取对比
    /// </summary>
    public class Hr_hy_ComparisonOfIdCardVerificationEntity 
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
        /// 主键
        /// </summary>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Column("F_CARDID")]
        public string F_CardID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("F_USERNAME")]
        public string F_UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column("F_SEX")]
        public string F_Sex { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        [Column("F_STATE")]
        public int? F_State { get; set; }
        /// <summary>
        /// 信息比结果
        /// </summary>
        [Column("F_INFORMATIONCONTRASTDIFFERENCE")]
        public string F_InformationContrastDifference { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Column("F_OPERATIONPERSON")]
        public string F_OperationPerson { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Column("F_OPERATINGTIME")]
        public DateTime? F_OperatingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("F_USERID")]
        public string  F_UserId { get; set; }
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
        #region 扩展字段
        /// <summary>
        /// 联系方式
        /// </summary>
        public string F_Contact { get; set; }
        /// <summary>
        /// 学历信息
        /// </summary>
        public string F_EducationInformation { get; set; }
        #endregion
    }
}

