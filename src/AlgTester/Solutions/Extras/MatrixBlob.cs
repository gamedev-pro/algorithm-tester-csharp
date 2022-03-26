using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Solutions.Extras
{
    class MatrixBlob
    {
        /*Find how many 0’s are adjacent to each other (rectangles) in a 2d matrix*/
        public static int solution(int[][] matrix)
        {
            var maxCount = 0;
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    var count = 0;
                    var boundsX = matrix.Length;
                    var boundsY = matrix[x].Length;
                    //Console.WriteLine("DOIT: " + x + ", " + y);
                    FloodFill(matrix, x, y, boundsX, boundsY, 0, ref count, new HashSet<KeyValuePair<int, int>>());

                    maxCount = Math.Max(count, maxCount);
                }
            }

            return maxCount;
        }

        static void FloodFill(int[][] matrix, int x, int y, int boundsX, int boundsY, int target, ref int count, HashSet<KeyValuePair<int, int>> visitedPositions)
        {
            //Console.WriteLine(boundsX + ", " + boundsY);
            if (x >= boundsX || y >= boundsY)
            {
                return;
            }

            var pair = new KeyValuePair<int, int>(x, y);
            if (visitedPositions.Contains(pair))
            {
                return;
            }

            visitedPositions.Add(pair);

            var value = matrix.SafeGet(x, y);
            if (value == null || value != target)
            {
                return;
            }

            count++;

            foreach (var neighbourCoords in GetNeighbours(x, y))
            {
                var neighbourValue = matrix.SafeGet(neighbourCoords.Key, neighbourCoords.Value);

                if (neighbourValue != null && neighbourValue != target)
                {
                    if (neighbourCoords.Key != x)
                    {
                        boundsX = neighbourCoords.Key;
                    }
                    if (neighbourCoords.Value != y)
                    {
                        boundsY = neighbourCoords.Value;
                    }
                }
            }

            foreach (var neighbourCoords in GetNeighbours(x, y))
            {
                FloodFill(matrix, neighbourCoords.Key, neighbourCoords.Value, boundsX, boundsY, target, ref count, visitedPositions);
            }
        }

        static IEnumerable<KeyValuePair<int, int>> GetNeighbours(int x, int y)
        {
            yield return new KeyValuePair<int, int>(x, y + 1);//right
            yield return new KeyValuePair<int, int>(x + 1, y);//down
            yield return new KeyValuePair<int, int>(x + 1, y + 1);//down right
        }
    }

    static class MatrixExtensions
    {
        public static int? SafeGet(this int[][] matrix, int x, int y)
        {
            if (x >= matrix.Length || x < 0 ||
                y >= matrix[x].Length || y < 0)
            {
                return null;
            }

            return matrix[x][y];
        }
    }
}
