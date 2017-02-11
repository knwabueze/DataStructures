﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class CircularLinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        public CircularNode<T> Head { get; private set; }

        public bool Empty
        {
            get { return Count() == 0; }
        }

        private IEnumerable<CircularNode<T>> Nodes
        {
            get
            {
                for (int i = 0; i < Count(); i++)
                {
                    yield return GetNode(i);
                }
            }
        }

        public CircularLinkedList()
        {
            Head = null;
        }

        public T Add(T value)
        {
            return Add(Count(), value);
        }

        public T Add(int index, T value)
        {
            if (Head == null)
            {
                Head = new CircularNode<T>(value, Head, Head);
                Head.Next = Head;
                Head.Previous = Head;
                return value;
            }

            else if (Empty || index == 0)
            {
                Head = new CircularNode<T>(value, Head, Head.Previous);
                Head.Next.Previous = Head;
                return value;
            }

            if (index > Count())
                index = Count();

            if (index < 0)
                throw new IndexOutOfRangeException();


            CircularNode<T> current = GetNode(index - 1);

            current.Next = new CircularNode<T>(value, current.Next, current);

            if (index >= Count())
                Head.Previous = current.Next;

            return value;
        }

        public bool Contains(T value)
        {
            bool contains = false;
            for (int i = 0; i < Count(); i++)
            {
                if (Get(i).Equals(value))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public T Get(int index)
        {
            return GetNode(index).Value;
        }

        private CircularNode<T> GetNode(int index)
        {
            if (index >= Count() || index < 0)
                throw new IndexOutOfRangeException();

            CircularNode<T> current = Head;

            for (int i = 0; i < index; i++)
                current = current.Next;

            return current;
        }

        public int IndexOf(T value)
        {
            int currentIndex = 0;
            bool found = false;

            for (int i = 0; i < Count(); i++)
            {
                if (Get(i).Equals(value))
                {
                    currentIndex = i;
                    found = true;
                }
            }

            if (!found)
                throw new KeyNotFoundException();

            return currentIndex;
        }

        public T Remove(int index)
        {

            if (!GetNode(index).Equals(Head))
            {
                CircularNode<T> current = GetNode(index);

                current.Next.Previous = current.Previous;
                current.Previous.Next = current.Next;

                T value = current.Value;
                current = null;

                return value;
            }
            else
            {
                if (Head.Next == Head)
                {
                    T temp = Head.Value;
                    Head = null;
                    return temp;
                }

                Head.Previous.Next = Head.Next;
                Head.Next.Previous = Head.Previous;

                T value = Head.Value;
                Head = Head.Next;

                return value;
            }

            throw new KeyNotFoundException();
        }

        public T Set(int index, T value)
        {
            GetNode(index).Value = value;
            return value;
        }

        public int Count()
        {
            int counter = 1;

            if (Head == null)
            {
                return 0;
            }

            CircularNode<T> current = Head;

            while (current != Head.Previous)
            {
                current = current.Next;
                counter++;
            }

            return counter;
        }

        public void Clear()
        {
            Head = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (CircularNode<T> node in Nodes)
            {
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get { return Get(i); }
            set { Set(i, value); }
        }
    }
}
