using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AlgTester.Extensions;
using AlgTester.Loaders;
using AlgTester.Parsers;
using AlgTesterRuntime.Core;
using Newtonsoft.Json;

namespace AlgTester.Core
{
    public class SolutionTesterV2
    {
        private const string TestFileSuffix = "Tests.txt";
        private Type solutionClass;
        private object solutionClassInstance;
        private MethodInfo solutionMethod;
        private Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;
        private IEnumerable<TestCase> testCases;

        private SolutionTesterV2()
        {	
            
        }
        
        public static SolutionTesterV2 New<TClass>() where TClass : new()
        {
            var classType = typeof(TClass);
            var solutionTester = new SolutionTesterV2();
            solutionTester.solutionClass = classType;
            solutionTester.solutionClassInstance = new TClass();
            solutionTester.solutionMethod = FindSolutionMethodAsserted(classType);
            return solutionTester;
        }
        
        public SolutionTesterV2 WithAutoTestFile()
        {	
            var testFile = TryFindTestSuiteFile();
            if (testFile == null)
            {
                throw new System.Exception($"Couldn't find test file for class {solutionClass.Name}.\nTry adding a file named {GetTestFileName()} on your project");
            }
            testCases = GetTestCases(testFile);
            return this;
        }
        
        public SolutionTesterV2 WithInput<T1>()
        {	
            //TODO: Validate input mathes solutionMethod;
            runSolutionFunc = (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                var result = solutionMethod.Invoke(solutionClassInstance, new object[] { typedInput1 });
                return new List<object>() { result };
            };
            return this;
        }
        
        private string GetTestFileName()
        {
            return $"{solutionClass.Name}_{TestFileSuffix}";
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
        private static MethodInfo FindSolutionMethodAsserted(Type type)
        {
            var methods = type.GetMethods().Where(m => m.IsDefined(typeof(SolutionAttribute)));
            if (!methods.Any())
            {
                throw new EntryPointNotFoundException($"Solution method not found on class {type}");
            }
            if (methods.Count() > 1)
            {
                var methodsStr = string.Join('\n', methods.Select(m => m.Name));
                throw new AmbiguousMatchException($"More than one method with [Solution] attribute in class {type}. Found:\n{methodsStr}");
            }
            return methods.First();
        }
    }
}
