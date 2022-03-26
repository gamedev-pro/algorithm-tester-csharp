using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions._5_PrefixSums
{
    class MinAvg
    {
        public int solution(int[] A)
        {
            /*
             * The key is knowing that there must be either a 2 or 3 sized slice with the minimum average (MA).
             * This can be proved by the following:
                * Consider a slice S of N elements, with N > 3, which is KNOWN that it contains the global minimum avg (MA)
                * 1. If N is even, we can divide S in two sub-slices of length 2. Those slices must have the same average because:
                    * If they have different averages, one of them would HAVE to be lower than MA, which is a contradiction
                    * Thus, both sub-slices have the same avg which is equal MA
                * 2. If N is odd we can divide S in two sub-slices of length 2 and 3. And the same conclusion as above follows,
                * they MUST have the same average
                * 
                * Another explanation:
                    * The key point to understand in this proof is that NO sub-slice of a slice with the global MA can have an average
                    * smaller than MA (because it's a contradiction), nor greater than MA, because this would have to be compensated by
                    * another average smaller than MA, which leads to the same contradiction
             */

            /*
             * So the solution is, for every starting index (0 to A.Length - 1), test a 2 sized and 3 sized slice
             */

            var prefixSum = new PrefixSum(A);
            var minAvg = double.MaxValue;
            var bestStart = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                var size2Avg = prefixSum.GetAvg(i, Math.Min(i + 1, A.Length - 1));
                if (size2Avg < minAvg)
                {
                    minAvg = size2Avg;
                    bestStart = i;
                }

                var size3Avg = prefixSum.GetAvg(i, Math.Min(i + 2, A.Length - 1));
                if (size3Avg < minAvg)
                {
                    minAvg = size3Avg;
                    bestStart = i;
                }
            }

            return bestStart;
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

            public double GetAvg(int start, int end)
            {
                return GetSum(start, end) / (double)(end - start + 1);
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
