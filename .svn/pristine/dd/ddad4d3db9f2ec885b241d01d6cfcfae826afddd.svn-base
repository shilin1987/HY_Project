using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-22 16:56
    /// 描 述：来料计划填报推送提醒
    /// </summary>
    public class B2B_CUST_PLAN_WARNEntity 
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        [Column("F_CUST_CODE")]
        public string F_CUST_CODE { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        [Column("F_SUBJECT")]
        public string F_SUBJECT { get; set; }
        /// <summary>
        /// 收件人员
        /// </summary>
        [Column("F_RECIPIENTS")]
        public string F_RECIPIENTS { get; set; }
        /// <summary>
        /// 抄送人员
        /// </summary>
        [Column("F_COPY_TO")]
        public string F_COPY_TO { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("F_CONTENT")]
        public string F_CONTENT { get; set; }
        /// <summary>
        /// 每月几号（1-31）
        /// </summary>
        [Column("F_DAY")]
        public int? F_DAY { get; set; }
        /// <summary>
        /// 小时（24H制）
        /// </summary>
        [Column("F_TIME")]
        public string F_TIME { get; set; }
        /// <summary>
        /// 建立人员
        /// </summary>
        [Column("F_CREATE_PERSON")]
        public string F_CREATE_PERSON { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("F_CREATE_DATE")]
        public DateTime? F_CREATE_DATE { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("F_FLG")]
        public int? F_FLG { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_GUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_GUID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

