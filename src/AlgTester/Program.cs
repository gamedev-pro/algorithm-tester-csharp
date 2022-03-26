using System;
using System.Collections.Generic;
using AlgTester.Core;
using AlgTester.Extensions;

namespace AlgTester
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTestResults(SolutionSetup.GetTestCases(), SolutionSetup.GetSolutionFunction());
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
