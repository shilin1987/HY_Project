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
    public class B2B_PLAN_MATERIAL_ALLOTEntity 
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        /// <summary>
        /// 分配月份
        /// </summary>
        [Column("F_ALLOT_MONTH")]
        public string F_ALLOT_MONTH { get; set; }
        /// <summary>
        /// 分配人员
        /// </summary>
        [Column("F_ALLOT_PERSON")]
        public string F_ALLOT_PERSON { get; set; }
        /// <summary>
        /// 分配日期
        /// </summary>
        [Column("F_ALLOT_DATE")]
        public DateTime? F_ALLOT_DATE { get; set; }
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

