using AlgTester.API;

namespace TesterApp
{
    public static class Solution
    {	
        public static int MyCodingChallengeSolution(int n, int[] arr)
        {	
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solutionFunc = Solution.MyCodingChallengeSolution;
            SolutionTester.New()
                //No implicity generic method resolution for C# 9.0
                .WithSolution(solutionFunc)
                .WithTestCase(2, new int[] { 1, 3 }, 0) // Type safe Input and output
                .WithTestCase(3, new int[] { 2, 3, 5 }, 1) // Another test case (this one will fail)
                .WithTestCase(3, new int[] { 2, 3, 5 }, 0) // and another :)
                .Run();
        }
    }
}
