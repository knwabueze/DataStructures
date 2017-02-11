using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface IBinarySearchTree
    {
        void InOrderTraverse();
        void PreOrderTraverse();
        void PostOrderTraverse();

        BinaryIntNode Search(int key);
        BinaryIntNode IterativeFind(int position);
        BinaryIntNode Minimum();
        BinaryIntNode Maximum();

        void Insert(BinaryIntNode newNode);
        void Delete(BinaryIntNode deleteNode);
        bool isEmpty();
    }
}
