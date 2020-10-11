using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int A, int B, int K)
    {
        //A + remainder is divisible by K
        var remainder = A % K;

        //Assuming the first number in the range is divisible by K (A + remainder)
        //The range of divisible numbers will be the integer division result of (topRange - bottomRange) / K
        return (remainder == 0 ? 1 : 0) + (B - A + remainder) / K;
    }
}