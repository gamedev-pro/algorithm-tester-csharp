using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Extensions
{
    static class LinqExtensions
    {
        const int MAX_PRINT_LENGTH = 50;
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy((item) => rnd.Next());
        }

        public static string ToOutputString<T>(this IEnumerable<T> source)
        {
            string data = JsonConvert.SerializeObject(source);
            if (data.Length > MAX_PRINT_LENGTH)
            {
                //magic numbers ftw
                return data.Substring(0, MAX_PRINT_LENGTH - 10) + "..." + data.Substring(data.Length - 3 - 10, 10 + 3);
            }
            return data;
        }
    }
}
