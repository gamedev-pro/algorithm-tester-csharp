using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AlgTester.Extensions;
using AlgTester.Loaders;
using AlgTester.Parsers;
using Newtonsoft.Json;

namespace AlgTester.Core
{
    public class SolutionTester
    {
        private const string TestFileSuffix = "Tests.txt";
        private Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;

        private string testFileName;
        private IEnumerable<TestCase> fileTestCases;
        private IEnumerable<TestCase> extraTestCases;

        private string solutionClassName;
        private string solutionMethodName;

        private SolutionTester()
        {	
            
        }
        
        public static SolutionTester New()
        {
            var solutionTester = new SolutionTester();
            solutionTester.fileTestCases = Enumerable.Empty<TestCase>();
            solutionTester.extraTestCases = Enumerable.Empty<TestCase>();
            return solutionTester;
        }
        
        public SolutionTester WithAutoTestFile()
        {	
            var testFile = TryFindTestSuiteFile();
            if (testFile == null)
            {
                throw new System.Exception($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {GetTestFileName()} on your project");
            }
            return WithTestFile(testFile);
        }
        
        public SolutionTester WithTestFile(string filePath)
        {
            testFileName = Path.GetFileName(filePath);
            fileTestCases = GetTestCases(filePath);
            return this;
        }
        
        public SolutionTester WithTestCases(IEnumerable<TestCase> tests)
        {
            extraTestCases = tests;
            return this;
        }
        
        public SolutionTester WithSolution<T1, TRet>(Func<T1, TRet> func)
        {	
            var del = (Delegate)func;
            solutionMethodName = del.Method.Name;
            solutionClassName = del.Method.DeclaringType.Name;

            runSolutionFunc = (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                return new List<object>() { func(typedInput1) };
            };
            return this;
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
        
        public void Run()
        {	
            if (runSolutionFunc == null)
            {
                throw new System.Exception("solution function is null");
            }

            var comparer = new AlgTesterOutputComparer<IEnumerable<object>>();
            var fileTestResults = RunSuite(fileTestCases, comparer, runSolutionFunc);
            PresentTestSuiteResults($"{testFileName}", fileTestResults);

            var extraTestResults = RunSuite(extraTestCases, comparer, runSolutionFunc);
            PresentTestSuiteResults("Extra", extraTestResults);
            Console.WriteLine("\n\n");
        }
        
        private static void PresentTestSuiteResults(string suiteName, IEnumerable<AlgTestResult> results)
        {
            if (!results.Any())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n*****\nResults for Test Suite: {suiteName}\n\n*****\n");
            foreach (var testResult in results)
            {
                Console.ForegroundColor = testResult.Passed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(
                    string.Format("Test {0}: Input = {1}, Expected = {2}, Actual = {3}", 
                    testResult.Index,
                    testResult.TestCase.Input.ToOutputString(),
                    testResult.TestCase.Output.ToOutputString(),
                    testResult.Actual.ToOutputString())
                );
            }
        }
        
        private static IEnumerable<AlgTestResult> RunSuite(
            IEnumerable<TestCase> testSuite,
            AlgTesterOutputComparer<IEnumerable<object>> comparer,
            Func<IEnumerable<object>, IEnumerable<object>> solutionFunc
            )
        {	
            int testIndex = 0;
            var results = Enumerable.Empty<AlgTestResult>();
            foreach (var testCase in testSuite)
            {
                var actual = solutionFunc(testCase.Input);
                var passed = comparer.Equals(actual, testCase.Output);

                var result = new AlgTestResult
                {
                    Index = testIndex,
                    TestCase = testCase,
                    Actual = actual,
                    Passed = passed
                };

                results = results.Append(result);
                testIndex++;
            }
            return results;
        }

        public static IEnumerable<TestCase> GetTestCases(string testFile, IEnumerable<TestCase> extraTestCases = null)
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
    }
}
