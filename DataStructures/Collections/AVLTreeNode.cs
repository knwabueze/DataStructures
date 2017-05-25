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
            return Value.ToString() + "( Balance: " + Balance + "," + "Height: " + Height + ")";
        }

        public void SwitchValuesWithNode(AVLTreeNode<T> node)
        {
            var intermediateValue = this.Value;
            Value = node.Value;
            node.Value = intermediateValue;
        }

        public int Height
        {
            get
            {
                if (LeftChild == null && RightChild == null)
                    return 1;

                int left = 0;
                int right = 0;

                if (LeftChild != null)
                    left = LeftChild.Height;
                if (RightChild != null)
                    right = RightChild.Height;

                return Math.Max(left, right) + 1;
            }
        }
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

                return right - left;
            }
        }
    }
}