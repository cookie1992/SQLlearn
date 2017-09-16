using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLHELPER2;
using System.Data.SqlClient;
using System.IO;

namespace 省市
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //向Treeview中加载表
            NewMethod();
        }

        private void NewMethod()
        {
            treeView1.Nodes.Clear();
            Loadtreeview(-1, treeView1.Nodes);
        }

        private void Loadtreeview(int v, TreeNodeCollection nodes)
        {
            richTextBox1.Clear();
            List<category> model = GetCategory(v);
            foreach (category item in model)
            {
                TreeNode node = nodes.Add(item.ToString());
                node.Tag = item.tid;
                Loadtreeview(item.tid, node.Nodes);
            }


        }


        private List<category> GetCategory(int tparentid)
        {
            List<category> list = new List<category>();
            string str = "select * from category where tparentid = @tid";
            SqlParameter tid = new SqlParameter("@tid", SqlDbType.Int) { Value = tparentid };
            using (SqlDataReader reader = SQLHELPER.ExecuteReader(str, tid))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        category model = new category();
                        model.tid = reader.GetInt32(0);
                        model.tname = reader.GetString(1);
                        model.tparentid = reader.GetInt32(2);
                        list.Add(model);
                    }
                }
            }
            return list;


        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listBox1.Items.Clear();
            int t = (int)e.Node.Tag;
            string sql = "select * from ContentInfo where dTid=@dtid";
            SqlParameter p1 = new SqlParameter("@dtid", SqlDbType.Int) { Value = t };
            using (SqlDataReader reader = SQLHELPER.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Content model = new Content();
                        model.did = (int)reader[0];
                        model.dtid = (int)reader[1];
                        model.dname = reader[2].ToString();
                        model.content = reader[3].ToString();
                        listBox1.Items.Add(model);
                    }
                }


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                int did = (listBox1.SelectedItem as Content).did;
                string sql = "select dContent from ContentInfo where did=@did";
                SqlParameter p1 = new SqlParameter("did", SqlDbType.Int) { Value = did };
                string str = string.Empty;
                object obj = SQLHELPER.ExecuteScalar(sql, p1);
                if (obj != null)
                {
                    str = obj.ToString();
                }

                richTextBox1.AppendText(str);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formaddcathlog fm = new Formaddcathlog(-1);
            fm.treeload = NewMethod;
            fm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                int t = (int)treeView1.SelectedNode.Tag;
                Formaddcathlog fm = new Formaddcathlog(t);
                fm.treeload = NewMethod;
                fm.Show();
            }
            else
            {
                MessageBox.Show("请选择类别", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                int tag = (int)treeView1.SelectedNode.Tag;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //导入
                    string path = folderBrowserDialog1.SelectedPath;
                    string[] txts = Directory.GetFiles(path, "*.txt");
                    foreach (string item in txts)
                    {
                        //文件名
                        string txtpath = Path.GetFileNameWithoutExtension(item);
                        //文章内容
                        string content = string.Empty;
                        if (File.ReadAllText(item, Encoding.Default)!=null)
                        {
                            content = File.ReadAllText(item, Encoding.Default);
                        }                      
                        string sql = "insert into ContentInfo(dTid,dname,dContent)values(@did, @dname, @dcont)";
                        SqlParameter[] param = new SqlParameter[]
                        {
                            new SqlParameter("@did",SqlDbType.Int){Value=tag},
                            new SqlParameter("@dname",SqlDbType.Int){Value=tag},
                            new SqlParameter("@dcont",SqlDbType.Int){Value=tag},

                        };
                        SQLHELPER.ExecuteNonquery(sql, param);

                    }
                }

            }
        }
    }
}
