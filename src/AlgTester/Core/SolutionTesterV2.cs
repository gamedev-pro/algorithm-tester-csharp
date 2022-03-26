using System;
using System.Collections.Generic;
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
        private Type solutionClass;
        private object solutionClassInstance;
        private MethodInfo solutionMethod;
        private Func<IEnumerable<object>, IEnumerable<object>> runSolutionFunc;
        private IEnumerable<TestCase> testCases;

        private SolutionTesterV2()
        {	
            
        }
        
        public static SolutionTesterV2 New<TClass, T1>(string testFile) where TClass : new()
        {
            var solutionTester = new SolutionTesterV2();
            solutionTester.solutionClass = typeof(TClass);
            solutionTester.solutionClassInstance = new TClass();
            //TODO: remove hardcode
            solutionTester.solutionMethod = solutionTester.solutionClass.GetMethod("FindRepeatingElement_Naive");
            solutionTester.testCases = GetTestCases(testFile);
            solutionTester.runSolutionFunc = (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                var result = solutionTester.solutionMethod.Invoke(solutionTester.solutionClassInstance, new object[] { typedInput1 });
                return new List<object>() { result };
            };
            return solutionTester;
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
    }
}
