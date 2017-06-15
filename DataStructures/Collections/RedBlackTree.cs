using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    // Rule check for adding is different than rule check for deleting
    public class RedBlackTree<T> : BinarySearchTree<T, RedBlackTreeNode<T>>
        where T : IComparable
    {
        public new RedBlackTreeNode<T> Insert(T value)
        {
            RedBlackTreeNode<T> node = base.Insert(value);
            return node;
        }
    }
}
