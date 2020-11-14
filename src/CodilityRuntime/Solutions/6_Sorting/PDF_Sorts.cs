using CodilityRuntime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Solutions.Sorting
{
    class SelectionSort
    {
        //Find the smallest element of the array and put it in the first position of the array
        //Repeat for the rest of the array
        //O(n2) on the worst case

        public void Sort(int[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                var minIndex = i;
                var min = collection[i];
                for (int k = i; k < collection.Length; k++)
                {
                    if (collection[k] < min)
                    {
                        minIndex = k;
                        min = collection[k];
                    }
                }

                Swap(minIndex, i, collection);
            }
        }

        void Swap(int indexA, int indexB, int[] collection) 
        {
            var temp = collection[indexB];
            collection[indexB] = collection[indexA];
            collection[indexA] = temp;
        }
    }

    class CountingSort
    {
        //It's O(n + k), where K is the greatest element in the array
        //Only works for positive integers (or by shiffting negatives) and requires O(k) memory
        //Impractical if K is too large

        public void Sort(int[] collection)
        {
            var counts = BuildCounts(collection);

            var index = 0;
            for (int i = 0; i < counts.Count(); i++)
            {
                for (int j = 0; j < counts.ElementAt(i); j++)
                {
                    collection[index++] = i;
                }
            }
        }

        private IEnumerable<int> BuildCounts(IEnumerable<int> collection)
        {
            var counters = new int[collection.Max() + 1];
            foreach (var element in collection)
            {
                counters[element]++;
            }

            return counters;
        }
    }

    class MergeSort
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            if (collection.Count() == 1)
            {
                return new int[] { collection.ElementAt(0) };
            }

            var mid = collection.Count() / 2;
            var left = Sort(collection.Take(mid));
            var right = Sort(collection.Skip(mid));
            var result = MergeSorted(left, right);
            return result;
        }

        private IEnumerable<int> MergeSorted(IEnumerable<int> a, IEnumerable<int> b)
        {
            using (var aEnumerator = a.GetEnumerator())
            using (var bEnumerator = b.GetEnumerator())
            {
                var aExists = aEnumerator.MoveNext();
                var bExists = bEnumerator.MoveNext();
                while (aExists || bExists)
                {
                    if (aExists && bExists)
                    {
                        if (aEnumerator.Current < bEnumerator.Current)
                        {
                            yield return aEnumerator.Current;
                            aExists = aEnumerator.MoveNext();
                        }
                        else
                        {
                            yield return bEnumerator.Current;
                            bExists = bEnumerator.MoveNext();
                        }
                    }
                    else
                    {
                        if (aExists)
                        {
                            yield return aEnumerator.Current;
                            aExists = aEnumerator.MoveNext();
                        }
                        else if (bExists)
                        {
                            yield return bEnumerator.Current;
                            bExists = bEnumerator.MoveNext();
                        }
                    }
                }
            }
        }
    }
}
