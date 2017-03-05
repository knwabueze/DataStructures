using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class AVLTreeNode<T> : BinarySearchTreeNode<T, AVLTreeNode<T>>
        where T : IComparable
    {
        public AVLTreeNode()
        {
            Height = 1;

            AVLTreeNode<T> current = this;

            while (current.Parent != null)
            {
                if (current.Height == current.Parent.Height)
                    current.Parent.Height++;

                current = current.Parent;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public int Height { get; set; }
        public int Balance
        {
            get
            {
                int left = 0;
                int right = 0;

                if (LeftChild != null)
                    left = LeftChild.Height;

                if (RightChild != null)
                    right = RightChild.Height;

                return left - right;
            }
        }
    }
}