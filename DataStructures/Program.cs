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
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            for (int i = 0; i < 8999; i++)
            {
                bst.Insert(MathUtils.Random.Next());
            }

            bst.Sort();

            Console.ReadKey();
        }
    }
}
