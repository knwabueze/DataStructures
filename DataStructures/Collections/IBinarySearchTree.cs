using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface IBinarySearchTree
    {
        void Insert(int value);
        void Remove(int value);
        void Clear();

        BinarySearchTreeNode[] InOrderTraverse();
        BinarySearchTreeNode[] PreOrderTraverse();
        BinarySearchTreeNode[] PostOrderTraverse();

        BinarySearchTreeNode SearchNode(int key);
        BinarySearchTreeNode IterativeFind(int value);

        int Minimum();
        int Maximum();
    }
}
