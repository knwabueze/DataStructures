using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class UndirectedGraphVertexEqualityComparer<T> : IEqualityComparer<UndirectedGraphVertex<T>>
        where T : IComparable<T>
    {
        public bool Equals(UndirectedGraphVertex<T> x, UndirectedGraphVertex<T> y)
        {
            return x.Value.CompareTo(y.Value) == 0;
        }

        public int GetHashCode(UndirectedGraphVertex<T> obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
