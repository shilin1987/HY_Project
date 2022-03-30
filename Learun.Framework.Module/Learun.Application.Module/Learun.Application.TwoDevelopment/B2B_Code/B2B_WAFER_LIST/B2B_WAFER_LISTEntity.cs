using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-24 14:32
    /// 描 述：晶圆清单导入
    /// </summary>
    public class B2B_WAFER_LISTEntity 
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
        /// 审核日期
        /// </summary>
        [Column("FCHECK_DATE")]
        public DateTime? FCHECK_DATE { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        [Column("FCHECK_PERSON")]
        public string FCHECK_PERSON { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("FMANAGE_FLG")]
        public string FMANAGE_FLG { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [Column("FFILE_NAME")]
        public string FFILE_NAME { get; set; }
        /// <summary>
        /// 文件存放路径
        /// </summary>
        [Column("FADRESS")]
        public string FADRESS { get; set; }
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

