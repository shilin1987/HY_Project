using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-16 14:11
    /// 描 述：来料计划产能分配
    /// </summary>
    public class B2B_PLAN_MATERIAL_ALLOT_SUBEntity 
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
        /// 产品系统
        /// </summary>
        [Column("F_PRODUCT_SERIES")]
        public string F_PRODUCT_SERIES { get; set; }
        /// <summary>
        /// 产品外形式
        /// </summary>
        [Column("F_PACKAGE_MODEL")]
        public string F_PACKAGE_MODEL { get; set; }
        /// <summary>
        /// 月份一计划数量
        /// </summary>
        [Column("F_PLAN_MONTH_ONE")]
        public int? F_PLAN_MONTH_ONE { get; set; }
        /// <summary>
        /// 月份一实际数量
        /// </summary>
        [Column("F_REAL_MONTH_ONE")]
        public int? F_REAL_MONTH_ONE { get; set; }
        /// <summary>
        /// 月份二计划数量
        /// </summary>
        [Column("F_PLAN_MONTH_TWO")]
        public int? F_PLAN_MONTH_TWO { get; set; }
        /// <summary>
        /// 月份二实际数量
        /// </summary>
        [Column("F_REAL_MONTH_TWO")]
        public int? F_REAL_MONTH_TWO { get; set; }
        /// <summary>
        /// 月份三计划数量
        /// </summary>
        [Column("F_PLAN_MONTH_THREE")]
        public int? F_PLAN_MONTH_THREE { get; set; }
        /// <summary>
        /// 月份三实际数量
        /// </summary>
        [Column("F_REAL_MONTH_THREE")]
        public int? F_REAL_MONTH_THREE { get; set; }
        /// <summary>
        /// 未投数量
        /// </summary>
        [Column("F_WT_QTY")]
        public int? F_WT_QTY { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        [Column("F_KC_QTY")]
        public int? F_KC_QTY { get; set; }
        /// <summary>
        /// 分配数量
        /// </summary>
        [Column("F_ALLOT_QTY")]
        public int? F_ALLOT_QTY { get; set; }
        /// <summary>
        /// 日分配数量
        /// </summary>
        [Column("F_ALLOT_DAY_QTY")]
        public int? F_ALLOT_DAY_QTY { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// 分配月份
        /// </summary>
        [Column("F_ALLOT_MONTH")]
        public string F_ALLOT_MONTH { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
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
    }
}

