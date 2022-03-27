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
                .Run();
        }
    }
}
