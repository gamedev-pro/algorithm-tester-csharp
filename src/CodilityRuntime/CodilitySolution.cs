using CodilityRuntime.Core;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

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
        var bits = new BitArray(new int[] { n });
        int currentGap = 0, maxGap = 0;
        bool firstGapFound = false;
        foreach (bool bit in bits)
        {
            if (firstGapFound)
            {
                if (bit)
                {
                    maxGap = currentGap > maxGap ? currentGap : maxGap;
                    currentGap = 0;
                }
                else
                {
                    currentGap++;
                }
            }
            else
            {
                if (bit)
                {
                    firstGapFound = true;
                    currentGap = 0;
                }
            }
        }

        return maxGap;
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
