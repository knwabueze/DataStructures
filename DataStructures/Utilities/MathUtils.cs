using System;
using System.Collections.Generic;

namespace DataStructures.Utilities
{
    public static class MathUtils
    {
        public static Random Random = new Random();

        public static T Choice<T>(List<T> e)
        {
            var ran = Random.Next(0, e.Count);
            return e[ran];
        }

        /// <summary>
        /// Returns the smallest value (by definition of IComparable) in the passed in arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arguments">List of arguments to compares</param>
        /// <returns></returns>
        public static T Min<T>(params T[] arguments)
            where T : IComparable<T>
        {
            if (arguments == null)
            {
                throw new Exception("Must pass in more than zero arguments.");
            }

            T smallest = arguments[0];

            for (int i = 0; i < arguments.Length; ++i)
            {
                if (arguments[i].CompareTo(smallest) < 0)
                {
                    smallest = arguments[i];
                }
            }

            return smallest;
        }

        /// <summary>
        /// Returns the largest value (by definition of IComparable) in the passed in arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arguments">List of arguments to compares</param>
        /// <returns></returns>
        public static T Max<T>(params T[] arguments)
            where T : IComparable<T>
        {
            if (arguments == null)
            {
                throw new Exception("Must pass in more than zero arguments.");
            }

            T largest = arguments[0];

            for (int i = 0; i < arguments.Length; ++i)
            {
                if (arguments[i].CompareTo(largest) > 0)
                {
                    largest = arguments[i];
                }
            }

            return largest;
        }
    }
}
