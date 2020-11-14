using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Solutions.Sorting
{
    class Distinct
    {
        public int solution(int[] A)
        {
            var set = new HashSet<int>(A);
            return set.Count();
        }
    }
}
