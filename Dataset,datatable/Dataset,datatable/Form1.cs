using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLHELPER2;

namespace Dataset_datatable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string constr = @"data source=SC-201703152226\SQLEXPRESS;initial catalog=Test123; integrated security=true";
            string sql = "select * from category";
            //DataTable dt = new DataTable();
            //using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            //{
            //    adapter.Fill(dt);

            //}

            dataGridView1.DataSource = SQLHELPER.ExecuteDataSet(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //类
            DataSet ds = new DataSet("school");
            //表
            DataTable dt = new DataTable("student");
            //表创建列
            //第一列
            DataColumn column1 = new DataColumn("Autoid", typeof(int));
            column1.AutoIncrement = true;
            column1.AutoIncrementSeed = 1;
            column1.AutoIncrementStep = 1;
            dt.Columns.Add(column1);
            //第二列
            DataColumn column2 = dt.Columns.Add("User Name", typeof(string));
            column2.AllowDBNull = false;
            //第三列
            dt.Columns.Add("User Age", typeof(int));


            //==============================
            //向表中加入数据
            //创建一行
            DataRow dr1 = dt.NewRow();
            dr1["User Name"] = "TOMF";
            dr1["User Age"] = 311;
            dt.Rows.Add(dr1);

            //create another row
            DataRow dr2 = dt.NewRow();
            dr2["User Name"] = "bva2MF";
            dr2["User Age"] = 11;
            dt.Rows.Add(dr2);





            //===========================================
            //表加入类
            ds.Tables.Add(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
