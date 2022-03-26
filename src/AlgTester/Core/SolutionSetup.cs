using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgTester.Extensions;
using AlgTester.Loaders;
using AlgTester.Parsers;

using SolutionGetter = AlgTester.Core.SolutionFunc<string, int>;

namespace AlgTester.Core
{
    public static class SolutionSetup
    {
        static IEnumerable<TestCase> GetExtraTestCases()
        {
            return new TestSuite(new List<TestCase>()
            {
                
            });
        }

        public static IEnumerable<TestCase> GetTestCases()
        {
            var loader = new TestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "test_cases.txt").ToString());
            var parser = new TestParser(loader);

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
            return SolutionGetter.Get(new Solution().solution);
        }
    }
}