using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        var passingCarsCount = 0;
        var westCarsCount = 0;
        for (int i = A.Length - 1; i >= 0; --i)
        {
            if (A[i] == 1)
            {
                ++westCarsCount;
            }
            else if (A[i] == 0)
            {
                passingCarsCount += westCarsCount;
            }

            if (passingCarsCount > 1_000_000_000)
            {
                return -1;
            }
        }
        return passingCarsCount;
    }
}