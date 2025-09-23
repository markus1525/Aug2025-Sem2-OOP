using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>();
            myList.Add("chicken");
            myList.Add("tea");
            myList.Add("coffee bean");
            myList.Add("duck");

            Console.WriteLine("myList[0]= {0}", myList[0]);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("List at position {0} is {1}", i, myList[i]);
            }

            // myList.RemoveAt(1);
            myList.Remove("Tea"); // won't work because Remove is case sensitive

            foreach (string listVal in myList)
            {
                Console.WriteLine("List value is {0}", listVal);
            }

            Dictionary<string, int> myDict = new Dictionary<string, int>();
            myDict.Add("bob", 83);
            myDict.Add("beans", 4);
            myDict.Add("dobby", 37);
            myDict.Add("chocolate", 66);
            myDict.Add("Goku", 9001);

            myDict["Leo"] = 6;

            foreach (string key in myDict.Keys)
            {
                Console.WriteLine("myDict contains key '{0}' and value '{1}'", key, myDict[key]);
            }
        }
    }
}
