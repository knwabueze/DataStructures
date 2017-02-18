using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTreeNode : INode<int>
    {
        public int Value { get; set; }

        public BinarySearchTreeNode LeftChild { get; set; }
        public BinarySearchTreeNode RightChild { get; set; }
        public BinarySearchTreeNode Parent { get; set; }

        public BinarySearchTreeNode(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
