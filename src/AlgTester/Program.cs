using System;
using System.Collections.Generic;
using CodilityRuntime.Core;
using CodilityRuntime.Extensions;
using Newtonsoft.Json;

namespace CodilityRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTestResults(CodilitySolutionSetup.GetTestCases(), CodilitySolutionSetup.GetSolutionFunction());
        }

        static void PrintTestResults(IEnumerable<CodilityTestCase> testSuite, Func<IEnumerable<object>, IEnumerable<object>> func)
        {
            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            var comparer = new CodilityOutputComparer<IEnumerable<object>>();
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
