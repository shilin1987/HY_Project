using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.Platform

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 09:14
    /// 描 述：上岗资格认证表
    /// </summary>
    public class Hy_Wl_NormalShiftEntity 
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
        public int? F_Description { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// 主表ID
        /// </summary>
        /// <returns></returns>
        [Column("F_USERID")]
        public string F_UserID { get; set; }
        
        /// <summary>
        /// 人员类别
        /// </summary>
        /// <returns></returns>
        [Column("F_PERSONNELCATEGORY")]
        public string F_PersonnelCategory { get; set; }
        ///// <summary>
        ///// 上岗日期
        ///// </summary>
        ///// <returns></returns>
        [Column("F_APPOINTMENTDATE")]
        public string F_AppointmentDate { get; set; }
        /// <summary>
        /// 试用期限
        /// </summary>
        /// <returns></returns>
        [Column("F_PROBATIONPERIOD")]
        public string F_ProbationPeriod { get; set; }
        /// <summary>
        /// 应知应会（笔试）
        /// </summary>
        /// <returns></returns>
        [Column("F_WRITTENEXAMINATION")]
        public decimal? F_writtenExamination { get; set; }
        /// <summary>
        /// 实际操作及能力
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATIONCAPABILITY")]
        public decimal? F_OperationCapability { get; set; }
        /// <summary>
        /// 工作态度及效率
        /// </summary>
        /// <returns></returns>
        [Column("F_WORKINGATTITUDE")]
        public decimal? F_workingAttitude { get; set; }
        /// <summary>
        /// 责任感及学习态度
        /// </summary>
        /// <returns></returns>
        [Column("F_RESPONSIBILITY")]
        public decimal? F_Responsibility { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        /// <returns></returns>
        [Column("F_SUM")]
        public decimal? F_SUM { get; set; }
        /// <summary>
        /// 部门/工序BPM
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATIONBPM")]
        public string F_OperationBPM { get; set; }
        /// <summary>
        /// 部门/工序主管
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATIONDIRECTOR")]
        public string F_OperationDirector { get; set; }
        /// <summary>
        /// 部门负责人
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATIONCHARGE")]
        public string F_OperationCharge { get; set; }
        /// <summary>
        /// 品质管理部
        /// </summary>
        /// <returns></returns>
        [Column("F_QUALITYMANAGEMENT")]
        public string F_QualityManagement { get; set; }
        /// <summary>
        /// 人力资源部
        /// </summary>
        /// <returns></returns>
        [Column("F_HUMANRESOURCES")]
        public string F_HumanResources { get; set; }
        /// <summary>
        /// 表单号
        /// </summary>
        /// <returns></returns>
        [Column("F_NO")]
        public string F_NO { get; set; }
        /// <summary>
        /// 是否下载
        /// </summary>
        /// <returns></returns>
        [Column("F_IsDownload")]
        public string F_IsDownload { get; set; }
        /// <summary>
        /// 试用日期
        /// </summary>
        /// <returns></returns>
        [Column("F_TrialDate")]
        public string F_TrialDate { get; set; }
        /// <summary>
        /// OA返回状态
        /// </summary>
        [Column("F_Status")]
        public string F_Status { get; set; }
        /// <summary>
        /// OA返回调用信息
        /// </summary>
        [Column("F_Mes")]
        public string F_Mes { get; set; }
        /// <summary>
        /// 请求OA soap请求头信息
        /// </summary>
        [Column("F_RequerstDescriptionInfo")]
        public string F_RequerstDescriptionInfo { get; set; }
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
    }
}

