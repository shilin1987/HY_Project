using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 14:53
    /// 描 述：新菜价补贴计算
    /// </summary>
    public class FS_VegetablePricesEntity 
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
        public string F_Id { get; set; }
        /// <summary>
        /// 人员工号
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        [Column("F_USERNAME")]
        public string F_UserName { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        [Column("F_YEAR")]
        public string F_Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        [Column("F_MONTH")]
        public string F_Month { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Column("F_DEPTID")]
        public string F_DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("F_DEPTNAME")]
        public string F_DeptName { get; set; }
        /// <summary>
        /// 成本中心编号
        /// </summary>
        [Column("F_COSTCENTERNO")]
        public string F_CostCenterno { get; set; }
        /// <summary>
        /// 成本中心名称
        /// </summary>
        [Column("F_COSTCENTERNAME")]
        public string F_CostCenterName { get; set; }
        /// <summary>
        /// 早餐次数合计
        /// </summary>
        [Column("F_MONBREAKFASTTOGETHER")]
        public int? F_MonBreakfastTogether { get; set; }
        /// <summary>
        /// 午餐次数合计
        /// </summary>
        [Column("F_MONLUNCHTOGETHER")]
        public int? F_MonLunchTogether { get; set; }
        /// <summary>
        /// 晚餐次数合计
        /// </summary>
        [Column("F_MONDINNERTOGETHER")]
        public int? F_MonDinnerTogether { get; set; }
        /// <summary>
        /// 夜宵次数合计
        /// </summary>
        [Column("F_MONSUPPERTOGETHER")]
        public int? F_MonSupperTogether { get; set; }
        /// <summary>
        /// 月总报销金额
        /// </summary>
        [Column("F_COUNTMONEY")]
        public decimal? F_CountMoney { get; set; }
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
        #region 扩展字段
        #endregion
    }
}

