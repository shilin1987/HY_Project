using LaoQinAndHRDataBasicsWService.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaoQinAndHRDataBasicsWService.DatabaseHelper
{
    public static class DbExtend
    {
        public static DataTable Select_Table_Info(this WTS_HTEntities model, string sql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = model.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
          
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public static DataTable Select_Table_Info(this WTS_HTEntities model, string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = model.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
