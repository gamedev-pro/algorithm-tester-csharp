using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions
{
    class SwappingElements
    {
        public bool solution(int[] A, int[] B)
        {
            var diff = B.Sum() - A.Sum();

            if (diff % 2 == 1)
            {
                return false;
            }

            diff /= 2;
            var countersA = BuildCounts(A);
            foreach (var candidateInB in B)
            {
                var candidateInA = candidateInB - diff;
                if (candidateInA > 0 && candidateInA < countersA.Count() && countersA.ElementAt(candidateInA) > 0)
                {
                    return true;
                }
            }

            return false;
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
}
