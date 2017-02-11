using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        T Add(int index, T value);
        
        T Add(T value);

        int IndexOf(T value);

        T Remove(int index);

        bool Contains(T value);

        T Get(int index);

        int Count();

        T Set(int index, T value);

        void Clear();
    }
}
