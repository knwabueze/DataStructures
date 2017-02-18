using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface IBinarySearchTree<TNode, TKey>
        where TKey : IComparable
        where TNode : INode<TKey>
    {
        void Insert(TKey value);
        void Remove(TKey value);
        void Clear();

        TNode[] InOrderTraverse();
        TNode[] PreOrderTraverse();
        TNode[] PostOrderTraverse();

        TNode SearchNode(TKey key);
        TNode IterativeFind(TKey key);

        TKey Minimum();
        TKey Maximum();
    }
}
