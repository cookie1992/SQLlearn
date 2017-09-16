using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连接池
{
    /// <summary>
    /// 默认情况下，连接池是被启动的
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string constr = @"Data source=SC-201703152226\SQLEXPRESS;initial catalog=new video;integrated security=true";
            using (SqlConnection con = new SqlConnection(constr))
            {
                Console.WriteLine("OK");
            
            }
            Console.ReadKey();
        }
    }
}
