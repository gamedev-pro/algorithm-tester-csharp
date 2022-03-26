using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions._4_CountingElements
{
    class MissingInteger
    {
        public int solution(int[] A)
        {
            var countersA = BuildCounters(A);

            if (!countersA.Any())
            {
                return 1;
            }

            for (int n = 1; n < countersA.Count(); n++)
            {
                if (countersA.ElementAt(n) == 0)
                {
                    return n;
                }
            }

            return countersA.Count();
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
