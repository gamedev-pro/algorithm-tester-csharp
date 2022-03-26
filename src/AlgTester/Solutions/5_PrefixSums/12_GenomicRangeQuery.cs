using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions._5_PrefixSums
{
    class GenomicRangeQuery
    {
        public int[] solution(string S, int[] P, int[] Q)
        {
            //The solution is to create a separate array for each nucleotide, 
            //with 0s and 1s (1 for when the nucleotide is in the given index) and the same length as S
            //Then if the PrefixSum for a given range {P[k],Q[k]} will be > 0 if the given nucleotide is present in the range
            //So, to find the minimum impact factor, we just need to go through each array of PrefixSum in order,
            //and return whenever the sum is > 0
            var separatedImpactFators = new Dictionary<char, int[]>
        {
            { 'A', new int[S.Length] },
            { 'C', new int[S.Length] },
            { 'G', new int[S.Length] },
            { 'T', new int[S.Length] }
        };

            for (int i = 0; i < S.Length; i++)
            {
                var nucleotide = S[i];
                separatedImpactFators[nucleotide][i] = 1;
            }

            var prefixSums = new Dictionary<char, PrefixSum>
        {
            { 'A', new PrefixSum(separatedImpactFators['A']) },
            { 'C', new PrefixSum(separatedImpactFators['C']) },
            { 'G', new PrefixSum(separatedImpactFators['G']) },
            { 'T', new PrefixSum(separatedImpactFators['T']) },
        };

            var queryAnswers = new List<int>(P.Length);
            for (int i = 0; i < P.Length; i++)
            {
                var start = P[i];
                var end = Q[i];

                foreach (var nucleotideToPrefixSum in prefixSums)
                {
                    if (nucleotideToPrefixSum.Value.GetSum(start, end) > 0)
                    {
                        queryAnswers.Add(GetImpactFactor(nucleotideToPrefixSum.Key));
                        break;
                    }
                }
            }

            return queryAnswers.ToArray();
        }

        private int GetImpactFactor(char nucleotide)
        {
            return impactFactors[char.ToLower(nucleotide)];
        }

        private Dictionary<char, int> impactFactors = new Dictionary<char, int>
    {
        {'a', 1},
        {'c', 2},
        {'g', 3},
        {'t', 4}
    };

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
