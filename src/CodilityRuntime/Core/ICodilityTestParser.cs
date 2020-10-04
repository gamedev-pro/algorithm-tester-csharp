using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Core
{
    interface ICodilityTestParser<TInput, TOutput>
    {
        CodilityTestsSuite<TInput, TOutput> GetTestCases();
    }
}
