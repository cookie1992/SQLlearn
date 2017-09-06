using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> array = new List<string>();
            array.Add(richTextBox1.Text);
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs1 = new FileStream("储存.bin", FileMode.Create))
            {
                binary.Serialize(fs1, array);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BinaryFormatter binary = new BinaryFormatter();
            List<string> array = new List<string>();
            if (!File.Exists("储存.bin"))
            {
                using (FileStream fs3=new FileStream("储存.bin",FileMode.Create))
                {

                }              
            }
            using (FileStream fs2 = new FileStream("储存.bin", FileMode.Open))
            {
                using (StreamReader str=new StreamReader(fs2))
                {
                    if (str.ReadToEnd()==string.Empty)
                    {

                    }
                    else
                    {
                        fs2.Seek(0, SeekOrigin.Begin);
                        object o = binary.Deserialize(fs2);
                        array = o as List<string>;
                    }
                    foreach (var item in array)
                    {
                        richTextBox2.Text += item;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
