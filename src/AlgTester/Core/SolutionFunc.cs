using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgTester.Core
{
    public class SolutionFunc<T1, TRet>
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

    public class SolutionFunc<T1, T2, TRet>
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

    public class SolutionFunc<T1, T2, T3, TRet>
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

    public class SolutionFunc<T1, T2, T3, T4, TRet>
    {
        public static Func<IEnumerable<object>, IEnumerable<object>> Get(Func<T1, T2, T3, T4, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                T3 typedInput3 = JsonConvert.DeserializeObject<T3>(JsonConvert.SerializeObject(input.ElementAt(2)));
                T4 typedInput4 = JsonConvert.DeserializeObject<T4>(JsonConvert.SerializeObject(input.ElementAt(3)));
                return new List<object>() { func(typedInput1, typedInput2, typedInput3, typedInput4) };
            };
        }
    }

    public class SolutionFunc<T1, T2, T3, T4, T5, TRet>
    {
        public static Func<IEnumerable<object>, IEnumerable<object>> Get(Func<T1, T2, T3, T4, T5, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                T3 typedInput3 = JsonConvert.DeserializeObject<T3>(JsonConvert.SerializeObject(input.ElementAt(2)));
                T4 typedInput4 = JsonConvert.DeserializeObject<T4>(JsonConvert.SerializeObject(input.ElementAt(3)));
                T5 typedInput5 = JsonConvert.DeserializeObject<T5>(JsonConvert.SerializeObject(input.ElementAt(4)));
                return new List<object>() { func(typedInput1, typedInput2, typedInput3, typedInput4, typedInput5) };
            };
        }
    }
}
