﻿using AlgTester.API;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionFunc = FindRepeatedElement.FindRepeatingElement_Naive;
            SolutionTester.New()
                .WithSolution(solutionFunc)
                .WithAutoTestFile()
                .WithTestCase(new int[] { 1, 1, 3, 4 }, 0)
                .Run();
        }
    }
}
