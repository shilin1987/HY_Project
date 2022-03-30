﻿using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-28 14:04
    /// 描 述：岗级工资和基本工资维护
    /// </summary>
    public class Hy_hr_PostLevelEntity 
    {
        public object PostLevelId;
        #region 实体成员
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// 岗级编号
        /// </summary>
        [Column("F_POSTLEVELCODE")]
        public string F_PostlevelCode { get; set; }
        /// <summary>
        /// 岗级名称
        /// </summary>
        [Column("F_POSTLEVELNAME")]
        public string F_PostlevelName { get; set; }
        /// <summary>
        /// 岗位工资最低值
        /// </summary>
        [Column("F_POSTSALARYMINIMUM")]
        public decimal? F_PostSalaryMinimum { get; set; }
        /// <summary>
        /// 岗位工资最大值
        /// </summary>
        [Column("F_POSTSALARYMAXIMUM")]
        public decimal? F_PostSalaryMaximum { get; set; }
        /// <summary>
        /// 岗位工资
        /// </summary>
        [Column("F_BASEPAY")]
        public decimal? F_BasePay { get; set; }
        /// <summary>
        /// 绩效工资
        /// </summary>
        [Column("F_PERFORMANCEPAY")]
        public decimal? F_PerformancePay { get; set; }
        /// <summary>
        /// 全勤奖
        /// </summary>
        [Column("F_PERFECTATTENDANCE")]
        public decimal? F_PerfectAttendance { get; set; }
        /// <summary>
        /// 技能工资
        /// </summary>
        [Column("F_SKILLSALARY")]
        public decimal? F_SkillSalary { get; set; }
        /// <summary>
        /// 管理技能工资
        /// </summary>
        [Column("F_MANAGEMENTSKILLSALARY")]
        public decimal? F_ManagementSkillSalary { get; set; }
        /// <summary>
        /// 交通补贴
        /// </summary>
        [Column("F_TRANSPORTATIONSUBSIDY")]
        public decimal? F_TransportationSubsidy { get; set; }
        /// <summary>
        /// 住房补贴
        /// </summary>
        [Column("F_HOUSINGSUBSIDY")]
        public decimal? F_HousingSubsidy { get; set; }
        /// <summary>
        /// 值班补贴
        /// </summary>
        [Column("F_DUTYALLOWANCE")]
        public decimal? F_DutyAllowance { get; set; }
        /// <summary>
        /// 误餐补贴
        /// </summary>
        [Column("F_MISSEDMEALALLOWANCE")]
        public decimal? F_MissedMealAllowance { get; set; }
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
        /// 岗级工资ID
        /// </summary>
        //public string PostLevelId { get; set; }
        #endregion
    }
}

