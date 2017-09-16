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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = 0;
            if (textBox1.Text==globalhel.pwd)
            {
               if(textBox2.Text==textBox3.Text)
               {

                   using (SqlConnection con=new SqlConnection(globalhel.constr))
                   {
                       //string sql = string.Format("UPDATE logininfo set loginpwd='{0}' WHERE lid={1}", textBox2.Text, globalhel.autoid);
                       string sql = "UPDATE logininfo set loginpwd=@pwd WHERE lid=@id";                      
                       using (SqlCommand cmd =new SqlCommand(sql,con))
                       {
                           SqlParameter[] pms = new SqlParameter[]
                           {
                               new SqlParameter("@pwd",SqlDbType.VarChar,50) {Value=textBox2.Text.Trim()},
                               new SqlParameter("@id",SqlDbType.Int) {Value=globalhel.autoid}
                           };
                           cmd.Parameters.AddRange(pms);
                           con.Open();
                           r = cmd.ExecuteNonQuery();
                       }
                   }
                   if (r!=0)
                   {
                       MessageBox.Show("修改密码成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else
                   {
                       MessageBox.Show("密码修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                   }
               }
                else
               {
                   MessageBox.Show("两次输入密码不一样", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               }
            }
            else
            {
                MessageBox.Show("旧密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private string password;
        private void change_Load(object sender, EventArgs e)
        {
            password = toke();

        }
        public Func<string> toke;
    }
}
