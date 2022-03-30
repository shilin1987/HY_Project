using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：B2B_Account
    /// 日 期：2021-10-28 15:35
    /// 描 述：来料计划填报
    /// </summary>
    public class B2B_PLAN_INCOMING_MATERIALEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_GUID
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        [Column("F_CUST_CODE")]
        public string F_CUST_CODE { get; set; }
        /// <summary>
        /// 填报月份
        /// </summary>
        [Column("F_WRITE_MONTH")]
        public string F_WRITE_MONTH { get; set; }
        /// <summary>
        /// 填报人员
        /// </summary>
        [Column("F_WRITE_PRESON")]
        public string F_WRITE_PRESON { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        [Column("F_WRITE_DATE")]
        public string F_WRITE_DATE { get; set; }
        /// <summary>
        /// 合并标记
        /// </summary>
        [Column("F_MERGE_FLG")]
        public decimal? F_MERGE_FLG { get; set; }
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

