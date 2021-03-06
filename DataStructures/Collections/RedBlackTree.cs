﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Collections
{
    public class RedBlackTree<T> : BinarySearchTree<T, RedBlackTreeNode<T>>, IEnumerable<RedBlackTreeNode<T>>
        where T : IComparable
    {
        private readonly System.Collections.Generic.List<Action<RedBlackTreeNode<T>>> Checks;
        private readonly System.Collections.Generic.List<Action<RedBlackTreeNode<T>>> DeletionChecks;

        public RedBlackTree()
            : base()
        {
            Checks = new System.Collections.Generic.List<Action<RedBlackTreeNode<T>>>
            {
                FirstCheck,
                SecondCheck,
                ThirdCheck,
                FourthCheck,
                FifthCheck
            };

            DeletionChecks = new System.Collections.Generic.List<Action<RedBlackTreeNode<T>>>
            {
                FirstDeletionCheck,
                SecondDeletionCheck,
                ThirdDeletionCheck
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

            if (Size == 1) // if deleted node is root
            {
                Root = null;
            }

            if (!hasLeftChild && !hasRightChild) // has neither child
            {
                if (isLeftChild)
                {
                    nodeToBeRemoved.Parent.LeftChild = RedBlackTreeNode<T>.NILNode.Copy();
                    nodeToBeRemoved.Parent.LeftChild.Parent = nodeToBeRemoved.Parent;

                    if (nodeToBeRemoved.Color == RedBlack.Black)
                    {
                        nodeToBeRemoved.Parent.LeftChild.Color = RedBlack.DoubleBlack;
                        DeletionRuleCheck(nodeToBeRemoved.Parent.LeftChild);
                    }
                }
                else
                {
                    nodeToBeRemoved.Parent.RightChild = RedBlackTreeNode<T>.NILNode.Copy();
                    nodeToBeRemoved.Parent.RightChild.Parent = nodeToBeRemoved.Parent;

                    if (nodeToBeRemoved.Color == RedBlack.Black)
                    {
                        nodeToBeRemoved.Parent.RightChild.Color = RedBlack.DoubleBlack;
                        DeletionRuleCheck(nodeToBeRemoved.Parent.RightChild);
                    }
                }
            }

            else if (hasLeftChild && hasRightChild) // has both children
            {
                var maxLeftSubtree = nodeToBeRemoved.LeftChild;

                while (!maxLeftSubtree.RightChild.IsNIL)
                    maxLeftSubtree = maxLeftSubtree.RightChild;

                nodeToBeRemoved.Value = maxLeftSubtree.Value;

                maxLeftSubtree.LeftChild.Parent = maxLeftSubtree.Parent;
                maxLeftSubtree.Parent.LeftChild = maxLeftSubtree.LeftChild;

                if (maxLeftSubtree.Color == RedBlack.Red || nodeToBeRemoved.Color == RedBlack.Red)
                {
                    nodeToBeRemoved.Color = RedBlack.Black;
                }
                else if (maxLeftSubtree.Color == RedBlack.Black && nodeToBeRemoved.Color == RedBlack.Black)
                {
                    nodeToBeRemoved.Color = RedBlack.DoubleBlack;
                    DeletionRuleCheck(nodeToBeRemoved);
                }
            }

            else // has only a left child or right child
            {
                var child = AvailableChild(nodeToBeRemoved);

                if (nodeToBeRemoved == Root)
                {
                    Root = child;
                }

                else if (isLeftChild)
                {
                    nodeToBeRemoved.Parent.LeftChild = child;
                }
                else
                {
                    nodeToBeRemoved.Parent.RightChild = child;
                }

                child.Parent = nodeToBeRemoved.Parent;

                if (child.Color == RedBlack.Red || nodeToBeRemoved.Color == RedBlack.Red)
                {
                    child.Color = RedBlack.Black;
                }
                else if (child.Color == RedBlack.Black && nodeToBeRemoved.Color == RedBlack.Black)
                {
                    child.Color = RedBlack.DoubleBlack;
                }
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
            var currentCheck = 0;
            var currentNode = doubleBlackNode;
            while (currentNode.Color == RedBlack.DoubleBlack && currentNode != Root)
            {
                DeletionChecks[currentCheck].Invoke(doubleBlackNode);
                currentCheck++;

                if (currentCheck >= DeletionChecks.Count)
                {
                    currentCheck = 0;
                }

                if (currentNode.Color != RedBlack.DoubleBlack && currentNode.Parent.Color == RedBlack.DoubleBlack)
                {
                    currentNode = currentNode.Parent;
                }
            }

            Root.Color = RedBlack.Black;
        }

        #region Deletion Checks
        protected void FirstDeletionCheck(RedBlackTreeNode<T> node)
        {
            var isLeftChild = node.Parent.LeftChild == node;
            var parent = node.Parent;
            var sibling = isLeftChild ? node.Parent.RightChild : node.Parent.LeftChild;
            var rightNephew = sibling.RightChild;
            var leftNephew = sibling.LeftChild;

            var bothAreRed = (rightNephew.Color == RedBlack.Red && leftNephew.Color == RedBlack.Red);
            var bothAreBlack = (rightNephew.Color == RedBlack.Black && leftNephew.Color == RedBlack.Black);

            if (sibling.Color == RedBlack.Black)
            {
                // Left-Left Case (s is left child of its parent and r is left child of s or both children of s are red)
                if (!isLeftChild && (bothAreRed || leftNephew.Color == RedBlack.Red))
                {
                    RotateRight(node.Parent);
                    node.Color = RedBlack.Black;
                }

                // Left-Right Case (s is left child of its parent and r is right child)
                else if (!isLeftChild && rightNephew.Color == RedBlack.Red)
                {
                    RotateLeft(sibling);

                    sibling.Color = RedBlack.Red;
                    rightNephew.Color = RedBlack.Black;

                    RotateRight(node.Parent);

                    sibling.Color = RedBlack.Black;
                    node.Color = RedBlack.Black;
                }

                // Right-Right Case (s is right child of its parent and r is right child of s or both children of s are red)
                else if (isLeftChild && (bothAreRed || rightNephew.Color == RedBlack.Red))
                {
                    RotateLeft(node.Parent);
                    node.Color = RedBlack.Black;
                }

                // Right-Left Case (s is right child of its parent and r is left child of s)
                else if (isLeftChild && leftNephew.Color == RedBlack.Red)
                {
                    RotateRight(sibling);

                    sibling.Color = RedBlack.Red;
                    leftNephew.Color = RedBlack.Black;

                    RotateLeft(node.Parent);

                    sibling.Color = RedBlack.Black;
                    node.Color = RedBlack.Black;
                }

                
            }
        }

        protected void SecondDeletionCheck(RedBlackTreeNode<T> node)
        {
            var isLeftChild = node.Parent.LeftChild == node;
            var sibling = isLeftChild ? node.Parent.RightChild : node.Parent.LeftChild;
            var rightNephew = sibling.RightChild;
            var leftNephew = sibling.LeftChild;

            if (sibling.Color == RedBlack.Red)
            {
                // Left Case (s is left of its parent)
                if (!isLeftChild)
                {
                    RotateRight(node.Parent);
                }

                // Right Case (s is right of its parent)
                else if (isLeftChild)
                {
                    RotateLeft(node.Parent);
                }
            }
        }

        protected void ThirdDeletionCheck(RedBlackTreeNode<T> node)
        {
            var isLeftChild = node.Parent.LeftChild == node;
            var parent = node.Parent;
            var sibling = isLeftChild ? node.Parent.RightChild : node.Parent.LeftChild;
            var rightNephew = sibling.RightChild;
            var leftNephew = sibling.LeftChild;
            
            var bothAreBlack = (rightNephew.Color == RedBlack.Black && leftNephew.Color == RedBlack.Black);

            if (sibling.Color == RedBlack.Black && bothAreBlack)
            {
                sibling.Color = RedBlack.Red;
                node.Color = RedBlack.Black;

                if (parent.Color == RedBlack.Black)
                {
                    parent.Color = RedBlack.DoubleBlack;
                }

                else
                {
                    parent.Color = RedBlack.Black;
                }

            }
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
