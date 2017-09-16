using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHELPER2
{
    public static class SQLHELPER
    {
        private static string constr = @"data source=SC-201703152226\SQLEXPRESS;initial catalog=Test123; integrated security=true";

        //封装增
        public static int ExecuteNonquery(string sql, params SqlParameter[] pms)
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
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }


            }
        }

        public static DataTable ExecuteDataSet(string sql,params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            {
                if (pms!=null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                    
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

