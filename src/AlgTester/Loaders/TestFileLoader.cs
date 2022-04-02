using System;
using System.Collections.Generic;
using System.IO;
using AlgTester.Core;
using System.Text;

namespace AlgTester.Loaders
{
    class TestFileLoader : ITestLoader
    {
        public TestFileLoader(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new System.ArgumentException($"Couldn't find file at path: {filePath}");
            }
            this.filePath = filePath;
        }

        public string GetContent()
        {
            if (content != null)
            {
                return content;
            }

            //not catching anything here
            content = File.ReadAllText(filePath);

            return content;
        }

        string filePath = null;
        string content = null;
    }
}
