using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    // Rule check for adding is different than rule check for deleting
    // So far Checks 1, 4, and 5 are working and tested
    // Checks 2 and 3 have not been tested
    public class RedBlackTree<T> : BinarySearchTree<T, RedBlackTreeNode<T>>
        where T : IComparable
    {
        public readonly List<Action<RedBlackTreeNode<T>>> Checks;

        public RedBlackTree()
            : base()
        {
            Checks = new List<Action<RedBlackTreeNode<T>>>();
            Checks.Add(FirstCheck);
            Checks.Add(SecondCheck);
            Checks.Add(ThirdCheck);
            Checks.Add(FourthCheck);
            Checks.Add(FifthCheck);
        }

        public new RedBlackTreeNode<T> Insert(T value)
        {
            if (Root == null)
            {
                Size++;
                Root = new RedBlackTreeNode<T>()
                {
                    Value = value,
                    Parent = RedBlackTreeNode<T>.NILNode.Copy(),
                    RightChild = RedBlackTreeNode<T>.NILNode.Copy(),
                    LeftChild = RedBlackTreeNode<T>.NILNode.Copy()
                };

                RuleCheck(Root);
                return Root;
            }

            var node = InsertR(Root, value);
            RuleCheck(node);
            return node;
        }

        public new RedBlackTreeNode<T> InsertR(RedBlackTreeNode<T> parent, T value)
        {
            if (value.CompareTo(parent.Value) >= 0)
            {
                if (parent.RightChild.IsNIL)
                {
                    Size++;
                    parent.RightChild = new RedBlackTreeNode<T>()
                    {
                        Value = value,
                        Parent = parent,
                        RightChild = RedBlackTreeNode<T>.NILNode.Copy(),
                        LeftChild = RedBlackTreeNode<T>.NILNode.Copy()
                    };
                    return parent.RightChild;
                }
                return InsertR(parent.RightChild, value);
            }

            else if (value.CompareTo(parent.Value) < 0)
            {
                if (parent.LeftChild.IsNIL)
                {
                    Size++;
                    parent.LeftChild = new RedBlackTreeNode<T>()
                    {
                        Value = value,
                        Parent = parent,
                        RightChild = RedBlackTreeNode<T>.NILNode.Copy(),
                        LeftChild = RedBlackTreeNode<T>.NILNode.Copy()
                    };
                    return parent.LeftChild;
                }
                return InsertR(parent.LeftChild, value);
            }

            return null;
        }

        public new void Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void RuleCheck(RedBlackTreeNode<T> node)
        {
            var currentNode = node;

            while (currentNode.Color == RedBlack.Red && currentNode.Parent.Color == RedBlack.Red)
            {
                foreach (var method in Checks)
                {
                    method.Invoke(currentNode);

                    if (currentNode.Color != RedBlack.Red || currentNode.Parent.Color != RedBlack.Red) break;
                }

                currentNode = node.Parent;
            }

            Root.Color = RedBlack.Black;
        }

        protected void FirstCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var gp = parent.Parent;
            var uncle = parent == gp.RightChild ? gp.LeftChild : gp.RightChild;

            if (uncle.Color == RedBlack.Red)
            {
                gp.Color = RedBlack.Red;
                uncle.Color = RedBlack.Black;
                parent.Color = RedBlack.Black;
            }
        }

        protected void SecondCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.RightChild == node && gp.LeftChild == parent)
            {
                RotateLeft(parent);
                FourthCheck(node);
            }
        }

        protected void ThirdCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.LeftChild == node && gp.RightChild == parent)
            {
                RotateRight(parent);
                FifthCheck(node);
            }
        }

        protected void FourthCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.LeftChild == node && gp.LeftChild == parent)
            {
                RotateRight(gp);

                parent.Color = RedBlack.Black;
                gp.Color = RedBlack.Red;
            }
        }

        protected void FifthCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.RightChild == node && gp.RightChild == parent)
            {
                RotateLeft(gp);

                parent.Color = RedBlack.Black;
                gp.Color = RedBlack.Red;
            }
        }

        protected void RotateLeft(RedBlackTreeNode<T> subject)
        {
            var fulcrum = subject.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var subjectParent = subject.Parent;

            subject.RightChild = leftFulcrum;

            if (subject != Root)
            {
                if (subjectParent.LeftChild == subject) subjectParent.LeftChild = fulcrum;

                else subjectParent.RightChild = fulcrum;

                fulcrum.Parent = subjectParent;
            }
            else
            {
                fulcrum.Parent = RedBlackTreeNode<T>.NILNode.Copy();
                Root = fulcrum;
            }

            fulcrum.LeftChild = subject;
            subject.Parent = fulcrum;
        }

        protected void RotateRight(RedBlackTreeNode<T> subject)
        {
            var fulcrum = subject.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var subjectParent = subject.Parent;

            subject.LeftChild = rightFulcrum;

            if (subject != Root)
            {
                if (subjectParent.LeftChild == subject) subjectParent.LeftChild = fulcrum;

                else subjectParent.RightChild = fulcrum;

                fulcrum.Parent = subjectParent;
            }
            else
            {
                fulcrum.Parent = RedBlackTreeNode<T>.NILNode.Copy();
                Root = fulcrum;
            }

            fulcrum.RightChild = subject;
            subject.Parent = fulcrum;
        }
    }
}
