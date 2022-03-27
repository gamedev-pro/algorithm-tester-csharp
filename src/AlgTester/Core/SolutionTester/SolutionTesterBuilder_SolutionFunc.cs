using System;
using System.Collections.Generic;

namespace AlgTester.Core
{
    public partial class SolutionTester
    {
        public struct SolutionTesterBuilder_SolutionFunc
        {
            internal SolutionTester SolutionTester;

            public SolutionTesterBuilder_TestSuite WithSolution<T1, TRet>(Func<T1, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            public SolutionTesterBuilder_TestSuite WithSolution<T1, T2, TRet>(Func<T1, T2, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            public SolutionTesterBuilder_TestSuite WithSolution<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            public SolutionTesterBuilder_TestSuite WithSolution<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            public SolutionTesterBuilder_TestSuite WithSolution<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            public SolutionTesterBuilder_TestSuite WithSolution<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> func)
            {
                return WithRunSolutionFunc(
                    (Delegate)func,
                    SolutionFunc.Get(func)
                );
            }
            
            private SolutionTesterBuilder_TestSuite WithRunSolutionFunc(Delegate func, Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc)
            {	
                SolutionTester.solutionMethodName = func.Method.Name;
                SolutionTester.solutionClassName = func.Method.DeclaringType.Name;
                SolutionTester.runSolutionFunc = runSolutionFunc;
                return new SolutionTesterBuilder_TestSuite
                {
                    SolutionTester = SolutionTester
                };
            }
        }
    }
}