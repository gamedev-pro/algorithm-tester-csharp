using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Core
{
    public struct CodilityTestCase
    {
        public IEnumerable<object> Input { get; set; }
        public IEnumerable<object> Output { get; set; }
    }

    public struct CodilityTestsSuite : IEnumerable<CodilityTestCase>
    {
        public CodilityTestsSuite(IEnumerable<CodilityTestCase> testCases)
        {
            this.testCases = testCases;
        }

        IEnumerator<CodilityTestCase> IEnumerable<CodilityTestCase>.GetEnumerator()
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

        private IEnumerable<CodilityTestCase> testCases;
    }
}
