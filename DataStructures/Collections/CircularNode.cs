using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class CircularNode<T> : INode<T>
    {
        private T _value;
        private CircularNode<T> _next;
        private CircularNode<T> _prev;

        public CircularNode<T> Next {
            get { return _next; }
            set { _next = value; } 
        }

        public CircularNode<T> Previous {
            get { return _prev; }
            set { _prev = value; }
        }

        public T Value {
            get { return _value; }
            set { _value = value; }
        }

        public CircularNode(T value, CircularNode<T> next, CircularNode<T> prev) {
            _value = value;
            _next = next;
            _prev = prev;
        }
    }
}
