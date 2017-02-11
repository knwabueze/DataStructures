using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class BinarySearchTree : IBinarySearchTree
    {
        public BinaryIntNode RootNode { get; protected set; }
        public int Size { get; protected set; }

        public BinarySearchTree()
        {
            RootNode = null;
            Size = 0;
        }

        public void Delete(BinaryIntNode deleteNode)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public void Insert(BinaryIntNode newNode)
        {
            if (isEmpty())
            {
                RootNode = newNode;
                Size++;
                return;
            }           
        }

        public bool isEmpty()
        {
            return Size == 0;
        }

        public BinaryIntNode IterativeFind(int position)
        {
            throw new NotImplementedException();
        }

        public BinaryIntNode Maximum()
        {
            throw new NotImplementedException();
        }

        public BinaryIntNode Minimum()
        {
            throw new NotImplementedException();
        }

        public void PostOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public void PreOrderTraverse()
        {
            throw new NotImplementedException();
        }

        public BinaryIntNode Search(int key)
        {
            throw new NotImplementedException();
        }
    }
}
