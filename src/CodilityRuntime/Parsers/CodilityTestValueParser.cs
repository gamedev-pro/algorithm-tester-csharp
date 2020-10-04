using System;
using System.Collections.Generic;

namespace CodilityRuntime.Parsers
{
    static class CodilityTestValueParser
    {
        public static T Parse<T>(string value)
        {
            return (T) ParseInternal(typeof(T), value);
        }

        public static object ParseInternal(Type type, string value)
        {
            if (type.IsAssignableFrom(typeof(int)))
            {
                return int.Parse(value);
            }

            if (type.IsAssignableFrom(typeof(float)))
            {
                return float.Parse(value);
            }

            if (type.IsAssignableFrom(typeof(string)))
            {
                return int.Parse(value);
            }

            if (type.IsAssignableFrom(typeof(IEnumerable<object>)))
            {
                return ParseCollectionInternal<object>(value);
            }

            throw new System.NotImplementedException(string.Format("ParseInternal not implemented for type: {0}", type.ToString()));
        }

        static IEnumerable<T> ParseCollectionInternal<T>(string value)
        {
            var elements = value.Replace("[", "").Replace("]", "").Split(',');
            foreach (var element in elements)
            {
                yield return Parse<T>(element);
            }
        }
    }
}
