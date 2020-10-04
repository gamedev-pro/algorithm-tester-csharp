using CodilityRuntime.Core;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;
using CodilityRuntime.Solutions;

//BEGIN: Copy Past on Codility
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using InputType = System.Int32;
using OutputType = System.Int32;

class Solution
{
    public InputType solution(OutputType n)
    {
        return BinaryGap.solution(n);
    }
}
//END: Copy Past on Codility

namespace CodilityRuntime
{
    public static class CodilitySolution
    {
        public static CodilityTestsSuite<InputType, OutputType> GetTestCases()
        {
            var loader = new CodilityTestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../test_cases.txt").ToString());
            var parser = new CodilityTestParser<InputType, OutputType>(loader);

            return parser.GetTestCases();

            //return new CodilityTestsSuite<int, int>(new List<CodilityTestCase<InputType, OutputType>>()
            //{
            //    new CodilityTestCase<InputType, OutputType>() { Input = 0, Output = 2 }
            //});
        }

        public static Func<InputType, OutputType> GetSolutionFunction()
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
