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
            AVLTree<int> avl = new AVLTree<int>();

            Random rnd = new Random();
            int seed = rnd.Next();

            //rnd = new Random(324358688);

            for (int i = 0; i < 5; i++)
            {
                int rndnum = rnd.Next(20);
                avl.Insert(rndnum);
            }

            AVLTreeNode<int>[] arr = avl.InOrderTraverse();

            //avl.Remove(101);

            Console.Read();

            //BinarySearchTree<int> bst = new BinarySearchTree<int>();

            //bst.Insert(100);
            //var node = bst.SearchNode(100);
        }
    }
}
