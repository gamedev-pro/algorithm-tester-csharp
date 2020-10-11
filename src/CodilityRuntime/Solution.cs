using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
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