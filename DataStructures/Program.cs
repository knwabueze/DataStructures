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
        public static void Main(string[] args)
        {
            BinarySearchTree<char> bst = new BinarySearchTree<char>('A', 'B', 'C', 'D', 'E', 'F', 'G');
            bst.Sort();
            
            Console.WriteLine("--END--");
        }
    }
}
