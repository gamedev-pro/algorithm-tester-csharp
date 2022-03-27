using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AlgTester.Core;
using AlgTester.Loaders;
using AlgTester.Parsers;
using AlgTester.Presentation;

namespace AlgTester.API
{
    public struct SolutionTesterBuilder
    {	
        private const string TestFileSuffix = "Tests.txt";
        private string testFileName;
        internal string solutionClassName;
        internal string solutionMethodName;
        internal SolutionTestSuiteRunner SolutionTester;
        public SolutionTesterBuilder WithAutoTestFile()
        {	
            var testFile = TryFindTestSuiteFile();
            if (testFile == null)
            {
                throw new System.Exception($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {GetTestFileName()} on your project");
            }
            return WithTestFile(testFile);
        }
        
        public SolutionTesterBuilder WithTestFile(string filePath)
        {
            testFileName = Path.GetFileName(filePath);
            SolutionTester.fileTestCases = GetTestCases(filePath);
            return this;
        }
        
        public SolutionTesterBuilder WithTestCases(IEnumerable<TestCase> tests)
        {
            SolutionTester.extraTestCases = tests;
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
        public SolutionTesterBuilder WithPresenter(ITestResultsPresenter presenter)
        {
            SolutionTester.presenter = presenter;
            return this;
        }
    }
}