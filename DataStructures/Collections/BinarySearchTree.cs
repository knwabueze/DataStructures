using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree : IBinarySearchTree
    {
        public BinarySearchTreeNode Root { get; private set; }

        public int Size { get; private set; }

        public bool Empty { get { return Size == 0; } }

        public BinarySearchTree()
        {
            Clear();
        }

        public BinarySearchTree(params int[] nodes)
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

        public void Insert(int value)
        {
            if (Root == null)
            {
                Size++;
                Root = new BinarySearchTreeNode(value);
                return;
            }

            InsertR(Root, value);
        }

        private void InsertR(BinarySearchTreeNode parent, int value)
        {
            if (value > parent.Value)
            {
                if (parent.RightChild == null)
                {
                    Size++;
                    parent.RightChild = new BinarySearchTreeNode(value)
                    {
                        Parent = parent
                    };
                    return;
                }

                InsertR(parent.RightChild, value);
            }

            else if (value <= parent.Value)
            {
                if (parent.LeftChild == null)
                {
                    Size++;
                    parent.LeftChild = new BinarySearchTreeNode(value)
                    {
                        Parent = parent
                    };
                    return;
                }

                InsertR(parent.LeftChild, value);
            }
        }

        public BinarySearchTreeNode IterativeFind(int value)
        {
            BinarySearchTreeNode current = Root;
            do
            {
                if (value < current.Value)
                    current = current.LeftChild;

                if (value > current.Value)
                    current = current.RightChild;

                if (value == current.Value)
                    return current;
            } while (current != null);

            throw new KeyNotFoundException();
        }

        public int Maximum()
        {
            BinarySearchTreeNode current = Root;

            while (current.RightChild != null)
                current = current.RightChild;

            return current.Value;
        }

        public int Minimum()
        {
            BinarySearchTreeNode current = Root;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        public void Remove(int value)
        {
            BinarySearchTreeNode current = SearchNode(value);
            bool isLeftChild = false;

            // Check if current is left child or right child of parent if has parent
            if (current.Parent != null)
            {
                if (current.Value < current.Parent.Value)
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
                BinarySearchTreeNode destination = current.LeftChild;

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
                BinarySearchTreeNode destination = current.LeftChild;
                current.Value = destination.Value;
                current.LeftChild = destination.LeftChild;
                current.RightChild = destination.RightChild;
                destination = null;
            }

            // Move Right Child
            else if (current.LeftChild == null)
            {
                BinarySearchTreeNode destination = current.RightChild;
                current.Value = destination.Value;
                current.LeftChild = destination.LeftChild;
                current.RightChild = destination.RightChild;
                destination = null;
            }

            Size--;
        }

        private BinarySearchTreeNode SearchNodeR(BinarySearchTreeNode current, int key)
        {
            if (key < current.Value)
                return SearchNodeR(current.LeftChild, key);

            if (key > current.Value)
                return SearchNodeR(current.RightChild, key);

            if (key == current.Value)
                return current;

            throw new KeyNotFoundException();
        }

        public BinarySearchTreeNode SearchNode(int key)
        {
            return SearchNodeR(Root, key);
        }

        public BinarySearchTreeNode[] InOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public BinarySearchTreeNode[] PreOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public BinarySearchTreeNode[] PostOrderTraverse()
        {
            throw new NotImplementedException();
        }
    }
}
