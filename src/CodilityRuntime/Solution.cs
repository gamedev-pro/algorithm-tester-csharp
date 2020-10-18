using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int solution(int[] A)
    {
        var dict = new CodilityRuntime.Solutions.Extras.CoreDataStructs.MapWithDoubleList<int, int>();
        dict.Add(1, 1);
        dict.Add(2, 1);
        dict.Add(3, 3);
        dict.Add(1, 67);
        dict.Add(4, 1);
        dict.Add(5, 3);
        dict.Add(6, 3);

        Console.WriteLine(dict.ToString());
        Console.WriteLine(dict.Get(1));
        Console.WriteLine(dict.Get(10));
        return -1;
    }
}