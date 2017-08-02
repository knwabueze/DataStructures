using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Collections
{
    // Rule check for adding is different than rule check for deleting
    // So far Checks 1, 4, and 5 are working and tested
    // Checks 2 and 3 have not been tested
    public class RedBlackTree<T> : BinarySearchTree<T, RedBlackTreeNode<T>>, IEnumerable<RedBlackTreeNode<T>>
        where T : IComparable
    {
        public readonly List<Action<RedBlackTreeNode<T>>> Checks;

        public RedBlackTree()
            : base()
        {
            Checks = new List<Action<RedBlackTreeNode<T>>>
            {
                FirstCheck,
                SecondCheck,
                ThirdCheck,
                FourthCheck,
                FifthCheck
            };

            Root = null;
            Size = 0;
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

        private new RedBlackTreeNode<T> InsertR(RedBlackTreeNode<T> parent, T value)
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
            var nodeToBeRemoved = SearchNode(value);
            var isLeftChild = nodeToBeRemoved.Parent.LeftChild == nodeToBeRemoved;
            var hasLeftChild = !nodeToBeRemoved.LeftChild.IsNIL;
            var hasRightChild = !nodeToBeRemoved.RightChild.IsNIL;

            if (!hasLeftChild && !hasRightChild) // has neither child
            {
                if (isLeftChild)
                    nodeToBeRemoved.Parent.LeftChild = RedBlackTreeNode<T>.NILNode.Copy();
                else
                    nodeToBeRemoved.Parent.RightChild = RedBlackTreeNode<T>.NILNode.Copy();
            }

            else if (hasLeftChild && hasRightChild) // has both children
            {
                var maxLeftSubtree = nodeToBeRemoved.LeftChild;

                while (!maxLeftSubtree.RightChild.IsNIL)
                    maxLeftSubtree = maxLeftSubtree.RightChild;

                nodeToBeRemoved.Value = maxLeftSubtree.Value;

                maxLeftSubtree.LeftChild.Parent = maxLeftSubtree.Parent;
                maxLeftSubtree.Parent.LeftChild = maxLeftSubtree.LeftChild;
            }

            else // has only a left child or right child
            {
                var child = AvailableChild(nodeToBeRemoved);

                if (nodeToBeRemoved == Root)
                {
                    Root = child;
                    child.Parent = RedBlackTreeNode<T>.NILNode.Copy();
                }

                else if (isLeftChild)
                    nodeToBeRemoved.Parent.LeftChild = child;
                else
                    nodeToBeRemoved.Parent.RightChild = child;

                child.Parent = nodeToBeRemoved.Parent;
            }

            Size--;
        }

        private RedBlackTreeNode<T> AvailableChild(RedBlackTreeNode<T> node)
        {
            var hasLeftChild = !node.LeftChild.IsNIL;
            return hasLeftChild ? node.LeftChild : node.RightChild;
        }

        protected void RuleCheck(RedBlackTreeNode<T> node)
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

        protected void SecondCheck(RedBlackTreeNode<T> node) // double rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.RightChild == node && gp.LeftChild == parent)
            {
                RotateLeft(parent);

                if (!FourthCheck(parent, true))
                {
                    FifthCheck(parent);
                }
            }
        }

        protected void ThirdCheck(RedBlackTreeNode<T> node) // double rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.LeftChild == node && gp.RightChild == parent)
            {
                RotateRight(parent);

                if (!FifthCheck(parent, true))
                {
                    FourthCheck(parent);
                }
            }
        }

        protected void FourthCheck(RedBlackTreeNode<T> node) // single rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.LeftChild == node && gp.LeftChild == parent)
            {
                parent.Parent.Color = RedBlack.Red;
                parent.RightChild.Color = RedBlack.Red;
                parent.Color = RedBlack.Black;

                RotateRight(gp);
            }
        }

        protected bool FourthCheck(RedBlackTreeNode<T> node, bool returnsBool) // single rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.LeftChild == node && gp.LeftChild == parent)
            {
                parent.Parent.Color = RedBlack.Red;
                parent.RightChild.Color = RedBlack.Red;
                parent.Color = RedBlack.Black;

                RotateRight(gp);
                return true;
            }
            return false;
        }

        protected void FifthCheck(RedBlackTreeNode<T> node) // single rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.RightChild == node && gp.RightChild == parent)
            {
                parent.Parent.Color = RedBlack.Red;
                parent.LeftChild.Color = RedBlack.Red;
                parent.Color = RedBlack.Black;

                RotateLeft(gp);
            }

        }

        protected bool FifthCheck(RedBlackTreeNode<T> node, bool returnsBool) // single rotation
        {
            var parent = node.Parent;
            var gp = parent.Parent;

            if (parent.RightChild == node && gp.RightChild == parent)
            {
                parent.Parent.Color = RedBlack.Red;
                parent.LeftChild.Color = RedBlack.Red;
                parent.Color = RedBlack.Black;

                RotateLeft(gp);
                return true;
            }
            return false;
        }

        protected void RotateLeft(RedBlackTreeNode<T> node)
        {
            var fulcrum = node.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var nodeParent = node.Parent;

            node.RightChild = leftFulcrum;

            if (node != Root)
            {
                if (nodeParent.LeftChild == node) nodeParent.LeftChild = fulcrum;

                else nodeParent.RightChild = fulcrum;

                fulcrum.Parent = nodeParent;
            }
            else
            {
                fulcrum.Parent = RedBlackTreeNode<T>.NILNode.Copy();
                Root = fulcrum;
            }

            fulcrum.LeftChild = node;
            node.Parent = fulcrum;
        }

        protected void RotateRight(RedBlackTreeNode<T> node)
        {
            var fulcrum = node.LeftChild;
            var rightFulcrum = fulcrum.RightChild;
            var leftFulcrum = fulcrum.LeftChild;
            var nodeParent = node.Parent;

            node.LeftChild = rightFulcrum;

            if (node != Root)
            {
                if (nodeParent.LeftChild == node) nodeParent.LeftChild = fulcrum;

                else nodeParent.RightChild = fulcrum;

                fulcrum.Parent = nodeParent;
            }
            else
            {
                fulcrum.Parent = RedBlackTreeNode<T>.NILNode.Copy();
                Root = fulcrum;
            }

            fulcrum.RightChild = node;
            node.Parent = fulcrum;
        }

        public new IEnumerator<RedBlackTreeNode<T>> GetEnumerator()
        {
            foreach (var val in InOrderTraverse())
            {
                if (!val.IsNIL) yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
