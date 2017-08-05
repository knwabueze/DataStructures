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
            RedBlackTree<int> rbtree = new RedBlackTree<int>();

            //rbtree.Insert(89);
            //rbtree.Insert(33);
            //rbtree.Insert(121);
            //rbtree.Insert(122);
            //rbtree.Insert(123);
            //rbtree.Insert(122);
            //rbtree.Insert(122);
            //rbtree.Insert(33);
            //rbtree.Remove(89);

            rbtree.Insert(89);
            rbtree.Insert(29);
            rbtree.Insert(122);
            rbtree.Insert(121);
            rbtree.Insert(123);
            rbtree.Insert(40);
            rbtree.Insert(25);
            rbtree.Insert(29);
            rbtree.Insert(15);
            rbtree.Insert(14);
            rbtree.Insert(16);
            rbtree.Remove(15);

            Console.Read();
        }
    }
}
