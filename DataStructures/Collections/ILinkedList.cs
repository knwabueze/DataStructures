using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface ILinkedList<T>
    {
        T Add(int index, T value);        
        T Add(T value);
        T Remove(int index);

        T Get(int index);
        T Set(int index, T value);

        int IndexOf(T value);        
        bool Contains(T value);        

        int Count();        
        void Clear();
    }
}
