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
    public class B2B_PLAN_INCOMING_MATERIAL_SUBEntity 
    {

        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        [Column("F_ID")]
        public string F_ID { get; set; }
        /// <summary>
        /// PARTID
        /// </summary>
        [Column("PARTID")]
        public string PARTID { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        [Column("F_PRODUCT_MODEL")]
        public string F_PRODUCT_MODEL { get; set; }
        /// <summary>
        /// 封装外形
        /// </summary>
        [Column("F_PACKAGE_MODEL")]
        public string F_PACKAGE_MODEL { get; set; }
        /// <summary>
        /// 封装等级
        /// </summary>
        [Column("F_PRODUCT_LEVEL")]
        public string F_PRODUCT_LEVEL { get; set; }
        /// <summary>
        /// 芯片型号
        /// </summary>
        [Column("F_WAFER_MODEL")]
        public string F_WAFER_MODEL { get; set; }
        /// <summary>
        /// 晶圆尺寸
        /// </summary>
        [Column("F_WAFER_SIZE")]
        public string F_WAFER_SIZE { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        [Column("F_PACKAGING_TYPE")]
        public string F_PACKAGING_TYPE { get; set; }
        /// <summary>
        /// 焊线编号
        /// </summary>
        [Column("F_WIRE_SOLDER_CODE")]
        public string F_WIRE_SOLDER_CODE { get; set; }
        /// <summary>
        /// 焊线描述
        /// </summary>
        [Column("F_WIRE_SOLDER_NAME")]
        public string F_WIRE_SOLDER_NAME { get; set; }
        /// <summary>
        /// 框架编号
        /// </summary>
        [Column("F_SHELL_FRAM_CODE")]
        public string F_SHELL_FRAM_CODE { get; set; }
        /// <summary>
        /// 框架描述
        /// </summary>
        [Column("F_SHELL_FRAM_NAME")]
        public string F_SHELL_FRAM_NAME { get; set; }
        /// <summary>
        /// 月份一
        /// </summary>
        [Column("F_MONTH_ONE")]
        public string F_MONTH_ONE { get; set; }
        /// <summary>
        /// 月份二
        /// </summary>
        [Column("F_MONTH_TWO")]
        public string F_MONTH_TWO { get; set; }
        /// <summary>
        /// 月份三
        /// </summary>
        [Column("F_MONTH_THREE")]
        public string F_MONTH_THREE { get; set; }
        /// <summary>
        /// 月份四
        /// </summary>
        [Column("F_MONTH_FOUR")]
        public string F_MONTH_FOUR { get; set; }
        /// <summary>
        /// 月份五
        /// </summary>
        [Column("F_MONTH_FIVE")]
        public string F_MONTH_FIVE { get; set; }
        /// <summary>
        /// 月份六
        /// </summary>
        [Column("F_MONTH_SIX")]
        public string F_MONTH_SIX { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARK")]
        public string F_REMARK { get; set; }
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
    }
}

