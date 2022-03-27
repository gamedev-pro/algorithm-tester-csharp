using System;
using AlgTester.Core;

namespace AlgTester.API
{
    public struct SolutionTesterBuilder_SolutionFunc
    {
        internal SolutionTestSuiteRunner SolutionTester;

        public SolutionTesterBuilder<T1, TRet> WithSolution<T1, TRet>(Func<T1, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }

        public SolutionTesterBuilder WithSolution<T1, T2, TRet>(Func<T1, T2, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, T2, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }

        public SolutionTesterBuilder WithSolution<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, T2, T3, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, T2, T3, T4, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }
        public SolutionTesterBuilder WithSolution<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> func)
        {
            SolutionTester.runSolutionFunc = SolutionFunc.Get(func);
            var del = (Delegate)func;
            return new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>
            {
                SolutionTester = SolutionTester,
                solutionClassName = del.Method.DeclaringType.Name,
                solutionMethodName = del.Method.Name
            };
        }
    }
}