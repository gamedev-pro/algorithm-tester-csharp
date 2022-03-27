using System;
using System.Collections.Generic;
using AlgTester.Core;

namespace AlgTester.API
{
    public struct SolutionTesterBuilder_SolutionFunc
    {
        internal SolutionTestSuiteRunner SolutionTester;

        public SolutionTesterBuilder WithSolution<T1, TRet>(Func<T1, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        public SolutionTesterBuilder WithSolution<T1, T2, TRet>(Func<T1, T2, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> func)
        {
            return WithRunSolutionFunc(
                (Delegate)func,
                SolutionFunc.Get(func)
            );
        }
        
        private SolutionTesterBuilder WithRunSolutionFunc(Delegate func, Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc)
        {	
            SolutionTester.runSolutionFunc = runSolutionFunc;
            return new SolutionTesterBuilder
            {
                SolutionTester = SolutionTester,
                solutionClassName = func.Method.DeclaringType.Name,
                solutionMethodName = func.Method.Name
            };
        }
    }
}