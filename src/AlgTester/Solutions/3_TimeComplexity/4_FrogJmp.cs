using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Solutions
{
    class FrogJmp
    {
        public int solution(int X, int Y, int D)
        {
            return (int)Math.Ceiling(((double)Y - X) / D);
        }
    }
}
