using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-18 18:04
    /// 描 述：客户订单维护
    /// </summary>
    public class B2B_CUST_ORDEREntity 
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        [Column("FGUID")]
        public string FGUID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        [Column("FCUST_CODE")]
        public string FCUST_CODE { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("FCREATE_DATE")]
        public DateTime? FCREATE_DATE { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        [Column("FCHECK_PERSON")]
        public string FCHECK_PERSON { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [Column("FCHECK_DATE")]
        public DateTime? FCHECK_DATE { get; set; }
        /// <summary>
        /// 处理标记
        /// </summary>
        [Column("FMANAGE_FLG")]
        public string FMANAGE_FLG { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("FREMARK")]
        public string FREMARK { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Column("FORDER_TYPE")]
        public string FORDER_TYPE { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.FGUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.FGUID = keyValue;
        }
        #endregion
    }
}

