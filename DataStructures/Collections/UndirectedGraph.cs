using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class UndirectedGraph<T>
        where T : IComparable<T>
    {
        public ISet<UndirectedGraphVertex<T>> Nodes;

        /// <summary>
        /// Constructs an object of the type UndirectedGraph with initialized nodes.
        /// </summary>
        /// <param name="nodes">Any enumerable type that contains nodes.</param>
        public UndirectedGraph(IEnumerable<UndirectedGraphVertex<T>> nodes)
        {
            Nodes = (ISet<UndirectedGraphVertex<T>>)nodes;
        }

        /// <summary>
        /// Constructs an object of the type UndirectedGraph with initialized values.
        /// </summary>
        /// <param name="values"></param>
        public UndirectedGraph(IEnumerable<T> values)
        {
            Nodes = new HashSet<UndirectedGraphVertex<T>>();
            foreach (var node in values)
            {
                Nodes.Add(new UndirectedGraphVertex<T> { Value = node });
            }
        }

        /// <summary>
        /// Constructs an object of the type UndirectedGraph with no initialized nodes or values.
        /// </summary>
        public UndirectedGraph()
        {
            Nodes = new HashSet<UndirectedGraphVertex<T>>();
        }

        /// <summary>
        /// Creates a new vertex on the graph and returns a reference to it.
        /// </summary>
        /// <returns>Referernce to a node on the graph</returns>
        public UndirectedGraphVertex<T> CreateVertex(T value)
        {
            UndirectedGraphVertex<T> vertex = new UndirectedGraphVertex<T>
            {
                Value = value
            };

            Nodes.Add(vertex);

            return vertex;
        }

        /// <summary>
        /// Inserts a vertex into the undirected graph.
        /// </summary>
        /// <param name="value"></param>
        public void AddVertex(UndirectedGraphVertex<T> value)
        {
            Nodes.Add(value);
        }

        /// <summary>
        /// Tries to make two nodes into neighbors.
        /// </summary>
        /// <param name="a">Node on the graph</param>
        /// <param name="b">Node on the graph</param>
        /// <returns>True if both nodes are on the graph, false otherwise</returns>
        public bool TryAddPair(UndirectedGraphVertex<T> a, UndirectedGraphVertex<T> b)
        {
            if (Nodes.Contains(a) && Nodes.Contains(b))
            {
                a.AddEdge(b);
                b.AddEdge(a);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Attempts to remove a vertex from the graph.
        /// </summary>
        /// <param name="a">Node on tthe graph</param>
        /// <returns></returns>
        public bool TryRemoveVertex(UndirectedGraphVertex<T> a)
        {
            if (Nodes.Contains(a))
            {
                foreach (var neighbor in a.Edges)
                {
                    if (neighbor.Edges.Contains(a))
                    {
                        neighbor.RemoveEdge(a);
                    }
                }

                Nodes.Remove(a);
            }

            return false;
        }

        /// <summary>
        /// Determines whether or not this graph contains the specified vertex.
        /// </summary>
        /// <param name="a">Node on the graph.</param>
        /// <returns>True if the graph contains this vertex, otherwise false</returns>
        public bool HasVertex(UndirectedGraphVertex<T> a)
        {
            return Nodes.Contains(a);
        }

        /// <summary>
        /// Traverses the graph depth first, recursively.
        /// </summary>
        /// <param name="root">Current node on recursive structure</param>
        /// <param name="returnedNodes">List that the nodes will be added</param>
        /// <param name="unvisitedNodes">All unvisited nodes</param>
        private void DepthFirstTraversalR(UndirectedGraphVertex<T> root, System.Collections.Generic.List<UndirectedGraphVertex<T>> returnedNodes,
            ISet<UndirectedGraphVertex<T>> unvisitedNodes = null)
        {
            if (unvisitedNodes == null)
            {
                unvisitedNodes = new HashSet<UndirectedGraphVertex<T>>(Nodes);
            }

            if (unvisitedNodes.Contains(root))
            {
                unvisitedNodes.Remove(root);
            }
            else
            {
                return;
            }

            // base case
            if (!unvisitedNodes.Overlaps(root.Edges))
            {
                returnedNodes.Add(root);
                return;
            }

            else
            {
                foreach (var edge in root.Edges)
                {
                    DepthFirstTraversalR(edge, returnedNodes, unvisitedNodes);
                }

                returnedNodes.Add(root);
                return;
            }
        }

        /// <summary>
        /// Iterates over all the nodes in the graph depth-first, recursively.
        /// </summary>
        /// <param name="root">Node to start on.</param>
        /// <returns></returns>
        public IEnumerable<UndirectedGraphVertex<T>> DepthFirstTraversal(UndirectedGraphVertex<T> root)
        {
            var ret = new System.Collections.Generic.List<UndirectedGraphVertex<T>>();

            DepthFirstTraversalR(root, ret);

            return (ret as IEnumerable<UndirectedGraphVertex<T>>);
        }

        /// <summary>
        /// Iterates over all the nodes in the graph breadth-first, recursively.
        /// </summary>
        /// <param name="root">Node to begin on.</param>
        /// <returns></returns>
        public IEnumerable<UndirectedGraphVertex<T>> BreadthFirstTraversal(UndirectedGraphVertex<T> root)
        {
            UndirectedGraphVertex<T> currentNode = root;
            Queue<UndirectedGraphVertex<T>> waitList = new Queue<UndirectedGraphVertex<T>>();
            System.Collections.Generic.List<UndirectedGraphVertex<T>> visitedNodes = new System.Collections.Generic.List<UndirectedGraphVertex<T>>
            {
                root
            };

            while (true)
            {
                foreach (var neighbor in currentNode.Edges)
                {
                    if (!visitedNodes.Contains(neighbor) && !waitList.Contains(neighbor))
                    {
                        waitList.Enqueue(neighbor);
                    }
                }

                if (waitList.Count == 0) break;

                var nextNode = waitList.Dequeue();
                visitedNodes.Add(nextNode);
                currentNode = nextNode;                
            }

            return visitedNodes;
        }
    }
}
