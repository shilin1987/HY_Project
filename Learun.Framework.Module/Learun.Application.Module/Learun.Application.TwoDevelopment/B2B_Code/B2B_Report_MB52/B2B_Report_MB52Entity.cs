using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_MB52
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-02-22 09:49
    /// 描 述：产成品库存报表
    /// </summary>
    public class B2B_Report_MB52Entity
    {
        //[Column("MATNR")]
        public string MATNR { get; set; }//物料编号

        //[Column("MAKTX")]
        public string MAKTX { get; set; }//物料描述

        //[Column("PARTID")]
        public string PARTID { get; set; }//MES PartID

        //[Column("LGORT")]
        public string LGORT { get; set; }//库存地点

        //[Column("LGOBE")]
        public string LGOBE { get; set; }//仓储地点的描述

        //[Column("WERKS")]
        public string WERKS { get; set; }//工厂

        //[Column("CLABS")]
        public Int64 CLABS { get; set; }//非限制库存

        //[Column("CUMLM")]
        public Int64 CUMLM { get; set; }//中转中库存

        //[Column("CSPEM")]
        public Int64 CSPEM { get; set; }//扣押冻结库存

        //[Column("UNIT")]
        public string UNIT { get; set; }//基本计量单位

        //[Column("CHARG")]
        public string CHARG { get; set; }//批号

        //[Column("SOBKZ")]
        public string SOBKZ { get; set; }//特殊库存标识

        //[Column("ERSDA")]
        public string ERSDA { get; set; }//收货日期

        //[Column("CUST_PARTIN")]
        public string CUST_PARTIN { get; set; }//产品型号

        //[Column("CUST_PARTOUT")]
        public string CUST_PARTOUT { get; set; }//出厂产品型号

        //[Column("ZZJGLX")]
        public string ZZJGLX { get; set; }//加工类型

        //[Column("PACKAGE_M")]
        public string PACKAGE_M { get; set; }//封装形式

        //[Column("CUST_CODE")]
        public string CUST_CODE { get; set; }//客户代码

        //[Column("KUNNR")]
        public string KUNNR { get; set; }//客户编号

        //[Column("ZCUST_LOT")]
        public string ZCUST_LOT { get; set; }//客户批次

        //[Column("CHILD_LOT")]
        public string CHILD_LOT { get; set; }//流程卡号

        //[Column("DATECODE")]
        public string DATECODE { get; set; }//DATE CODE

        //[Column("BIN")]
        public string BIN { get; set; }//BIN别 

        //[Column("WAFER_LOT_NO")]
        public string WAFER_LOT_NO { get; set; }//晶圆芯片批次

        //[Column("STOCK_TYPE")]
        public string STOCK_TYPE { get; set; }//库存类型

        //[Column("ZZGYLC")]
        public string ZZGYLC { get; set; }//特殊工艺

        //[Column("PACKAGE_TYPE")]
        public string PACKAGE_TYPE { get; set; }//包装方式

        //[Column("ZZBZFS_DESC")]
        public string ZZBZFS_DESC { get; set; }//包装方式说明

        //[Column("ZASSY_GRADE")]
        public string ZASSY_GRADE { get; set; }//封装等级

        //[Column("ZEP_GRADE")]
        public string ZEP_GRADE { get; set; }//环保等级

        //[Column("ORDER_TYPE")]
        public string ORDER_TYPE { get; set; }//MES工单类型

        //[Column("INBOX_NO")]
        public string INBOX_NO { get; set; }//内盒箱号

        //[Column("ZOUT_BOX")]
        public string ZOUT_BOX { get; set; }//外箱箱号

        //[Column("RECEIPT_NO")]
        public string RECEIPT_NO { get; set; }//入库单号

        //[Column("LOTID")]
        public string LOTID { get; set; }//Lot ID

        //[Column("CUST_BIN")]
        public string CUST_BIN { get; set; }//备注4(批次) 

        //[Column("CUST_PO")]
        public string CUST_PO { get; set; }//客户PO

        //[Column("CUST_DEVICE")]
        public string CUST_DEVICE { get; set; }//芯片型号

        //[Column("MARKING_INFO")]
        public string MARKING_INFO { get; set; }//印章内容

        //[Column("REMARK")]
        public string REMARK { get; set; }//备注

        //[Column("VMI")]
        public string VMI { get; set; }//VMI

        //[Column("ZBIN")]
        public string ZBIN { get; set; }//货位

        //[Column("ZZBIZ_TYPE")]
        public string ZZBIZ_TYPE { get; set; }//业务类型

        //[Column("ZSOBKZ")]
        public string ZSOBKZ { get; set; }      //库存类型 '空 = ALL B = 客户库存 A = 非限制

        //[Column("IV_FLAG")]
        public string IV_FLAG { get; set; }      //为 X 过滤掉已占用库存（可选）

        //[Column("INBOXtype")]
        public string INBOXtype { get; set; }      //为 X 内盒显示

        //[Column("ZOUTtype")]
        public string ZOUTtype { get; set; }      //为 X 外箱显示

        //[Column("FindType")]
        public string FindType { get; set; }
    }
}
