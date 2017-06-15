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
        }

        public override string ToString()
        {
            return Value.ToString() + "( Balance: " + Balance + "," + "Height: " + GetHeight() + ")";
        }        

        public bool HasChildren()
        {
            bool left = false;
            bool right = false;

            if (LeftChild != null)
            {
                left = true;
            }

            if (RightChild != null)
            {
                right = true;
            }

            return left || right;
        }

        public int GetHeight()
        {
            if (LeftChild == null && RightChild == null)
                return 1;

            int left = 0;
            int right = 0;

            if (LeftChild != null)
                left = LeftChild.GetHeight();
            if (RightChild != null)
                right = RightChild.GetHeight();

            return Math.Max(left, right) + 1;
        }
        public int Balance
        {
            get
            {
                int left = 0;
                int right = 0;

                if (LeftChild != null)
                    left = LeftChild.GetHeight();

                if (RightChild != null)
                    right = RightChild.GetHeight();

                return right - left;
            }
        }
    }
}