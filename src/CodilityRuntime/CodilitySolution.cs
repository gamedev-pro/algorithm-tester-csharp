using CodilityRuntime.Core;
using CodilityRuntime.Loaders;
using CodilityRuntime.Parsers;

//BEGIN: Copy Past on Codility
using System;
using System.IO;

using InputType = System.Collections.Generic.IEnumerable<object>;
using OutputType = System.Collections.Generic.IEnumerable<object>;

class Solution
{
    public int solution(int n, string b)
    {
        return -1;
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
            return CodilityRuntimeUtils.GetSolutionFunc<int, string, int>(new Solution().solution);
        }
    }
}
