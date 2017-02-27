using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class KeyValuePair<K, V> : IComparable
        where K : IComparable
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public int CompareTo(object obj)
        {
            KeyValuePair<K, V> toBeCompared = obj as KeyValuePair<K, V>;
            return Key.CompareTo(toBeCompared.Key);
        }
    }
}
