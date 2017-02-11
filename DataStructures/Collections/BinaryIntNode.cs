using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinaryIntNode : INode<int>
    {
        public BinaryIntNode LeftChild { get; set; }
        public BinaryIntNode RightChild { get; set; }
        public int Value { get; set; }

        public BinaryIntNode(int value)
        {
            Value = value;
        }
    }
}
