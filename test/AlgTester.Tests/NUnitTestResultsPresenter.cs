using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;
using AlgTester.Extensions;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal class NUnitTestResultsPresenter : ITestResultsPresenter
    {
        public void Present(IEnumerable<AlgTestResult> fileTestResults, IEnumerable<AlgTestResult> extraTestResults)
        {
            var allResults = fileTestResults.Concat(extraTestResults);
            var resultComparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            foreach (var result in allResults)
            {
                Assert.True(result.Passed, $"Test {result.Index} Failed:\nExpected: {result.TestCase.Output.ToOutputString()}\nActual: {result.Actual.ToOutputString()}");
            }
        }
    }
}