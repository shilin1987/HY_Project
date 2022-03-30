using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-07 14:19
    /// 描 述：考勤班次维护
    /// </summary>
    public class MonthlyVegetablePriceSubsidyEntity
    {
        #region 实体成员
        /// <summary>
        /// 系统oid
        /// </summary>
        [Column("OID")]
        public string oid { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Column("USERID")]
        public string userid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("USERNAME")]
        public string username { get; set; }
        /// <summary>
        /// 一级组织
        /// </summary>
        [Column("LEVELORGONE")]
        public string LevelOrgOne { get; set; }
        /// <summary>
        /// 二级组织
        /// </summary>
        [Column("LEVELORGTWO")]
        public string LevelOrgTwo { get; set; }
        /// <summary>
        /// 三级组织
        /// </summary>
        [Column("LEVELORGTHREE")]
        public string LevelOrgThree { get; set; }
        /// <summary>
        /// 四级组织
        /// </summary>
        [Column("LEVELORGFOUR")]
        public string LevelOrgFour { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        [Column("SHIFT_NO")]
        public string shift_no { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        [Column("DATEOFATTENDANCE")]
        public string DateofAttendance { get; set; }
        /// <summary>
        /// 出勤时数
        /// </summary>
        [Column("ATTENDANCEHOURS")]
        public string AttendanceHours { get; set; }
        /// <summary>
        /// 年假时长
        /// </summary>
        [Column("ANNUALEAVEHOURS")]
        public string AnnuaLeaveHours { get; set; }
        /// <summary>
        /// 出差时数
        /// </summary>
        [Column("BUSINESSHOURS")]
        public string BusinessHours { get; set; }
        /// <summary>
        /// 外出时数
        /// </summary>
        [Column("OUTFORHOURS")]
        public string Outforhours { get; set; }
        /// <summary>
        /// 在岗时长
        /// </summary>
        [Column("ONTHEJOBWORKHOURS")]
        public string Onthejobworkhours { get; set; }
        /// <summary>
        /// 五级组织
        /// </summary>
        [Column("FIVEGROUPS")]
        public string FiveGroups { get; set; }
        /// <summary>
        /// 上班制度
        /// </summary>
        [Column("WORKSYSTEM")]
        public string WorkSystem { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        [Column("CLOCKTIME")]
        public string Clocktime { get; set; }
        /// <summary>
        /// 迟到时间
        /// </summary>
        [Column("MINUTESLATE")]
        public string Minuteslate { get; set; }
        /// <summary>
        /// 早退分钟
        /// </summary>
        [Column("LEAVEEARLYMINUTES")]
        public string LeaveEarlyMinutes { get; set; }
        /// <summary>
        /// 平日加班统计值（刷卡）
        /// </summary>
        [Column("STATISTICSTIME")]
        public string StatisticsTime { get; set; }
        /// <summary>
        /// 平日加班确认值
        /// </summary>
        [Column("SURETIME")]
        public string SureTime { get; set; }
        /// <summary>
        /// 加班转调休
        /// </summary>
        [Column("OVERTIMEWORK")]
        public string OvertimeWork { get; set; }
        /// <summary>
        /// 双休加班统计值
        /// </summary>
        [Column("STATISTICSTIME1")]
        public string StatisticsTime1 { get; set; }
        /// <summary>
        /// 双休加班确认值
        /// </summary>
        [Column("SURETIME1")]
        public string SureTime1 { get; set; }
        /// <summary>
        /// 法定加班统计值
        /// </summary>
        [Column("STATISTICSTIME2")]
        public string StatisticsTime2 { get; set; }
        /// <summary>
        /// 法定加班确认值
        /// </summary>
        [Column("SURETIME2")]
        public string SureTime2 { get; set; }
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
        /// AttendanceDate
        /// </summary>
        [Column("ATTENDANCEDATE")]
        public string AttendanceDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.oid = Guid.NewGuid().ToString();
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
            this.oid = keyValue;
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

