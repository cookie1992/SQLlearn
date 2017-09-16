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

namespace _01_通过ado.net连接数据库
{
    public partial class _02_作业描述 : Form
    {
        string constr = "data source=SC-201703152226\\SQLEXPRESS;initial catalog=new video; integrated security=true";
        public _02_作业描述()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value1 = textBox1.Text;
            string value2 = richTextBox1.Text;
            string order = "insert into classinfo values('" + value1 + "','" + value2 + "')";
            excu(order);
        }

        private void excu(string order)
        {
            int r;
            using (SqlConnection con = new SqlConnection(constr))
            {

                string sql = order;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    r = cmd.ExecuteNonQuery();
                    LoadData();

                }
            }
            MessageBox.Show("成功对" + r.ToString() + "条对象进行改变");
        }

        private void _02_作业描述_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<TBLClass> list = new List<TBLClass>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from classinfo";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TBLClass model = new TBLClass();
                                model.classid = reader.GetInt32(0);
                                model.classname = reader.GetString(1);
                                model.classabs = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                                model.claascheack = reader.IsDBNull(3) ? "null" : reader.GetBoolean(3).ToString();
                                list.Add(model);//把model对象加到list中
                            }
                        }
                    }

                }
            }
            //数据绑定的时候，只认‘属性’，不认“字段”
            this.dataGridView1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value1 = textBox2.Text;
            string order = "delete from classinfo where classid='" + value1 + "'";
            excu(order);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value1 = textBox4.Text;
            string value2 = textBox3.Text;
            string value3 = richTextBox2.Text;
            string order = "update classinfo set classname='" + value2 + "',classabs='" + value3 + "' where classid='" + value1 + "'";
            excu(order);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select count(*) from classinfo";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    object r = Convert.ToString(cmd.ExecuteScalar());
                    MessageBox.Show("表内总共有" + r + "条信息");
                }
            }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentrow = dataGridView1.Rows[e.RowIndex];
            TBLClass tBL = (TBLClass)currentrow.DataBoundItem;
            if (tBL != null)
            {
                textBox4.Text = tBL.classid.ToString();
                textBox3.Text = tBL.classname;
                richTextBox2.Text = tBL.classabs;
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            string value1 = textBox1.Text;
            string value2 = richTextBox1.Text;
            int i = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string order = string.Format(@"insert into dbo.classinfo(classname,classabs) output inserted.classid values(@value1,@value2)");
                //output inserted.classid 表示将新插入的该数据有返回，因此使用cmd.ExecuteScalar()的反方
                using (SqlCommand cmd = new SqlCommand(order, con))
                {
                    SqlParameter[] pms = new SqlParameter[]
                    {
                      new SqlParameter("@value1",SqlDbType.NVarChar) {Value =value1},
                      new SqlParameter("@value2", SqlDbType.NVarChar) {Value =value2 }
                    };
                    cmd.Parameters.AddRange(pms);
                    con.Open();
                    object obj = cmd.ExecuteScalar();
                    i = Convert.ToInt32(obj);
                }
            }
            LoadData();
            MessageBox.Show("插入新对象编号为" + i.ToString());
        }
    }
}
