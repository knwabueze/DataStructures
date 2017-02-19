using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTreeNode<T> : INode<T>
        where T : IComparable
    {
        public T Value { get; set; }

        public BinarySearchTreeNode<T> LeftChild { get; set; }
        public BinarySearchTreeNode<T> RightChild { get; set; }
        public BinarySearchTreeNode<T> Parent { get; set; }

        public BinarySearchTreeNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
