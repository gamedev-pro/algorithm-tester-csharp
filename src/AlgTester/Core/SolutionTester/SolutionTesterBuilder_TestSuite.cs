
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
        public struct SolutionTesterBuilder_TestSuite
        {	
            internal SolutionTester SolutionTester;
            public SolutionTesterBuilder_TestSuite WithAutoTestFile()
            {	
                var testFile = TryFindTestSuiteFile();
                if (testFile == null)
                {
                    throw new System.Exception($"Couldn't find test file for class {SolutionTester.solutionClassName}.\nTry adding a file named {GetTestFileName()} on your project");
                }
                return WithTestFile(testFile);
            }
            
            public SolutionTesterBuilder_TestSuite WithTestFile(string filePath)
            {
                SolutionTester.testFileName = Path.GetFileName(filePath);
                SolutionTester.fileTestCases = GetTestCases(filePath);
                return this;
            }
            
            public SolutionTesterBuilder_TestSuite WithTestCases(IEnumerable<TestCase> tests)
            {
                SolutionTester.extraTestCases = tests;
                return this;
            }
            private string GetTestFileName()
            {
                return $"{SolutionTester.solutionClassName}_{TestFileSuffix}";
            }

            private string TryFindTestSuiteFile()
            {
                var files = Directory.GetFiles(Directory.GetCurrentDirectory(), GetTestFileName(), SearchOption.AllDirectories);
                return files.FirstOrDefault();
            }

            public IEnumerable<TestCase> GetTestCases(string testFile, IEnumerable<TestCase> extraTestCases = null)
            {
                var absPath = Path.GetFullPath(testFile);
                Debug.Assert(File.Exists(absPath), $"Couldn't find test file for path: {absPath}");
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
            
            public SolutionTester Build()
            {
                //TODO: Check everything is valid?
                return SolutionTester;
            }
            
            public void Run()
            {
                Build().Run();
            }
        }
    }
}