using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Garage
{
    class Oscar
    {
        private void Test1()
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
        }

    }
}
