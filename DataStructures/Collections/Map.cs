using DataStructures.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class Map<K, V> : IEnumerable<V>
        where V : IComparable
    {
        private BinarySearchTree<KeyValuePair<K, V>> backend;

        public Map()
        {
            backend = new BinarySearchTree<KeyValuePair<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                var query = backend.InOrderTraverse()
                    .Where(t => key.Equals(t.Value.Key))
                    .Select(t => t.Value.Value);

                return query.First();
            }
            set
            {
                var query =
                   from t in backend.InOrderTraverse()
                   where key.Equals(t.Value.Key)
                   select t.Value;

                backend.SearchNode(query.First()).Value.Value = value;
            }
        }

        public void Add(K key, V value)
        {
            var query =
                from t in backend.InOrderTraverse()
                where key.Equals(t.Value.Key)
                select t.Value;

            if (!query.Any())
            {
                backend.Insert(new KeyValuePair<K, V>()
                {
                    Key = key,
                    Value = value
                });
                return;
            }

            throw new KeyAlreadyExistsException();
        }

        public void Remove(K key)
        {
            var query =
                from t in backend.InOrderTraverse()
                where key.Equals(t.Value.Key)
                select t.Value;

            backend.Remove(query.First());
        }

        public IEnumerator<V> GetEnumerator()
        {
            var arr = backend.InOrderTraverse();

            foreach (var value in arr)
                yield return value.Value.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
