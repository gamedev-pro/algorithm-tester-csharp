using System;
using Xunit;
using CodilityRuntime.Core;

namespace CodilityRuntime.Tests
{
    public class CodilityRuntimeTests
    {
        [Fact]
        public void TestSolution()
        {
            TestSolutionInternal(CodilitySolution.GetTestCases(), CodilitySolution.GetSolutionFunction());
        }

        void TestSolutionInternal<TInput, TOutput>(CodilityTestsSuite<TInput, TOutput> testSuite, Func<TInput, TOutput> func)
        {
            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            foreach (var testCase in testSuite)
            {
                var actual = func(testCase.Input);

                Assert.Equal(testCase.Output, actual, new CodilityOutputComparer<TOutput>());
            }
        }
    }
}
