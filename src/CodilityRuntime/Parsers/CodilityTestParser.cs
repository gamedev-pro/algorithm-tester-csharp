using System;
using System.Collections.Generic;
using CodilityRuntime.Loaders;
using CodilityRuntime.Core;
using System.Text;

namespace CodilityRuntime.Parsers
{
    class CodilityTestParser<TInput, TOutput> : ICodilityTestParser<TInput, TOutput>
    {
        public CodilityTestParser(ICodilityTestLoader loader)
        {
            this.loader = loader;
        }

        public CodilityTestsSuite<TInput, TOutput> GetTestCases()
        {
            var testCases = new List<CodilityTestCase<TInput, TOutput>>();

            var inputsAndOutputsRaw = GetInputAndOutputs();
            using (var inputsEnumerator = inputsAndOutputsRaw.Key.GetEnumerator())
            using (var outputsEnumerator = inputsAndOutputsRaw.Value.GetEnumerator())
            {
                while (inputsEnumerator.MoveNext() && outputsEnumerator.MoveNext())
                {
                    TInput parsedInput = CodilityTestValueParser.Parse<TInput>(inputsEnumerator.Current);
                    TOutput parsedOutput = CodilityTestValueParser.Parse<TOutput>(outputsEnumerator.Current);

                    testCases.Add(new CodilityTestCase<TInput, TOutput>() { Input = parsedInput, Output = parsedOutput });
                }
            }

            return new CodilityTestsSuite<TInput, TOutput>(testCases);
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
            foreach (var line in lines)
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

        ICodilityTestLoader loader;
    }
}
