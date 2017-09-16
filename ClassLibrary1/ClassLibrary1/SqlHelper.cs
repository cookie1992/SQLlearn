using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SqlHelperl类
{
    public static class SqlHelper
    {
        private static string constr = ConfigurationManager.AppSettings["sqlserver"];

        //封装增
        public static int ExecuteNonquery(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con=new SqlConnection(constr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if (pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }


            }
        }
    }
}
