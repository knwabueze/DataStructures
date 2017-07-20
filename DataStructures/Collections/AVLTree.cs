using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public class AVLTree<T> : BinarySearchTree<T, AVLTreeNode<T>>
        where T : IComparable
    {
        public new AVLTreeNode<T> Insert(T value)
        {
            AVLTreeNode<T> node = base.Insert(value);
            CheckBalance(node);
            return node;
        }

        public new void Remove(T value)
        {
            AVLTreeNode<T> parent = base.SearchNode(value).Parent;
            base.Remove(value);
            CheckBalance(parent);
        }

        protected void CheckBalance(AVLTreeNode<T> subject)
        {
            if (subject.Balance > 1)
            {
                RotateLeft(subject);
            }

            else if (subject.Balance < -1)
            {
                RotateRight(subject);
            }

            if (subject == Root)
                return;

            CheckBalance(subject.Parent);
        }

        protected void RotateLeft(AVLTreeNode<T> subject)
        {
            // Collect references for nodes involved in rotation
            var fulcrum = subject.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var subjectParent = subject.Parent;

            if (leftFulcrum != null)
            {
                if (fulcrum.Balance != 1)
                {
                    RotateRight(fulcrum);
                    fulcrum = leftFulcrum;
                    leftFulcrum = fulcrum.LeftChild;
                }

            }
            subject.RightChild = leftFulcrum;

            if (subject != Root)
            {
                if (subjectParent.LeftChild == subject) subjectParent.LeftChild = fulcrum;

                else subjectParent.RightChild = fulcrum;

                fulcrum.Parent = subjectParent;
            }
            else
            {
                fulcrum.Parent = null;
                Root = fulcrum;
            }


            fulcrum.LeftChild = subject;
            subject.Parent = fulcrum;
        }

        protected void RotateRight(AVLTreeNode<T> subject)
        {
            var fulcrum = subject.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var subjectParent = subject.Parent;            

            if (rightFulcrum != null)
            {
                if (fulcrum.Balance != -1)
                {
                    RotateLeft(fulcrum);
                    fulcrum = rightFulcrum;
                    rightFulcrum = fulcrum.RightChild;
                }
            }
            subject.LeftChild = rightFulcrum;

            if (subject != Root)
            {
                if (subjectParent.LeftChild == subject) subjectParent.LeftChild = fulcrum;

                else subjectParent.RightChild = fulcrum;

                fulcrum.Parent = subjectParent;
            }
            else
            {
                fulcrum.Parent = null;
                Root = fulcrum;
            }

            fulcrum.RightChild = subject;
            subject.Parent = fulcrum;
        }

        public AVLTree() : base()
        {
        }
    }
}