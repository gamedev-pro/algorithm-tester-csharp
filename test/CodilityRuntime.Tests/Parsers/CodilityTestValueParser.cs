using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Tests.Parsers
{
    static class CodilityTestValueParser<T>
    {
        public static T Parse(string value)
        {
            var parsedValue = default(T);
            ParseInternal(out parsedValue, value);
            return parsedValue;
        }

        static void ParseInternal(out T parsedValue, string value)
        {
            throw new System.NotImplementedException();
        }

        static void ParseInternal(out int parsedValue, string value) 
        {
            parsedValue = int.Parse(value);
        }

        static void ParseInternal(out float parsedValue, string value)
        {
            parsedValue = float.Parse(value);
        }

        static void ParseInternal(out string parsedValue, string value)
        {
            parsedValue = value;
        }

        static void ParseInternal(out IEnumerable<T> parsedValue, string value)
        {
            var elements = value.Replace("[", "").Replace("]", "").Split(',');
            var parsedElements = new List<T>(elements.Length);
            foreach (var element in elements)
            {
                parsedElements.Add(Parse(element));
            }
            parsedValue = parsedElements;
        }
    }
}
