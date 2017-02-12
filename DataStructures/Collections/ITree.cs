using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface ITree<T>
    {
        void Insert(T value);
        void Remove(T value);
        void Clear();

        void InOrderTraverse();
        void PreOrderTraverse();
        void PostOrderTraverse();
        
        INode<T> SearchNode(int key);
        INode<T> IterativeFind(int position);

        T Minimum();
        T Maximum();
    }
}
