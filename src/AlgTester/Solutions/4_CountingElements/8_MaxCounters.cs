using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Solutions
{
    class MaxCounterEfficient
    {
        public int[] solution(int N, int[] A)
        {
            var counters = new int[N];
            var currentMaxCounter = 0;
            var maxCounter = 0;

            foreach (var operation in A)
            {
                if (IsMaxOperation(N, operation))
                {
                    maxCounter = currentMaxCounter;
                }
                else
                {
                    var x = operation - 1;
                    counters[x] = CalculateCounterValueAtIndex(counters, x, maxCounter) + 1;
                    currentMaxCounter = counters[x] > currentMaxCounter ? counters[x] : currentMaxCounter;
                }
            }

            for (int i = 0; i < N; i++)
            {
                counters[i] = CalculateCounterValueAtIndex(counters, i, maxCounter);
            }

            return counters;
        }

        private bool IsMaxOperation(int countersNum, int operation)
        {
            return operation == countersNum + 1;
        }

        private int CalculateCounterValueAtIndex(int[] counters, int counterIndex, int maxCounter)
        {
            return counters[counterIndex] < maxCounter ? maxCounter : counters[counterIndex];
        }
    }

    class MaxCountersNaive
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
