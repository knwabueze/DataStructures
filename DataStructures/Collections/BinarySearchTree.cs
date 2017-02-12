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
        public BinarySearchTreeNode Root
        {
            get;
            private set;
        }

        public int Size
        {
            get;
            private set;
        }

        public bool Empty
        {
            get
            {
                return Size == 0;
            }
        }

        public BinarySearchTree()
        {
            Clear();
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
                Root.Parent = null;
                Root.LeftChild = null;
                Root.RightChild = null;
                return;
            }

            if (value <= Root.Value)
            {
                InsertR(Root, Root.LeftChild, value);
            }

            if (value > Root.Value)
            {
                InsertR(Root, Root.RightChild, value);
            }
        }

        private void InsertR(BinarySearchTreeNode parent, BinarySearchTreeNode child, int value)
        {

            if (parent.Value < value)
            {
                if (child == null)
                {
                    Size++;
                    child = new BinarySearchTreeNode(value);
                    child.Parent = parent;
                    parent.RightChild = child;
                    child.RightChild = null;
                    child.LeftChild = null;
                    return;
                }

                InsertR(child, child.RightChild, value);
            }

            if (parent.Value >= value)
            {
                if (child == null)
                {
                    Size++;
                    child = new BinarySearchTreeNode(value);
                    child.Parent = parent;
                    parent.LeftChild = child;
                    child.RightChild = null;
                    child.LeftChild = null;
                    return;
                }

                InsertR(child, child.LeftChild, value);
            }
        }

        public BinarySearchTreeNode IterativeFind(int value)
        {
            BinarySearchTreeNode current = Root;

            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;

                if (value > current.Value)
                    current = current.RightChild;

                if (value == current.Value)
                    return current;
            }

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
            throw new NotImplementedException();
        }

        private BinarySearchTreeNode SearchNodeR(BinarySearchTreeNode current, int key)
        {
            if (key < current.Value)
            {
                return SearchNodeR(current.LeftChild, key);
            }

            if (key > current.Value)
            {
                return SearchNodeR(current.RightChild, key);
            }

            if (key == current.Value)
            {
                return current;
            }

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
