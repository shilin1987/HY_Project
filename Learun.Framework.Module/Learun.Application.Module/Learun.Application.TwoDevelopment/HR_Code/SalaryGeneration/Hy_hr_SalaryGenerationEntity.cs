﻿using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 10:51
    /// 描 述：最终工资结算展示
    /// </summary>
    public class Hy_hr_SalaryGenerationEntity 
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
        public int? F_Description { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 结算工资年月
        /// </summary>
        [Column("F_WAGESYEARMONTH")]
        public int? F_WagesYearMonth { get; set; }
        /// <summary>
        /// 缺勤扣款
        /// </summary>
        [Column("F_ABSENCEFROMDUTY")]
        public decimal? F_AbsenceFromDuty { get; set; }
        /// <summary>
        /// 奖惩补贴
        /// </summary>
        [Column("F_REWARDPUNISHMENTSUBSIDY")]
        public decimal? F_RewardPunishmentSubsidy { get; set; }
        /// <summary>
        /// 五险一金
        /// </summary>
        [Column("F_FIVEINSURANCESONEFUND")]
        public decimal? F_FiveInsurancesOneFund { get; set; }
        /// <summary>
        /// 房费
        /// </summary>
        [Column("F_ROOMRATE")]
        public decimal? F_RoomRate { get; set; }
        /// <summary>
        /// 加班工资
        /// </summary>
        [Column("F_OVERTIMEPAY")]
        public decimal? F_OvertimePay { get; set; }
        /// <summary>
        /// 全勤奖加回
        /// </summary>
        [Column("F_TOTALMANAGEMENTSYSTEM")]
        public decimal? F_TotalManagementSystem { get; set; }
        /// <summary>
        /// 应发工资
        /// </summary>
        [Column("F_WAGESPAYABLE")]
        public decimal? F_WagesPayable { get; set; }
        /// <summary>
        /// 个税缴纳
        /// </summary>
        [Column("F_PERSONALINCOMETAX")]
        public decimal? F_PersonalIncomeTax { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        [Column("F_ELECTRICITYFEES")]
        public decimal? F_ElectricityFees { get; set; }
        /// <summary>
        /// 党费
        /// </summary>
        [Column("F_PARTYMEMBERSHIPDUES")]
        public decimal? F_PartyMembershipDues { get; set; }
        /// <summary>
        /// 财务扣款
        /// </summary>
        [Column("F_FINANCIALDEDUCTION")]
        public decimal? F_FinancialDeduction { get; set; }
        /// <summary>
        /// 实发工资
        /// </summary>
        [Column("F_NETSALARY")]
        public decimal? F_NetSalary { get; set; }
        /// <summary>
        /// F_ID
        /// </summary>
        [Column("F_ID")]
        public string F_ID { get; set; }

        /// <summary>
        /// 法定节假日加班工资
        /// </summary>
        public decimal? F_StatutoryHolidaysMoney { get; set; }

        /// <summary>
        /// 通讯补贴
        /// </summary>
        public decimal? F_CommunicationAllowance { get; set; }

        /// <summary>
        /// 工龄工资(倒班)
        /// </summary>
        public decimal? F_SeniorityPay { get; set; }

        /// <summary>
        /// 延时工资(倒班)
        /// </summary>
        public decimal? F_DelaySalary { get; set; }

        /// <summary>
        /// 夜班津贴(倒班)
        /// </summary>
        public decimal? F_NightShiftAllowance { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string F_note { get; set; }

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

