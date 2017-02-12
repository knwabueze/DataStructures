using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree : ITree<int>, IEnumerable<int>
    {
        public BinaryTreeIntNode Root
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

        private IEnumerable<BinaryTreeIntNode> Nodes
        {
            get
            {
                BinaryTreeIntNode current = Root;
                while (current.RightChild != null)
                {
                    yield return current;
                    current = current.RightChild;
                }

                current = Root.LeftChild;
                while (current.LeftChild != null)
                {
                    yield return current;
                    current = current.LeftChild;
                }
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

        public void InOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Size++;
                Root = new BinaryTreeIntNode(value);
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

        private void InsertR(BinaryTreeIntNode parent, BinaryTreeIntNode child, int value)
        {

            if (parent.Value < value)
            {
                if (child == null)
                {
                    Size++;
                    child = new BinaryTreeIntNode(value);
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
                    child = new BinaryTreeIntNode(value);
                    child.Parent = parent;
                    parent.LeftChild = child;
                    child.RightChild = null;
                    child.LeftChild = null;
                    return;
                }

                InsertR(child, child.LeftChild, value);
            }
        }

        public INode<int> IterativeFind(int position)
        {
            throw new NotImplementedException();
        }

        public int Maximum()
        {
            BinaryTreeIntNode current = Root;

            while (current.RightChild != null)
                current = current.RightChild;

            return current.Value;
        }

        public int Minimum()
        {
            BinaryTreeIntNode current = Root;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        public void PostOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public void PreOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public void Remove(int value)
        {
            throw new NotImplementedException();
        }

        private BinaryTreeIntNode SearchNodeR(BinaryTreeIntNode current, int key)
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

        public INode<int> SearchNode(int key)
        {
            return SearchNodeR(Root, key);
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (BinaryTreeIntNode node in Nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
