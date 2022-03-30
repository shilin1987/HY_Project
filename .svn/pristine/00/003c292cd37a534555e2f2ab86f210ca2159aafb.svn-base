using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-16 19:34
    /// 描 述：菜价补贴月汇总数据
    /// </summary>
    public class Hr_vpsmonthdataALLEntity 
    {
        #region 实体成员
        /// <summary>
        /// oid
        /// </summary>
        [Column("OID")]
        public string oid { get; set; }
        /// <summary>
        /// center_cost
        /// </summary>
        [Column("CENTER_COST")]
        public string center_cost { get; set; }
        /// <summary>
        /// countperson
        /// </summary>
        [Column("COUNTPERSON")]
        public string countperson { get; set; }
        /// <summary>
        /// summoney
        /// </summary>
        [Column("SUMMONEY")]
        public string summoney { get; set; }
        /// <summary>
        /// avgmoney
        /// </summary>
        [Column("AVGMONEY")]
        public string avgmoney { get; set; }
        /// <summary>
        /// bk
        /// </summary>
        [Column("BK")]
        public string bk { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.oid = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.oid = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

