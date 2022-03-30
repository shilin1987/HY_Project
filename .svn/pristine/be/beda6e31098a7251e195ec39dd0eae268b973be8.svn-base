using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-02 16:41
    /// 描 述：客户月度来料计划合并功能
    /// </summary>
    public class B2B_PLAN_MATERIAL_MERGEEntity 
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        /// <summary>
        /// 合并日期
        /// </summary>
        [Column("F_MERGE_DATE")]
        public DateTime? F_MERGE_DATE { get; set; }
        /// <summary>
        /// 合并人员
        /// </summary>
        [Column("F_MERGE_PRESON")]
        public string F_MERGE_PRESON { get; set; }
        /// <summary>
        /// 分配标记
        /// </summary>
        [Column("F_PLAN_ALLOT_FLG")]
        public int? F_PLAN_ALLOT_FLG { get; set; }
        /// <summary>
        /// 分配日期
        /// </summary>
        [Column("F_PLAN_ALLOT_DATE")]
        public DateTime? F_PLAN_ALLOT_DATE { get; set; }
        /// <summary>
        /// 分配人员
        /// </summary>
        [Column("F_PLAN_ALLOT_PRESON")]
        public string F_PLAN_ALLOT_PRESON { get; set; }
        /// <summary>
        /// 合并月份
        /// </summary>
        [Column("F_MERGE_MONTH")]
        public string F_MERGE_MONTH { get; set; }
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

