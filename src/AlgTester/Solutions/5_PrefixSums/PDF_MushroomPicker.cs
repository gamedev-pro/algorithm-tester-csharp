using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions._5_PrefixSums
{
    class MushroomPicker
    {
        public int solution(int[] A, int k, int m)
        {
            var prefixSum = new PrefixSum(A);
            var maxCollected = 0;

            //The key is knowing that the mushroom picker should change directions only once.
            //So we try going 0-m steps right and then the remaining left, and vice-versa, and just store the max sum
            for (var rightSteps = 0; rightSteps + k < A.Length; ++rightSteps)
            {
                var end = k + rightSteps;
                var stepsActuallyTaken = end - k;
                var stepsRemaining = m - stepsActuallyTaken;
                var start = Math.Max(0, end - stepsRemaining);

                maxCollected = Math.Max(maxCollected, prefixSum.GetSum(start, end));
            }

            for (int leftSteps = 0; k - leftSteps >= 0; leftSteps++)
            {
                var start = k - leftSteps;
                var stepsActuallyTaken = k - start;
                var stepsRemaining = m - stepsActuallyTaken;
                var end = Math.Min(A.Length - 1, start + stepsRemaining);

                maxCollected = Math.Max(maxCollected, prefixSum.GetSum(start, end));
            }

            return maxCollected;
        }

        public class PrefixSum
        {
            public PrefixSum(IEnumerable<int> collection)
            {
                BuildPrefixSums(collection);
            }

            public int GetSum(int start, int end)
            {
                if (start < 0 || start > end || end + 1 >= prefixSums.Length)
                {
                    throw new System.Exception("Out of Range prefix sum exception");
                }
                return prefixSums[end + 1] - prefixSums[start];
            }

            private void BuildPrefixSums(IEnumerable<int> collection)
            {
                prefixSums = new int[collection.Count() + 1];
                for (int i = 1; i < prefixSums.Length; i++)
                {
                    prefixSums[i] = prefixSums[i - 1] + collection.ElementAt(i - 1);
                }
            }

            private int[] prefixSums;
        }
    }
}
