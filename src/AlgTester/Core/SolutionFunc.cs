using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgTester.Core
{
    internal class SolutionFunc
    {
        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, TRet>(Func<T1, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                return new List<object>() { func(typedInput1) };
            };
        }
        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, T2, TRet>(Func<T1, T2, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                return new List<object>() { func(typedInput1, typedInput2) };
            };
        }
        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                T3 typedInput3 = JsonConvert.DeserializeObject<T3>(JsonConvert.SerializeObject(input.ElementAt(2)));
                return new List<object>() { func(typedInput1, typedInput2, typedInput3) };
            };
        }
        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> func)
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
        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> func)
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

        internal static Func<IEnumerable<object>, IEnumerable<object>> Get<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> func)
        {
            return (input) =>
            {
                T1 typedInput1 = JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(input.ElementAt(0)));
                T2 typedInput2 = JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(input.ElementAt(1)));
                T3 typedInput3 = JsonConvert.DeserializeObject<T3>(JsonConvert.SerializeObject(input.ElementAt(2)));
                T4 typedInput4 = JsonConvert.DeserializeObject<T4>(JsonConvert.SerializeObject(input.ElementAt(3)));
                T5 typedInput5 = JsonConvert.DeserializeObject<T5>(JsonConvert.SerializeObject(input.ElementAt(4)));
                T6 typedInput6 = JsonConvert.DeserializeObject<T6>(JsonConvert.SerializeObject(input.ElementAt(5)));
                return new List<object>() { func(typedInput1, typedInput2, typedInput3, typedInput4, typedInput5, typedInput6) };
            };
        }
    }
}
