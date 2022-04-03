using AlgTester.Core;

namespace AlgTester.API
{
    public class SolutionTesterBuilder<T1, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, TRet> WithTestCase(T1 p1, TRet o)
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithTestCase(new object[] { p1 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, TRet>)base.WithPresenter(presenter);
        }

        public new SolutionTesterBuilder<T1, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, TRet>)base.ShowFailedTestsOnly();
        }
    }

    public class SolutionTesterBuilder<T1, T2, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, TRet> WithTestCase(T1 p1, T2 p2, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithTestCase(new object[] { p1, p2 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, T2, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, T2, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, T2, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, T2, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>)base.WithPresenter(presenter);
        }
        public new SolutionTesterBuilder<T1, T2, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, T2, TRet>)base.ShowFailedTestsOnly();
        }
    }

    public class SolutionTesterBuilder<T1, T2, T3, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithTestCase(new object[] { p1, p2, p3 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, T2, T3, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, T2, T3, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, T2, T3, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, T2, T3, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>)base.WithPresenter(presenter);
        }
        public new SolutionTesterBuilder<T1, T2, T3, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, T2, T3, TRet>)base.ShowFailedTestsOnly();
        }
    }
    public class SolutionTesterBuilder<T1, T2, T3, T4, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>)base.WithPresenter(presenter);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>)base.ShowFailedTestsOnly();
        }
    }

    public class SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4, p5 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>)base.WithPresenter(presenter);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>)base.ShowFailedTestsOnly();
        }
    }
    public class SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4, p5, p6 }, new object[] { o });
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithStringTestCase(string input, string output)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithStringTestCase(input, output);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithAutoTestFile();
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithTestFile(testFile);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>)base.WithPresenter(presenter);
        }
        public new SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> ShowFailedTestsOnly()
        {	
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>)base.ShowFailedTestsOnly();
        }
    }
}