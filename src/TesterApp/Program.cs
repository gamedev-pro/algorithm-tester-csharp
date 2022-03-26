
using AlgTester.Core;

using SolutionGetter = AlgTester.Core.SolutionFunc<string, int>;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionFunc = SolutionGetter.Get(new Solution().solution);
            SolutionTester.Test(solutionFunc);
        }
    }
}
