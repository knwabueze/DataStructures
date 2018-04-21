using DataStructures.Exceptions;
using System.Collections;
using System.Collections.Generic;
using Key = System.Int32;
using Weight = System.Single;

namespace DataStructures.Collections
{
    public class DjikstrasWeightedGraph<T> : WeightedGraph<T>
    {
        readonly static Weight? Infinity = null;

        public class VertexMetadata
        {
            public Key? FounderNode;
            public Weight? CumulativeWeight;
            public bool Visited;

            public static VertexMetadata Identity
            {
                get
                {
                    return new VertexMetadata
                    {
                        FounderNode = null,
                        CumulativeWeight = Infinity,
                        Visited = false
                    };
                }
            }
        }

        class WeightComparer : IComparer<(Key, VertexMetadata x)>
        {
            public int Compare((Key, VertexMetadata x) a, (Key, VertexMetadata x) b)
            {
                return a.x.CumulativeWeight == b.x.CumulativeWeight ? 0 : (a.x.CumulativeWeight < b.x.CumulativeWeight ? -1 : 1);
            }
        }        

        /// <summary>
        /// Calculates the shortest path between <paramref name="a"/> and <paramref name="b"/> using Djikstra's Algorithm.
        /// </summary>
        /// <param name="a">Starting node to search from</param>
        /// <param name="b">Destination node to find</param>
        /// <returns>The shortest path from point a to point b and its associated weight</returns>
        public Weight CalculateShortestPath(Key a, Key b)
        {
            var w = CalculateShortestPath(a, b, out var throwAway);

            return w;
        }

        /// <summary>
        /// Calculates the shortest path between <paramref name="a"/> and <paramref name="b"/> using Djikstra's Algorithm.
        /// </summary>
        /// <param name="a">Starting node to search from</param>
        /// <param name="b">Destination node to find</param>
        /// <returns>The shortest path from point a to point b and its associated weight</returns>
        public Weight CalculateShortestPath(Key a, Key b, out Map<Key, VertexMetadata> vertexData)
        {            
            Map<Key, VertexMetadata> vertexMeta = new Map<Key, VertexMetadata>();
            vertexData = vertexMeta;

            PriorityQueue<(Key, VertexMetadata)> q = new PriorityQueue<(Key, VertexMetadata)>();
            List<Key> currentlyEnqueued = new List<Key>();

            foreach (var key in Keys)
            {
                var m = VertexMetadata.Identity;
                vertexMeta.Add(key, m);
            }

            /*
             * Assign the start vertex's known distance to 0 (since it is a distance of 0 from the start vertex!) and add it to a PriorityQueue.
             * The priority of the vertices is their cumulative distance. 
             */
            var aMeta = vertexMeta[a];
            aMeta.CumulativeWeight = 0;

            q.Enqueue((a, aMeta));
            currentlyEnqueued.Add(a);

            do
            {
                var (currentVertex, meta) = q.Dequeue();
                currentlyEnqueued.Remove(currentVertex);

                // Iterate through all neighbors
                for (int i = 0; i < adjMatrix_.Width; ++i)
                {
                    var weight = adjMatrix_[currentVertex, i];
                    if (weight == 0) // these nodes are not connected
                    {
                        continue;
                    }

                    var m = vertexMeta[i];

                    var previousDistance = m.CumulativeWeight;
                    var currentDistance = meta.CumulativeWeight + weight;

                    // first short-circuit evaluate
                    if (!previousDistance.HasValue || currentDistance < previousDistance)
                    {
                        m.CumulativeWeight = currentDistance;
                        m.FounderNode = currentVertex;
                    }

                    //add them if possible
                    if (!currentlyEnqueued.Contains(i) && !m.Visited)
                    {
                        q.Enqueue((i, m));
                        currentlyEnqueued.Add(i);
                    }
                }

                if (vertexMeta[b].Visited == true)
                {
                    return vertexMeta[b].CumulativeWeight.Value;
                }

                meta.Visited = true;

            } while (currentlyEnqueued.Count > 0);

            throw new NoPathBetweenNodesException(a, b);
        }
    }
}
