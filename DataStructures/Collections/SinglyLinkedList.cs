using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class SinglyLinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        public int Size
        {
            get;
            private set;
        }

        public SinglyNode<T> Head
        {
            get;
            private set;
        }

        public SinglyNode<T> Tail
        {
            get;
            private set;
        }

        public bool Empty
        {
            get
            {
                return Size == 0;
            }
        }

        private IEnumerable<SinglyNode<T>> Nodes
        {
            get
            {
                SinglyNode<T> current = Head;

                for (int i = 0; i < Size; i++)
                {
                    yield return current;
                    current = current.Next;
                }
            }
        }

        public SinglyLinkedList()
        {
            Head = null;
        }

        public T Add(int index, T value)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            if (Empty)
            {
                Head = new SinglyNode<T>(value, null);
                Tail = Head;
                Size++;
                return value;
            }

            if (index >= Size - 1)
            {
                Tail.Next = new SinglyNode<T>(value, null);
                Tail = Tail.Next;
                Size++;
                return value;
            }

            GetNode(index).Next = new SinglyNode<T>(value, GetNode(index).Next);
            Size++;
            return value;
        }

        public T Add(T value)
        {
            return Add(Size, value);
        }

        public void Clear()
        {
            Head = null;
            Size = 0;
            Tail = null;
        }

        public bool Contains(T value)
        {
            foreach (SinglyNode<T> node in Nodes)
            {
                if (value.Equals(node.Value))
                    return true;
            }

            return false;
        }

        public int Count()
        {
            return Size;
        }

        public T Get(int index)
        {
            return GetNode(index).Value;
        }

        private SinglyNode<T> GetNode(int index)
        {
            int counter = 0;
            foreach (SinglyNode<T> node in Nodes)
            {
                if (counter == index)
                    return node;
                
                counter++;
            }

            throw new KeyNotFoundException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (SinglyNode<T> node in Nodes)
                yield return node.Value;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < Size; i++)
            {
                if (GetNode(i).Value.Equals(value))
                    return i;
            }

            return -1;
        }

        public T Remove(int index)
        {
            SinglyNode<T> current = GetNode(index);
            T value = current.Value;

            GetNode(index - 1).Next = current.Next;
            current = null;

            return value;
        }

        public T Set(int index, T value)
        {
            GetNode(index).Value = value;
            return value;
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
