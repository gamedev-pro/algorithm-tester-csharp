using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    //N is [0,200_000]
    //S contains only [,(,{,],),}
    public int solution(string S)
    {
        if (S.Length % 2 != 0)
        {
            return 0;
        }

        var stack = new Stack<char>(S.Length / 2);
        foreach (var c in S)
        {
            if (stack.Count > 0 && closingScopesToOpeningScopes.ContainsKey(c) && stack.Peek() == closingScopesToOpeningScopes[c])
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0 ? 1 : 0;
    }

    static Dictionary<char, char> closingScopesToOpeningScopes = new Dictionary<char, char>
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
    };
}