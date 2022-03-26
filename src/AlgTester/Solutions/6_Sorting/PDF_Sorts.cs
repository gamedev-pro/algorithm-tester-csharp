using AlgTester.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions.Sorting
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

    class MergeSortNoCareForMemory
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

    class MergeSort
    {
        public void Sort(int[] collection)
        {
            var sortedCollection = new int[collection.Length];
            Sort(collection, sortedCollection, 0, collection.Length - 1);
        }

        private void Sort(int[] collectionToSort, int[] sortedCollection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var mid = (start + end) / 2;
            Sort(collectionToSort, sortedCollection, start, mid);
            Sort(collectionToSort, sortedCollection, mid + 1, end);
            Merge(collectionToSort, sortedCollection, start, mid, end);
        }

        private void Merge(int[] collectionToSort, int[] sortedCollection, int start, int mid, int end)
        {
            var leftIndex = start;
            var rightIndex = mid + 1;
            var sortedIndex = leftIndex;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (collectionToSort[leftIndex] < collectionToSort[rightIndex])
                {
                    sortedCollection[sortedIndex] = collectionToSort[leftIndex];
                    ++leftIndex;
                }
                else
                {
                    sortedCollection[sortedIndex] = collectionToSort[rightIndex];
                    ++rightIndex;
                }
                ++sortedIndex;
            }

            Array.Copy(collectionToSort, leftIndex, sortedCollection, sortedIndex, mid + 1 - leftIndex);
            Array.Copy(collectionToSort, rightIndex, sortedCollection, sortedIndex, end + 1 - rightIndex);
            Array.Copy(sortedCollection, leftIndex, collectionToSort, leftIndex, rightIndex - leftIndex);
        }
    }

    class BubbleSort
    {
        public void Sort(int[] collection)
        {
            var didSwap = true;

            while (didSwap)
            {
                didSwap = false;
                var i = 0;
                var j = 1;
                for (; j < collection.Length; i++, j++)
                {
                    if (collection[j] < collection[i])
                    {
                        didSwap = true;
                        Swap(collection, i, j);
                    }
                }
            }
        }

        private void Swap(int[] collection, int a, int b)
        {
            var temp = collection[b];
            collection[b] = collection[a];
            collection[a] = temp;
        }
    }

    class QuickSort
    {
        public void Sort(int [] collection)
        {
            Sort(collection, 0, collection.Length - 1);
        }

        private void Sort(int[] collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivotIndex = Split(collection, start, end);
            Sort(collection, start, pivotIndex - 1);
            Sort(collection, pivotIndex + 1, end);
        }

        private int Split(int[] collection, int start, int end)
        {
            var pivotIndex = ChoosePivot(start, end);
            var minIndex = start;

            //Move every element < pivot to the left of minIndex
            for (int i = start; i <= end; i++)
            {
                if (collection[i] < collection[pivotIndex])
                {
                    Swap(collection, minIndex++, i);
                }
            }

            //Swap pivot index and minIndex
            if (minIndex + 1 < end)
            {
                Swap(collection, minIndex, pivotIndex);
            }

            return minIndex;
        }

        private int ChoosePivot(int start, int end)
        {
            return end;
        }

        private void Swap(int[] collection, int a, int b)
        {
            var temp = collection[b];
            collection[b] = collection[a];
            collection[a] = temp;
        }
    }
}
