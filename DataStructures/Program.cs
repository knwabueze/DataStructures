using DataStructures.Collections;
using DataStructures.Sorting;
using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Map<string, int> map = new Map<string, int>
            {
                { "test", 3 },
                { "test2", 4}
            };

            map.Add("test3", 4);
            map["test3"] = 8;
            
            Console.WriteLine(map["test"]);          
            Console.WriteLine(map["test3"]);
            Console.WriteLine(map["test2"]);

            Console.ReadKey();
        }
    }
}
