using Dapper;
using Learun.Application.TwoDevelopment.B2B_Code.B2B_Report_WaferStock;
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
    /// 日 期：2022-02-25 17:20
    /// 描 述：晶圆库存报表
    /// </summary>
    public class B2B_Report_WaferStockService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<B2B_Report_WaferStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append($"SELECT ");
                strSql.Append($"r.STATUS,r.CUST_CODE,r.CUST_DEVICE,r.DEVICE,r.PART_ID,r.CUSTLOTID,r.START_QTY,r.CURRENT_QTY,r.START_WAFER, ");
                strSql.Append($"r.CURRENT_WAFER,r.START_DATE,r.START_DATE1,r.START_DATE1,r.LOT_STATUS,r.WAFER_NO,r.COMP_SUB_QTY,r.BIN_QTY, ");
                strSql.Append($"r.WAFER_LOCATION,r.PARAM_8,r.PARAM_39,r.PARAM_36,r.PARAM_37,r.PARAM_35,r.PO_PARAM_17,r.LOTID,r.WAFER_AREA, ");
                strSql.Append($"r.LOT_TYPE,r.REMARK,r.REMARK2   ");
                strSql.Append($"  FROM SLRS_WAFER_STOCK  r  ");
                strSql.Append($"  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    strSql.Append($" AND to_char(r.START_DATE1,'yyyy/MM/dd hh:mm:ss') >= '{queryParam["StartTime"].ToDate().ToString("G")}' AND to_char(r.START_DATE1,'yyyy/MM/dd hh:mm:ss')<='{queryParam["EndTime"].ToDate().ToString("G")}'");
                }
                if (!queryParam["CUST_CODE"].IsEmpty())
                {
                    
                    strSql.Append($" AND r.CUST_CODE ='{queryParam["CUST_CODE"]}'");
                }
                if (!queryParam["DEVICE"].IsEmpty())
                {

                    strSql.Append($" AND r.DEVICE  like '%{queryParam["DEVICE"]}%'");
                }
                if (!queryParam["CUSTLOTID"].IsEmpty())
                {

                    strSql.Append($" AND r.CUSTLOTID like '%{queryParam["CUSTLOTID"]}%'");
                }
                return this.BaseRepository("B2BDatabase").FindList<B2B_Report_WaferStockEntity>(strSql.ToString());
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
