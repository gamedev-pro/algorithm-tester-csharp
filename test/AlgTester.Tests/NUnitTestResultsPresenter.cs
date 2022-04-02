using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;
using AlgTester.Extensions;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal class NUnitTestResultsPresenter : ITestResultsPresenter
    {
        public void Present(IEnumerable<AlgTestResult> allResults)
        {
            var resultComparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            foreach (var result in allResults)
            {
                Assert.True(result.Passed, $"Test {result.Index} Failed:\nExpected: {result.TestCase.Output.ToOutputString()}\nActual: {result.Actual.ToOutputString()}");
            }
        }
    }

    internal class NUnitFilterTestsPresenter : ITestResultsPresenter
    {
        private int expectedResultsCount;

        internal NUnitFilterTestsPresenter(int expectedResultsCount)
        {
            this.expectedResultsCount = expectedResultsCount;
        }

        public void Present(IEnumerable<AlgTestResult> allResults)
        {
            Assert.AreEqual(allResults.Count(), expectedResultsCount);
        }
    }
}