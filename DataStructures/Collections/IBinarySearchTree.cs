using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface IBinarySearchTree<T, TNode>
        where T : IComparable
        where TNode : INode<T>
    {
        void Insert(T value);
        void Remove(T value);
        void Clear();

        TNode[] InOrderTraverse();
        TNode[] PreOrderTraverse();
        TNode[] PostOrderTraverse();
        
        TNode SearchNode(T key);
        TNode IterativeFind(T key);

        TNode Minimum();
        TNode Maximum();
    }
}
