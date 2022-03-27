using System.Linq;
using AlgTester.Core;

namespace AlgTester.API
{
    public static class SolutionTester
    {	
        public static SolutionTesterBuilder_SolutionFunc New()
        {
            var solutionTester = new SolutionTestSuiteRunner();
            solutionTester.fileTestCases = Enumerable.Empty<TestCase>();
            solutionTester.extraTestCases = Enumerable.Empty<TestCase>();
            return new SolutionTesterBuilder_SolutionFunc
            {
                SolutionTester = solutionTester
            };
        }
    }
}
