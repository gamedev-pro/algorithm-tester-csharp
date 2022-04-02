using System;
using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;
using AlgTester.Extensions;

namespace AlgTester.Presentation
{
    public class TestResultsConsolePresenter : ITestResultsPresenter
    {
        private readonly string solutionMethodName;
        private readonly bool presentFailedOnly;

        public TestResultsConsolePresenter(string solutionMethodName, bool presentFailedOnly)
        {
            this.solutionMethodName = solutionMethodName;
            this.presentFailedOnly = presentFailedOnly;
        }

        public void Present(IEnumerable<AlgTestResult> testResults)
        {
            Console.WriteLine('\n');

            if (!testResults.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No tests to present!");
            }
            else
            {	
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Results for Test Suite: {solutionMethodName}\n");
                foreach (var testResult in testResults.Where(t => !presentFailedOnly || !t.Passed))
                {
                    Console.ForegroundColor = testResult.Passed ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(
                        string.Format("Test {0}: Input = {1}, Expected = {2}, Actual = {3}", 
                        testResult.Index,
                        testResult.TestCase.Input.ToOutputString(),
                        testResult.TestCase.Output.ToOutputString(),
                        testResult.Actual.ToOutputString())
                    );
                }
            }

            Console.WriteLine("\n\n");
        }
    }
}