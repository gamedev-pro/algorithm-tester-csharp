using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityRuntime.Core
{
    class CodilitySolutionFunc<T1, TRet>
    {
        public static Func<IEnumerable<object>, IEnumerable<object>> Get(Func<T1, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                return new List<object>() { func(typedInput1) };
            };
        }
    }

    class CodilitySolutionFunc<T1, T2, TRet>
    {
        public static Func<IEnumerable<object>, IEnumerable<object>> Get(Func<T1, T2, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                return new List<object>() { func(typedInput1, typedInput2) };
            };
        }
    }

    class CodilitySolutionFunc<T1, T2, T3, TRet>
    {
        public static Func<IEnumerable<object>, IEnumerable<object>> Get(Func<T1, T2, T3, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                T3 typedInput3 = JsonConvert.DeserializeObject<T3>(JsonConvert.SerializeObject(input.ElementAt(2)));
                return new List<object>() { func(typedInput1, typedInput2, typedInput3) };
            };
        }
    }
}
