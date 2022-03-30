using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlyVegetablePriceSubsidy
{
    public class MonthlyVegetablePriceSubsidyService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MonthlyVegetablePriceSubsidyDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(" select  " +
                                " user_code,user_name,zccount,wccount,wc1count,yxcount,zccount*1+wccount*2+wc1count*2+yxcount*2 as countmoneymonth from  " +
                                " (select user_code ,user_name,sum(zccount) zccount,sum(wccount) wccount,sum(wc1count) wc1count,sum(yxcount) yxcount from ( " +
                                " (select user_code ,user_name ,'0' zccount ,'0' wccount ,'0' wc1count ,sum(cltype) yxcount from (select  user_code,user_name,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                                " (select Hr_user_attendance.oid,user_code ,user_name, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5 " +
                                " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                                  " ) uni2 left join  " +
                                " (select * from (select Person_Name, Person_No,Comsume_Date,cl,sum(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                                " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                                " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'00:00:00',108) and convert(varchar(10),'01:00:59',108)  " +
                                " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                                " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                                " as uni4 where  uni4.Person_No is not null group by user_code,user_name,cl  " +
                                " union all " +
                                " select  user_code,user_name,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                                " (select Hr_user_attendance.oid,user_code ,user_name, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5 " +
                                " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                                  " ) uni2 left join  " +
                                " (select * from (select Person_Name, Person_No,Comsume_Date,cl,sum(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                                " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                                " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'22:00:00',108) and convert(varchar(10),'23:59:59',108)  " +
                                " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                                " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                                " as uni4 where  uni4.Person_No is not null  group by user_code,user_name,cl ) " +
                                " as wcuni  group by user_code,user_name,cl) " +
                                " union all " +
                                " (select user_code,user_name,zccount,wccount,wc1count,'0' yxcount from  " +
                                " (select user_code,user_name,sum(isnull(zc,'0')) zccount,sum(isnull(wc,'0')) wccount,sum(isnull(wc1,'0')) wc1count,sum(isnull(yx,'0')) yxcount,sum(monthmoney) monthmoney  from  " +
                                " (select user_code,user_name,monthmoney,早餐 zc,午餐 wc,晚餐 wc1,夜宵 yx from  " +
                                 " ( select * from  (select user_code,user_name,cl,sum(mas_money) monthmoney,count(cl) cltype from  " +
                                " (select * from ( " +
                                " (select Hr_user_attendance.oid,user_code ,user_name, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5 " +
                                " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                                  " ) un1 left join  (select * from  " +
                                " ( select  Person_Name, Person_No,Comsume_Date,cl,sum(countmoney) countmoney, count(allcount) allcount  from (select Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date, cl,sum(Comsume_Sum) countmoney, count(cl) allcount from  " +
                                " (SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'早餐' cl " +
                                " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'06:01:00',108) and convert(varchar(10),'08:30:59',108)  " +
                                " union all " +
                                " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'午餐' cl " +
                                " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'10:30:00',108) and convert(varchar(10),'13:59:59',108)  " +
                                " union all " +
                                " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'晚餐' cl " +
                                " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'17:00:00',108) and convert(varchar(10),'21:00:00',108) " +
                                " ) as unicb " +
                                " group by Person_Name, Person_No,Comsume_Date,cl) c group by Person_Name, Person_No,Comsume_Date,cl) a, Hr_MealAllowanceStandard b where a.cl = b.mas_name  " +
                                " and countmoney -b.mas_limitminmoney >=0) un2 on un1.user_code = un2.Person_No and un1.rq = un2.Comsume_Date) " +
                                " ) as un3 where  un3.Person_No is not null   group by user_code,user_name,cl ) as un4 " +
                                " ) as un5 " +
                                " PIVOT(sum(cltype) FOR cl IN([早餐],[午餐],[晚餐],[夜宵])) AS pvt) as un6 group by user_code,user_name) as un7  " +
                                " ) )as enduni2 group by user_code ,user_name) as enduni3  " +
                                " order by user_code  ");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["userid"].IsEmpty())
                {
                    dp.Add("user_code", "%" + queryParam["user_code"].ToString() + "%", DbType.String);
                    strSql.Append(" AND user_code Like @user_code ");
                }
                if (!queryParam["user_name"].IsEmpty())
                {
                    dp.Add("user_name", "%" + queryParam["user_name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND user_name Like @user_name ");
                }
                /*
                if (!queryParam["shift_no"].IsEmpty())
                {
                    dp.Add("shift_no", "%" + queryParam["shift_no"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.shift_no Like @shift_no ");
                }*/
                strSql.Append(" order by user_code ");
                return this.BaseRepository().FindList<MonthlyVegetablePriceSubsidyDTO>(strSql.ToString(), dp, pagination);
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

    }
    #endregion
}
