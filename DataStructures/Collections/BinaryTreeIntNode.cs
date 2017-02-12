using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinaryTreeIntNode : INode<int>
    {
        public int Value { get; set; }

        public BinaryTreeIntNode LeftChild { get; set; }
        public BinaryTreeIntNode RightChild { get; set; }
        public BinaryTreeIntNode Parent { get; set; }

        public BinaryTreeIntNode(int value)
        {
            Value = value;
        }
    }
}
