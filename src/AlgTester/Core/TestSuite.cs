using System.Collections;
using System.Collections.Generic;

namespace AlgTester.Core
{
    public struct TestSuite : IEnumerable<TestCase>
    {
        public TestSuite(IEnumerable<TestCase> testCases)
        {
            this.testCases = testCases;
        }

        IEnumerator<TestCase> IEnumerable<TestCase>.GetEnumerator()
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

        private IEnumerable<TestCase> testCases;
    }
}
