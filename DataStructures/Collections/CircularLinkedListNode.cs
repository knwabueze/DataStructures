using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class CircularLinkedListNode<T> : INode<T>
    {
        private T _value;
        private CircularLinkedListNode<T> _next;
        private CircularLinkedListNode<T> _prev;

        public CircularLinkedListNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public CircularLinkedListNode<T> Previous
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public CircularLinkedListNode(T value, CircularLinkedListNode<T> next, CircularLinkedListNode<T> prev)
        {
            _value = value;
            _next = next;
            _prev = prev;
        }
    }
}
