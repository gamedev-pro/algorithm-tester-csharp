using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgTester.Core;
using AlgTester.Loaders;
using AlgTester.Parsers;
using AlgTester.Presentation;

namespace AlgTester.API
{
    public class SolutionTesterBuilder<T1, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, TRet> WithTestCase(T1 p1, TRet o)
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithTestCase(new object[] { p1 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, TRet>)base.WithPresenter(presenter);
        }
    }

    public class SolutionTesterBuilder<T1, T2, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, TRet> WithTestCase(T1 p1, T2 p2, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithTestCase(new object[] { p1, p2 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, T2, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, T2, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, T2, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, TRet>)base.WithPresenter(presenter);
        }
    }

    public class SolutionTesterBuilder<T1, T2, T3, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithTestCase(new object[] { p1, p2, p3 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, T2, T3, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, T2, T3, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, T2, T3, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, TRet>)base.WithPresenter(presenter);
        }
    }
    public class SolutionTesterBuilder<T1, T2, T3, T4, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, TRet>)base.WithPresenter(presenter);
        }
    }

    public class SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4, p5 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, TRet>)base.WithPresenter(presenter);
        }
    }
    public class SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> : SolutionTesterBuilder
    {
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithTestCase(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, TRet o)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithTestCase(new object[] { p1, p2, p3, p4, p5, p6 }, new object[] { o });
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithAutoTestFile()
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithAutoTestFile();
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithTestFile(string testFile)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>) base.WithTestFile(testFile);
        }
        public SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet> WithPresenter(ITestResultsPresenter presenter)
        {
            return (SolutionTesterBuilder<T1, T2, T3, T4, T5, T6, TRet>)base.WithPresenter(presenter);
        }
    }

    public abstract class SolutionTesterBuilder
    {	
        private const string TestFileSuffix = "Tests.txt";
        protected string testFileName;
        internal string solutionClassName;
        internal string solutionMethodName;
        internal SolutionTestSuiteRunner SolutionTester;
        
        protected SolutionTesterBuilder WithAutoTestFile()
        {	
            var testFile = TryFindTestSuiteFile();
            if (testFile == null)
            {
                throw new System.Exception($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {GetTestFileName()} on your project");
            }
            return WithTestFile(testFile);
        }
        
        protected SolutionTesterBuilder WithTestFile(string filePath)
        {
            testFileName = Path.GetFileName(filePath);
            SolutionTester.fileTestCases = GetTestCases(filePath);
            return this;
        }
        protected SolutionTesterBuilder WithTestCase(object[] intputs, object[] outputs)
        {
            SolutionTester.extraTestCases = SolutionTester.extraTestCases.Append(new TestCase
            {
                Input = intputs,
                Output = outputs
            });
            return this;
        }
        
        public SolutionTestSuiteRunner Build()
        {
            if (!SolutionTester.fileTestCases.Any() && !SolutionTester.extraTestCases.Any())
            {
                WithAutoTestFile();
            }
            if (SolutionTester.presenter == null)
            {
                WithPresenter(new TestResultsConsolePresenter(testFileName, solutionMethodName));
            }
            return SolutionTester;
        }
        
        public void Run()
        {
            Build().Run();
        }

        private string GetTestFileName()
        {
            return $"{solutionClassName}_{TestFileSuffix}";
        }

        private string TryFindTestSuiteFile()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), GetTestFileName(), SearchOption.AllDirectories);
            return files.FirstOrDefault();
        }

        private IEnumerable<TestCase> GetTestCases(string testFile, IEnumerable<TestCase> extraTestCases = null)
        {
            var absPath = Path.GetFullPath(testFile);
            if (!File.Exists(absPath))
            {
                throw new System.ArgumentException($"Couldn't find test file for path: {absPath}");
            }
            var loader = new TestFileLoader(absPath);
            var parser = new TestParser(loader);

            var testSuite = parser.GetTestCases();
            foreach (var testCase in testSuite)
            {
                yield return testCase;
            }

            if (extraTestCases != null)
            {	
                foreach (var extraTestCase in extraTestCases)
                {
                    yield return extraTestCase;
                }
            }
        }
        protected SolutionTesterBuilder WithPresenter(ITestResultsPresenter presenter)
        {
            SolutionTester.presenter = presenter;
            return this;
        }
    }
}