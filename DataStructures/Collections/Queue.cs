using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Queue<T> : IEnumerable<T>
    {
        protected CircularLinkedList<T> backend;

        public static Queue<T> CopyTo(Queue<T> stackToCopy)
        {
            var newQueue = new Queue<T>();

            for (int i = 0; i < stackToCopy.Count; i++)
            {
                newQueue.backend.Add(i, stackToCopy.backend[i]);
            }

            return newQueue;
        }

        public int Count
        {
            get
            {
                return backend.Count();
            }
        }

        public Queue()
        {
            backend = new CircularLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            backend.Add(value);
        }

        public T Dequeue()
        {
            return backend.Remove(0);
        }

        public void Clear()
        {
            if (!backend.Empty)
                backend.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return backend.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
