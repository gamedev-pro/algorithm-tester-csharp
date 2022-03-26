using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions.Sorting
{
    class Triangles
    {
        public int solution(int[] A)
        {
            //N is [0,100_000]
            //Elements are [-int32,int32], use long
            if (A.Length > 2)
            {
                //Filter <= 0 values (they can't constitute a triangle);
                var filteredArray = A.Where(e => e > 0).ToArray();
                Array.Sort(filteredArray);

                /*
                 * For P, Q, R, by sorting the array we guarantee (A[P] + A[R] > A[Q]) and (A[Q] + A[R] > A[P]), because R will be the largest
                 * So we only need to check for A[P] + A[Q] > A[R]
                 * Since it's given that 0 <= P > Q > R, just one for loop on the ordered array will suffice.
                 * And if the sorted array has a triplet, the unsorted one will to, just in a different configuration of P, Q and R
                 */
                for (int i = 0; i < filteredArray.Length - 2; i++)
                {
                    //We check A[P] > A[R] - A[Q] to avoid going over the int32 limit
                    if (filteredArray[i] > filteredArray[i + 2] - filteredArray[i + 1])
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }
    }
}
