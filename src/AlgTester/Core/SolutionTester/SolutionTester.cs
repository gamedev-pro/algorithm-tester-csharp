using System;
using System.Collections.Generic;
using System.Linq;
using AlgTester.Extensions;

namespace AlgTester.Core
{
    public partial class SolutionTester
    {
        private const string TestFileSuffix = "Tests.txt";
        private Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;

        private string testFileName;
        private IEnumerable<TestCase> fileTestCases;
        private IEnumerable<TestCase> extraTestCases;

        private string solutionClassName;
        private string solutionMethodName;

        private SolutionTester()
        {	
            
        }
        
        public static SolutionTesterBuilder_SolutionFunc New()
        {
            var solutionTester = new SolutionTester();
            solutionTester.fileTestCases = Enumerable.Empty<TestCase>();
            solutionTester.extraTestCases = Enumerable.Empty<TestCase>();
            return new SolutionTesterBuilder_SolutionFunc
            {
                SolutionTester = solutionTester
            };
        }
        
        public void Run()
        {	
            if (runSolutionFunc == null)
            {
                throw new System.Exception("solution function is null");
            }

            var comparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            var fileTestResults = RunSuite(fileTestCases, comparer, runSolutionFunc);
            PresentTestSuiteResults($"{testFileName}", fileTestResults);

            var extraTestResults = RunSuite(extraTestCases, comparer, runSolutionFunc);
            PresentTestSuiteResults("Extra", extraTestResults);
            Console.WriteLine("\n\n");
        }
        
        private static void PresentTestSuiteResults(string suiteName, IEnumerable<AlgTestResult> results)
        {
            if (!results.Any())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n*****\nResults for Test Suite: {suiteName}\n\n*****\n");
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
        
        private static IEnumerable<AlgTestResult> RunSuite(
            IEnumerable<TestCase> testSuite,
            AlgTesterOutputComparer<IEnumerable<object>> comparer,
            Func<IEnumerable<object>, IEnumerable<object>> solutionFunc)
        {	
            int testIndex = 0;
            var results = Enumerable.Empty<AlgTestResult>();
            foreach (var testCase in testSuite)
            {
                var actual = solutionFunc(testCase.Input);
                var passed = comparer.Equals(actual, testCase.Output);

                var result = new AlgTestResult
                {
                    Index = testIndex,
                    TestCase = testCase,
                    Actual = actual,
                    Passed = passed
                };

                results = results.Append(result);
                testIndex++;
            }
            return results;
        }
    }
}
