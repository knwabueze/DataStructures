using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface IBinarySearchTree<TKey>
        where TKey : IComparable
    {
        void Insert(TKey value);
        void Remove(TKey value);
        void Clear();

        BinarySearchTreeNode<TKey>[] InOrderTraverse();
        BinarySearchTreeNode<TKey>[] PreOrderTraverse();
        BinarySearchTreeNode<TKey>[] PostOrderTraverse();

        BinarySearchTreeNode<TKey> SearchNode(TKey key);
        BinarySearchTreeNode<TKey> IterativeFind(TKey key);

        BinarySearchTreeNode<TKey> Minimum();
        BinarySearchTreeNode<TKey> Maximum();
    }
}
