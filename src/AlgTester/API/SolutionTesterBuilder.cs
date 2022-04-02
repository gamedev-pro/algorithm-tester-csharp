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
            var fileNames = GetDefaultTestFileNames();
            var testFile = FindSolutionFilePath(fileNames);
            if (testFile == null)
            {
                var possibleFileNames = string.Join(',', GetDefaultTestFileNames());
                throw new System.ArgumentException($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {possibleFileNames} on your project");
            }
            return WithTestFile(testFile);
        }
        
        protected SolutionTesterBuilder WithTestFile(string fileNameOrPath)
        {
            var fullPath = FindSolutionFilePath(new string[] { fileNameOrPath });
            if (string.IsNullOrEmpty(fullPath))
            {	
                throw new System.ArgumentException($"Couldn't find any test file with name {fileNameOrPath}. Make sure the name is correct and the file is inside your project directory.");
            }
            SolutionTester.testCases = SolutionTester.testCases.Concat(GetTestCases(new TestFileLoader(fullPath)));
            return this;
        }

        protected SolutionTesterBuilder WithTestCase(object[] intputs, object[] outputs)
        {
            SolutionTester.testCases = SolutionTester.testCases.Append(new TestCase
            {
                Input = intputs,
                Output = outputs
            });
            return this;
        }
        public SolutionTesterBuilder WithStringTestCase(string input, string output)
        {
            SolutionTester.testCases = SolutionTester.testCases.Concat(GetTestCases(new TestStringLoader(input, output)));
            return this;
        }
        
        public SolutionTestSuiteRunner Build()
        {
            if (!SolutionTester.testCases.Any())
            {
                WithAutoTestFile();
            }
            if (SolutionTester.presenter == null)
            {
                WithPresenter(new TestResultsConsolePresenter(solutionMethodName));
            }
            return SolutionTester;
        }
        
        public void Run()
        {
            Build().Run();
        }
        
        public void Run(params int[] indexes)
        {
            Build().Run(indexes);
        }

        private IEnumerable<string> GetDefaultTestFileNames()
        {
            yield return $"{solutionClassName}_{solutionMethodName}_{TestFileSuffix}";
            yield return $"{solutionMethodName}_{TestFileSuffix}";
            yield return $"{solutionClassName}_{TestFileSuffix}";
        }

        private static string FindSolutionFilePath(IEnumerable<string> fileNamesOrPaths)
        {
            foreach (var fileNameOrPath in fileNamesOrPaths)
            {
                if (File.Exists(fileNameOrPath))
                {
                    return fileNameOrPath;
                }
                var searchName = fileNameOrPath.Split('/').LastOrDefault();

                var path = Directory.GetFiles(Directory.GetCurrentDirectory(), searchName, SearchOption.AllDirectories).FirstOrDefault();
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }
            return null;
        }

        private IEnumerable<TestCase> GetTestCases(ITestLoader loader)
        {
            var parser = new TestParser(loader);
            var testSuite = parser.GetTestCases();
            foreach (var testCase in testSuite)
            {
                yield return testCase;
            }
        }

        protected SolutionTesterBuilder WithPresenter(ITestResultsPresenter presenter)
        {
            SolutionTester.presenter = presenter;
            return this;
        }
    }
}