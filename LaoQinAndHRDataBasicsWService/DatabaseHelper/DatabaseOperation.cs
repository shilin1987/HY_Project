using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Util.DataTableListMutualTransformation;

namespace LaoQinAndHRDataBasicsWService.DatabaseHelper
{
    /// <summary>
    /// sqlserver数据库批量新增修改类
    /// </summary>
    public static class DatabaseOperation
    {
        #region 数据库连接字符串
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly string ConnString = ConfigurationManager.ConnectionStrings["HRSqlConnection"].ConnectionString;
        #endregion

        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        private static DataTable ExecuteDataTable(SqlConnection conn, string cmdText)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                return ExecuteQuery(conn, cmdText);
            }
        }

        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(SqlConnection conn, string cmdText)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                    sdr.Close();
                    sdr.Dispose();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            return dt;
        }


        #region SqlBulkCopy方式批量新增数据
        /// <summary>
        /// SqlBulkCopy方式批量新增数据
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="modelList">实体类集合</param>
        /// <param name="destinationTableName">目标表名</param>
        /// <param name="removeColumns">移除的字段列集合</param>
        /// <param name="bulkCopyTimeout">超时时间</param>
        public static void BulkCopy<T>(List<T> modelList, string destinationTableName, List<string> removeColumns = null, int? bulkCopyTimeout = null)
        {
            if (string.IsNullOrEmpty(destinationTableName))
            {
                destinationTableName = typeof(T).Name;
            }
            var dt = MutualTransformation.ToDataTable(modelList);
            if (removeColumns != null && removeColumns.Count > 0)
            {
                foreach (var item in removeColumns)
                {
                    dt.Columns.Remove(item);
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (var sbc = new SqlBulkCopy(conn))
                {
                    sbc.BatchSize = modelList.Count;
                    sbc.DestinationTableName = destinationTableName;
                    sbc.BulkCopyTimeout = bulkCopyTimeout ?? 300;
                    conn.Open();
                    sbc.WriteToServer(dt);
                }
            }
        }
        #endregion

        #region SqlBulkCopy方式批量修改数据
        /// <summary>
        /// SqlBulkCopy方式批量修改数据
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="modelList">实体类集合</param>
        /// <param name="onRelations">关联字段</param>
        /// <param name="destinationTableName">目标表名</param>
        /// <param name="removeColumns">移除的字段列集合</param>
        /// <param name="UpdateColumns">更新的字段集合，不填则全部</param>
        public static string BatchUpdate<T>(List<T> modelList, string onRelations, string destinationTableName = null, List<string> removeColumns = null, List<string> UpdateColumns = null)
        {
            var updateResult = string.Empty;
            if (string.IsNullOrEmpty(destinationTableName))
                destinationTableName = typeof(T).Name.Replace("EN", "");
            var dt = MutualTransformation.ToDataTable(modelList);
            if (removeColumns != null && removeColumns.Count > 0)
            {
                foreach (var item in removeColumns)
                {
                    dt.Columns.Remove(item);
                }
            }
            var sbUpdateColumns = new StringBuilder();
            var columnsIndex = 0;
            //只更新某字段
            if (UpdateColumns != null && UpdateColumns.Count > 0)
            {
                foreach (var updateColumn in UpdateColumns)
                {
                    if (columnsIndex > 0)
                    {
                        sbUpdateColumns.Append(", ");
                    }
                    sbUpdateColumns.AppendFormat("T.{0} = Tmp.{0}", updateColumn);
                    columnsIndex++;
                }
            }
            else
            {
                //更新全部字段
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    var colname = dt.Columns[i];
                    if (colname.ColumnName != onRelations)
                    {
                        if (columnsIndex > 0)
                        {
                            sbUpdateColumns.Append(", ");
                        }
                        sbUpdateColumns.AppendFormat("T.{0} = Tmp.{0}", colname.ColumnName);
                        columnsIndex++;
                    }
                }
            }

            string sbOnRelation = string.Format("T.{0} = Tmp.{1}", onRelations, onRelations);
            var tempTableName = @"#Temp" + destinationTableName;
            var createtempsql = string.Format("select * into {0} from {1} where 1=2", tempTableName, destinationTableName);
            var updatesql = string.Format("UPDATE T SET {0} FROM {1} T INNER JOIN {2} Tmp ON {3}; DROP TABLE {2};", sbUpdateColumns.ToString(), destinationTableName, tempTableName, sbOnRelation.ToString());

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();
                        command.CommandText = createtempsql;
                        command.ExecuteNonQuery();
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 300;
                            bulkcopy.DestinationTableName = tempTableName;
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        command.CommandTimeout = 300;
                        command.CommandText = updatesql;
                        int countQuery = command.ExecuteNonQuery();
                        updateResult = countQuery > 0 ? "1" : countQuery.ToString();
                    }
                    catch (Exception ex)
                    {
                        updateResult= string.Format("BatchUpdate:{0}表失败,原因:{1}", destinationTableName, ex.Message + ex.StackTrace);
                       // Console.WriteLine("BatchUpdate:{0}表失败,原因:{1}", destinationTableName, ex.Message + ex.StackTrace);
                        // Handle exception properly
                    }
                    finally
                    {
                        //stopwatch.Stop();
                        //Console.WriteLine("更新耗时:{0}",stopwatch.ElapsedMilliseconds);
                        //list.Clear();
                        conn.Close();
                    }
                }
            }
            return updateResult;
        }
        #endregion

    }
}
