using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class AVLTree<T> : BinarySearchTree<T, AVLTreeNode<T>>
        where T : IComparable
    {
        protected void CheckBalance()
        {
        }

        public AVLTree(params T[] nodes) : base(nodes)
        {
        }
    }     
}

