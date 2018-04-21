using DataStructures.Collections;
using System;

namespace DataStructures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DjikstrasWeightedGraph<int> wg = new DjikstrasWeightedGraph<int>();

            var zero = wg.InsertNode('0');
            var one = wg.InsertNode('1');
            var two = wg.InsertNode('2');
            var three = wg.InsertNode('3');

            wg.AssignEdge(zero, one, 10);
            wg.AssignEdge(zero, three, 2);
            wg.AssignEdge(zero, two, 3);
            wg.AssignEdge(two, three, 6);
            wg.AssignEdge(one, three, 7);

            float cost = wg.CalculateShortestPath(zero, three);
        }
    }
}
