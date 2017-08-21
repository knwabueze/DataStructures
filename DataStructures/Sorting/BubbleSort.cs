using DataStructures.Collections;
using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting
{
    public static class BubbleSort
    {
        public static void Sort(List<int> array)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < array.Count - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        SortingUtils.Swap(i, i+1, array);
                        isSorted = false;
                    }
                }

            }
        }

        public static void Sort(ILinkedList<int> linkedList)
        {
            bool isSorted = false;

            while (!isSorted) {

                isSorted = true;
                for (int i = 0; i < linkedList.Count() - 1; i++)
                {
                    if (linkedList[i] > linkedList[i + 1])
                    {
                        SortingUtils.Swap(i, i+1, linkedList);
                        isSorted = false;
                    }
                }
            }
        }
    }
}
