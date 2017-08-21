using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting
{    
    public static class MergeSort
    {
        public static void Sort<T>(List<T> list) // -> O(n log n) time complexity, O(n) space complexity
            where T : IComparable
        {            
            Sort(list, 0, list.Count());
        }

        public static void Sort<T>(List<T> list, int min, int max) // min is inclusive, max is exclusive, O(n log n) time complexity
            where T : IComparable
        {
            if (max - min <= 1)
            {
                return;
            }
            
            int mp = (max + min) / 2; // Define the midpoint btwn max and min

            Sort(list, min, mp); // Divide-and-conquer (mergesort) on left side
            Sort(list, mp, max); // Divide-and-conquer (mergesort) on right side
            Merge(list, min, max); // Call merge on left and right side
        }

        private static void Merge<T>(List<T> list, int min, int max)
            where T : IComparable
        {
            int mp = (max + min) / 2; // Define the midpoint btwn max and min

            T[] tmpA = list.Skip(min).Take(mp - min).ToArray(); // Create queue-like structure for min to mp
            T[] tmpB = list.Skip(mp).Take(max - mp).ToArray(); // Create queue-like structure for mp to max

            T[] tmpTotal = new T[max - min]; // Create temp array -> O(n) space complexity
            
            int minI = tmpA.Count() - 1, maxI = tmpB.Count() - 1, totalI = tmpTotal.Count() - 1;

            while (minI >= 0 || maxI >= 0) // Check while there are still items in tmpA or tmpB
            {
                if (minI >= 0 && maxI >= 0) // Case A: Both have items, therefore we must compare which one gets inserted
                {
                    if (tmpA[minI].CompareTo(tmpB[maxI]) >= 0) // Case A.1 : If el1 >= el2, insert e1
                    {
                        tmpTotal[totalI--] = tmpA[minI--];
                    }

                    else // Case A.2 : Otherwise insert el2
                    {
                        tmpTotal[totalI--] = tmpB[maxI--];
                    }
                }

                else if (minI >= 0) // Case B : Only el1 has items left, so insert el1
                {
                    tmpTotal[totalI--] = tmpA[minI--];
                }

                else // Case C : Only el2 has items left, so insert el2
                {
                    tmpTotal[totalI--] = tmpB[maxI--];
                }
            }
            
            for (int i = min; i < max; i++) // Replace elements back into respective order in list
            {
                list[i] = tmpTotal[i - min];
            }
        }
    }
}
