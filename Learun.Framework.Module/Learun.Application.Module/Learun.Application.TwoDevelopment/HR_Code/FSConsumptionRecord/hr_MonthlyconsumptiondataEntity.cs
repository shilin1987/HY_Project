using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 15:35
    /// 描 述：人员消费记录查询
    /// </summary>
    public class hr_MonthlyconsumptiondataEntity 
    {
        #region 实体成员
        /// <summary>
        /// oid
        /// </summary>
        [Column("OID")]
        public string oid { get; set; }
        /// <summary>
        /// Person_Name
        /// </summary>
        [Column("PERSON_NAME")]
        public string Person_Name { get; set; }
        /// <summary>
        /// Person_No
        /// </summary>
        [Column("PERSON_NO")]
        public string Person_No { get; set; }
        /// <summary>
        /// Card_No
        /// </summary>
        [Column("CARD_NO")]
        public string Card_No { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        [Column("IP")]
        public string IP { get; set; }
        /// <summary>
        /// Tabie_No
        /// </summary>
        [Column("TABIE_NO")]
        public string Tabie_No { get; set; }
        /// <summary>
        /// Tabie_Name
        /// </summary>
        [Column("TABIE_NAME")]
        public string Tabie_Name { get; set; }
        /// <summary>
        /// ZK_Amount
        /// </summary>
        [Column("ZK_AMOUNT")]
        public decimal? ZK_Amount { get; set; }
        /// <summary>
        /// Comsume_ID
        /// </summary>
        [Column("COMSUME_ID")]
        public int? Comsume_ID { get; set; }
        /// <summary>
        /// Business_ID
        /// </summary>
        [Column("BUSINESS_ID")]
        public int? Business_ID { get; set; }
        /// <summary>
        /// Person_ID
        /// </summary>
        [Column("PERSON_ID")]
        public int? Person_ID { get; set; }
        /// <summary>
        /// Tabie_ID
        /// </summary>
        [Column("TABIE_ID")]
        public int? Tabie_ID { get; set; }
        /// <summary>
        /// Dining_ID
        /// </summary>
        [Column("DINING_ID")]
        public int? Dining_ID { get; set; }
        /// <summary>
        /// Dishes_ID
        /// </summary>
        [Column("DISHES_ID")]
        public int? Dishes_ID { get; set; }
        /// <summary>
        /// Copies
        /// </summary>
        [Column("COPIES")]
        public int? Copies { get; set; }
        /// <summary>
        /// Comsume_Date
        /// </summary>
        [Column("COMSUME_DATE")]
        public DateTime? Comsume_Date { get; set; }
        /// <summary>
        /// Comsume_Sum
        /// </summary>
        [Column("COMSUME_SUM")]
        public decimal? Comsume_Sum { get; set; }
        /// <summary>
        /// Discount_Sum
        /// </summary>
        [Column("DISCOUNT_SUM")]
        public decimal? Discount_Sum { get; set; }
        /// <summary>
        /// Comsume_Type
        /// </summary>
        [Column("COMSUME_TYPE")]
        public int? Comsume_Type { get; set; }
        /// <summary>
        /// Preferential_Mode
        /// </summary>
        [Column("PREFERENTIAL_MODE")]
        public int? Preferential_Mode { get; set; }
        /// <summary>
        /// Serial
        /// </summary>
        [Column("SERIAL")]
        public string Serial { get; set; }
        /// <summary>
        /// Reserve1
        /// </summary>
        [Column("RESERVE1")]
        public string Reserve1 { get; set; }
        /// <summary>
        /// Reserve2
        /// </summary>
        [Column("RESERVE2")]
        public string Reserve2 { get; set; }
        /// <summary>
        /// Reserve3
        /// </summary>
        [Column("RESERVE3")]
        public string Reserve3 { get; set; }
        /// <summary>
        /// User_No
        /// </summary>
        [Column("USER_NO")]
        public string User_No { get; set; }
        /// <summary>
        /// Modify_Date
        /// </summary>
        [Column("MODIFY_DATE")]
        public DateTime? Modify_Date { get; set; }
        /// <summary>
        /// Create_Date
        /// </summary>
        [Column("CREATE_DATE")]
        public DateTime? Create_Date { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// Dishes_No
        /// </summary>
        [Column("DISHES_NO")]
        public string Dishes_No { get; set; }
        /// <summary>
        /// Dishes_Name
        /// </summary>
        [Column("DISHES_NAME")]
        public string Dishes_Name { get; set; }
        /// <summary>
        /// EnterpriseNo
        /// </summary>
        [Column("ENTERPRISENO")]
        public string EnterpriseNo { get; set; }
        /// <summary>
        /// IsCorrect
        /// </summary>
        [Column("ISCORRECT")]
        public string IsCorrect { get; set; }
        /// <summary>
        /// Extend1
        /// </summary>
        [Column("EXTEND1")]
        public string Extend1 { get; set; }
        /// <summary>
        /// Grade
        /// </summary>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// Dept_ID
        /// </summary>
        [Column("DEPT_ID")]
        public int? Dept_ID { get; set; }
        /// <summary>
        /// Extend3
        /// </summary>
        [Column("EXTEND3")]
        public string Extend3 { get; set; }
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

