using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CodilityRuntime.Core
{
    public class CodilityOutputComparer<T> : IEqualityComparer<T>
    {
        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            return JsonConvert.SerializeObject(x).Equals(JsonConvert.SerializeObject(y));
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.GetHashCode();
        }
    }
}
