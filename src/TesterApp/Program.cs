
using AlgTester.Core;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionFunc = SolutionFunc<int[], int, int>.Get(FindRepeatedElement.FindRepeatingElement_Naive);
            SolutionTester.Test("src/TesterApp/Solutions/FindRepeatedNumber/FindRepeatedElement_TestCases.txt", solutionFunc);
        }
    }
}
