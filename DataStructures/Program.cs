using DataStructures.Collections;
using System;

namespace DataStructures
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            WeightedGraph<char> myBaby = new WeightedGraph<char>();

            var zero = myBaby.InsertNode('0');
            var one = myBaby.InsertNode('1');
            var two = myBaby.InsertNode('2');
            var three = myBaby.InsertNode('3');

            myBaby.AssignEdge(zero, one, 10);
            myBaby.AssignEdge(zero, three, 2);
            myBaby.AssignEdge(zero, two, 3);
            myBaby.AssignEdge(two, three, 6);
            myBaby.AssignEdge(one, three, 7);
        }
    }
}
