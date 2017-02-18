using DataStructures.Collections;
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
        public static void Main(String[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(0);
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(10);

            Console.WriteLine(bst.Maximum().ToString());
            Console.WriteLine(bst.Minimum().ToString());   

            bst.Remove(6);
            bst.Remove(10);
            bst.Remove(2);
            bst.Remove(0);

            Console.WriteLine("---END---");
        }
    }
}
