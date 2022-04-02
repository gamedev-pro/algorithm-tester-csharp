using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgTester.Core;
using AlgTester.Loaders;
using AlgTester.Parsers;
using AlgTester.Presentation;

namespace AlgTester.API
{
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
                var possibleFileNames = string.Join(',', GetTestFileNames());
                throw new System.Exception($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {possibleFileNames} on your project");
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

        private IEnumerable<string> GetTestFileNames()
        {
            yield return $"{solutionClassName}_{solutionMethodName}_{TestFileSuffix}";
            yield return $"{solutionMethodName}_{TestFileSuffix}";
            yield return $"{solutionClassName}_{TestFileSuffix}";
        }

        private string TryFindTestSuiteFile()
        {
            foreach (var fileName in GetTestFileNames())
            {
                var file = Directory.GetFiles(Directory.GetCurrentDirectory(), fileName, SearchOption.AllDirectories).FirstOrDefault();
                if (!string.IsNullOrEmpty(file))
                {
                    return file;
                }
            }
            return null;
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