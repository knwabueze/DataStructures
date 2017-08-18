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
            //rbtree.Insert(29);
            //rbtree.Insert(122);
            //rbtree.Insert(121);
            //rbtree.Insert(123);
            //rbtree.Insert(40);
            //rbtree.Insert(25);
            //rbtree.Insert(29);
            //rbtree.Insert(15);
            //rbtree.Insert(14);
            //rbtree.Insert(16);
            //rbtree.Remove(15);

            /** Case A Tests Start Here **/
            //rbtree.Insert(20);
            //rbtree.Insert(10);
            //rbtree.Insert(30);
            //rbtree.Insert(25);
            //rbtree.Insert(35);
            //rbtree.Remove(10);

            //rbtree.Insert(30);
            //rbtree.Insert(20);
            //rbtree.Insert(40);
            //rbtree.Insert(35);
            //rbtree.Insert(50);
            //rbtree.Remove(20);

            //rbtree.Insert(30);
            //rbtree.Insert(20);
            //rbtree.Insert(40);
            //rbtree.Insert(35);
            //rbtree.Remove(20);
            /** Case A Tests End Here **/

            /** Case B Tests Start Here **/
            rbtree.Insert(20);
            rbtree.Insert(10);
            rbtree.Insert(30);

            rbtree.SearchNode(10).Color = RedBlack.Black;
            rbtree.SearchNode(30).Color = RedBlack.Black;

            rbtree.Remove(10);
            /** Case B End Start Here **/


            Console.Read();
        }
    }
}
