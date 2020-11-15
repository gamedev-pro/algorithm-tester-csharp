using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        var threeMax = FindThreeMaxByComparison(A, (a, b) => a > b);
        var threeMins = FindThreeMaxByComparison(A, (a, b) => a < b);

        var maxProduct = A[threeMax[0]] * A[threeMax[1]] * A[threeMax[2]];
        var candidateMaxProduct = A[threeMax[2]] * A[threeMins[1]] * A[threeMins[2]];
        maxProduct = candidateMaxProduct > maxProduct ? candidateMaxProduct : maxProduct;

        return maxProduct;
    }

    private int[] FindThreeMaxByComparison(int[] A, Func<int, int, bool> comparisonFunc)
    {
        var firstThrees = new int[] { A[0], A[1], A[2] };
        var max = FindMaxIndexByComparison(firstThrees, comparisonFunc);
        var secondMax = -1;
        var thirdMax = -1;
        if (max == 0)
        {
            secondMax = comparisonFunc(A[1],A[2]) ? 1 : 2;
            thirdMax = comparisonFunc(A[1], A[2]) ? 2 : 1;
        }
        else if (max == 1)
        {
            secondMax = comparisonFunc(A[0],A[2]) ? 0 : 2;
            thirdMax = comparisonFunc(A[0], A[2]) ? 2 : 0;
        }
        else if (max == 2)
        {
            secondMax = comparisonFunc(A[0],A[1]) ? 0 : 1;
            thirdMax = comparisonFunc(A[0], A[1]) ? 1 : 0;
        }

        for (int i = 3; i < A.Length; i++)
        {
            if (comparisonFunc(A[i],A[max]))
            {
                var temp = max;
                var temp2 = secondMax;
                max = i;
                secondMax = temp;
                thirdMax = temp2;
            }
            else if (comparisonFunc(A[i],A[secondMax]))
            {
                var temp = secondMax;
                secondMax = i;
                thirdMax = temp;
            }
            else if (comparisonFunc(A[i], A[thirdMax]))
            {
                thirdMax = i;
            }
        }
        return new int[] { thirdMax, secondMax, max };
    }

    private int FindMaxIndexByComparison(int[] a, Func<int, int, bool> comparisonFunc)
    {
        var maxIndex = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (comparisonFunc(a[i], a[maxIndex]))
            {
                maxIndex = i;
            }
        }

        return maxIndex;
    }
}