using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.Platform

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-31 10:54
    /// 描 述：RWrittenExamination
    /// </summary>
    public class Hy_Recruit_WrittenExaminationEntity 
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
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        /// <returns></returns>
        [Column("F_SCORE")]
        public decimal? F_Score { get; set; }
        /// <summary>
        /// 笔试题库外键
        /// </summary>
        /// <returns></returns>
        [Column("F_WRITTENTESTQUESTIONBANKID")]
        public string F_WrittenTestQuestionBankId { get; set; }
        /// <summary>
        /// 新员工外键
        /// </summary>
        /// <returns></returns>
        [Column("F_CANDIDATESID")]
        public string F_CandidatesID { get; set; }
        /// <summary>
        /// F_IDCard
        /// </summary>
        /// <returns></returns>
        [Column("F_IDCARD")]
        public string F_IDCard { get; set; }
        /// <summary> 
        /// 真实姓名 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary> 
        /// 性别 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_GENDER")]
        public string F_Gender { get; set; }
        /// <summary> 
        /// 学历 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_EDUCATION")]
        public string F_Education { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
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
            this.F_Id = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

