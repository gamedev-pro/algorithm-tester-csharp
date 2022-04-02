using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgTester.Core
{
    public class SolutionTestSuiteRunner
    {
        internal Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;
        internal IEnumerable<TestCase> testCases;
        internal ITestResultsPresenter presenter;

        internal SolutionTestSuiteRunner()
        {	
        }
        
        public void Run()
        {	
            if (runSolutionFunc == null)
            {
                throw new System.Exception("solution function is null");
            }

            var comparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            var fileTestResults = RunSuite(testCases, comparer, runSolutionFunc);
            presenter.Present(fileTestResults);
        }
        
        public void Run(params int[] indexes)
        {	
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
