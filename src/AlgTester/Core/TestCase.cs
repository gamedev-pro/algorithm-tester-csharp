using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Core
{
    public struct TestCase
    {
        public IEnumerable<object> Input { get; set; }
        public IEnumerable<object> Output { get; set; }
    }
}
