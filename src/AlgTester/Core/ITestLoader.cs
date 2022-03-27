using System.Collections.Generic;

namespace AlgTester.Core
{
    public interface ITestResultsPresenter
    {
        void Present(IEnumerable<AlgTestResult> fileTestResults, IEnumerable<AlgTestResult> extraTestResults);
    }

    interface ITestLoader
    {
        string GetContent();
    }
}
