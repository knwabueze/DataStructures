using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Stack<T> : IEnumerable<T>
    {
        protected CircularLinkedList<T> backend;

        public static Stack<T> CopyTo(Stack<T> stackToCopy)
        {
            var newStack = new Stack<T>();

            for (int i = 0; i < stackToCopy.Count; i++)
            {
                newStack.backend.Add(stackToCopy.backend[i]);
            }

            return newStack;
        }

        public int Count
        {
            get
            {
                return backend.Count();
            }

            protected set { }
        }

        public Stack()
        {
            backend = new CircularLinkedList<T>();
        }

        public void Push(T item)
        {
            backend.Add(0, item);
        }

        public T Pop()
        {
            return backend.Remove(0);
        }

        public T Peek()
        {
            return backend.Head.Value;
        }

        public void Clear()
        {
            backend.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return backend.Select(item => item.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
