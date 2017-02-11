using DataStructures.Collections;
using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting
{
    public static class InsertionSort
    {
        public static void Sort(List<int> list)
        {
            while (!SortingUtils.IsSorted(list))
            {
                for (int i = 1; i < list.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (list[i - j] > list[i - j - 1])
                            break;

                        SortingUtils.Swap(i - j, i - j - 1, list);
                    }
                }
            }
        }

        public static void Sort(ILinkedList<int> linkedList)
        {
            while (!SortingUtils.IsSorted(linkedList))
            {
                for (int i = 1; i < linkedList.Count(); i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (linkedList.Get(i - j) > linkedList.Get(i - j - 1))
                            break;

                        SortingUtils.Swap(i - j, i - j - 1, linkedList);
                    }
                }
            }
        }
    }
}
