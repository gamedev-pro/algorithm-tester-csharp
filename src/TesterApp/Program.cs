using AlgTester.API;//Include lib

static int MyCodingChallengeSolution(int n, int[] arr)
{	
    return 0;
}

// Save the function you want to test in a variable (it will help C# auto resolve the correct method call)
var solutionFunc = MyCodingChallengeSolution;
// Run your tests
SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithAutoTestFile()
    .Run();//Run tests!

Program_Dotnet5.Main_Dotnet5(new string[0]);
