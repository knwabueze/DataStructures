using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree<T, TNode> : IBinarySearchTree<T, TNode>, IEnumerable<TNode>
        where T : IComparable
        where TNode : BinarySearchTreeNode<T, TNode>, new()
    {
        public TNode Root { get; protected set; }
        public int Size { get; protected set; }
        public bool Empty { get { return Size == 0; } }

        public BinarySearchTree()
        {
            Clear();
        }
        public BinarySearchTree(params T[] nodes)
        {
            Clear();
            foreach (var node in nodes)
                Insert(node);
        }

        public void Clear()
        {
            Size = 0;
            Root = null;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Size++;
                Root = new TNode()
                {
                    Value = value
                };
                return;
            }

            InsertR(Root, value);
        }

        protected void InsertR(TNode parent, T value)
        {
            if (value.CompareTo(parent.Value) > 0)
            {
                if (parent.RightChild == null)
                {
                    Size++;
                    parent.RightChild = new TNode()
                    {
                        Value = value,
                        Parent = parent
                    };
                    return;
                }

                InsertR(parent.RightChild, value);
            }

            else if (value.CompareTo(parent.Value) <= 0)
            {
                if (parent.LeftChild == null)
                {
                    Size++;
                    parent.LeftChild = new TNode()
                    {
                        Value = value,
                        Parent = parent
                    };
                    return;
                }

                InsertR((TNode)parent.LeftChild, value);
            }
        }

        public TNode IterativeFind(T value)
        {
            TNode current = Root;
            do
            {
                if (value.CompareTo(current.Value) < 0)
                    current = current.LeftChild;

                if (value.CompareTo(current.Value) > 0)
                    current = current.RightChild;

                if (value.CompareTo(current.Value) == 0)
                    return current;
            } while (current != null);

            throw new KeyNotFoundException();
        }

        public TNode Maximum()
        {
            TNode current = Root;

            while (current.RightChild != null)
                current = current.RightChild;

            return current;
        }

        public TNode Minimum()
        {
            TNode current = Root;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current;
        }

        public void Remove(T value)
        {
            TNode nodeToBeRemoved = SearchNode(value);
            bool isLeftChild = false;

            if (nodeToBeRemoved.Parent != null)
            {
                if (nodeToBeRemoved.Value.CompareTo(nodeToBeRemoved.Parent.Value) < 0)
                    isLeftChild = true;
                else
                    isLeftChild = false;
            }

            if (Size == 1)
                Root = null;

            else if (nodeToBeRemoved.LeftChild == null && nodeToBeRemoved.RightChild == null)
            {
                if (isLeftChild)
                    nodeToBeRemoved.Parent.LeftChild = null;
                else
                    nodeToBeRemoved.Parent.RightChild = null;

                nodeToBeRemoved = null;
            }

            else if (nodeToBeRemoved.LeftChild != null && nodeToBeRemoved.RightChild != null)
            {
                TNode destination = nodeToBeRemoved.LeftChild;

                while (destination.RightChild != null)
                    destination = destination.RightChild;

                nodeToBeRemoved.Value = destination.Value;

                if (destination.LeftChild != null)
                {
                    destination.LeftChild.Parent = destination.Parent;
                    destination.Parent.LeftChild = destination.LeftChild;
                }

                else
                {
                    destination.Parent.LeftChild = null;
                }

            }

            else if (nodeToBeRemoved.RightChild != null)
            {
                if (nodeToBeRemoved == Root)
                {
                    Root = nodeToBeRemoved.RightChild;
                    Root.Parent = null;
                }

                else if (!isLeftChild)
                {
                    nodeToBeRemoved.Parent.RightChild = nodeToBeRemoved.RightChild;
                    nodeToBeRemoved.RightChild.Parent = nodeToBeRemoved.Parent;
                }

                else
                {
                    nodeToBeRemoved.Parent.LeftChild = nodeToBeRemoved.RightChild;
                    nodeToBeRemoved.RightChild.Parent = nodeToBeRemoved.Parent;
                }
            }

            else if (nodeToBeRemoved.LeftChild != null)
            {
                if (nodeToBeRemoved == Root)
                {
                    Root = nodeToBeRemoved.LeftChild;
                    Root.Parent = null;
                }

                else if (!isLeftChild)
                {
                    nodeToBeRemoved.Parent.RightChild = nodeToBeRemoved.LeftChild;
                    nodeToBeRemoved.LeftChild.Parent = nodeToBeRemoved.Parent;
                }

                else
                {
                    nodeToBeRemoved.Parent.LeftChild = nodeToBeRemoved.LeftChild;
                    nodeToBeRemoved.LeftChild.Parent = nodeToBeRemoved.Parent;
                }
            }

            Size--;
        }

        protected TNode SearchNodeR(TNode current, T key)
        {
            if (key.CompareTo(current.Value) < 0)
                return SearchNodeR(current.LeftChild, key);

            if (key.CompareTo(current.Value) > 0)
                return SearchNodeR(current.RightChild, key);

            if (key.CompareTo(current.Value) == 0)
                return current;

            throw new KeyNotFoundException();
        }

        public TNode SearchNode(T key)
        {
            return SearchNodeR(Root, key);
        }

        public TNode[] InOrderTraverse()
        {
            List<TNode> keys = new List<TNode>(Size);

            InOrderTraverseR(ref keys, Root);

            return keys.ToArray();
        }

        protected void InOrderTraverseR(ref List<TNode> list, TNode current)
        {
            if (current == null)
                return;

            InOrderTraverseR(ref list, current.LeftChild);

            list.Add(current);

            InOrderTraverseR(ref list, current.RightChild);
        }

        public TNode[] PreOrderTraverse()
        {
            List<TNode> keys = new List<TNode>(Size);

            PreOrderTraverseR(ref keys, Root);

            return keys.ToArray();
        }

        protected void PreOrderTraverseR(ref List<TNode> list, TNode current)
        {
            if (current == null)
                return;

            PreOrderTraverseR(ref list, current.RightChild);

            list.Add(current);

            PreOrderTraverseR(ref list, current.LeftChild);
        }

        public TNode[] PostOrderTraverse()
        {
            List<TNode> keys = new List<TNode>(Size);

            PostOrderTraverseR(ref keys, Root);

            return keys.ToArray();
        }

        protected void PostOrderTraverseR(ref List<TNode> list, TNode current)
        {
            if (current == null)
                return;

            PostOrderTraverseR(ref list, current.LeftChild as TNode);

            PostOrderTraverseR(ref list, current.RightChild as TNode);

            list.Add(current);
        }

        public IEnumerator<TNode> GetEnumerator()
        {
            foreach (var val in InOrderTraverse())
                yield return val;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class BinarySearchTree<T> : BinarySearchTree<T, BinarySearchTreeNode<T>>
        where T : IComparable
    {
        public BinarySearchTree() : base()
        {
        }
        public BinarySearchTree(params T[] nodes) : base(nodes)
        {
        }
    }
}
