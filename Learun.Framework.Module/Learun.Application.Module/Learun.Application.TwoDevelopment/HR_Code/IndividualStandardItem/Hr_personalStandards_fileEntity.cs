using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-11 10:41
    /// 描 述：个人标准工资明细
    /// </summary>
    public class Hr_personalStandards_fileEntity 
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
        /// uudi
        /// </summary>
        [Column("F_PS01")]
        public string F_ps01 { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        [Column("F_PS02")]
        public string F_ps02 { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("F_PS03")]
        public string f_ps03 { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        [Column("F_PS04")]
        public decimal? f_ps04 { get; set; }
        /// <summary>
        /// 技能工资
        /// </summary>
        [Column("F_PS05")]
        public decimal? f_ps05 { get; set; }
        /// <summary>
        /// 管理技能工资
        /// </summary>
        [Column("F_PS06")]
        public decimal? f_ps06 { get; set; }
        /// <summary>
        /// 全勤奖励
        /// </summary>
        [Column("F_PS07")]
        public decimal? f_ps07 { get; set; }
        /// <summary>
        /// 交通补贴
        /// </summary>
        [Column("F_PS08")]
        public decimal? f_ps08 { get; set; }
        /// <summary>
        /// 住房补贴
        /// </summary>
        [Column("F_PS09")]
        public decimal? f_ps09 { get; set; }
        /// <summary>
        /// 值班补贴
        /// </summary>
        [Column("F_PS10")]
        public decimal? f_ps10 { get; set; }
        /// <summary>
        /// 专干补贴
        /// </summary>
        [Column("F_PS11")]
        public decimal? f_ps11 { get; set; }
        /// <summary>
        /// 误餐补贴
        /// </summary>
        [Column("F_PS12")]
        public decimal? f_ps12 { get; set; }
        /// <summary>
        /// 岗级
        /// </summary>
        [Column("F_PS13")]
        public string f_ps13 { get; set; }
        /// <summary>
        /// 绩效工资
        /// </summary>
        [Column("F_PS14")]
        public decimal? f_ps14 { get; set; }
        /// <summary>
        /// 标准工资
        /// </summary>
        [Column("F_PS15")]
        public decimal? f_ps15 { get; set; }
        /// <summary>
        /// 延时基准
        /// </summary>
        [Column("F_PS16")]
        public decimal? f_ps16 { get; set; }
        /// <summary>
        /// 大夜班补贴基准
        /// </summary>
        [Column("F_PS17")]
        public decimal? f_ps17 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ps01 = Guid.NewGuid().ToString();
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
            this.F_ps01 = keyValue;
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

