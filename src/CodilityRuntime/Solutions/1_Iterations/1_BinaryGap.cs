using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Solutions
{
    class BinaryGap
    {
        public static int solution(int n)
        {
            var bits = new BitArray(new int[] { n });
            int currentGap = 0, maxGap = 0;
            bool firstGapFound = false;
            foreach (bool bit in bits)
            {
                if (firstGapFound)
                {
                    if (bit)
                    {
                        maxGap = currentGap > maxGap ? currentGap : maxGap;
                        currentGap = 0;
                    }
                    else
                    {
                        currentGap++;
                    }
                }
                else
                {
                    if (bit)
                    {
                        firstGapFound = true;
                        currentGap = 0;
                    }
                }
            }

            return maxGap;
        }
    }
}
