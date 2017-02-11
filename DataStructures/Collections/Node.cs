
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Node<T> : INode<T>
    {
        public Node<T> Next
        {
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }

        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
