using System;
using System.Collections.Generic;
using System.IO;
using AlgTester.Extensions;
using AlgTester.Loaders;
using AlgTester.Parsers;

namespace AlgTester.Core
{
    public static class SolutionTester
    {	
        public static void Test(string testFile, Func<IEnumerable<object>, IEnumerable<object>> solutionFunc)
        {	
            PrintTestResults(GetTestCases(testFile), solutionFunc);
        }

        public static IEnumerable<TestCase> GetTestCases(string testFile, IEnumerable<TestCase> extraTestCases = null)
        {
            var absPath = Path.GetFullPath(testFile);
            var loader = new TestFileLoader(absPath);
            var parser = new TestParser(loader);

            var testSuite = parser.GetTestCases();
            foreach (var testCase in testSuite)
            {
                yield return testCase;
            }

            if (extraTestCases != null)
            {	
                foreach (var extraTestCase in extraTestCases)
                {
                    yield return extraTestCase;
                }
            }
        }
        
        static void PrintTestResults(IEnumerable<TestCase> testSuite, Func<IEnumerable<object>, IEnumerable<object>> func)
        {
            if (func == null)
            {
                throw new System.Exception("solution function is null");
            }

            var comparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            int testIndex = 0;
            foreach (var testCase in testSuite)
            {
                var actual = func(testCase.Input);
                var passed = comparer.Equals(actual, testCase.Output);
                Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(
                    string.Format("Test {0}: Input = {1}, Expected = {2}, Actual = {3}", 
                    testIndex,
                    testCase.Input.ToOutputString(),
                    testCase.Output.ToOutputString(),
                    actual.ToOutputString())
                );

                testIndex++;
            }
        }
    }
}
