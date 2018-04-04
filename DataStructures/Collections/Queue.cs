using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Initializes a queue mathmatical model, with elements of those in collection, and enough spaces to hold them.
        /// </summary>
        /// <param name="collection">Collections whose elements are copied into the queue</param>
        public Queue(IEnumerable<T> collection)
            :base()
        {
            foreach (var c in collection)
            {
                Enqueue(c);
            }
        }

        public void Enqueue(T value)
        {
            backend.Add(value);
        }

        public bool Contains(T value)
        {
            return backend.IndexOf(value) != -1;
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
            return backend.Select(item => item.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
