using System;
using System.Collections.Generic;
using System.Linq;
using AlgTester.API;
using AlgTester.Core;

namespace AlgTester.Tests
{
    internal static class SolutionTesterUtils
    {	
        internal static SolutionTesterBuilder NewSolutionTester<T1, TRet>(Func<T1, TRet> func, IEnumerable<TestCase> testCases = null)
        {
            return SolutionTester.New()
                .WithSolution(func)
                .WithPresenter(new NUnitTestResultsPresenter())
                .WithTestCases(testCases ?? Enumerable.Empty<TestCase>());
        }
    }
}