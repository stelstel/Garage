using System;
using System.Collections.Generic;

namespace Garage
{
    class Program
    {
        public static UI Ui { get; set; } = new UI();
        //public static Garage<Vehicle> Garage { get; set; }

        static void Main()
        {
            Test1();
            Test2();

            Menu.Run();
        }

        static void Test1()
        {
            Console.WriteLine("Test1");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("key1", "key1 value");

            foreach (KeyValuePair<string, string> entry in dic)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }

            dic["key1"] = "key1 new value";

            foreach (KeyValuePair<string, string> entry in dic)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }

            Console.WriteLine(dic.ToString());
            //Console.ReadLine();
        }

        static void Test2()
        {
            Console.WriteLine("Test1");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("key1", "value");

            foreach (KeyValuePair<string, string> entry in dic)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }

            dic["key1"] = "changed";
            
            foreach (KeyValuePair<string, string> entry in dic)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }


            Console.WriteLine(dic.ToString());
            Console.ReadLine();
        }
    }
}
