using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructures.Collections
{
    /// <summary>
    /// DynamicMatrix is a wrapper for a dynamically-growing array of arrays.
    /// <para/>
    /// Mainly used in graph structures, a dynamically-growing matrix can easily used
    /// to represent the adjecency matrix in a graph data structure.
    /// <para/>
    /// The first dimension is always the width, and the secondary dimension is always the height.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicMatrix2D<T> : IEnumerable<T[]>
    {
        protected T[,] inner_;

        public T this[int x, int y]
        {
            get => inner_[x, y];
            set => inner_[x, y] = value;
        }

        public int Count => Width * Height;
        
        public int Width => inner_.GetLength(1);
        public int Height => inner_.GetLength(0);        

        protected const int StartingWidth = 4;
        protected const int StartingHeight = 4;

        /// <summary>
        /// Constructs an object of the type DynamicMatrix<typeparamref name="T"/> where the internal buffer mirrors an identity matrix.
        /// With an initial width and height of <paramref name="size"/>.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DynamicMatrix2D<int> Identity(int size = StartingWidth)
        {
            var mat = new DynamicMatrix2D<int>(size, size);

            for (int i = 0; i < size; ++i)
            {
                mat[i, i] = 1;
            }

            return mat;
        }

        /// <summary>
        /// Constructs an object of the type DynamicMatrix where <typeparamref name="T"/> is the type of the elements of the matrix
        /// with an optional starting width and/or height.
        /// </summary>
        /// <param name="width">Starting width of 2 dimensional internal buffer, by default is 4</param>
        /// <param name="height">Starting height of 2 dimensional intenral buffer, by default is 4</param>
        public DynamicMatrix2D(int width = StartingWidth, int height = StartingHeight)
        {
            inner_ = new T[height, width];
        }
        
        /// <summary>
        /// Adds <paramref name="size"/> amount of width and height to internal buffer.
        /// </summary>
        /// <param name="size">The number of width and height elements to add to internal buffer</param>
        public void AddDepth(int size)
        {
            Resize(size + Width, size + Height);
        }

        /// <summary>
        /// Sets the width and height of the internal buffer to <paramref name="size"/>.
        /// </summary>
        /// <param name="size"></param>
        public void SetDepth(int size)
        {
            Resize(size, size);
        }
        

        protected void Resize(int newWidth, int newHeight, int startX = 0, int startY = 0)
        {
            // First find the smaller of the two iterations of both dimensions,
            // the, iteraviely along the height, clone from elements 0 to the smaller of those dimensions into the new 2d array

            int oldWidth = Width;
            int oldHeight = Height;

            T[,] old = inner_;
            inner_ = new T[newHeight, newWidth];

            int copyWidth = Math.Min(oldWidth, newWidth);
            int copyHeight = Math.Min(oldHeight, newHeight);

            for (int i = startY; i < copyHeight; ++i)
            {
                for (int j = startX; j < copyWidth; ++j)
                {
                    inner_[i, j] = old[i, j];
                }
            }
        }

        public IEnumerator<T[]> GetEnumerator()
        {
            for (int i = 0; i < Height; ++i)
            {
                T[] nextArr = new T[Width];

                for (int j = 0; j < Width; ++j)
                {
                    nextArr[j] = inner_[j, i];
                }

                yield return nextArr;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            var height = Height;

            for (int i = 0; i < height; ++i)
            {
                ret.Append('[');
                var width = Width;
                for (int j = 0; j < width; ++j)
                {
                    ret.Append(inner_[i, j].ToString());
                    if (j + 1 != width)
                    {
                        ret.Append(", ");
                    }
                }

                ret.Append("]\n");
            }

            return ret.ToString();
        }
    }
}
