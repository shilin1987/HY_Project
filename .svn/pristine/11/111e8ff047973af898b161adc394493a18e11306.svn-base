using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 21:11
    /// 描 述：菜价补贴月明细数据
    /// </summary>
    public class FS_VegetablePriceSubsidyMonthlyDetailsEntity 
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
        /// 姓名
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [Column("F_USERNAME")]
        public string F_UserName { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        [Column("F_YEAR")]
        public string F_Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        [Column("F_MONTH")]
        public string F_Month { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        [Column("F_SHIFTTYPE")]
        public string F_ShiftType { get; set; }
        /// <summary>
        /// 签卡
        /// </summary>
        [Column("F_QK")]
        public DateTime? F_Qk { get; set; }
        /// <summary>
        /// 早餐
        /// </summary>
        [Column("F_BREAKFAST")]
        public decimal? F_Breakfast { get; set; }
        /// <summary>
        /// 午餐
        /// </summary>
        [Column("F_LUNCH")]
        public decimal? F_Lunch { get; set; }
        /// <summary>
        /// 晚餐
        /// </summary>
        [Column("F_DINNER")]
        public decimal? F_Dinner { get; set; }
        /// <summary>
        /// 夜宵
        /// </summary>
        [Column("F_NIGHT")]
        public decimal? F_Night { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        [Column("F_STANDARDCOMBINED")]
        public decimal? F_StandardCombined { get; set; }

        /// <summary>
        /// 实际上班时长
        /// </summary>
        [Column("F_Time")]
        public decimal? F_Time { get; set; }

        /// <summary>
        /// 实际上班时长
        /// </summary>
        [Column("F_ShiftName")]
        public string F_ShiftName { get; set; }

        /// <summary>
        /// 实际上班时长
        /// </summary>
        [Column("F_ShiftTypeExend")]
        public string F_ShiftTypeExend { get; set; }
        /// <summary>
        /// 实际上班时长
        /// </summary>
        [Column("F_ShiftTime")]
        public decimal? F_ShiftTime { get; set; }


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
        #endregion
    }
}

