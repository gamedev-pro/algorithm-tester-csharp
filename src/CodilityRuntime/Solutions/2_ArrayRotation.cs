using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Solutions
{
    class ArrayRotation
    {
        public int[] solution(int[] A, int K)
        {
            var shifted = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                int shiftedIndex = (i + K) % A.Length;
                shifted[shiftedIndex] = A[i];
            }
            return shifted;
        }
    }
}
