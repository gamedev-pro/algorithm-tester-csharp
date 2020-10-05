using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        //Sum(1,N)
        //Missing Number = X
        //Sum(A) = Sum(1,N) - X + N+1
        //Diff = Sum(A) - Sum(1,N) = -X + N+ 1
        //X = N + 1 - Diff
        var diff = SumCollection(A) - SumConsecutives(1, A.Length);

        return A.Length + 1 - diff;
    }

    int SumConsecutives(int from, int length)
    {
        int sum = 0;
        for (int n = from; n <= length; n++)
        {
            sum += n;
        }
        return sum;
    }

    int SumCollection(int[] collection)
    {
        int sum = 0;
        for (int i = 0; i < collection.Length; i++)
        {
            sum += collection[i];
        }
        return sum;
    }
}