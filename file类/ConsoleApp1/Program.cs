﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("demo"))
            {
               
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);   
            }
            
            Directory.Delete("123.txt");
            Console.ReadKey();

        }
    }
}
