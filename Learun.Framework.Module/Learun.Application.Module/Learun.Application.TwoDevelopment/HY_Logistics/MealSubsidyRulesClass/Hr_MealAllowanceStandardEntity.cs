using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HY_Logistics
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 17:02
    /// 描 述：餐别补贴规则
    /// </summary>
    public class Hr_MealAllowanceStandardEntity 
    {
        #region 实体成员
        /// <summary>
        /// mas_no
        /// </summary>
        [Column("MAS_NO")]
        public string mas_no { get; set; }
        /// <summary>
        /// mas_name
        /// </summary>
        [Column("MAS_NAME")]
        public string mas_name { get; set; }
        /// <summary>
        /// startime
        /// </summary>
        [Column("STARTIME")]
        public string startime { get; set; }
        /// <summary>
        /// endtime
        /// </summary>
        [Column("ENDTIME")]
        public string endtime { get; set; }
        /// <summary>
        /// mas_money
        /// </summary>
        [Column("MAS_MONEY")]
        public decimal? mas_money { get; set; }
        /// <summary>
        /// mas_limitminmoney
        /// </summary>
        [Column("MAS_LIMITMINMONEY")]
        public decimal? mas_limitminmoney { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.mas_no = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.mas_no = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

