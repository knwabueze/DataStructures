using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class PriorityQueue<T> : IEnumerable<T>, IEnumerable
        where T : IComparable<T>
    {
        private BinaryHeap<T> heap_;

        /// <summary>
        /// Initializes an object of the type PriorityQueue with an optional array of values.
        /// </summary>
        /// <param name="starting">Optional array of <typeparamref name="T"/></param>
        public PriorityQueue(params T[] starting)
        {
            heap_ = new BinaryHeap<T>(BinaryHeap<T>.Ordering.Max, starting);
        }

        public void Enqueue(T value)
        {
            heap_.AddNode(value);
        }

        public T Dequeue()
        {
            return heap_.Pop();
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (heap_.Count > 0)
            {
                yield return Dequeue();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
