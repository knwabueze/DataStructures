using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Collections
{
    public interface ILinkedList<T>
    {
        /// <summary>
        /// Add object at index
        /// </summary>
        /// <param name="index">Index to add at</param>
        /// <param name="value">Value to add</param>
        /// <returns>Returns Specified Generic Type, but if out of bounds then return OutOfBoundsException or caps at max index</returns>
        T Add(int index, T value);

        /// <summary>
        /// Add object at end of Collection
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <returns>Returns Specified Generic Type</returns>
        T Add(T value);

        /// <summary>
        /// Gets indexOf node
        /// </summary>
        /// <param name="node">Value to find indexOf</param>
        /// <returns>Returns index of value if exists, else throw NotFoundException</returns>
        int IndexOf(T value);

        /// <summary>
        /// Removes value from index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns removed object, else if not exists then throw NotFoundException</returns>
        T Remove(int index);

        /// <summary>
        /// Checks if value is in collection
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>Returns true if collection contains value, else returns false</returns>
        bool Contains(T value);

        /// <summary>
        /// Returns value at index
        /// </summary>
        /// <param name="index">Index of value</param>
        /// <returns>Returns value at index if exists, else throw NotFoundException</returns>
        T Get(int index);

        int Count();

        T Set(int index, T value);

        void Clear();
    }
}
