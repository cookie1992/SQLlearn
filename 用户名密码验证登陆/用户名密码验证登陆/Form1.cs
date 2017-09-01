using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 用户名密码验证登陆
{
    public partial class Form1 : Form
    {
        int log = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            globalhel.constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video; integrated security=true";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region 拼接SQL语句 存在SQL注入攻击
            //string id=textBox1.Text.Trim();
            //string pwd=textBox2.Text;
            //int count=0;

            //using (SqlConnection con=new SqlConnection(globalhel.constr))
            //{
            //    string sql = string.Format("select COUNT(*) from logininfo where loginid='{0}' and loginpwd='{1}' ", id, pwd);
            //    using (SqlCommand cmd=new SqlCommand(sql,con))
            //    {
            //        con.Open();
            //        object obj = cmd.ExecuteScalar();
            //        count = Convert.ToInt32(obj);
            //    }
            //}


            //if (count>0)
            //{
            //    MessageBox.Show("登陆成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("登陆失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            #endregion
            #region 带参数的SQL语句 避免SQL注入攻击
            int i = 0;
            using (SqlConnection con = new SqlConnection(globalhel.constr))
            {
                string sql = string.Format("select COUNT(*) from logininfo where loginid=@id and loginpwd=@pwd ");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //SqlParameter paramid = new SqlParameter("@id",SqlDbType.VarChar,20) {Value = textBox1.Text.Trim()};
                    //SqlParameter parampwd = new SqlParameter("@pwd", SqlDbType.VarChar, 50) { Value = textBox2.Text.Trim() };               
                    //cmd.Parameters.Add(paramid);
                    //cmd.Parameters.Add(parampwd);
                    SqlParameter[] pms = new SqlParameter[]
                    {
                      new SqlParameter("@id",SqlDbType.VarChar,20) {Value = textBox1.Text.Trim()},
                      new SqlParameter("@pwd", SqlDbType.VarChar, 50) { Value = textBox2.Text.Trim() }
                    };
                    cmd.Parameters.AddRange(pms);
                    con.Open();
                    object obj = cmd.ExecuteScalar();
                    i = Convert.ToInt32(obj);
                }
            }
            if (i > 0)
            { 
                MessageBox.Show("登陆成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string pwd = textBox2.Text;
            string pwd1=" ";
            using (SqlConnection con = new SqlConnection(globalhel.constr))
            {
                string sql = string.Format("select * from logininfo where loginid='{0}'", id);
         
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {

                                pwd1 = reader.GetString(2);
                                if (pwd == pwd1)
                                {
                                    globalhel.autoid = reader.GetInt32(0);
                                    globalhel.pwd = reader.GetString(2);
                                    log=2;
                                }
                                else
                                {
                                    log=1;
                                }
                            }
                        }
                        else
                        {
                            log=0;
                        }

                    }

                }
            }
            if(log==0)
            {
                MessageBox.Show("用户不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (log == 1)
            {
                MessageBox.Show("密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else if (log==2)
            {
                MessageBox.Show("登陆成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change chej = new change();
            chej.Show();
        }
    }
}
