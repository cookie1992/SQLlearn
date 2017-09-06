using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 练习序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList
            {
                123,
                123,
                13323,
                "tommy"
            };
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream("topic.bin", FileMode.Create))
            {
                binary.Serialize(fs, array);
            }


        }
    }
}
