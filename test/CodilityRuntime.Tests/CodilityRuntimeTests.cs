using System;
using Xunit;
using CodilityRuntime.Tests.Loaders;
using CodilityRuntime.Tests.Parsers;
using CodilityRuntime.Tests.Core;
using System.IO;

namespace CodilityRuntime.Tests
{
    public class CodilityRuntimeTests
    {
        [Fact]
        public void TestSolution()
        {
            TestSolutionInternal(CodilitySolution.GetSolutionFunction());
        }

        void TestSolutionInternal<TInput, TOutput>(Func<TInput, TOutput> func)
        {
            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            var loader = new CodilityTestFileLoader(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../test_cases.txt").ToString());
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
