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
    public class B2B_WAFER_LIST_SUBEntity 
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        [Column("FGUID")]
        public string FGUID { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        [Column("FID")]
        public string FID { get; set; }
        /// <summary>
        /// 芯片型号
        /// </summary>
        [Column("FWAFER_TYPE")]
        public string FWAFER_TYPE { get; set; }
        /// <summary>
        /// 芯片批号
        /// </summary>
        [Column("FWAFER_BATCH")]
        public string FWAFER_BATCH { get; set; }
        /// <summary>
        /// 片数
        /// </summary>
        [Column("FWAFER_QTY")]
        public string FWAFER_QTY { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        [Column("FWAFER_NUMBER")]
        public string FWAFER_NUMBER { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column("FWAFER_DIE")]
        public string FWAFER_DIE { get; set; }
        /// <summary>
        /// 扩展参数_01
        /// </summary>
        [Column("FPARAMETER_01")]
        public string FPARAMETER_01 { get; set; }
        /// <summary>
        /// FPARAMETER_02
        /// </summary>
        [Column("FPARAMETER_02")]
        public string FPARAMETER_02 { get; set; }
        /// <summary>
        /// FPARAMETER_03
        /// </summary>
        [Column("FPARAMETER_03")]
        public string FPARAMETER_03 { get; set; }
        /// <summary>
        /// FPARAMETER_04
        /// </summary>
        [Column("FPARAMETER_04")]
        public string FPARAMETER_04 { get; set; }
        /// <summary>
        /// FPARAMETER_05
        /// </summary>
        [Column("FPARAMETER_05")]
        public string FPARAMETER_05 { get; set; }
        /// <summary>
        /// FPARAMETER_06
        /// </summary>
        [Column("FPARAMETER_06")]
        public string FPARAMETER_06 { get; set; }
        /// <summary>
        /// FPARAMETER_07
        /// </summary>
        [Column("FPARAMETER_07")]
        public string FPARAMETER_07 { get; set; }
        /// <summary>
        /// FPARAMETER_08
        /// </summary>
        [Column("FPARAMETER_08")]
        public string FPARAMETER_08 { get; set; }
        /// <summary>
        /// FPARAMETER_09
        /// </summary>
        [Column("FPARAMETER_09")]
        public string FPARAMETER_09 { get; set; }
        /// <summary>
        /// FPARAMETER_10
        /// </summary>
        [Column("FPARAMETER_10")]
        public string FPARAMETER_10 { get; set; }
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
        #region 扩展字段
        /// <summary>
        /// 客户代码
        /// </summary>
        [NotMapped]
        public string FCUST_CODE { get; set; }
        #endregion
    }
}

