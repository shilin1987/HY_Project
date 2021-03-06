using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate
{
    /// <summary>
    /// 
    /// </summary>
    public class FormulaToCalculateService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="filedName"></param>
        /// <param name="f_userid"></param>
        /// <param name="monthTime"></param>
        /// <param name="timeFiled"></param>
        /// <returns></returns>
        public IEnumerable<DataStorageDTO> GetMonthList(string tabName,string filedName,string f_userid,string monthTime,string timeFiled)
        {
            try
            {
                var strSql = new StringBuilder();
                if ("Hy_hr_PostLevel".Equals(tabName))
                {
                    strSql = strSql.Append("SELECT ");
                    strSql.Append(@" 
                    hrp.");
                    strSql.Append("F_BasePay as Num ");
                    strSql.Append("FROM lr_base_user lbu ,Hy_hr_PostLevel hrp ");
                    strSql.Append("WHERE 1=1 and lbu.F_SalaryMethod = hrp.F_PostlevelCode ");
                    strSql.Append(" AND lbu.F_UserId = '" + f_userid + "' ");
                }
                else
                {
                    strSql.Append("SELECT ");
                    strSql.Append(@"
                    t.");
                    strSql.Append(filedName + " as Num ");
                    strSql.Append("  FROM " + tabName + " t ");
                    strSql.Append("  WHERE 1=1 and t.F_userid = '" + f_userid + "'");
                    strSql.Append(" AND " + timeFiled + " = '" + monthTime + "'");
                }

                return this.BaseRepository().FindList<DataStorageDTO>(strSql.ToString());
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
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="filedName"></param>
        /// <param name="userid"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DataStorageDTO> GetMonthList(string tabName, string filedName, string userid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.");
                strSql.Append(filedName + " as Num");
                strSql.Append("  FROM " + tabName + " t ");
                if ("Hr_personalStandards_file".Equals(tabName))
                {
                    strSql.Append("  WHERE 1=1 and t.F_ps02 = '" + userid + "' ");
                }
                else
                {
                    strSql.Append("  WHERE 1=1 and t.F_userid = '" + userid + "' ");
                }
   
                return this.BaseRepository().FindList<DataStorageDTO>(strSql.ToString());
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
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="filedName"></param>
        /// <param name="userid"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DataStorageDTO> GetGenMonthList(string tabName, string filedName, string userid, string v)
        {
            try
            {

                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.");
                strSql.Append(filedName + " as Num ");
        
                strSql.Append("  FROM Hy_hr_EverybodyStandardWage t left join (SELECT a.F_ItemId, b.F_Item SubItem, a.F_ID Id, a.F_Cost SubCost, a.F_IsFixedCost IsFixedCost, a.F_Formula Formula FROM Hy_hr_StandardWage aleft join Hy_hr_OperationItems b on a.F_ItemId = b.F_ItemId UNIONselect a.F_ItemId, b.F_Item SubItem, a.F_ID Id, a.F_Cost SubCost, 2 IsFixedCost, '' Formula from Hy_hr_EverybodyStandardWageSub a left join Hy_hr_OperationItems b on a.F_ItemId = b.F_ItemId) t1 on t.F_ItemId = t1.F_ItemId");
                strSql.Append("  WHERE 1=1 and t.F_userid = '" + userid + "' ");
                return this.BaseRepository().FindList<DataStorageDTO>(strSql.ToString());
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
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="filedName"></param>
        /// <param name="userid"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DataStorageDTO> GetGenRewardsMonthList(string tabName, string filedName, string userid, string v,string type)
        {
            try
            {

                var strSql = new StringBuilder();

                strSql.Append("SELECT ");
                strSql.Append(@" 
                s.");
                strSql.Append("F_Costmoney  as Num ");
                strSql.Append("FROM (");
                if ("通讯补贴".Equals(type))
                {
                    strSql.Append("SELECT  T.F_USERID,T.F_DateRewardPunishment,ISNULL(SUM(F_CommunicationAllowance),0) F_Costmoney ");
                }
                else
                {
                    //奖惩
                    strSql.Append("SELECT  T.F_USERID,T.F_DateRewardPunishment,ISNULL(SUM(F_Costmoney),0) F_Costmoney ");
                }
               // strSql.Append("SELECT  T.F_USERID,T.F_DateRewardPunishment,ISNULL(SUM(F_CommunicationAllowance),0) F_Costmoney ");
                strSql.Append("FROM (select ");
                strSql.Append("F_USERID,");
                strSql.Append("F_DateRewardPunishment,");
                if ("通讯补贴".Equals(type))
                {
                    strSql.Append("case when b.F_Item ='通讯补贴' then F_Cost else 0 end F_CommunicationAllowance ");
                }
                else
                {
                    //奖惩
                    strSql.Append("case when b.F_Item ='通讯补贴' then 0 else (case when a.F_RewardorPunishment = 1 then a.F_Cost else a.F_Cost*(-1) end)  end F_Costmoney ");
                }

                strSql.Append("from Hy_hr_RewardPunishment a, Hy_hr_OperationItems b where a.F_ItemId  = b.F_ItemId ");
                strSql.Append(") T GROUP BY F_USERID,F_DateRewardPunishment ) s ");
                strSql.Append(" WHERE 1=1 and  s.F_USERID = '"+ userid + "' AND s.F_DateRewardPunishment = '"+v+"' ");
                return this.BaseRepository().FindList<DataStorageDTO>(strSql.ToString());
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

        #region 获取数据库流水号编码

        /// <summary>
        /// funtion:返回数据库流水号
        /// author：cz
        /// time:2021-09-24
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="filedName">字段名</param>
        /// <param name="flowLength">数字流水码长度</param>
        /// <param name="head">抬头</param>
        /// <param name="db">数据库类型</param>
        /// <returns></returns>
        public IEnumerable<DataStoreNumDTO> getTableFileNum(string dbinfo,string tableName,string filedName,int flowLength,string head,string db)
        {
            try
            {
                DataStoreNumDTO ds = new DataStoreNumDTO();
                var strSql = new StringBuilder();
                string  da = DateTime.Now.ToString("yyyyMMdd");
                head = head + "-" + da;
                if ("sqlServer".Equals(db))
                {
                    strSql.Append("SELECT  '" + head + "' + RIGHT('000000' + convert(varchar(30), (CONVERT(int, ISNULL(RIGHT(MAX(t." + filedName + "), "+ flowLength + "), 0)) + 1)), "+ flowLength + ") as NUM ");
                    strSql.Append("  FROM " + tableName + " t ");
                    strSql.Append("  WHERE 1=1 and  "+ filedName + " like '"+head+"%' ");
                }
                else if ("mySql".Equals(db))
                {

                }
                else if("oracle".Equals(db))
                {

                }
                else
                {
 
                }
                if (string.IsNullOrEmpty(dbinfo))
                {
                    return this.BaseRepository().FindList<DataStoreNumDTO>(strSql.ToString());
                }
                else
                {
                    return this.BaseRepository(dbinfo).FindList<DataStoreNumDTO>(strSql.ToString());
                }
            
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
        #endregion
    }
}
