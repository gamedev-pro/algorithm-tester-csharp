using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Solutions
{
    class PermMissingElement
    {
        public int solution(int[] A)
        {
            if (A.Length == 0)
            {
                return 1;
            }

            var set = new HashSet<int>(A);
            for (int element = 1; element <= A.Length + 1; element++)
            {
                if (!set.Contains(element))
                {
                    return element;
                }
            }

            throw new System.Exception("Some assumption is wrong");
        }
    }

    class PermMissingElement2
    {
        public int solution(int[] A)
        {
            //Sum(1,N)
            //Missing Number = X
            //Sum(A) = Sum(1,N) - X + N+1
            //Diff = Sum(A) - Sum(1,N) = -X + N+ 1
            //X = N + 1 - Diff
            var diff = SumConsecutives(1, A.Length) - SumCollection(A);

            return A.Length + 1 - diff;
        }

        int SumConsecutives(int from, int length)
        {
            int sum = 0;
            for (int n = from; n <= length; n++)
            {
                sum += n;
            }
            return sum;
        }

        int SumCollection(IEnumerable<int> collection)
        {
            return collection.Sum();
        }
    }
}
