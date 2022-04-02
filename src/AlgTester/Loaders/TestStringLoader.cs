using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AlgTester.Core;

namespace AlgTester.Loaders
{
    class TestStringLoader : ITestLoader
    {
        private string content;

        public TestStringLoader(IList<string> inputs, IList<string> outputs)
        {
            Debug.Assert(inputs.Count == outputs.Count, $"Mismatch input and output count (input count is {inputs.Count}, output count is {outputs.Count}");
            var strBuilder = new StringBuilder();
            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var output = outputs[i];
                strBuilder.Append(input);
                strBuilder.Append(';');
                strBuilder.Append(output);
                strBuilder.Append('\n');
            }
            content = strBuilder.ToString();
        }
        
        public TestStringLoader(string input, string output)
        {
            content = $"{input};{output}";
        }

        public string GetContent()
        {
            return content;
        }
    }
}
