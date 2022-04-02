using System.Collections.Generic;

namespace AlgTester.Core
{
    public interface ITestResultsPresenter
    {
        void Present(IEnumerable<AlgTestResult> testResults);
        bool PresentFailedOnly { set; }
    }
}
