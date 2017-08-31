using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace _01_通过ado.net连接数据库
{
    class Program
    {
       
        static void Main(string[] args)
        {
            #region 如何创建连接
            ////连接数据库的步骤
            ////1.创建连接字符串
            ////服务器实例data source=.本机名称.SC-201703152226\SQLEXPRESS 服务器名字
            ////初始化连接分类initial catalog=数据库名
            ////集成身份验证方式integrated security=true
            ////账号登录User ID= sa; Password=123
            //string constr = "Data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            ////string constr = "Data source=SC-201703152226\SQLEXPRESS;initial catalog=new video;User ID= sa; Password=123";
            ////2.创建连接对象
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    //测试，打开连接
            //    // //3.打开连接
            //    con.Open();
            //    Console.WriteLine("打开连接成功");
            //    //4.关闭连接
            //}
            //Console.WriteLine("关闭连接，释放资源");
            //Console.ReadKey();
            #endregion

            #region 向表中插入数据
            ////连接字符串
            //string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            ////创建连接对象
            //using(SqlConnection con=new SqlConnection(constr))
            //{

            //    //编写sql语句
            //    string sql = "insert into department values('技术部')";
            //    //创建一个执行sql语句的对象（命令对象）sqlcomman
            //    using(SqlCommand cmd=new SqlCommand (sql,con))
            //    {
            //        //正确的打开端口时机 最晚打开 最早关闭 节省资源
            //        try
            //        {
            //            con.Open();
            //            Console.WriteLine("创建成功");
            //        }
            //        catch
            //        {
            //            Console.WriteLine("创建失败,请重试");
            //        }
            //        //开始执行sql语句
            //        //注意：此语句只有执行insert \delete\update语句时才有返回行数，执行其他命令是返回-1
            //       int r=cmd.ExecuteNonQuery();//  insert\delete\update语句时 有返回值int 表示执行语句后影响后的行数
            //       Console.WriteLine("成功插入了" + r.ToString() + "行信息");
            //       //cmd.ExecuteReader();//   查询出多行多列结果
            //       //cmd.ExecuteScalar();//  执行返回返回单个结果
            //    }

            //}
            //Console.ReadKey();

            #endregion


            #region 删除一条数据
            ////1.连接字符串
            //string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            ////2.连接对象
            //using(SqlConnection con=new SqlConnection(constr))
            //{
            //    //3.sql语句
            //    string sql = "delete from department where depname='技术部'";
            //   //4.创建sqlcommand对象
            //   using(SqlCommand cmd=new SqlCommand(sql,con))
            //   {
            //       //5.打开连接
            //       con.Open();
            //       //6.执行
            //       int r = cmd.ExecuteNonQuery();
            //       Console.WriteLine("成功更改了" + r.ToString() + "行信息");
            //   }
            //}
            //Console.ReadKey();
         


            #endregion

            #region 修改
            ////连接语句
            ////创建连接
            ////sql语句
            ////创建sqlcommand对象
            ////打开连接
            ////执行
            //string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            //using(SqlConnection con=new SqlConnection(constr))
            //{
            //    string sql = "update  department set depname='技术部' where depid=1";
            //    using(SqlCommand cmd=new SqlCommand(sql,con))
            //    {
            //        con.Open();
            //        int r = cmd.ExecuteNonQuery();
            //        Console.WriteLine("成功更改了" + r.ToString() + "行信息");
            //    }
            //}
            //Console.ReadKey();
            #endregion

            #region  查询出表中的记录数据
            //string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = "select count(*) from department";
            //    using(SqlCommand cmd=new SqlCommand(sql,con))
            //    {
            //        con.Open();
            //        //需要注意返回值是否为NULL，如果为NULL需要经过其他操作
            //        object count= (int)cmd.ExecuteScalar();
            //        Console.WriteLine("表中共有{0}条数据", count);
            //    }
            //}
            //Console.ReadKey();
            #endregion
            
               //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            #region 查询数据
            //string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video;integrated security=true";
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = "select * from classinfo";
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();    
            //        using (SqlDataReader sdr=  cmd.ExecuteReader())//sqldatareader为只读属性，只进
            //        {
            //            //在获取数据之前，先判断一下是否查询到了数据
            //            if (sdr.HasRows)//如果有数据为TRUE，没数据为FalSE
            //            {
            //                //进行取数据操作，有数据为TRUE，没数据为FALSE
            //                while(sdr.Read())
            //                {
            //                    //获取当前READ的数据
            //                    //获取每一列的数据
            //                    //sdr.fieldcount 当前查询语句的个数
            //                    for (int i=0;i<sdr.FieldCount;i++)
            //                    {
            //                        //通过列的名称可获得索引值：sdr["列名"]
            //                        Console.Write(sdr[i] + "    |    ");
            //                        //  Console.Write(sdr.GetValue(i) + "    |    ");
            //                    }
            //                    Console.WriteLine();
            //                }
            //            }
            //            else 
            //            { 
            //                Console.WriteLine("没有数据");
            //            }
            //        }
              
            //    }
            //}
            //Console.ReadKey();
            #endregion


            Application.Run(new _02_作业描述());
        }
    }
}
