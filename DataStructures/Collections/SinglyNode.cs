
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class SinglyNode<T> : INode<T>
    {
        public SinglyNode<T> Next
        {
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }

        public SinglyNode(T value, SinglyNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
