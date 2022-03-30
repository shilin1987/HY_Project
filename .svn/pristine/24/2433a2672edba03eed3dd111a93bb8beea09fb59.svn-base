using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TemporaryPro_Web.Models
{
    public class UntilDB
    {
        ReturnCommon rc = new ReturnCommon();
        public ReturnCommon insert()
        {
            string connectionString = "Server=10.100.200.86;Initial Catalog=adms706;User ID=sa;Password=malaihong";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string uuid = System.Guid.NewGuid().ToString("N");
                string ass = "insert into HY_Temporary_userinfo (f_useroid, f_userid, f_username) values ('"+ uuid + "','222','333')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(ass, conn);
                cmd.CommandType = CommandType.Text;
                //SqlDataReader sqldr = cmd.ExecuteReader();
                int count =  cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    rc.Falg = true;
                }
                else
                {
                    rc.Falg = false;
                    rc.Meg = "注册失败,请联系管理员！！！";
                }
                return rc;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally{
                conn.Close();
            }
        }
    }
}