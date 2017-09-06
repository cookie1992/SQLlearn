using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using 练习序列化;

namespace 练习反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter binary = new BinaryFormatter();
            ArrayList array = new ArrayList();
            using (FileStream fs=new FileStream(@"E:\Users\Administrator\source\repos\文件流\练习反序列化\Debug\topic.bin",FileMode.Open))
            {
                object o = binary.Deserialize(fs);
                array = o as ArrayList;

            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
