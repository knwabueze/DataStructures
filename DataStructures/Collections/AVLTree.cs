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

        //public new void Remove(T value)
        //{
        //   // AVLTreeNode<T> shiftNode = SearchNode(value).Parent;

        //    base.Remove(value);

        //    //if (shiftNode != null)
        //      //  CheckBalance(shiftNode);
        //}

        protected void CheckBalance(AVLTreeNode<T> subject)
        {
            // right top heavy
            if (subject.Balance > 1)
            {
                RotateLeft(subject);
            }

            // left top heavy
            else if (subject.Balance < -1)
            {
                RotateRight(subject);
            }

            if (subject == Root)
                return;

            CheckBalance(subject.Parent);
        }

        //       x        
        //      / \
        //     s   f
        protected void RotateLeft(AVLTreeNode<T> subject)
        {
            #region Deprecated RotateLeft
            //AVLTreeNode<T> newNode = subject.RightChild;

            //while (newNode.LeftChild != null)
            //    newNode = newNode.LeftChild;

            ////subject.LeftChild = subject.Parent;
            ////subject.Parent = subject.LeftChild.Parent;

            //newNode.Parent.LeftChild = null;

            //newNode = subject.Parent;
            //subject.Parent = newNode.LeftChild.Parent;

            ////if (subject.LeftChild == Root)
            ////    Root = subject;

            //if (newNode.LeftChild == Root)
            //    Root = subject;

            ////subject.LeftChild.Parent = subject;
            ////subject.LeftChild.RightChild = null;

            //newNode.LeftChild.Parent = subject;
            //newNode.LeftChild.RightChild = null;

            ////{
            ////    Root.Height--;
            ////    List<AVLTreeNode<T>> query = new List<AVLTreeNode<T>>();
            ////    InOrderTraverseR(ref query, subject.LeftChild);

            ////    foreach (var result in query)
            ////        result.Height -= 2;

            ////}

            //{
            //    Root.Height--;
            //    List<AVLTreeNode<T>> query = new List<AVLTreeNode<T>>();
            //    InOrderTraverseR(ref query, newNode);

            //    foreach (var result in query)
            //        result.Height -= 2;
            //}

            ////if (subject.Parent == null)
            ////    return;

            ////else if (subject.Value.CompareTo(subject.Parent.Value) <= 0)
            ////    subject.Parent.LeftChild = subject;

            ////else
            ////    subject.Parent.RightChild = subject;

            //if (subject.Parent == null)
            //    return;

            //else if (subject.Value.CompareTo(subject.Parent.Value) <= 0)
            //    subject.Parent.LeftChild = subject;

            //else
            //    subject.Parent.RightChild = subject;
            #endregion

            AVLTreeNode<T> elect = subject.RightChild;

            while (elect.LeftChild != null)
                elect = elect.LeftChild;

            // Check if double rotation
            if (subject.RightChild != elect)
            {
                // This check doesn't make anysense, revise
                //if (elect.LeftChild != null)
                //{
                //    elect.LeftChild.Parent = subject;
                //    subject.RightChild = elect.LeftChild;
                //}                

                subject.RightChild.Parent = elect;
                subject.RightChild.LeftChild = null;
                elect.RightChild = subject.RightChild;
                subject.RightChild = null;
            }
            if (subject != Root)
            {
                elect.Parent = subject.Parent;

                if (subject.Parent.LeftChild == subject)
                    elect.Parent.LeftChild = elect;

                else
                    subject.Parent.RightChild = elect;
            }
            else
            {
                elect.Parent = null;
                Root = elect;
            }

            subject.RightChild = null;
            elect.LeftChild = subject;
            subject.Parent = elect;
        }

        protected void RotateRight(AVLTreeNode<T> subject)
        {
            #region Deprecated RotateRight
            //subject.RightChild = subject.Parent;
            //subject.Parent = subject.RightChild.Parent;

            //if (subject.RightChild == Root)
            //    Root = subject;

            //subject.RightChild.Parent = subject;
            //subject.RightChild.LeftChild = null;

            //{
            //    Root.Height--;
            //    List<AVLTreeNode<T>> query = new List<AVLTreeNode<T>>();
            //    InOrderTraverseR(ref query, subject.RightChild);

            //    foreach (var result in query)
            //        result.Height -= 2;

            //}

            //if (subject.Parent == null)
            //    return;

            //else if (subject.Value.CompareTo(subject.Parent.Value) <= 0)
            //    subject.Parent.RightChild = subject;

            //else
            //    subject.Parent.LeftChild = subject;
            #endregion

            AVLTreeNode<T> elect = subject.LeftChild;

            while (elect.RightChild != null)
                elect = elect.RightChild;

            // Check if double rotation
            if (subject.LeftChild != elect)
            {
                // This check doesn't make anysense, revise
                //if (elect.LeftChild != null)
                //{
                //    elect.LeftChild.Parent = subject;
                //    subject.RightChild = elect.LeftChild;
                //}                

                subject.LeftChild.Parent = elect;
                subject.LeftChild.RightChild = null;
                elect.LeftChild = subject.LeftChild;
                subject.LeftChild = null;
            }
            if (subject != Root)
            {
                elect.Parent = subject.Parent;

                if (subject.Parent.LeftChild == subject)
                    subject.Parent.LeftChild = elect;

                else
                    subject.Parent.RightChild = elect;
            }
            else
            {
                elect.Parent = null;
                Root = elect;
            }

            subject.LeftChild = null;
            elect.RightChild = subject;
            subject.Parent = elect;
        }

        public AVLTree() : base()
        {
        }
    }
}