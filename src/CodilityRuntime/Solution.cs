using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        var valueSet = new CodilityRuntime.Solutions.Extras.CoreDataStructs.HashSetWithDoubleList<int>(A);
        Console.WriteLine(valueSet.ToString());
        return valueSet.Count();
    }
}