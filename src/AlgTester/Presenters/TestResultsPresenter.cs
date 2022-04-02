using System.Collections.Generic;
using System.Linq;
using AlgTester.Core;

namespace AlgTester.Presentation
{
    public abstract class TestResultsPresenter : ITestResultsPresenter
    {
        public bool PresentFailedOnly { protected get; set; }

        public void Present(IEnumerable<AlgTestResult> testResults)
        {
            PresentInternal(testResults.Where(t => !PresentFailedOnly || !t.Passed));
        }

        protected abstract void PresentInternal(IEnumerable<AlgTestResult> filteredTests);
    }
}