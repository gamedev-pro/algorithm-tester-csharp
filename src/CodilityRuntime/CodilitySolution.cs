using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public int solution(int[] A)
    {
        var hits = new Dictionary<int,int>(A.Length);
        foreach (var element in A)
        {
            var hitCount = hits.ContainsKey(element) ? hits[element] : 0;
            hits[element] = hitCount + 1;
        }

        return hits.First(elementAndHitCount => elementAndHitCount.Value % 2 != 0).Key;
    }
}