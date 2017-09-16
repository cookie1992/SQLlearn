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

namespace 省市
{
    public partial class Formaddcathlog : Form
    {
        public Formaddcathlog()
        {
            InitializeComponent();
        }

        private int tpid;
        public Formaddcathlog(int t):this()
        {
            tpid = t;
        }

        public Action treeload;
        private void button1_Click(object sender, EventArgs e)
        {
            string tname = textBox1.Text;
            string sql = "insert into category values(@tname,@tpid)";
            SqlParameter[] p1=new SqlParameter[]
            {
                new SqlParameter("tname", SqlDbType.NVarChar) { Value=tname},
                new SqlParameter("tpid", SqlDbType.Int) { Value=tpid},
            };
            int r = SQLHELPER.ExecuteNonquery(sql, p1);
            if (treeload!=null)
            {
                treeload.Invoke();
            }
            this.Close();
        }
    }
}
