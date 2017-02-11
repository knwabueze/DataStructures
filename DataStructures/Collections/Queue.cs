using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Queue<T>
    {
        protected CircularLinkedList<T> collection;

        public static Queue<T> Copy(Queue<T> stackToCopy)
        {
            var newQueue = new Queue<T>();

            for (int i = 0; i < stackToCopy.Count; i++)
            {
                newQueue.collection.Add(i, stackToCopy.collection.Get(i));
            }

            return newQueue;
        }

        public int Count
        {
            get
            {
                return collection.Count();
            }
        }

        public Queue()
        {
            collection = new CircularLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            collection.Add(value);
        }

        public T Dequeue()
        {
            return collection.Remove(0);
        }

        public void Clear()
        {
            if (!collection.Empty)
                collection.Clear();
        }
    }
}
