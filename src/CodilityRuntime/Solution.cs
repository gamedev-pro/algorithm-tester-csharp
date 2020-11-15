using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int[] solution(int[] A)
    {
        new CodilityRuntime.Solutions.Sorting.QuickSort().Sort(A);
        return A;
    }
}