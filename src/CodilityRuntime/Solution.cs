using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        //3,1,2,4,3
        //3,4,6,10,13
        //p=1 3, 13-3 = 10, diff 7
        //p=2 4, 13-4 = 9, diff 5
        var aggregatedSums = new double[A.Length];
        for (int i = 0; i < A.Length; i++)
        {
            var previousValue = i == 0 ? 0 : aggregatedSums[i - 1];
            aggregatedSums[i] = previousValue + A[i];
        }

        var minAbsDiff = double.MaxValue;
        for (int p = 1; p < A.Length; p++)
        {
            var beforeP = aggregatedSums[p-1];
            var afterP = aggregatedSums[A.Length - 1] - beforeP;

            var diff = Math.Abs(beforeP - afterP);
            minAbsDiff = Math.Min(diff, minAbsDiff);
        }

        return (int) minAbsDiff;
    }
}