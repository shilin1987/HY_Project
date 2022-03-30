using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.FSConsumptionRecord;
using Learun.Application.TwoDevelopment.HY_Logistics;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-10 15:35
    /// 描 述：人员消费记录查询
    /// </summary>
    public class FSConsumptionRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<hr_MonthlyconsumptiondataEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.oid,
                t.Person_No,
                t.Person_Name,
                t.Tabie_ID,
                t.Tabie_Name,
                t.Comsume_Date,
                t.Comsume_Sum
                ");
                strSql.Append("  FROM hr_Monthlyconsumptiondata t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.Comsume_Date >= @startTime AND t.Comsume_Date <= @endTime ) ");
                }
                if (!queryParam["Person_No"].IsEmpty())
                {
                    dp.Add("Person_No", "%" + queryParam["Person_No"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.Person_No Like @Person_No ");
                }
                if (!queryParam["Person_Name"].IsEmpty())
                {
                    dp.Add("Person_Name", "%" + queryParam["Person_Name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.Person_Name Like @Person_Name ");
                }
                if (!queryParam["Comsume_Sum"].IsEmpty())
                {
                    dp.Add("Comsume_Sum", "%" + queryParam["Comsume_Sum"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.Comsume_Sum Like @Comsume_Sum ");
                }
                return this.BaseRepository().FindList<hr_MonthlyconsumptiondataEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取正月数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthConsumptionPersonList(string userId, string year, string month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                a.Person_No,
                a.year,
                a.month,
                a.Comsume_Date,
                a.money countMoney
                ");
                strSql.Append("  from (select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Date ,Comsume_Sum money ");
                strSql.Append("  from hr_Monthlyconsumptiondata With (NoLock) where  Tabie_No in ( ");
                strSql.Append("  select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1) ");
                strSql.Append("  )  a ");
                strSql.Append("  where 1=1  and Person_No = '" + userId + "' and  year ='" + year + "' and month ='" + month + "' ");

                return this.BaseRepository().FindList<FSRecordsOfConsumptionDTO>(strSql.ToString());
            }
            catch(Exception ex)
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
        /// 获取整月消费记录
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthConsumptionList(string year, string month)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                a.Person_No,
                a.year,
                a.month,
                a.Comsume_Date,
                a.money countMoney
                ");
                strSql.Append("  from (select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Date,Comsume_Sum money ");
                strSql.Append("  from hr_Monthlyconsumptiondata With (NoLock) where  Tabie_No in ( ");
                strSql.Append("  select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1) ");
                strSql.Append("  )  a ");
                strSql.Append("  where 1=1   and  year ='" + year + "' and month ='" + month + "' ");

                return this.BaseRepository().FindList<FSRecordsOfConsumptionDTO>(strSql.ToString());
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
        /// 查询对应的消费记录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="rq"></param>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsOfConsumptionDTO> GetOneMonthlyconsumptiondataEntity(string userid, string year, string month, string rq, Hr_MealAllowanceStandardEntity entity, string type)
        {
            try
            {
                string []b =  rq.Split(' ');
                if (b.Length > 0)
                {
                    rq = b[0];
                }
                string starTime = "";
                string endTime = "";
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                a.Person_No,
                a.year,
                a.month,
                sum(a.money) countMoney
                ");

                if ("4".Equals(type))
                {
                    //夜宵拼接开始时间和结束时间 //rq2021-12-01
                    string nextDay = Time.GetNextDayTime(rq);
                    starTime = rq + " " + entity.startime;
                    endTime = nextDay + " " + entity.endtime;
                }
                else
                {
                    //早餐，午餐，晚餐
                    starTime = rq + " " + entity.startime;
                    endTime = rq + " " + entity.endtime;
                }
                strSql.Append("  from (select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Sum money ");
                strSql.Append("  from hr_Monthlyconsumptiondata With (NoLock) where  Comsume_Date BETWEEN CONVERT(datetime, '" + starTime + "', 20) and  ");
                strSql.Append("  CONVERT(datetime, '"+ endTime + "', 20) and Tabie_No in ( ");
                strSql.Append("  select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1) ");
                strSql.Append("  )  a ");
                strSql.Append("  where 1=1  and Person_No = '"+ userid + "' and  year ='"+year+ "' and month ='"+ month + "' ");
                strSql.Append(" group by Person_No,year,month ");
                return this.BaseRepository().FindList<FSRecordsOfConsumptionDTO>(strSql.ToString());
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
        /// 查询对应的消费记录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="rq"></param>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<FSRecordsConsumptionDTO> GetMonthlyconsumptiondataList(string userId,string rq,string breakfastBegan, string breakfastEnd,
            string LunchBegan, string LunchEnd, string dinnerBegan ,string dinnerEnd,string nightBegan ,string nightEnd)
        {
            try
            {
                string[] b = rq.Split(' ');
                if (b.Length > 0)
                {
                    rq = b[0];
                }
                var strSql = new StringBuilder();
                //夜宵拼接开始时间和结束时间 //rq2021-12-01
                string nextDay = Time.GetNextDayTime(rq);
                nightBegan = rq + " " + nightBegan;
                nightEnd = nextDay + " " + nightEnd;
                
                //早餐，午餐，晚餐
                breakfastBegan = rq + " " + breakfastBegan;
                breakfastEnd = rq + " " + breakfastEnd;
                LunchBegan = rq + " " + LunchBegan;
                LunchEnd = rq + " " + LunchEnd;
                dinnerBegan = rq + " " + dinnerBegan;
                dinnerEnd = rq + " " + dinnerEnd;

                strSql.Append(" select Person_No ,year,month zc,wc,wcc,yx from  ");
                strSql.Append(" ( ");
                strSql.Append(" SELECT ");
                strSql.Append(" a.Person_No, ");
                strSql.Append(" a.year, ");
                strSql.Append(" a.month, ");
                strSql.Append(" 'yx' 'type', ");
                strSql.Append(" sum(a.money) countyx ");
                strSql.Append(" from ( select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Sum money  ");
                strSql.Append(" from hr_Monthlyconsumptiondata With (NoLock) where  Comsume_Date BETWEEN CONVERT(datetime, '"+ nightBegan + "', 20) and   ");
                strSql.Append(" CONVERT(datetime, '"+ nightEnd + "', 20) and Tabie_No in (  ");
                strSql.Append(" select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1)  ");
                strSql.Append(" )  as a  group by Person_No,year,month  ");
                strSql.Append(" union all ");
                strSql.Append(" SELECT ");
                strSql.Append(" a.Person_No, ");
                strSql.Append(" a.year, ");
                strSql.Append(" a.month, ");
                strSql.Append(" 'zc' 'type', ");
                strSql.Append(" sum(a.money) countzc ");
                strSql.Append(" from ( select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Sum money  ");
                strSql.Append(" from hr_Monthlyconsumptiondata With (NoLock) where  Comsume_Date BETWEEN CONVERT(datetime, '"+ breakfastBegan + "', 20) and   ");
                strSql.Append(" CONVERT(datetime, '"+ breakfastEnd + "', 20) and Tabie_No in (  ");
                strSql.Append(" select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1)  ");
                strSql.Append(" )  as a  group by Person_No,year,month  ");
                strSql.Append(" union all ");
                strSql.Append(" SELECT ");
                strSql.Append(" a.Person_No, ");
                strSql.Append(" a.year, ");
                strSql.Append(" a.month, ");
                strSql.Append(" 'wc' 'type', ");
                strSql.Append(" sum(a.money) countwc ");
                strSql.Append(" from ( select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Sum money  ");
                strSql.Append(" from hr_Monthlyconsumptiondata With (NoLock) where  Comsume_Date BETWEEN CONVERT(datetime, '"+ LunchBegan + "', 20) and   ");
                strSql.Append(" CONVERT(datetime, '"+ LunchEnd + "', 20) and Tabie_No in (  ");
                strSql.Append(" select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1)  ");
                strSql.Append(" )  as a  group by Person_No,year,month  ");
                strSql.Append(" union all ");
                strSql.Append(" SELECT ");
                strSql.Append(" a.Person_No, ");
                strSql.Append(" a.year, ");
                strSql.Append(" a.month, ");
                strSql.Append(" 'wcc' 'type', ");
                strSql.Append(" sum(a.money) countwcc ");
                strSql.Append(" from ( select Person_No , year(Comsume_Date) year,month(Comsume_Date) month,Comsume_Sum money  ");
                strSql.Append(" from hr_Monthlyconsumptiondata With (NoLock) where  Comsume_Date BETWEEN CONVERT(datetime, '"+ dinnerBegan + "', 20) and   ");
                strSql.Append(" CONVERT(datetime, '"+ dinnerEnd + "', 20) and Tabie_No in (  ");
                strSql.Append(" select F_CounterNo from FS_CounterTheWindowsill where F_TheValidity = 1)  ");
                strSql.Append(" )  as a  group by Person_No,year,month  ");
                strSql.Append(" ) as nu1  PIVOT(sum(countyx) FOR nu1.type IN([zc],[wc],[wcc],[yx])) AS T  ");
                strSql.Append(" where Person_No = '"+userId+"' ");
                return this.BaseRepository().FindList<FSRecordsConsumptionDTO>(strSql.ToString());
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
        /// 获取hr_Monthlyconsumptiondata表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public hr_MonthlyconsumptiondataEntity Gethr_MonthlyconsumptiondataEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<hr_MonthlyconsumptiondataEntity>(keyValue);
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
                this.BaseRepository().Delete<hr_MonthlyconsumptiondataEntity>(t=>t.oid == keyValue);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, hr_MonthlyconsumptiondataEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
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
