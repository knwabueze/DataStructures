using System;

namespace DataStructures.Collections
{
    public class RedBlackTreeNode<T> : BinarySearchTreeNode<T, RedBlackTreeNode<T>>
        where T : IComparable
    {
        public RedBlack Color { get; set; }
        public bool IsNIL { get; set; }

        public RedBlackTreeNode()
        {
            this.Color = RedBlack.Red;
            this.IsNIL = false;
        }

        public static readonly RedBlackTreeNode<T> NILNode = new RedBlackTreeNode<T>()
        {
            Color = RedBlack.Black,
            IsNIL = true 
        };

        public RedBlackTreeNode<T> Copy()
        {
            return new RedBlackTreeNode<T>()
            {
                Color = this.Color,
                IsNIL = this.IsNIL
            };
        }

        public override string ToString()
        {
            if (this.IsNIL)
                return "NIL";

            return base.ToString();
        }
    }

    public enum RedBlack
    {
        Red,
        Black,
        DoubleBlack
    }
}
