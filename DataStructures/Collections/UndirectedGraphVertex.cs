using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class UndirectedGraphVertex<T>
        where T : IComparable<T>
    {
        public ISet<UndirectedGraphVertex<T>> Edges { get; private set; }
        public T Value { get; set; }

        public UndirectedGraphVertex()
        {
            Edges = new HashSet<UndirectedGraphVertex<T>>();
        }

        public void AddEdge(UndirectedGraphVertex<T> other)
        {
            Edges.Add(other);
        }

        public void RemoveEdge(UndirectedGraphVertex<T> other)
        {
            Edges.Remove(other);
        }
    }
}
