using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodilityRuntime.Extensions;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

using CodilitySolutionGetter = CodilityRuntime.Core.CodilitySolutionFunc<int, int[], int>;

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
                    Input = new List<object>()
                    {
                        100000,
                        Enumerable.Range(1, 100000)
                    },
                    Output = new List<object>() { 100000-1 }
                },
                new CodilityTestCase
                {
                    Input = new List<object>()
                    {
                        100000,
                        Enumerable.Range(1, 100000).Concat(Enumerable.Range(1, 100000))
                    },
                    Output = new List<object>() { 100000-1 }
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