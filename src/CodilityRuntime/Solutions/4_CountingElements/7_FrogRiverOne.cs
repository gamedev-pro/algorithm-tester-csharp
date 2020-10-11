using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FrogRiverOne
{
    public int solution(int X, int[] A)
    {
        if (A.Length < X)
        {
            return -1;
        }

        //TODO: early exist if A.Length == X and A has repeated elements?

        var droppedLeaves = new HashSet<int>(A.Length);
        for (int i = 0; i < A.Length; i++)
        {
            var leaveX = A[i];
            //Is the leave required but hasn't dropped yet
            if (leaveX <= X && !droppedLeaves.Contains(leaveX))
            {
                droppedLeaves.Add(leaveX);
            }

            //if our set is equal X all of the required leaves were dropped
            if (droppedLeaves.Count == X)
            {
                return i;
            }
        }
        return -1;
    }
}