using System;
using System.Collections.Generic;
using System.IO;
using CodilityRuntime.Tests.Core;
using System.Text;

namespace CodilityRuntime.Tests.Loaders
{
    class CodilityTestFileLoader : ICodilityTestLoader
    {
        public CodilityTestFileLoader(string filePath)
        {
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
