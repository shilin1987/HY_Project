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
    public class B2B_CUST_ORDER_SUBEntity 
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
        /// PARTID                                                         
        /// </summary>
        [Column("FPARTID")]
        public string FPARTID { get; set; }  
        /// <summary>
        /// 芯片型号
        /// </summary>
        [Column("FWAFER_TYPE")]
        public string FWAFER_TYPE { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        [Column("FPRODUCT_TYPE")]
        public string FPRODUCT_TYPE { get; set; }
        /// <summary>
        /// 封装形式
        /// </summary>
        [Column("FPACKAGE_TYPE")]
        public string FPACKAGE_TYPE { get; set; }
        /// <summary>
        /// 芯片批号
        /// </summary>
        [Column("FWAFER_BATCH")]
        public string FWAFER_BATCH { get; set; }
        /// <summary>
        /// CUST_PO
        /// </summary>
        [Column("FCUST_PO")]
        public string FCUST_PO { get; set; }
        /// <summary>
        /// 片数
        /// </summary>
        [Column("FWAFER_NUMBER")]
        public string FWAFER_NUMBER { get; set; }
        /// <summary>
        /// 片号
        /// </summary>
        [Column("FWAFER_NO")]
        public string FWAFER_NO { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column("FWAFER_QTY")]
        public string FWAFER_QTY { get; set; }
        /// <summary>
        /// 是否测试
        /// </summary>
        [Column("FIS_TEST")]
        public string FIS_TEST { get; set; }
        /// <summary>
        /// 测试规范编号
        /// </summary>
        [Column("FTEST_CODE")]
        public string FTEST_CODE { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        [Column("FIS_PRINT")]
        public string FIS_PRINT { get; set; }
        /// <summary>
        /// 印章规范编号
        /// </summary>
        [Column("FPRINT_CODE")]
        public string FPRINT_CODE { get; set; }
        /// <summary>
        /// 压焊图号
        /// </summary>
        [Column("FBONDING_CODE")]
        public string FBONDING_CODE { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        [Column("FPACKING_TYPE")]
        public string FPACKING_TYPE { get; set; }
        /// <summary>
        /// 环保等级
        /// </summary>
        [Column("FGREEN_LEVE")]
        public string FGREEN_LEVE { get; set; }
        /// <summary>
        /// 批次类型
        /// </summary>
        [Column("FBATCH_TYPE")]
        public string FBATCH_TYPE { get; set; }
        /// <summary>
        /// 封装等级
        /// </summary>
        [Column("FPACKAGE_LEVE")]
        public string FPACKAGE_LEVE { get; set; }
        /// <summary>
        /// 取片方式
        /// </summary>
        [Column("FGETWAFER_TYPE")]
        public string FGETWAFER_TYPE { get; set; }
        /// <summary>                                                        
        /// 贸易方式                                                         
        /// </summary>
        [Column("FTRADE_TYPE")]
        public string FTRADE_TYPE { get; set; }
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

