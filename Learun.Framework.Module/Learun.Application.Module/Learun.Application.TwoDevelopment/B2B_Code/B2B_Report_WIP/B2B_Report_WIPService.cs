using Dapper;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_WIP;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.B2B_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-03-01 16:38
    /// 描 述：WIP产品报表
    /// </summary>
    public class B2B_Report_WIPService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_WIPEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"SELECT ");
                strSql.Append($"t.CUSTOMER,t.CUST_PO,t.PACKAGE_CODE,t.CUSTPARTIN,t.LOTTYPE,t.PART_ID,t.PARENTID,t.LOADING_DATE2, ");
                strSql.Append($"t.TOTAL,t.LOADING_QTY,t.PDS,t.IQC002,t.DSW010,t.DAT020,t.WBD030,t.PDM,t.MLD040,t.PMC050,t.PLT060, ");
                strSql.Append($"t.FLG070,t.TNF080,t.AFN090,t.XFE_TEST,t.TST100,t.FVI,t.PACKING,t.OUT_PACKING,t.CUSTPARTOUT,t.CUST_UNIQUE_ID, ");
                strSql.Append($"t.CUSTDEVICE,t.WAFERLOTNO,t.DATECODE,t.LOADING_DATE,t.FLG,t.ASSEMBLYGRADE,t.po_line_no,t.delivery_date ");
                strSql.Append($"  FROM V_HYME_CUST_WIP_RPT_TB t ");
                strSql.Append($"  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                if (!queryParam["customer"].IsEmpty())
                {
                    strSql.Append($" and t.customer = '{queryParam["customer"]}'");
                }
                if (!queryParam["cust_po"].IsEmpty())
                {
                    strSql.Append($" and t.cust_po like '%{queryParam["cust_po"]}%'");
                }
                if (!queryParam["custpartin"].IsEmpty())
                {
                    strSql.Append($" and t.custpartin like '%{queryParam["custpartin"]}%'");
                }
                if (!queryParam["package_code"].IsEmpty())
                {
                    strSql.Append($" and t.package_code like '%{queryParam["package_code"]}%'");
                }
                if (!queryParam["custdevice"].IsEmpty())
                {
                    strSql.Append($" and t.custdevice like '%{queryParam["custdevice"]}%'");
                }
                if (!queryParam["waferlotno"].IsEmpty())
                {
                    strSql.Append($" and t.waferlotno like '%{queryParam["waferlotno"]}%'");
                }

                return this.BaseRepository("B2BDatabase").FindList<B2B_Report_WIPEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        public DataTable getexecl(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"SELECT ");
                strSql.Append($"t.CUSTOMER,t.CUST_PO,t.PACKAGE_CODE,t.CUSTPARTIN,t.LOTTYPE,t.PART_ID,t.PARENTID,t.LOADING_DATE2, ");
                strSql.Append($"t.TOTAL,t.LOADING_QTY,t.PDS,t.IQC002,t.DSW010,t.DAT020,t.WBD030,t.PDM,t.MLD040,t.PMC050,t.PLT060, ");
                strSql.Append($"t.FLG070,t.TNF080,t.AFN090,t.XFE_TEST,t.TST100,t.FVI,t.PACKING,t.OUT_PACKING,t.CUSTPARTOUT,t.CUST_UNIQUE_ID, ");
                strSql.Append($"t.CUSTDEVICE,t.WAFERLOTNO,t.DATECODE,t.LOADING_DATE,t.FLG,t.ASSEMBLYGRADE,t.po_line_no,t.delivery_date ");
                strSql.Append($"  FROM V_HYME_CUST_WIP_RPT_TB t ");
                strSql.Append($"  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                if (!queryParam["customer"].IsEmpty())
                {
                    strSql.Append($" and t.customer = '{queryParam["customer"]}'");
                }
                if (!queryParam["cust_po"].IsEmpty())
                {
                    strSql.Append($" and t.cust_po like '%{queryParam["cust_po"]}%'");
                }
                if (!queryParam["custpartin"].IsEmpty())
                {
                    strSql.Append($" and t.custpartin like '%{queryParam["custpartin"]}%'");
                }
                if (!queryParam["package_code"].IsEmpty())
                {
                    strSql.Append($" and t.package_code like '%{queryParam["package_code"]}%'");
                }
                if (!queryParam["custdevice"].IsEmpty())
                {
                    strSql.Append($" and t.custdevice like '%{queryParam["custdevice"]}%'");
                }
                if (!queryParam["waferlotno"].IsEmpty())
                {
                    strSql.Append($" and t.waferlotno like '%{queryParam["waferlotno"]}%'");
                }

                //return this.BaseRepository("B2BDatabase").FindList<B2B_Report_WIPEntity>(strSql.ToString());

                return this.BaseRepository("B2BDatabase").FindTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        #endregion

    }
}
