using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText("1.txt.txt",Encoding.Default);
            Console.WriteLine(str);
           
            Console.WriteLine(Encoding.GetEncoding("gb2312").ToString());
            Console.ReadKey();
        }
        
    }
}
