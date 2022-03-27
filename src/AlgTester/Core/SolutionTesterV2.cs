using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using AlgTester.Extensions;
using AlgTester.Loaders;
using AlgTester.Parsers;
using Newtonsoft.Json;

namespace AlgTester.Core
{
    public class SolutionTesterV2
    {
        private const string TestFileSuffix = "Tests.txt";
        private Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;
        private IEnumerable<TestCase> testCases;

        private string solutionClassName;
        private string solutionMethodName;

        private SolutionTesterV2()
        {	
            
        }
        
        public static SolutionTesterV2 New()
        {
            var solutionTester = new SolutionTesterV2();
            return solutionTester;
        }
        
        public SolutionTesterV2 WithAutoTestFile()
        {	
            var testFile = TryFindTestSuiteFile();
            if (testFile == null)
            {
                throw new System.Exception($"Couldn't find test file for class {solutionClassName}.\nTry adding a file named {GetTestFileName()} on your project");
            }
            testCases = GetTestCases(testFile);
            return this;
        }
        
        public SolutionTesterV2 WithTestFile(string filePath)
        {
            testCases = GetTestCases(filePath);
            return this;
        }
        
        public SolutionTesterV2 WithSolution<T1, TRet>(Func<T1, TRet> func)
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
            int testIndex = 0;
            foreach (var testCase in testCases)
            {
                var actual = runSolutionFunc(testCase.Input);
                var passed = comparer.Equals(actual, testCase.Output);
                Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(
                    string.Format("Test {0}: Input = {1}, Expected = {2}, Actual = {3}", 
                    testIndex,
                    testCase.Input.ToOutputString(),
                    testCase.Output.ToOutputString(),
                    actual.ToOutputString())
                );
                testIndex++;
            }
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
