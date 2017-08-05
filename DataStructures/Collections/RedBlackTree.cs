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
        private readonly List<Action<RedBlackTreeNode<T>>> Checks;
        private readonly List<Func<RedBlackTreeNode<T>, bool>> DeletionChecks;

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

            DeletionChecks = new List<Func<RedBlackTreeNode<T>, bool>>
            {
                FirstDeletionCheck,
                SecondDeletionCheck,
                ThirdDelectionCheck
            };
            
            Root = null;
            Size = 0;
        }

        #region Insertion + Deletion
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

                // Color left child black ( or double black if already black )
                if (maxLeftSubtree.LeftChild.Color == RedBlack.Red)
                {
                    maxLeftSubtree.LeftChild.Color = RedBlack.Black;
                }
                else
                {
                    maxLeftSubtree.LeftChild.Color = RedBlack.DoubleBlack;
                    DeletionRuleCheck(maxLeftSubtree.LeftChild);
                }
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
        #endregion

        private RedBlackTreeNode<T> AvailableChild(RedBlackTreeNode<T> node)
        {
            var hasLeftChild = !node.LeftChild.IsNIL;
            return hasLeftChild ? node.LeftChild : node.RightChild;
        }

        protected void DeletionRuleCheck(RedBlackTreeNode<T> doubleBlackNode)
        {
            foreach (var check in DeletionChecks)
            {
                if (check.Invoke(doubleBlackNode)) break;
            }
        }

        #region Deletion Checks
        protected bool FirstDeletionCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var isLeftChild = parent.LeftChild == node;
            var sibling = isLeftChild ? parent.RightChild : parent.LeftChild;

            if (isLeftChild && sibling.Color == RedBlack.Red)
            {
                sibling.Color = RedBlack.Black;
                parent.Color = RedBlack.Red;
                RotateLeft(parent);

                return true;
            }

            return false;
        }

        protected bool SecondDeletionCheck(RedBlackTreeNode<T> node)
        {
            var parent = node.Parent;
            var isLeftChild = parent.LeftChild == node;
            var sibling = isLeftChild ? parent.RightChild : parent.LeftChild;
            var rightNephew = sibling.RightChild;
            var leftNephew = sibling.LeftChild;

            if (rightNephew.Color == RedBlack.Black && leftNephew.Color == RedBlack.Black)
            {
                sibling.Color = RedBlack.Red;
                return true;
            }

            return false;
        }

        protected bool ThirdDelectionCheck(RedBlackTreeNode<T> node) // Run checks 2 through 5
        {
            var insertChecks = Checks.Skip(1);
            return false;
        }
        #endregion

        protected void RuleCheck(RedBlackTreeNode<T> node)
        {
            var currentNode = node;

            while (currentNode != Root)
            {
                if (currentNode.Color == RedBlack.Red && currentNode.Parent.Color == RedBlack.Red)
                {
                    foreach (var method in Checks)
                    {
                        method.Invoke(currentNode);

                        if (currentNode.Color != RedBlack.Red || currentNode.Parent.Color != RedBlack.Red) break;
                    }
                }

                currentNode = currentNode.Parent;
            }

            Root.Color = RedBlack.Black;
        }

        #region Insertion Checks
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
        #endregion

        #region Rotation Functions
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
        #endregion

        #region IEnumerable Functions
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
        #endregion
    }
}
