using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree<TKey> : IBinarySearchTree<BinarySearchTreeNode<TKey>, TKey>
        where TKey : IComparable
    {
        public BinarySearchTreeNode<TKey> Root { get; private set; }

        public int Size { get; private set; }

        public bool Empty { get { return Size == 0; } }

        public BinarySearchTree()
        {
            Clear();
        }

        public BinarySearchTree(params TKey[] nodes)
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

        public void Insert(TKey value)
        {
            if (Root == null)
            {
                Size++;
                Root = new BinarySearchTreeNode<TKey>(value);
                return;
            }

            InsertR(Root, value);
        }

        private void InsertR(BinarySearchTreeNode<TKey> parent, TKey value)
        {
            if (value.CompareTo(parent.Value) > 0)
            {
                if (parent.RightChild == null)
                {
                    Size++;
                    parent.RightChild = new BinarySearchTreeNode<TKey>(value)
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
                    parent.LeftChild = new BinarySearchTreeNode<TKey>(value)
                    {
                        Parent = parent
                    };
                    return;
                }

                InsertR(parent.LeftChild, value);
            }
        }

        public BinarySearchTreeNode<TKey> IterativeFind(TKey value)
        {
            BinarySearchTreeNode<TKey> current = Root;
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

        public TKey Maximum()
        {
            BinarySearchTreeNode<TKey> current = Root;

            while (current.RightChild != null)
                current = current.RightChild;

            return current.Value;
        }

        public TKey Minimum()
        {
            BinarySearchTreeNode<TKey> current = Root;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        public void Remove(TKey value)
        {
            BinarySearchTreeNode<TKey> current = SearchNode(value);
            bool isLeftChild = false;

            // Check if current is left child or right child of parent if has parent
            if (current.Parent != null)
            {
                if (current.Value.CompareTo(current.Parent.Value) < 0)
                    isLeftChild = true;
                else
                    isLeftChild = false;
            }

            // Case 1: If children don't exist
            if (current.LeftChild == null && current.RightChild == null)
            {
                if (isLeftChild)
                    current.Parent.LeftChild = null;
                else
                    current.Parent.RightChild = null;

                current = null;
            }

            // Case 2: If both children exist
            // Favor Left : Go one left that continue to go right
            else if (current.LeftChild != null && current.RightChild != null)
            {
                BinarySearchTreeNode<TKey> destination = current.LeftChild;

                while (destination.RightChild != null)
                    destination = destination.RightChild;

                current.Value = destination.Value;

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

            // Case 3: If one child exists

            // Move Left Child
            else if (current.RightChild == null)
            {
                BinarySearchTreeNode<TKey> destination = current.LeftChild;
                current.Value = destination.Value;
                current.LeftChild = destination.LeftChild;
                current.RightChild = destination.RightChild;
                destination = null;
            }

            // Move Right Child
            else if (current.LeftChild == null)
            {
                BinarySearchTreeNode<TKey> destination = current.RightChild;
                current.Value = destination.Value;
                current.LeftChild = destination.LeftChild;
                current.RightChild = destination.RightChild;
                destination = null;
            }

            Size--;
        }

        private BinarySearchTreeNode<TKey> SearchNodeR(BinarySearchTreeNode<TKey> current, TKey key)
        {
            if (key.CompareTo(current.Value) < 0)
                return SearchNodeR(current.LeftChild, key);

            if (key.CompareTo(current.Value) < 0)
                return SearchNodeR(current.RightChild, key);

            if (key.CompareTo(current.Value) == 0)
                return current;

            throw new KeyNotFoundException();
        }

        public BinarySearchTreeNode<TKey> SearchNode(TKey key)
        {
            return SearchNodeR(Root, key);
        }

        public BinarySearchTreeNode<TKey>[] InOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public BinarySearchTreeNode<TKey>[] PreOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public BinarySearchTreeNode<TKey>[] PostOrderTraverse()
        {
            throw new NotImplementedException();
        }
    }
}
