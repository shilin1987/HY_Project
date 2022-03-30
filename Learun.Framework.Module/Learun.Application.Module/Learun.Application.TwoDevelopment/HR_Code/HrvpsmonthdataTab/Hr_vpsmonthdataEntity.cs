using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-10 13:48
    /// 描 述：菜价补贴月数据
    /// </summary>
    public class Hr_vpsmonthdataEntity 
    {
        #region 实体成员
        /// <summary>
        /// 系统ID
        /// </summary>
        [Column("OID")]
        public string oid { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [Column("USER_CODE")]
        public string user_code { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("USER_NAME")]
        public string user_name { get; set; }
        /// <summary>
        /// 月早餐次数合计
        /// </summary>
        [Column("MONBREAKFASTTOGETHER")]
        public string monBreakfastTogether { get; set; }
        /// <summary>
        /// 月午餐次数合计
        /// </summary>
        [Column("MONLUNCHTOGETHER")]
        public string monLunchTogether { get; set; }
        /// <summary>
        /// 月晚餐次数合计
        /// </summary>
        [Column("MONDINNERTOGETHER")]
        public string monDinnerTogether { get; set; }
        /// <summary>
        /// 月夜宵次数合计
        /// </summary>
        [Column("MONSUPPERTOGETHER")]
        public string monSupperTogether { get; set; }
        /// <summary>
        /// 成本中心名称
        /// </summary>
        [Column("COST_CENTERNO")]
        public string cost_centerno { get; set; }
        /// <summary>
        /// 成本中心编号
        /// </summary>
        [Column("COST_CENTER")]
        public string cost_center { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        [Column("MONTHNO")]
        public string monthno { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        [Column("YEARNO")]
        public string yearno { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Column("DEPTID")]
        public string deptid { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("DEPTNAME")]
        public string deptname { get; set; }
        /// <summary>
        /// 月总报销金额
        /// </summary>
        [Column("COUNTMONEY")]
        public string countMoney { get; set; }
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

