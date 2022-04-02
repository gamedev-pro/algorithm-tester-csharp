using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;
using AlgTester.Extensions;
using AlgTester.Presentation;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal class NUnitTestResultsPresenter : ITestResultsPresenter
    {
        public bool PresentFailedOnly { set => throw new System.NotImplementedException(); }

        public void Present(IEnumerable<AlgTestResult> allResults)
        {
            var resultComparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            foreach (var result in allResults)
            {
                Assert.True(result.Passed, $"Test {result.Index} Failed:\nExpected: {result.TestCase.Output.ToOutputString()}\nActual: {result.Actual.ToOutputString()}");
            }
        }
    }

    internal class NUnitFilterTestsPresenter : TestResultsPresenter
    {
        private int expectedResultsCount;
        internal NUnitFilterTestsPresenter(int expectedResultsCount)
        {
            this.expectedResultsCount = expectedResultsCount;
        }
        protected override void PresentInternal(IEnumerable<AlgTestResult> filteredTests)
        {
            Assert.AreEqual(expectedResultsCount, filteredTests.Count());
        }
    }
}