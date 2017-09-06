using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person
            {
                Age = 13,
                Name = "123",
                Benchi = new car() { name = "smart" }

            };



            //二进制序列化    
            //1.创建序列化器
            BinaryFormatter binary = new BinaryFormatter();
            //2.开始
            using (FileStream fs = new FileStream("person.txt", FileMode.Create))
            {
                binary.Serialize(fs, p1);
            }       
            Console.WriteLine("ok");
            Console.ReadKey();



            ////xml 序列化
            //XmlSerializer xml = new XmlSerializer(typeof(Person));
            //using (FileStream fs=new FileStream("person.xml",FileMode.Create))
            //{
            //    xml.Serialize(fs, p1);
            //}

            //////json 序列化
            ////JavaScriptSerializer jser = new JavaScriptSerializer();
            ////string s1 = jser.Serialize(p1);
            //Console.WriteLine(s1);





        }
        [Serializable]
        public class Animal
        {
            public void Sayhi()
            { Console.WriteLine("hi~"); }
        }


        [Serializable]
        public class Person:Animal
        {
            public car Benchi { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public  Myclass Sayhello()
            {
                return new Myclass();
            }

        }

        [Serializable]
        public class car
        {
            public string name { get; set; }
        }
    }

    public class Myclass
    {

    }
}
