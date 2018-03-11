using DataStructures.Collections;
using System;
using System.Linq;

namespace DataStructures
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            UndirectedGraph<int> ud = new UndirectedGraph<int>();

            var x = ud.CreateVertex(0);
            var y = ud.CreateVertex(2);
            var z = ud.CreateVertex(1);
            var w = ud.CreateVertex(5);
            var k = ud.CreateVertex(3);
            var a = ud.CreateVertex(7);

            ud.TryAddPair(x, y);
            ud.TryAddPair(y, w);
            ud.TryAddPair(w, z);
            ud.TryAddPair(w, a);
            ud.TryAddPair(z, k);

            var iter = ud.DepthFirstTraversal(x);

            Console.ReadKey();
        }
    }
}
