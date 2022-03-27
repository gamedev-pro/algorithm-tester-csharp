using System;
using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;
using AlgTester.Extensions;

namespace AlgTester.Presentation
{
    public class TestResultsConsolePresenter : ITestResultsPresenter
    {
        private string testFileName;
        private string solutionMethodName;
        public TestResultsConsolePresenter(string testFileName, string solutionMethodName)
        {
            this.testFileName = testFileName;
            this.solutionMethodName = solutionMethodName;
        }

        private static void PresentTestSuiteResults(string suiteName, IEnumerable<AlgTestResult> results)
        {
            if (!results.Any())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Results for Test Suite: {suiteName}\n");
            foreach (var testResult in results)
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

        public void Present(IEnumerable<AlgTestResult> fileTestResults, IEnumerable<AlgTestResult> extraTestResults)
        {
            Console.WriteLine($"\n*****\nTest Suite for {solutionMethodName}\n\n*****");
            PresentTestSuiteResults(testFileName, fileTestResults);
            PresentTestSuiteResults("Extra", extraTestResults);
            Console.WriteLine("\n\n");
        }
    }
}