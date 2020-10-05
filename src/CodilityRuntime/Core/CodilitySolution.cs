using System;
using System.Collections.Generic;
using System.IO;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

using CodilitySolutionGetter = CodilityRuntime.Core.CodilitySolutionFunc<int, string, int>;

namespace CodilityRuntime.Core
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
            return CodilitySolutionGetter.Get(new Solution().solution);
        }
    }
}