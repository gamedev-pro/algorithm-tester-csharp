using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodilityRuntime.Extensions;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

using CodilitySolutionGetter = CodilityRuntime.Core.CodilitySolutionFunc<int[], int>;

namespace CodilityRuntime.Core
{
    public static class CodilitySolutionSetup
    {
        static IEnumerable<CodilityTestCase> GetExtraTestCases()
        {
            return new CodilityTestsSuite(new List<CodilityTestCase>()
            {
                new CodilityTestCase
                {
                    Input = new List<object> { Enumerable.Range(1, 100000+1).Where(e => e != 4) },
                    Output = new List<int> { 4 }.Cast<object>()
                },
                new CodilityTestCase
                {
                    Input = new List<object> { Enumerable.Range(1, 100000+1).Where(e => e != 7) },
                    Output = new List<int> { 7 }.Cast<object>()
                }
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