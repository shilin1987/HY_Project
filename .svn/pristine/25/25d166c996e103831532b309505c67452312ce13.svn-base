using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_MB52;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.SAP_Rfc
{
    public class SapRfc
    {

        private RfcConfigParameters configParams = null;
        private RfcRepository rfcRepository = null;
        private RfcDestination sapConfig = null;

        public SapRfc()
        {
            init();
        }
        private RfcConfigParameters GetConfigParams()
        {
            try
            {
                ////正式版
                //configParams = new RfcConfigParameters();
                ////Name property is neccessary, otherwise, NonInvalidParameterException will be thrown
                //configParams.Add(RfcConfigParameters.Name, "HYP");
                //configParams.Add(RfcConfigParameters.AppServerHost, "10.100.200.229");
                //configParams.Add(RfcConfigParameters.SystemNumber, "00"); // instance number
                //configParams.Add(RfcConfigParameters.SystemID, "HYP");
                //configParams.Add(RfcConfigParameters.User, "RFC_WW");
                //configParams.Add(RfcConfigParameters.Password, "12345.Com");
                //configParams.Add(RfcConfigParameters.Client, "900");
                //configParams.Add(RfcConfigParameters.Language, "ZH");
                //configParams.Add(RfcConfigParameters.PoolSize, "5");
                //configParams.Add(RfcConfigParameters.MaxPoolSize, "10");
                //configParams.Add(RfcConfigParameters.IdleTimeout, "30");

                ////测试版 120
                //configParams = new RfcConfigParameters();
                //// Name property is neccessary, otherwise, NonInvalidParameterException will be thrown
                //configParams.Add(RfcConfigParameters.Name, "S4D");
                //configParams.Add(RfcConfigParameters.AppServerHost, "192.168.98.249");
                //configParams.Add(RfcConfigParameters.SystemNumber, "00"); // instance number
                //configParams.Add(RfcConfigParameters.SystemID, "S4D");
                //configParams.Add(RfcConfigParameters.User, "RFC_WW");
                //configParams.Add(RfcConfigParameters.Password, "Init1234!");
                //configParams.Add(RfcConfigParameters.Client, "120");
                //configParams.Add(RfcConfigParameters.Language, "ZH");
                //configParams.Add(RfcConfigParameters.PoolSize, "5");
                //configParams.Add(RfcConfigParameters.MaxPoolSize, "10");
                //configParams.Add(RfcConfigParameters.IdleTimeout, "30");

                //测试版
                configParams = new RfcConfigParameters();
                // Name property is neccessary, otherwise, NonInvalidParameterException will be thrown
                configParams.Add(RfcConfigParameters.Name, "HYQ");
                configParams.Add(RfcConfigParameters.AppServerHost, "10.100.200.228");
                configParams.Add(RfcConfigParameters.SystemNumber, "00"); // instance number
                configParams.Add(RfcConfigParameters.SystemID, "HYQ");
                configParams.Add(RfcConfigParameters.User, "RFC_WW");
                configParams.Add(RfcConfigParameters.Password, "12345.Com");
                configParams.Add(RfcConfigParameters.Client, "900");
                configParams.Add(RfcConfigParameters.Language, "ZH");
                configParams.Add(RfcConfigParameters.PoolSize, "5");
                configParams.Add(RfcConfigParameters.MaxPoolSize, "10");
                configParams.Add(RfcConfigParameters.IdleTimeout, "30");

                return configParams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IRfcTable getSapStockInventory(B2B_Report_MB52Entity query)
        {   
            IRfcFunction invoke = rfcRepository.CreateFunction("ZFM_MM_MES_015"); //调用函数名 ZRFC_MARA_INFO
            invoke.SetValue("IV_WERKS", "2000"); //
            invoke.SetValue("IV_CUST_CODE", (query.CUST_CODE == null || query.CUST_CODE == "") ? "" : query.CUST_CODE.Replace("%", "*")); //
            invoke.SetValue("IV_FLAG", query.IV_FLAG); // 
            invoke.SetValue("IV_YZL", 1); //空 = 所有库存 1 = 非预指令库存 2 = 预指令库存
            IRfcStructure rfcstructSN = invoke.GetStructure("IS_INPUT");
            if (query.ORDER_TYPE != null && query.ORDER_TYPE.Equals("Z012"))
            {
                rfcstructSN.SetValue("KUNNR", query.KUNNR);//
            }
            rfcstructSN.SetValue("CUST_PARTIN", (query.CUST_PARTIN == null || query.CUST_PARTIN == "") ? query.CUST_PARTIN : query.CUST_PARTIN.Replace("%", "*"));//
            rfcstructSN.SetValue("CUST_PARTOUT", (query.CUST_PARTOUT == null || query.CUST_PARTOUT == "") ? query.CUST_PARTOUT : query.CUST_PARTOUT.Replace("%", "*"));//
            rfcstructSN.SetValue("PACKAGE_M", (query.PACKAGE_M == null || query.PACKAGE_M == "") ? query.PACKAGE_M : query.PACKAGE_M.Replace("%", "*"));//
            rfcstructSN.SetValue("ORDER_TYPE", query.ORDER_TYPE);//
            rfcstructSN.SetValue("ZZBZFS_DESC", query.ZZBZFS_DESC);//
            rfcstructSN.SetValue("WAFER_LOT_NO", "");//
            rfcstructSN.SetValue("CUST_PO", query.CUST_PO);//
            rfcstructSN.SetValue("BIN", query.BIN);//
            rfcstructSN.SetValue("BIN_CLASS", "");//
            rfcstructSN.SetValue("CUST_DEVICE", (query.CUST_DEVICE == null || query.CUST_DEVICE == "") ? query.CUST_DEVICE : query.CUST_DEVICE.Replace("%", "*"));//
            rfcstructSN.SetValue("DATECODE", query.DATECODE);//
            rfcstructSN.SetValue("ZZBIZ_TYPE", query.ZZBIZ_TYPE);//
            rfcstructSN.SetValue("ZSOBKZ", "");//'空 = ALL  B = 客户库存  A = 非限制
            rfcstructSN.SetValue("INBOX_NO", query.INBOX_NO);//
            rfcstructSN.SetValue("ZOUT_BOX", query.ZOUT_BOX);//
            invoke.SetValue("IS_INPUT", rfcstructSN); //
            IRfcTable stockTable = invoke.GetTable("IT_LGORT");

            String[] stock = null;
            if (query.LGORT != null && query.LGORT != "")
            {
                stock = query.LGORT.Split(',');
                for (int i = 0; i < stock.Length; i++)
                {
                    IRfcStructure import = rfcRepository.GetStructureMetadata("ZLGORT").CreateStructure();
                    import.SetValue("LGORT", stock[i]);
                    stockTable.Append(import);
                }
                invoke.SetValue("IT_LGORT", stockTable);
            }

            invoke.Invoke(sapConfig);
            IRfcTable rfcTable = invoke.GetTable("ET_OUT"); //获取内表

            return rfcTable;
        }

        public RfcDestination GetDestination()
        {
            RfcConfigParameters configParams = this.GetConfigParams();
            RfcDestination dest = RfcDestinationManager.GetDestination(configParams);

            return dest;
        }
        public void init()
        {
            if (configParams == null)
            {
                configParams = GetConfigParams();
            }
            if (this.rfcRepository == null)
            {
                sapConfig = RfcDestinationManager.GetDestination(configParams); //NCO3.0如果framework不是2.0此处会报错，跟系统64还32无关
                rfcRepository = sapConfig.Repository;
            }
        }
    }

}
