using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Solutions
{
    class MaxCounters
    {
        public int[] solution(int N, int[] A)
        {
            var counters = new int[N];
            int maxCounter = 0;
            for (int k = 0; k < A.Length; k++)
            {
                var operation = A[k];
                //add operation
                if (operation >= 1 && operation <= counters.Length)
                {
                    var counterIndex = operation - 1;
                    counters[counterIndex] += 1;
                    if (maxCounter < counters[counterIndex])
                    {
                        maxCounter = counters[counterIndex];
                    }
                }
                // max operation
                else if (operation == counters.Length + 1)
                {
                    for (int i = 0; i < counters.Length; i++)
                    {
                        counters[i] = maxCounter;
                    }
                }
            }

            return counters;
        }
    }
}
