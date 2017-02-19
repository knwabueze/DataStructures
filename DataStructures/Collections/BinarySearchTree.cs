using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; private set; }
        public int Size { get; private set; }
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
                Root = new BinarySearchTreeNode<T>(value);
                return;
            }

            InsertR(Root, value);
        }

        private void InsertR(BinarySearchTreeNode<T> parent, T value)
        {
            if (value.CompareTo(parent.Value) > 0)
            {
                if (parent.RightChild == null)
                {
                    Size++;
                    parent.RightChild = new BinarySearchTreeNode<T>(value)
                    {
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
                    parent.LeftChild = new BinarySearchTreeNode<T>(value)
                    {
                        Parent = parent
                    };
                    return;
                }

                InsertR(parent.LeftChild, value);
            }
        }

        public BinarySearchTreeNode<T> IterativeFind(T value)
        {
            BinarySearchTreeNode<T> current = Root;
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

        public BinarySearchTreeNode<T> Maximum()
        {
            BinarySearchTreeNode<T> current = Root;

            while (current.RightChild != null)
                current = current.RightChild;

            return current;
        }

        public BinarySearchTreeNode<T> Minimum()
        {
            BinarySearchTreeNode<T> current = Root;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current;
        }

        public void Remove(T value)
        {
            BinarySearchTreeNode<T> nodeToBeRemoved = SearchNode(value);
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
                BinarySearchTreeNode<T> destination = nodeToBeRemoved.LeftChild;

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

        private BinarySearchTreeNode<T> SearchNodeR(BinarySearchTreeNode<T> current, T key)
        {
            if (key.CompareTo(current.Value) < 0)
                return SearchNodeR(current.LeftChild, key);

            if (key.CompareTo(current.Value) > 0)
                return SearchNodeR(current.RightChild, key);

            if (key.CompareTo(current.Value) == 0)
                return current;

            throw new KeyNotFoundException();
        }

        public BinarySearchTreeNode<T> SearchNode(T key)
        {
            return SearchNodeR(Root, key);
        }

        public BinarySearchTreeNode<T>[] InOrderTraverse()
        {
            List<BinarySearchTreeNode<T>> keys = new List<BinarySearchTreeNode<T>>(Size); 

            InOrderTraverseR(ref keys, Root);

            return keys.ToArray();        
        }

        private void InOrderTraverseR(ref List<BinarySearchTreeNode<T>> list, BinarySearchTreeNode<T> current)
        {
            if (current == null)
                return;

            InOrderTraverseR(ref list, current.LeftChild);

            list.Add(current);

            InOrderTraverseR(ref list, current.RightChild);
        }

        public BinarySearchTreeNode<T>[] PreOrderTraverse()
        {
            List<BinarySearchTreeNode<T>> keys = new List<BinarySearchTreeNode<T>>(Size);

            PreOrderTraverseR(ref keys, Root);

            return keys.ToArray();
        }

        private void PreOrderTraverseR(ref List<BinarySearchTreeNode<T>> list, BinarySearchTreeNode<T> current)
        {
            if (current == null)
                return;

            PreOrderTraverseR(ref list, current.RightChild);

            list.Add(current);

            PreOrderTraverseR(ref list, current.LeftChild);
        }

        public BinarySearchTreeNode<T>[] PostOrderTraverse()
        {
            List<BinarySearchTreeNode<T>> keys = new List<BinarySearchTreeNode<T>>(Size);

            PostOrderTraverseR(ref keys, Root);

            return keys.ToArray();
        }

        private void PostOrderTraverseR(ref List<BinarySearchTreeNode<T>> list, BinarySearchTreeNode<T> current)
        {
            if (current == null)
                return;

            PostOrderTraverseR(ref list, current.LeftChild);

            PostOrderTraverseR(ref list, current.RightChild);

            list.Add(current);
        }
    }
}
