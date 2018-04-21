using DataStructures.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class BinaryHeap<T> : IEnumerable<T>, IEnumerable
        where T : IComparable<T>
    {
        private T[] internal_;
        private Ordering ord_;

        public enum Ordering
        {
            Max,
            Min
        }

        /// <summary>
        /// Initializes a heap tree with an optional array of starting nodes.
        /// </summary>
        /// <param name="insertNodes">Optional array of starting nodes to be inserted</param>
        /// <param name="ordering">Dictates how the elements are ordered, 
        /// max-heap dictates that a node must be larger than its children. 
        /// Vice versa for min-heap.</param>
        public BinaryHeap(Ordering ordering = Ordering.Min, params T[] insertNodes)
        {
            ord_ = ordering;
            internal_ = new T[0];

            for (int i = 0; i < insertNodes.Length; ++i)
            {
                AddNode(insertNodes[i]);
            }
        }

        public int Count => internal_.Length;

        /// <summary>
        /// Inserts node into tree.
        /// </summary>
        /// <param name="t">Value (will be used to sort) to insert into tree</param>
        public void AddNode(T t)
        {
            var old = internal_;
            internal_ = new T[internal_.Length + 1];

            for (int i = 0; i < old.Length; ++i)
            {
                internal_[i] = old[i];
            }

            internal_[internal_.Length - 1] = t;

            if (internal_.Length - 1 != 0)
            {
                HeapifyUp(internal_.Length - 1);
            }
        }

        /// <summary>
        /// Removes and returns root node of tree.
        /// </summary>
        /// <returns>Value of root node.</returns>
        public T Pop()
        {
            var ret = internal_[0];
            var old = internal_;
            internal_ = new T[internal_.Length - 1];

            if (internal_.Length > 0)
            {
                internal_[0] = old[old.Length - 1];

                for (int i = 1; i < internal_.Length; ++i)
                {
                    internal_[i] = old[i];
                }

                HeapifyDown(0);
            }

            return ret;
        }

        class TupleComparable : Tuple<int, T>, IComparable<TupleComparable>
        {
            public TupleComparable(int item1, T item2) : base(item1, item2)
            {
            }

            public int CompareTo(TupleComparable other)
            {
                return Item2.CompareTo(other.Item2);
            }
        }

        private void HeapifyDown(int idx)
        {
            int rightChild;
            int leftChild;

            int level = 0;
            int result = 0;

            while (idx > result)
            {
                result += (int)Math.Pow(2, ++level);
            }

            int levelIdx = idx - ((int)Math.Pow(2, level) - 1);
            int childrenLevel = level + 1;

            int leftIdx = (levelIdx * 2);
            int rightIdx = (levelIdx * 2) + 1;

            rightChild = ((int)Math.Pow(2, childrenLevel) - 1) + rightIdx;
            leftChild = ((int)Math.Pow(2, childrenLevel) - 1) + leftIdx;

            if (rightChild >= internal_.Length && leftChild >= internal_.Length)
            {
                return;
            }

            else
            {
                TupleComparable parent = new TupleComparable(idx, internal_[idx]);

                List<TupleComparable> workingValues = new List<TupleComparable>
                {
                    parent    
                };

                try
                {
                    TupleComparable left = new TupleComparable(leftChild, internal_[leftChild]);
                    workingValues.Add(left);
                }
                catch { }

                try
                {
                    TupleComparable right = new TupleComparable(rightChild, internal_[rightChild]);
                    workingValues.Add(right);
                }
                catch { }

                TupleComparable minmax;

                if (ord_ == Ordering.Min)
                {
                    minmax = MathUtils.Min(workingValues.ToArray());
                }

                else
                {
                    minmax = MathUtils.Max(workingValues.ToArray());
                }

                if (minmax.Item1 == parent.Item1)
                {
                    return;
                }

                else
                {
                    var temp = internal_[idx];
                    internal_[idx] = minmax.Item2;
                    internal_[minmax.Item1] = temp;

                    HeapifyDown(minmax.Item1);
                }
            }
        }

        private void HeapifyUp(int idx)
        {
            int currentIdx = idx;
            int parentIdx = 0;

            int initialLevel = 0;
            int result = 0;

            while (idx > result)
            {
                result += (int)Math.Pow(2, ++initialLevel);
            }

            int currentLevel = initialLevel;

            while (true)
            {
                var orderOnLevel = currentIdx - ((int)Math.Pow(2, currentLevel) - 1);

                var parentLevel = currentLevel - 1;
                var parentsOrderOnLevel = (int)Math.Floor((double)orderOnLevel / 2);

                parentIdx = ((int)Math.Pow(2, parentLevel) - 1) + parentsOrderOnLevel;

                var orderingResult = internal_[currentIdx].CompareTo(internal_[parentIdx]);
                bool order = false;

                switch (ord_)
                {
                    case Ordering.Max:
                        order = orderingResult > 0;
                        break;
                    case Ordering.Min:
                        order = orderingResult < 0;
                        break;
                }

                if (order)
                {
                    var temp = internal_[parentIdx];
                    internal_[parentIdx] = internal_[currentIdx];
                    internal_[currentIdx] = temp;
                }

                currentIdx = parentIdx;
                currentLevel = parentLevel;

                if (currentLevel == 0)
                {
                    break;
                }
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)internal_).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
