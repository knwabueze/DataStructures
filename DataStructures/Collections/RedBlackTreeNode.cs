using System;

namespace DataStructures.Collections
{
    public class RedBlackTreeNode<T> : BinarySearchTreeNode<T, RedBlackTreeNode<T>>
        where T : IComparable
    {
        public bool IsNIL { get; set; }

        protected RedBlack _color;

        public RedBlack Color
        {
            get
            {
                if (IsNIL)
                    return RedBlack.Black;
                return _color;
            }

            set
            {
                if (!IsNIL)
                    _color = value;
                else
                    _color = RedBlack.Black;
            }
        }
    }

    public enum RedBlack
    {
        Red,
        Black
    }
}
