using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-07 19:52
    /// 描 述：菜价补贴考勤数据明细
    /// </summary>
    public class Hr_user_attendanceEntity 
    {
        #region 实体成员
        /// <summary>
        /// 系统id
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
        /// 考勤时间
        /// </summary>
        [Column("RQ")]
        public DateTime? rq { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        [Column("BC")]
        public string bc { get; set; }
        /// <summary>
        /// 公差工时
        /// </summary>
        [Column("CHAIQ02")]
        public decimal? chaiq02 { get; set; }
        /// <summary>
        /// 外出工时
        /// </summary>
        [Column("CHAIQ01")]
        public decimal? chaiq01 { get; set; }
        /// <summary>
        /// 在岗工时
        /// </summary>
        [Column("CQGS")]
        public decimal? cqgs { get; set; }
        /// <summary>
        /// yearno
        /// </summary>
        [Column("YEARNO")]
        public string yearno { get; set; }
        /// <summary>
        /// monthno
        /// </summary>
        [Column("MONTHNO")]
        public string monthno { get; set; }
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

