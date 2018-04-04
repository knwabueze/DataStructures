using Key = System.Int32;
using Weight = System.Single;
using AdjacencyMatrix = DataStructures.Collections.DynamicMatrix2D<float>;

using System.Collections.Generic;

namespace DataStructures.Collections
{
    /// <summary>
    /// An object of the type WeightedGraph where T can be either a class, struct, or primitive.
    /// <para/>
    /// This object represents a weighted, directed graph data structure.
    /// </summary>
    /// <typeparam name="T">Value type represented by the nodes of the graph</typeparam>
    public class WeightedGraph<T>
    {
        AdjacencyMatrix adjMatrix_;
        Map<Key, T> valueMap_; // TODO: Replace this with a hash map vs. a bin-search tree.
        HashSet<Key> blackList_; // The only way to do deletion in order not to mess anything up is to just blacklist certain nodes. 

        /// <summary>
        /// Gets/sets value of the specified key.
        /// </summary>
        /// <param name="k">Key to modify</param>
        /// <returns>Value associated with <paramref name="k"/></returns>
        public T this[Key k]
        {
            get => valueMap_[k];
            set => valueMap_[k] = value;
        }

        /// <summary>
        /// Gets/sets the weight of the connection of <paramref name="a"/> to <paramref name="b"/>.
        /// </summary>
        /// <param name="a">Node pointing to <paramref name="b"/></param>
        /// <param name="b">Node being pointed at by <paramref name="a"/></param>
        /// <returns></returns>
        public Weight this[Key a, Key b]
        {
            get => adjMatrix_[a, b];
            set => adjMatrix_[a, b] = value;
        }

        /// <summary>
        /// Initializes an object of the type WeightedGraph with zero elements.
        /// </summary>
        public WeightedGraph()
        {
            adjMatrix_ = new AdjacencyMatrix(0, 0);
            valueMap_ = new Map<Key, T>();
            blackList_ = new HashSet<Key>();
        }

        /// <summary>
        /// Inserts a value into the graph and returns the index in which references the inserted node.
        /// </summary>
        /// <param name="value">Value attached to the to-be-inserted node</param>
        /// <returns></returns>
        public Key InsertNode(T value)
        {
            adjMatrix_.AddDepth(1);

            Key idx = adjMatrix_.Width - 1;

            valueMap_.Add(idx, value);

            return idx;
        }

        /// <summary>
        /// Assigns a <paramref name="weight"/> (and by definition direction) between the vertices represented by <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">Node that will point to <paramref name="b"/></param>
        /// <param name="b">Node that will be pointed to by <paramref name="a"/></param>
        /// <param name="weight">Any non-zero (zero is used to state that their is no connection between two nodes) value representing weight.</param>
        /// <returns>A tuple of (<paramref name="a"/>, <paramref name="b"/>)</returns>
        public (Key, Key) AssignEdge(Key a, Key b, Weight weight)
        {
            if (a > adjMatrix_.Width || b > adjMatrix_.Width || a < 0 || b < 0 || blackList_.Contains(a) || blackList_.Contains(b))
            {
                throw new System.Exception("One of the two nodes are not found in this graph.");
            }

            adjMatrix_[a, b] = weight;

            return (a, b);
        }

        /// <summary>
        /// Unassigns a connect between the vertices represented by <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">Node that will no longer point to <paramref name="b"/></param>
        /// <param name="b">Node that will no longer be pointed at by <paramref name="a"/></param>
        public void UnassignEdge(Key a, Key b)
        {
            if (a > adjMatrix_.Width || b > adjMatrix_.Width || a < 0 || b < 0 || blackList_.Contains(a) || blackList_.Contains(b))
            {
                throw new System.Exception("One of the two nodes are not found in this graph.");
            }

            adjMatrix_[a, b] = 0;
        }

        /// <summary>
        /// Removes a node from the graph. (Just zeroes out values from adjacency matrix, there is no such thing as deletion!)
        /// </summary>
        /// <param name="node">Key of the node that will be deleted.</param>
        /// <returns><paramref name="node"/> that was passed in.</returns>
        public Key RemoveNode(Key node)
        {
            if (node > adjMatrix_.Width || node < 0 || blackList_.Contains(node))
            {
                throw new System.Exception("This node is not in this graph.");
            }

            for (int i = 0; i < adjMatrix_.Width; ++i)
            {
                adjMatrix_[node, i] = 0;
                adjMatrix_[i, node] = 0;
            }

            blackList_.Add(node);
            valueMap_.Remove(node);

            return node;
        }

        /// <summary>
        /// Returns the first key inserted into the graph that matches the value. (only really useful where each value is unique)
        /// </summary>
        /// <param name="value">Value that the key will be searched with</param>
        /// <returns>First <see cref="Key"/> that has a value of <paramref name="value"/>, returns -1 if key not found</returns>
        public Key FindFirstKeyByValue(T value)
        {
            Key k = -1;

            foreach (var kv in valueMap_)
            {
                if (kv.Value.Equals(value))
                {
                    k = kv.Key;
                    break;
                }
            }

            return k;
        }

        /// <summary>
        /// Returns the all keys inserted into the graph that matches the value.
        /// </summary>
        /// <param name="value">Value that the keys will be searched with</param>
        /// <returns><see cref="Key"/>s that have a value of <paramref name="value"/>, returns empty IEnumerable if there are no keys</returns>
        public IEnumerable<Key> FindKeysByValue(T value)
        {
            foreach (var kv in valueMap_)
            {
                if (kv.Value.Equals(value))
                {
                    yield return kv.Key;
                }
            }
        }

        public override string ToString()
        {
            return adjMatrix_.ToString();
        }
    }
}
