using System;
using Xunit;
using CodilityRuntime.Core;
using System.Collections.Generic;

namespace CodilityRuntime.Tests
{
    public class CodilityRuntimeTests
    {
        [Fact]
        public void TestSolution()
        {
            TestSolutionInternal(CodilitySolutionSetup.GetTestCases(), CodilitySolutionSetup.GetSolutionFunction());
        }

        void TestSolutionInternal(IEnumerable<CodilityTestCase> testSuite, Func<IEnumerable<object>, IEnumerable<object>> func)
        {
            if (func == null)
            {
                throw new System.Exception("Codility solution function is null");
            }

            foreach (var testCase in testSuite)
            {
                var actual = func(testCase.Input);

                Assert.Equal(testCase.Output, actual, new CodilityOutputComparer<IEnumerable<object>>());
            }
        }
    }
}
