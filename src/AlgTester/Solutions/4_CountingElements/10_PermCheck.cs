using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions
{
    class PermCheck
    {
        public int solution(int[] A)
        {
            if (A.Count() == 1)
            {
                return A[0] == 1 ? 1 : 0;
            }

            if (A.Max() > A.Length)
            {
                return 0;
            }

            var counters = BuildCounters(A);

            for (int i = 1; i <= A.Length; i++)
            {
                if (counters.ElementAt(i) != 1)
                {
                    return 0;
                }
            }
            return 1;
        }

        private IEnumerable<int> BuildCounters(IEnumerable<int> collection)
        {
            int n = Math.Max(0, collection.Max() + 1);
            var counters = new int[n];

            if (counters.Count() == 0)
            {
                return counters;
            }

            foreach (var element in collection)
            {
                if (element >= 0 && element < n)
                {
                    ++counters[element];
                }
            }

            return counters;
        }
    }
}
