using CodilityRuntime.Core;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

//BEGIN: Copy Past on Codility
using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    public int solution(int n)
    {
        return 2;
    }
}
//END: Copy Past on Codility

namespace CodilityRuntime
{
    public static class CodilitySolution
    {
        public static CodilityTestsSuite GetTestCases()
        {
            var loader = new CodilityTestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../test_cases.txt").ToString());
            var parser = new CodilityTestParser(loader);

            return parser.GetTestCases();
        }

        public static Func<IEnumerable<object>, IEnumerable<object>> GetSolutionFunction()
        {
            return CodilityRuntimeUtils.GetSolutionFunc<int, int>(new Solution().solution);
        }
    }
}
