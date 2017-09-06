using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建序列化器
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = new FileStream(@"E:\Users\Administrator\source\repos\文件流\ConsoleApp1\Debug\person.txt", FileMode.Open))
            {
                object o = bf.Deserialize(file);
                ConsoleApp1.Program.Person person = o as ConsoleApp1.Program.Person;
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Name);
            }
            
      
            Console.WriteLine("ok");
            Console.ReadKey();
        }

    }
}
