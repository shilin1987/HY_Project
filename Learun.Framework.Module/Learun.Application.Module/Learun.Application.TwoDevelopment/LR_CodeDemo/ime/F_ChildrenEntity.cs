using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-16 09:43
    /// 描 述：测试功能
    /// </summary>
    public class F_ChildrenEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// F_text
        /// </summary>
        [Column("F_TEXT")]
        public string F_text { get; set; }
        /// <summary>
        /// F_input
        /// </summary>
        [Column("F_INPUT")]
        public string F_input { get; set; }
        /// <summary>
        /// F_radio
        /// </summary>
        [Column("F_RADIO")]
        public string F_radio { get; set; }
        /// <summary>
        /// F_checkbox
        /// </summary>
        [Column("F_CHECKBOX")]
        public string F_checkbox { get; set; }
        /// <summary>
        /// F_Layer
        /// </summary>
        [Column("F_LAYER")]
        public string F_Layer { get; set; }
        /// <summary>
        /// F_date
        /// </summary>
        [Column("F_DATE")]
        public DateTime? F_date { get; set; }
        /// <summary>
        /// F_parentId
        /// </summary>
        [Column("F_PARENTID")]
        public string F_parentId { get; set; }
        /// <summary>
        /// F_select
        /// </summary>
        [Column("F_SELECT")]
        public string F_select { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
    }
}

