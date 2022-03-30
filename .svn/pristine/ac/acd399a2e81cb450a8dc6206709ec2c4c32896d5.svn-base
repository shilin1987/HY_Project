using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-16 18:14
    /// 描 述：部门对应成本中心维护
    /// </summary>
    public class Hr_center_costEntity 
    {
        #region 实体成员
        /// <summary>
        /// 系统id
        /// </summary>
        [Column("OID")]
        public string oid { get; set; }
        /// <summary>
        /// 成本中心编号
        /// </summary>
        [Column("CENTER_COST_CODE")]
        public string center_cost_code { get; set; }
        /// <summary>
        /// 成本中心名称
        /// </summary>
        [Column("CENTER_COST")]
        public string center_cost { get; set; }
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

