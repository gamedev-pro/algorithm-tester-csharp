using AlgTester.API;//Include lib

public static class Solution
{	
    public static int MyCodingChallengeSolution(int n, int[] arr)
    {	
        return 0;
    }
}

class Program_Dotnet5
{
    public static void Main_Dotnet5(string[] args)
    {
        var solutionFunc = Solution.MyCodingChallengeSolution;
        SolutionTester.New()
            .WithSolution<int, int[], int>(solutionFunc)
            .WithAutoTestFile()
            .WithTestCase(2, new int[] { 1, 3 }, 0) // Type safe Input and output
            .WithTestCase(3, new int[] { 2, 3, 5 }, 1) // Another test case (this one will fail)
            .WithTestCase(3, new int[] { 2, 3, 5 }, 0) // and another :)
            .Run();
    }
}