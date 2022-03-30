using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-03 18:39
    /// 描 述：考勤班次维护
    /// </summary>
    public class Hr_SHIFTTIMETAB_fileEntity 
    {
        #region 实体成员
        /// <summary>
        /// OID
        /// </summary>
        [Column("OID")]
        public string OID { get; set; }
        /// <summary>
        /// shift_no
        /// </summary>
        [Column("SHIFT_NO")]
        public string shift_no { get; set; }
        /// <summary>
        /// shift_name
        /// </summary>
        [Column("SHIFT_NAME")]
        public string shift_name { get; set; }
        /// <summary>
        /// timelimit
        /// </summary>
        [Column("TIMELIMIT")]
        public decimal? timelimit { get; set; }
        /// <summary>
        /// attendancesystem
        /// </summary>
        [Column("ATTENDANCESYSTEM")]
        public string attendancesystem { get; set; }

        /// <summary>
        /// shift_type
        /// </summary>
        [Column("SHIFT_TYPE")]
        public string shift_type { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.OID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.OID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

