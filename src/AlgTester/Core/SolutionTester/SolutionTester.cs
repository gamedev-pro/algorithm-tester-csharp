using System;
using System.Collections.Generic;
using System.Linq;
using AlgTester.Extensions;

namespace AlgTester.Core
{
    public partial class SolutionTester
    {
        internal Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;

        internal string testFileName;
        internal IEnumerable<TestCase> fileTestCases;
        internal IEnumerable<TestCase> extraTestCases;

        internal string solutionClassName;
        internal string solutionMethodName;

        internal ITestResultsPresenter presenter;

        internal SolutionTester()
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
            var extraTestResults = RunSuite(extraTestCases, comparer, runSolutionFunc);
            presenter.Present(fileTestResults, extraTestResults);
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
