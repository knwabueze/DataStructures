using DataStructures.Collections;
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
            bst.Insert(21);
            bst.Insert(22);
            bst.Insert(3);
            bst.Insert(52);
            bst.Insert(12);
            bst.Insert(5);

            Console.WriteLine(bst.Maximum().ToString());
            Console.WriteLine(bst.Minimum().ToString());

            Console.WriteLine("---END---");
        }
    }
}
