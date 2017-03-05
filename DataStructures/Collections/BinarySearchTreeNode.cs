using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTreeNode<T, TNode> : INode<T>
        where T : IComparable
        where TNode : BinarySearchTreeNode<T, TNode>
    {
        public T Value { get; set; }

        public virtual TNode LeftChild { get; set; }
        public virtual TNode RightChild { get; set; }
        public virtual TNode Parent { get; set; }

        public BinarySearchTreeNode(T value)
        {
            Value = value;
        }

        public BinarySearchTreeNode()
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class BinarySearchTreeNode<T> : BinarySearchTreeNode<T, BinarySearchTreeNode<T>>
        where T : IComparable
    {

    }
}
