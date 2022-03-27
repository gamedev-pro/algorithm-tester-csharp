using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AlgTester.Loaders;
using AlgTester.Parsers;
using Newtonsoft.Json;

namespace AlgTester.Core
{
    public partial class SolutionTester
    {
        public struct SolutionTesterBuilder_SolutionFunc
        {
            internal SolutionTester SolutionTester;

            public SolutionTesterBuilder_TestSuite WithSolution<T1, TRet>(Func<T1, TRet> func)
            {	
                var del = (Delegate)func;
                SolutionTester.solutionMethodName = del.Method.Name;
                SolutionTester.solutionClassName = del.Method.DeclaringType.Name;

                SolutionTester.runSolutionFunc = (input) =>
                {
                    T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                    return new List<object>() { func(typedInput1) };
                };

                return new SolutionTesterBuilder_TestSuite
                {
                    SolutionTester = SolutionTester
                };
            }
        }
    }
}