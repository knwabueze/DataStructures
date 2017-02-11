using DataStructures.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Utilities
{
    public static class SortingUtils
    {
        // Swap indice 1 with indice 2 on a list
        public static void Swap(int ind1, int ind2, List<int> list) {
            int temp = list[ind1];

            list[ind1] = list[ind2];
            list[ind2] = temp;
        }

        // Check if the list is sorted in ascending order
        public static bool IsSorted(List<int> list) {
            bool sorted = true;

            for (int i = 0; i < list.Count - 1; i++) {
                if (list[i] > list[i + 1])
                    sorted = false;
            }

            return sorted;
        }

        public static void Swap(int ind1, int ind2, ILinkedList<int> linkedList)
        {
            int temp = linkedList.Get(ind1);

            linkedList.Set(ind1, linkedList.Get(ind2));
            linkedList.Set(ind2, temp);
        }

        public static bool IsSorted(ILinkedList<int> linkedList)
        {
            bool sorted = true;

            for (int i = 0; i < linkedList.Count() - 1; i++) {
                if (linkedList.Get(i) > linkedList.Get(i + 1))
                    sorted = false;
            }

            return sorted;
        }
    }
}
