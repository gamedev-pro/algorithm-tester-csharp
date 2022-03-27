using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Core
{
    public struct AlgTestResult
    {
        public int Index;
        public TestCase TestCase;
        public IEnumerable<object> Actual;
        public bool Passed;
    }

    public struct TestCase
    {
        public IEnumerable<object> Input { get; set; }
        public IEnumerable<object> Output { get; set; }
    }
}
