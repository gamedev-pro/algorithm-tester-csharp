using CodilityRuntime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public int[] solution(int N, int[] A)
    {
        //break A into arrays with the Max Operation in the end, and no MaxOperations in the beginning
        //For each broken array, count the number of repeated values. This will be how much each counter value will increase at the end
        //Set every counter to this max value, then iterate over the rest of operations doing the increases

        var splitIndexes = new List<int>(A.Length);
        for (int i = 0; i < A.Length; i++)
        {
            //TODO: case where several max operations in a roll
            if (IsMaxOperation(N, A[i]))
            {
                splitIndexes.Add(i);
            }
        }

        int startCounter = 0;
        foreach (var operations in SplitOperations(splitIndexes, A))
        {
            if (IsMaxOperation(N, operations.Last()))
            {

            }
            Console.WriteLine(operations.ToOutputString());
        }

        return new int[0];
    }

    private bool IsMaxOperation(int countersNum, int operation)
    {
        return operation == countersNum + 1;
    }

    private IEnumerable<IEnumerable<int>> SplitOperations(IEnumerable<int> splitIndexes, IEnumerable<int> operations)
    {
        var remaining = operations;
        foreach (var splitIndex in splitIndexes)
        {
            yield return remaining.Take(splitIndex + 1);
            remaining = remaining.Skip(splitIndex + 1);
        }

        yield return remaining;
    }
}