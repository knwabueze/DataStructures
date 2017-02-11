using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Stack<T>
    {
        protected CircularLinkedList<T> collection;

        public static Stack<T> Copy(Stack<T> stackToCopy)
        {
            var newStack = new Stack<T>();

            for (int i = 0; i < stackToCopy.Count; i++)
            {
                newStack.collection.Add(stackToCopy.collection.Get(i));
            }

            return newStack;
        }

        public int Count
        {
            get
            {
                return collection.Count();
            }

            protected set { }
        }

        public Stack()
        {
            collection = new CircularLinkedList<T>();
        }

        public void Push(T item)
        {
            collection.Add(0, item);
        }

        public T Pop()
        {
            return collection.Remove(0);
        }

        public T Peek()
        {
            return collection.Head.Value;
        }

        public void Clear()
        {
            collection.Clear();
        }
    }
}
