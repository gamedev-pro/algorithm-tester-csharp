using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Tests.Core
{
    struct CodilityTestCase<TInput, TOutput>
    {
        public TInput Input { get; set; }
        public TOutput Output { get; set; }
    }

    struct CodilityTestsSuite<TInput, TOutput> : IEnumerable<CodilityTestCase<TInput, TOutput>>
    {
        public CodilityTestsSuite(IEnumerable<CodilityTestCase<TInput, TOutput>> testCases)
        {
            this.testCases = testCases;
        }

        IEnumerator<CodilityTestCase<TInput, TOutput>> IEnumerable<CodilityTestCase<TInput, TOutput>>.GetEnumerator()
        {
            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        private IEnumerable<CodilityTestCase<TInput, TOutput>> testCases;
    }
}
