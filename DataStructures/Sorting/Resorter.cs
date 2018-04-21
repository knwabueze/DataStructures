using DataStructures.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting
{
    public static class Resorter
    {
        public static void Sort<T>(this BinarySearchTree<T> tree)
            where T : IComparable
        {
            var arr = tree.InOrderTraverse().ToList();

            foreach (var member in arr)
                tree.Remove(member.Value);

            // 0.5 0 1.5 1

            tree.Insert(arr[arr.Count() / 2].Value);
            arr.Remove(arr[arr.Count() / 2]);

            var subtrees = arr.Split();
            SortR(subtrees[0], subtrees[1], tree);
        }

        private static System.Collections.Generic.List<T>[] Split<T>(this System.Collections.Generic.List<T> list)
        {
            System.Collections.Generic.List<T> list1 = new System.Collections.Generic.List<T>();
            System.Collections.Generic.List<T> list2 = new System.Collections.Generic.List<T>();

            for (int i = 0; i < list.Count() / 2; i++)
            {
                list1.Add(list[i]);
            }

            for (int j = list.Count() / 2; j < list.Count(); j++)
            {
                list2.Add(list[j]);
            }

            return new[] { list1, list2 };
        }

        private static void SortR<T>(System.Collections.Generic.List<BinarySearchTreeNode<T>> leftSubtree,
            System.Collections.Generic.List<BinarySearchTreeNode<T>> rightSubtree,
            BinarySearchTree<T> tree)
            where T : IComparable
        {
            if (leftSubtree.Count() == 0 && rightSubtree.Count() == 0)
                return;

            if (leftSubtree.Count > 0)
            {
                tree.Insert(leftSubtree[leftSubtree.Count() / 2].Value);
                leftSubtree.Remove(leftSubtree[leftSubtree.Count() / 2]);
            }

            if (rightSubtree.Count > 0)
            {
                tree.Insert(rightSubtree[rightSubtree.Count() / 2].Value);
                rightSubtree.Remove(rightSubtree[rightSubtree.Count() / 2]);
            }

            SortR(leftSubtree, rightSubtree, tree);
        }
    }
}
