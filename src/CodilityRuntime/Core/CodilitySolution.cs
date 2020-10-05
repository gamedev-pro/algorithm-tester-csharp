using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodilityRuntime.Extensions;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

using CodilitySolutionGetter = CodilityRuntime.Core.CodilitySolutionFunc<int, int, int, int>;

namespace CodilityRuntime.Core
{
    public static class CodilitySolution
    {
        static IEnumerable<CodilityTestCase> GetExtraTestCases()
        {
            return new CodilityTestsSuite(new List<CodilityTestCase>()
            {
            });
        }

        public static IEnumerable<CodilityTestCase> GetTestCases()
        {
            var loader = new CodilityTestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../test_cases.txt").ToString());
            var parser = new CodilityTestParser(loader);

            var testSuite = parser.GetTestCases();
            foreach (var testCase in testSuite)
            {
                yield return testCase;
            }

            var extraTestSuite = GetExtraTestCases();
            foreach (var extraTestCase in extraTestSuite)
            {
                yield return extraTestCase;
            }
        }

        public static Func<IEnumerable<object>, IEnumerable<object>> GetSolutionFunction()
        {
            return CodilitySolutionGetter.Get(new Solution().solution);
        }
    }
}