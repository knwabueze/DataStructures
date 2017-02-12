
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class SinglyLinkedListNode<T> : INode<T>
    {
        public SinglyLinkedListNode<T> Next
        {
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }

        public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
