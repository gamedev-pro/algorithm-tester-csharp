using CodilityRuntime.Core;
using System;

namespace CodilityRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTestResults(CodilitySolution.GetTestCases(), CodilitySolution.GetSolutionFunction());
        }

        static void PrintTestResults<TInput, TOutput>(CodilityTestsSuite<TInput, TOutput> testSuite, Func<TInput, TOutput> func)
        {
            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            int testIndex = 0;
            foreach (var testCase in testSuite)
            {
                var actual = func(testCase.Input);

                Console.WriteLine(
                    string.Format("Test {0}: Input = {1}, Expected = {2}, Actual = {3}", 
                    testIndex, 
                    testCase.Input.ToString(), 
                    testCase.Output.ToString(), 
                    actual.ToString()));

                testIndex++;
            }
        }
    }
}
