using System;
using Xunit;
using CodilityRuntime.Tests.Loaders;
using CodilityRuntime.Tests.Parsers;
using CodilityRuntime.Tests.Core;

namespace CodilityRuntime.Tests
{
    public class CodilityRuntimeTests
    {
        [Fact]
        public void TestSolution()
        {
            TestSolutionInternal<int, int>();
        }

        void TestSolutionInternal<TInput, TOutput>()
        {
            var func = CodilitySolution.GetSolutionFunction<TInput, TOutput>();

            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            var loader = new CodilityTestFileLoader("");
            var parser = new CodilityTestParser<TInput, TOutput>(loader);

            var testSuite = parser.GetTestCases();
            foreach (var testCase in testSuite)
            {
                var actual = func(testCase.Input);
                Assert.Equal(testCase.Output, actual);
            }
        }
    }
}
