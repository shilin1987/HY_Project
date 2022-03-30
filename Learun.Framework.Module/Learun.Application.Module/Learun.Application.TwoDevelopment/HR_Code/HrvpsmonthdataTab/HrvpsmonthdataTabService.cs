﻿using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.HrvpsmonthdataTab;
using Learun.DataBase.Repository;
using Learun.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期："+year+"-06-10 13:48
    /// 描 述：菜价补贴月数据
    /// </summary>
    public class HrvpsmonthdataTabService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HrVpsMonthDataDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                /**
                 * 
                 select      t.oid,
                t.user_code,
                t.user_name,
                t.deptid,
                t.deptname,
                t.monBreakfastTogether,
                t.monLunchTogether,
                t.monDinnerTogether,
                t.monSupperTogether,
                t.cost_centerno,
                t.cost_center,
                t.countMoney,
                t.yearno,
                t.monthno 
                 from (select dbo.[FunGetUUID32](NEWID()) oid,user_code,user_name,enduni6.deptid,enduni6.deptname,yearno,monthno,monBreakfastTogether,monLunchTogether,monDinnerTogether,monSupperTogether,Hr_center_cost.center_cost_code cost_centerno,Hr_center_cost.center_cost cost_center, countMoney from (
               select  user_code,user_name,deptid,deptname,yearno,monthno,zccount as monBreakfastTogether,wccount as monLunchTogether,wc1count as monDinnerTogether ,yxcount as monSupperTogether	,zccount*enduni5.zc+wccount*enduni5.wc+wc1count*enduni5.wc1+yxcount*enduni5.yx as countMoney,
                    '' cost_centerno,'' cost_center from 
                    (select user_code ,user_name,deptid,deptname,yearno,monthno,sum(zccount) zccount,sum(wccount) wccount,sum(wc1count) wc1count,sum(yxcount) yxcount from (
                    (select user_code ,user_name ,deptid,deptname,yearno,monthno,'0' zccount ,'0' wccount ,'0' wc1count ,sum(cltype) yxcount from (select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from 
                    (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.BC IS NOT NULL AND  Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5
                    and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit 
                      ) uni2 left join 
                    (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from (
                    SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl
                    FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'00:00:00',108) and convert(varchar(10),'01:00:59',108) 
                    ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name 
                    and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date)
                    as uni4 where  uni4.Person_No is not null group by user_code,user_name,cl,deptid,deptname,yearno,monthno
                    union all--再次合并
                    select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from 
                    (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where  Hr_user_attendance.BC IS NOT NULL AND Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5
                    and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit 
                      ) uni2 left join 
                    (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from (
                    SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl
                    FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'22:00:00',108) and convert(varchar(10),'23:59:59',108) 
                    ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name 
                    and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date)
                    as uni4 where  uni4.Person_No is not null  group by user_code,user_name,cl,deptid,deptname,yearno,monthno )
                    as wcuni  group by user_code,user_name,cl,deptid,deptname,yearno,monthno)
                    union all
                    --order by user_code
                    --再次合并
                    (select user_code,user_name,deptid,deptname,yearno,monthno,zccount,wccount,wc1count,'0' yxcount from 
                    (select user_code,user_name,deptid,deptname,yearno,monthno,sum(isnull(zc,'0')) zccount,sum(isnull(wc,'0')) wccount,sum(isnull(wc1,'0')) wc1count,sum(isnull(yx,'0')) yxcount,sum(monthmoney) monthmoney  from 
                    (select user_code,user_name,monthmoney,deptid,deptname,yearno,monthno,早餐 zc,午餐 wc,晚餐 wc1,夜宵 yx from 
                     ( select * from  (select user_code,user_name,cl,deptid,deptname,yearno,monthno,sum(mas_money) monthmoney,count(cl) cltype from 
                    (select * from (
                    (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.BC IS NOT NULL AND Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = 2021 and Hr_user_attendance.monthno = 5
                    and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit 
                      ) un1 left join  (select * from 
                    ( select  Person_Name, Person_No,Comsume_Date,cl,sum(countmoney) countmoney, count(allcount) allcount  from (select Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date, cl,max(Comsume_Sum) countmoney, count(cl) allcount from 
                    (SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'早餐' cl
                    FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'06:01:00',108) and convert(varchar(10),'08:30:59',108) 
                    union all
                    --午餐类别
                    SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'午餐' cl
                    FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'10:30:00',108) and convert(varchar(10),'13:59:59',108) 
                    union all
                    --晚餐类别
                    SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'晚餐' cl
                    FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = 2021 and MONTH(t.Comsume_Date) = 5 and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'17:00:00',108) and convert(varchar(10),'21:00:00',108)
                    ) as unicb
                    group by Person_Name, Person_No,Comsume_Date,cl) c group by Person_Name, Person_No,Comsume_Date,cl) a, Hr_MealAllowanceStandard b where a.cl = b.mas_name 
                    and countmoney -b.mas_limitminmoney >=0) un2 on un1.user_code = un2.Person_No and un1.rq = un2.Comsume_Date)
                    ) as un3 where  un3.Person_No is not null   group by user_code,user_name,cl,deptid,deptname,yearno,monthno ) as un4
                    ) as un5
                    PIVOT(sum(cltype) FOR cl IN([早餐],[午餐],[晚餐],[夜宵])) AS pvt) as un6 group by user_code,user_name,deptid,deptname,yearno,monthno) as un7 
                    ) )as enduni2 group by user_code ,user_name,deptid,deptname,yearno,monthno) as enduni3 ,(SELECT  sum(isnull(早餐,0)) zc,sum(isnull(午餐,0)) wc,sum(isnull(晚餐,0)) wc1,sum(isnull(夜宵,0)) yx
					FROM HYDatabase.dbo.Hr_MealAllowanceStandard  as c
					 PIVOT(sum(mas_money) FOR mas_name IN([早餐],[午餐],[晚餐],[夜宵])) as enduni4) as enduni5 ) as enduni6 left join Hr_center_cost on enduni6.deptid = Hr_center_cost.deptid 
           
                    ) as t  
                 * 
                 */
                var queryParam = queryJson.ToJObject();
                //初始化时间
                var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();
      
                if (queryParam["yearno"].IsEmpty() && queryParam["monthno"].IsEmpty())
                {
                   // month = month.Replace("0", "");
                    if (!month.Equals("1"))
                    {
                        month = Convert.ToInt32(month) - 1 + "";
                    }
                    else
                    {
                        month = "12";
                        year = Convert.ToInt32(year) - 1 + "";
                    }
                }
                else
                {
                    if(!queryParam["yearno"].IsEmpty() && !queryParam["monthno"].IsEmpty())
                    {
                        year = queryParam["yearno"] +"";
                        month = queryParam["monthno"] + "";

                    }
                    else
                    {
                        if (!month.Equals("1"))
                        {
                            month = Convert.ToInt32(month) - 1 + "";
                        }
                        else
                        {
                            month = "12";
                            year = Convert.ToInt32(year) - 1 + "";
                        }
                    }
                }
   
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.oid,
                t.user_code,
                t.user_name,
                t.deptid,
                t.deptname,
                t.monBreakfastTogether,
                t.monLunchTogether,
                t.monDinnerTogether,
                t.monSupperTogether,
                t.cost_centerno,
                t.cost_center,
                t.countMoney,
                t.yearno,
                t.monthno
                ");
                strSql.Append(" from (select dbo.[FunGetUUID32](NEWID()) oid,user_code,user_name,enduni6.deptid,enduni6.deptname,yearno,monthno,monBreakfastTogether,monLunchTogether,monDinnerTogether,monSupperTogether,Hr_center_cost.center_cost_code cost_centerno,Hr_center_cost.center_cost cost_center, countMoney from ( " +
                    " select  user_code,user_name,deptid,deptname,yearno,monthno,zccount as monBreakfastTogether,wccount as monLunchTogether,wc1count as monDinnerTogether ,yxcount as monSupperTogether   ,zccount*enduni5.zc+wccount*enduni5.wc+wc1count*enduni5.wc1+yxcount*enduni5.yx as countMoney, " +
                    " '' cost_centerno,'' cost_center from  " +
                    " (select user_code ,user_name,deptid,deptname,yearno,monthno,sum(zccount) zccount,sum(wccount) wccount,sum(wc1count) wc1count,sum(yxcount) yxcount from ( " +
                    " (select user_code ,user_name ,deptid,deptname,yearno,monthno,'0' zccount ,'0' wccount ,'0' wc1count ,sum(cltype) yxcount from (select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = "+month+" " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) uni2 left join  " +
                    " (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                    " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'00:00:00',108) and convert(varchar(10),'01:00:59',108)  " +
                    " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                    " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                    " as uni4 where  uni4.Person_No is not null group by user_code,user_name,cl,deptid,deptname,yearno,monthno " +
                    " union all " +
                    " select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = " + month + " " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) uni2 left join  " +
                    " (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                    " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'22:00:00',108) and convert(varchar(10),'23:59:59',108)  " +
                    " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                    " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                    " as uni4 where  uni4.Person_No is not null  group by user_code,user_name,cl,deptid,deptname,yearno,monthno ) " +
                    " as wcuni  group by user_code,user_name,cl,deptid,deptname,yearno,monthno) " +
                    " union all " +
                    " (select user_code,user_name,deptid,deptname,yearno,monthno,zccount,wccount,wc1count,'0' yxcount from  " +
                    " (select user_code,user_name,deptid,deptname,yearno,monthno,sum(isnull(zc,'0')) zccount,sum(isnull(wc,'0')) wccount,sum(isnull(wc1,'0')) wc1count,sum(isnull(yx,'0')) yxcount,sum(monthmoney) monthmoney  from  " +
                    " (select user_code,user_name,monthmoney,deptid,deptname,yearno,monthno,早餐 zc,午餐 wc,晚餐 wc1,夜宵 yx from  " +
                     " ( select * from  (select user_code,user_name,cl,deptid,deptname,yearno,monthno,sum(mas_money) monthmoney,count(cl) cltype from  " +
                    " (select * from ( " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = " + month + " " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) un1 left join  (select * from  " +
                    " ( select  Person_Name, Person_No,Comsume_Date,cl,sum(countmoney) countmoney, count(allcount) allcount  from (select Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date, cl,max(Comsume_Sum) countmoney, count(cl) allcount from  " +
                    " (SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'早餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'06:01:00',108) and convert(varchar(10),'08:30:59',108)  " +
                    " union all " +
                    " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'午餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'10:30:00',108) and convert(varchar(10),'13:59:59',108)  " +
                    " union all " +
                    " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'晚餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'17:00:00',108) and convert(varchar(10),'21:00:00',108) " +
                    " ) as unicb " +
                    " group by Person_Name, Person_No,Comsume_Date,cl) c group by Person_Name, Person_No,Comsume_Date,cl) a, Hr_MealAllowanceStandard b where a.cl = b.mas_name  " +
                    " and countmoney -b.mas_limitminmoney >=0) un2 on un1.user_code = un2.Person_No and un1.rq = un2.Comsume_Date) " +
                    " ) as un3 where  un3.Person_No is not null   group by user_code,user_name,cl,deptid,deptname,yearno,monthno ) as un4 " +
                    " ) as un5 " +
                    " PIVOT(sum(cltype) FOR cl IN([早餐],[午餐],[晚餐],[夜宵])) AS pvt) as un6 group by user_code,user_name,deptid,deptname,yearno,monthno) as un7  " +
                    " ) )as enduni2 group by user_code ,user_name,deptid,deptname,yearno,monthno) as enduni3 ,(SELECT  sum(isnull(早餐,0)) zc,sum(isnull(午餐,0)) wc,sum(isnull(晚餐,0)) wc1,sum(isnull(夜宵,0)) yx " +
                    " FROM HYDatabase.dbo.Hr_MealAllowanceStandard  as c " +
                     " PIVOT(sum(mas_money) FOR mas_name IN([早餐],[午餐],[晚餐],[夜宵])) as enduni4) as enduni5 ) as enduni6 left join Hr_center_cost on enduni6.deptid = Hr_center_cost.deptid   " +
                    " ) as t ");
                strSql.Append("  WHERE 1=1 ");
      
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["user_code"].IsEmpty())
                {
                    dp.Add("user_code", "%" + queryParam["user_code"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.user_code Like @user_code ");
                }
                if (!queryParam["user_name"].IsEmpty())
                {
                    dp.Add("user_name", "%" + queryParam["user_name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.user_name Like @user_name ");
                }
                if (!queryParam["deptid"].IsEmpty())
                {
                    dp.Add("deptid", "%" + queryParam["deptid"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.deptid Like @deptid ");
                }
                if (!queryParam["deptname"].IsEmpty())
                {
                    dp.Add("deptname", "%" + queryParam["deptname"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.deptname Like @deptname ");
                }
                if (!queryParam["cost_centerno"].IsEmpty())
                {
                    dp.Add("cost_centerno", "%" + queryParam["cost_centerno"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.cost_centerno Like @cost_centerno ");
                }
                if (!queryParam["cost_center"].IsEmpty())
                {
                    dp.Add("cost_center", "%" + queryParam["cost_center"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.cost_center Like @cost_center ");
                }
                if (!queryParam["yearno"].IsEmpty())
                {
                    dp.Add("yearno", "%" + queryParam["yearno"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.yearno Like @yearno ");
                }
                if (!queryParam["monthno"].IsEmpty())
                {
                    dp.Add("monthno", "%" + queryParam["monthno"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.monthno Like @monthno ");
                }
                //strSql.Append("  order by deptid ");
                return this.BaseRepository().FindList<HrVpsMonthDataDTO>(strSql.ToString(),dp, pagination);
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

        /// <summary>
        /// 获取Hr_vpsmonthdata表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_vpsmonthdataEntity GetHr_vpsmonthdataEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hr_vpsmonthdataEntity>(keyValue);
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

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<Hr_vpsmonthdataEntity>(t=>t.oid == keyValue);
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
        public DataTable GetExportList(Pagination pagination, string queryJson)
        {
            try
            {
                JObject queryParam = new JObject();
                if (queryJson!=null && queryJson !="null")
                {
                    queryParam = queryJson.ToJObject();
                }
       
                
            
                var strSql = new StringBuilder();
                var year = DateTime.Now.Year.ToString();
                var month = (DateTime.Now.Month - 1).ToString();
                //表示1月需要修改
                if (DateTime.Now.Month == 1)
                {
                    month = 12 + "";
                    year = Convert.ToInt32(year) - 1 + "";
                }
                if (pagination != null && queryJson != null)
                {
                    if (queryParam["yearno"].IsEmpty() && queryParam["monthno"].IsEmpty())
                    {
                        // month = month.Replace("0", "");
                        if (DateTime.Now.Month == 1)
                        {
                            month = 12 + "";
                            year = Convert.ToInt32(year) - 1 + "";
                        }
                    }
                    else
                    {
                        if (!queryParam["yearno"].IsEmpty() && !queryParam["monthno"].IsEmpty())
                        {
                            year = queryParam["yearno"].ToString();
                            month = queryParam["monthno"].ToString();
                        }
                    }
                }

                strSql.Append("SELECT ");
                strSql.Append(@"
                t.oid,
                t.user_code,
                t.user_name,
                t.deptid,
                t.deptname,
                t.monBreakfastTogether,
                t.monLunchTogether,
                t.monDinnerTogether,
                t.monSupperTogether,
                t.cost_centerno,
                t.cost_center,
                t.countMoney,
                t.yearno,
                t.monthno
                ");
                strSql.Append(" from (select dbo.[FunGetUUID32](NEWID()) oid,user_code,user_name,enduni6.deptid,enduni6.deptname,yearno,monthno,monBreakfastTogether,monLunchTogether,monDinnerTogether,monSupperTogether,Hr_center_cost.center_cost_code cost_centerno,Hr_center_cost.center_cost cost_center, countMoney from ( " +
                    " select  user_code,user_name,deptid,deptname,yearno,monthno,zccount as monBreakfastTogether,wccount as monLunchTogether,wc1count as monDinnerTogether ,yxcount as monSupperTogether   ,zccount*enduni5.zc+wccount*enduni5.wc+wc1count*enduni5.wc1+yxcount*enduni5.yx as countMoney, " +
                    " '' cost_centerno,'' cost_center from  " +
                    " (select user_code ,user_name,deptid,deptname,yearno,monthno,sum(zccount) zccount,sum(wccount) wccount,sum(wc1count) wc1count,sum(yxcount) yxcount from ( " +
                    " (select user_code ,user_name ,deptid,deptname,yearno,monthno,'0' zccount ,'0' wccount ,'0' wc1count ,sum(cltype) yxcount from (select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = " + month + " " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) uni2 left join  " +
                    " (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                    " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'00:00:00',108) and convert(varchar(10),'01:00:59',108)  " +
                    " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                    " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                    " as uni4 where  uni4.Person_No is not null group by user_code,user_name,cl,deptid,deptname,yearno,monthno " +
                    " union all " +
                    " select  user_code,user_name,deptid,deptname,yearno,monthno,cl,sum(mas_money) monthmoney,count(cl) cltype from (select * from  " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = " + month + " " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) uni2 left join  " +
                    " (select * from (select Person_Name, Person_No,Comsume_Date,cl,max(Comsume_Sum) countmoney, count(cl) allcount from ( " +
                    " SELECT  Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date,Comsume_Sum,'夜宵' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'22:00:00',108) and convert(varchar(10),'23:59:59',108)  " +
                    " ) as uni1 group by Person_Name, Person_No,Comsume_Date,cl) as a1 ,Hr_MealAllowanceStandard b1 where a1.cl = b1.mas_name  " +
                    " and a1.countmoney -b1.mas_limitminmoney >=0) uni3 on uni2.user_code = uni3.Person_No and uni2.rq = uni3.Comsume_Date) " +
                    " as uni4 where  uni4.Person_No is not null  group by user_code,user_name,cl,deptid,deptname,yearno,monthno ) " +
                    " as wcuni  group by user_code,user_name,cl,deptid,deptname,yearno,monthno) " +
                    " union all " +
                    " (select user_code,user_name,deptid,deptname,yearno,monthno,zccount,wccount,wc1count,'0' yxcount from  " +
                    " (select user_code,user_name,deptid,deptname,yearno,monthno,sum(isnull(zc,'0')) zccount,sum(isnull(wc,'0')) wccount,sum(isnull(wc1,'0')) wc1count,sum(isnull(yx,'0')) yxcount,sum(monthmoney) monthmoney  from  " +
                    " (select user_code,user_name,monthmoney,deptid,deptname,yearno,monthno,早餐 zc,午餐 wc,晚餐 wc1,夜宵 yx from  " +
                     " ( select * from  (select user_code,user_name,cl,deptid,deptname,yearno,monthno,sum(mas_money) monthmoney,count(cl) cltype from  " +
                    " (select * from ( " +
                    " (select Hr_user_attendance.oid,user_code ,user_name,deptid,deptname,yearno,monthno, CONVERT(varchar(12) , rq, 111 ) rq ,bc,Hr_SHIFTTIMETAB_file.shift_name,chaiq01 + cqgs countime, timelimit,attendancesystem,shift_type from Hr_user_attendance,Hr_SHIFTTIMETAB_file where Hr_user_attendance.bc =Hr_SHIFTTIMETAB_file.shift_no  and Hr_user_attendance.yearno  = " + year + " and Hr_user_attendance.monthno = " + month + " " +
                    " and chaiq01 + cqgs >= Hr_SHIFTTIMETAB_file.timelimit  " +
                      " ) un1 left join  (select * from  " +
                    " ( select  Person_Name, Person_No,Comsume_Date,cl,sum(countmoney) countmoney, count(allcount) allcount  from (select Person_Name, Person_No, CONVERT(varchar(12) , Comsume_Date, 111 ) Comsume_Date, cl,max(Comsume_Sum) countmoney, count(cl) allcount from  " +
                    " (SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'早餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'06:01:00',108) and convert(varchar(10),'08:30:59',108)  " +
                    " union all " +
                    " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'午餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'10:30:00',108) and convert(varchar(10),'13:59:59',108)  " +
                    " union all " +
                    " SELECT Person_Name, Person_No, Card_No, Tabie_Name, ZK_Amount, Copies, Comsume_Date, Comsume_Sum, Discount_Sum, Serial, EnterpriseNo, IsCorrect, Extend1, Extend3,'晚餐' cl " +
                    " FROM HYDatabase.dbo.hr_Monthlyconsumptiondata t where  year(t.Comsume_Date) = " + year + " and MONTH(t.Comsume_Date) = " + month + " and  t.Tabie_ID in ('000001','000003','000005','000006','000007','000015') and convert(varchar(10),t.Comsume_Date,108) between convert(varchar(10),'17:00:00',108) and convert(varchar(10),'21:00:00',108) " +
                    " ) as unicb " +
                    " group by Person_Name, Person_No,Comsume_Date,cl) c group by Person_Name, Person_No,Comsume_Date,cl) a, Hr_MealAllowanceStandard b where a.cl = b.mas_name  " +
                    " and countmoney -b.mas_limitminmoney >=0) un2 on un1.user_code = un2.Person_No and un1.rq = un2.Comsume_Date) " +
                    " ) as un3 where  un3.Person_No is not null   group by user_code,user_name,cl,deptid,deptname,yearno,monthno ) as un4 " +
                    " ) as un5 " +
                    " PIVOT(sum(cltype) FOR cl IN([早餐],[午餐],[晚餐],[夜宵])) AS pvt) as un6 group by user_code,user_name,deptid,deptname,yearno,monthno) as un7  " +
                    " ) )as enduni2 group by user_code ,user_name,deptid,deptname,yearno,monthno) as enduni3 ,(SELECT  sum(isnull(早餐,0)) zc,sum(isnull(午餐,0)) wc,sum(isnull(晚餐,0)) wc1,sum(isnull(夜宵,0)) yx " +
                    " FROM HYDatabase.dbo.Hr_MealAllowanceStandard  as c " +
                     " PIVOT(sum(mas_money) FOR mas_name IN([早餐],[午餐],[晚餐],[夜宵])) as enduni4) as enduni5 ) as enduni6 left join Hr_center_cost on enduni6.deptid = Hr_center_cost.deptid   " +
                    " ) as t ");
                strSql.Append("  WHERE 1=1 ");
                return this.BaseRepository().FindTable(strSql.ToString());
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
