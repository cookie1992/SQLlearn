using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 素材管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "demo";
            LoadData(path, treeView1.Nodes);
        }

        private void LoadData(string path, TreeNodeCollection nodes)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                TreeNode td=treeView1.Nodes.Add(Path.GetFileName( item));
                LoadData(item, td.Nodes);
            }
            string[] file = Directory.GetFiles(path,"*.txt");
            foreach (var item in file)
            {
               TreeNode td= treeView1.Nodes.Add(Path.GetFileName(item));
                td.Tag = item;
                
            }

        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag!=null)
            {
                richTextBox1.Text = File.ReadAllText(e.Node.Tag.ToString(),Encoding.Default);
            }
        }
    }
}
