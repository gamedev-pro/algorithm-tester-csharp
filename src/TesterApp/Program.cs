using AlgTester.API;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionFunc = FindRepeatedElement.Solution;
            SolutionTester.New()
                .WithSolution(solutionFunc)
                .WithTestFile("FindRepeatedElement_Solution_Tests.txt")
                .WithTestCase(new int[] { 1, 1, 3, 4 }, 0)
                .Run();
        }
    }
}
