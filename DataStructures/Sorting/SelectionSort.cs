using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting
{
    public static class SelectionSort
    {
        public static void Sort(List<int> list)
        {

            while (!SortingUtils.IsSorted(list))
            {

                // outer for loop where i starts at 0 and ends at count
                // inner for loop where j starts at i and ends at count 
                // Index through whole array to find the smallest number starting from the ith entry
                // Place that number at outer loop's index

                for (int i = 0; i < list.Count; i++)
                {
                    int min = i;

                    for (int j = i; j < list.Count; j++)
                    {
                        // SWAP if smaller number is found
                        if (list[j] < list[min])
                        {
                            SortingUtils.Swap(j, min, list);
                        }
                    }

                    list[i] =  list[min];
                }
            }
        }
    }
}
