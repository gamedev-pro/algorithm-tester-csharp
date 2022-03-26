using System;
using System.Collections.Generic;
using AlgTester.Loaders;
using AlgTester.Core;
using System.Text;

namespace AlgTester.Parsers
{
    class TestParser : ITestParser
    {
        public TestParser(ITestLoader loader)
        {
            this.loader = loader;
        }

        public TestSuite GetTestCases()
        {
            var testCases = new List<TestCase>();

            var inputsAndOutputsRaw = GetInputAndOutputs();
            using (var inputsEnumerator = inputsAndOutputsRaw.Key.GetEnumerator())
            using (var outputsEnumerator = inputsAndOutputsRaw.Value.GetEnumerator())
            {
                while (inputsEnumerator.MoveNext() && outputsEnumerator.MoveNext())
                {
                    var parsedInput = TestValueParser.Parse<IEnumerable<object>>(inputsEnumerator.Current);
                    var parsedOutput = TestValueParser.Parse<IEnumerable<object>>(outputsEnumerator.Current);

                    testCases.Add(new TestCase() { Input = parsedInput, Output = parsedOutput });
                }
            }

            return new TestSuite(testCases);
        }

        KeyValuePair<IEnumerable<string>, IEnumerable<string>> GetInputAndOutputs()
        {
            if (loader == null)
            {
                return new KeyValuePair<IEnumerable<string>, IEnumerable<string>>();
            }

            var content = loader.GetContent();

            string[] lines = content.Split('\n');
            var inputs = new List<string>();
            var outputs = new List<string>();
            foreach (var line in FilterLines(lines))
            {
                var inputAndOutput = line.Split(';');

                if (inputAndOutput.Length != 2)
                {
                    throw new System.FormatException("Expected input and output to be separated by ;");
                }

                inputs.Add(inputAndOutput[0]);
                outputs.Add(inputAndOutput[1]);
            }

            return new KeyValuePair<IEnumerable<string>, IEnumerable<string>>(inputs, outputs);
        }

        IEnumerable<string> FilterLines(string[] lines)
        {
            foreach (var line in lines)
            {
                if (!ShouldIgnoreLine(line))
                {
                    yield return line;
                }
            }
        }

        bool ShouldIgnoreLine(string line)
        {
            return line.Length == 0 || (line.Length > 1 && line[0] == '/' && line[1] == '/');
        }

        ITestLoader loader;
    }
}
