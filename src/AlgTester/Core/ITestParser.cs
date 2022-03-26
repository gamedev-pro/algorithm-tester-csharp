using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Core
{
    interface ITestParser
    {
        TestSuite GetTestCases();
    }
}
