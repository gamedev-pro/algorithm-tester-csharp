using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Solutions._5_PrefixSums
{
    class MushroomPicker
    {
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
