using System.Linq;
using AlgTester.Core;

namespace AlgTester.API
{
    public static class SolutionTester
    {
        public static ITestResultsPresenter DefaultPresenter;
        public static SolutionTesterBuilder_SolutionFunc New()
        {
            var solutionTester = new SolutionTestSuiteRunner();
            solutionTester.testCases = Enumerable.Empty<TestCase>();
            solutionTester.presenter = DefaultPresenter;
            return new SolutionTesterBuilder_SolutionFunc
            {
                SolutionTester = solutionTester
            };
        }
    }
}
