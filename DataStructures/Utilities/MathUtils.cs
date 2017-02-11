using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Utilities
{
    public static class MathUtils
    {
        private static Random random = new Random();

        /// <summary>
        /// Inclusive lower-bound, Non-inclusive upper-bound
        /// </summary>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static float Random(int lower, int upper) {
            return random.Next(lower, upper);
        }

        /// <summary>
        /// Non-inclusive 
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Random(int max) {
            return random.Next(max);
        }
    }
}
