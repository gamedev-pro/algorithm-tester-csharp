using System;
using System.Collections.Generic;
using System.IO;
using CodilityRuntime.Core;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

namespace CodilityRuntime
{
    class Solution
    {
        public int solution(int N)
        {
            return 0;
        }
    }

    public static class CodilitySolution
    {
        public static CodilityTestsSuite<int, int> GetTestCases()
        {
            //CodilityTestsSuite<int, int> testSuite;
            //GetFileTestCases(out testSuite);
            //return testSuite;

            return new CodilityTestsSuite<int, int>(new List<CodilityTestCase<int, int>>() 
            {
                new CodilityTestCase<int, int>() { Input = 0, Output = 2 }
            });
        }

        public static Func<int, int> GetSolutionFunction()
        {
            return new Solution().solution;
        }

        static void GetFileTestCases<TInput, TOutput>(out CodilityTestsSuite<TInput, TOutput> testCases)
        {
            var loader = new CodilityTestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../test_cases.txt").ToString());
            var parser = new CodilityTestParser<TInput, TOutput>(loader);

            testCases = parser.GetTestCases();
        }
    }
}
