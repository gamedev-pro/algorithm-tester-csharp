using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityRuntime.Solutions.Sorting
{
    class NumberOfDiscIntersections
    {
        class Circle
        {
            public long Center;
            public long Radius;
            public long Left { get { return Center - Radius; } }
            public long Right { get { return Center + Radius; } }
        }

        /*
         * Comparer that will choose the left most circle (either by left edge or center)
         */
        class LeftMostCircleOrderer : IComparer<Circle>
        {
            public int Compare(Circle x, Circle y)
            {
                if (x.Left == y.Left)
                {
                    return x.Center.CompareTo(y.Center);
                }

                return x.Left.CompareTo(y.Left);
            }
        }
        public int solution(int[] A)
        {
            /*
             * 1 - We order the circles by left most edge (or left most position)
             * 2 - We go over the list of circles, storing the visited circles.
             *     2.1 - For every circle, the non-repeat intersection count will be equal to the number of visited circles UNLESS
             *     2.2 - Unless the visited circle's Right is less than the current circle's left, which means the visited circle won't ever
             *     count as an intersection again, and we can remove it from the list
             */
            var circles = A
                .Select((e, index) => new Circle { Center = index, Radius = e })
                .ToArray();

            Array.Sort(circles, new LeftMostCircleOrderer());

            var intersectingCircles = new List<Circle>(circles.Length);
            var intersections = 0;
            for (int i = 0; i < circles.Length; i++)
            {
                //Go over intersecting circles, and removing the ones that shouldn't be count as an intersection
                //(any in which Right is less than the current circle's Left)
                for (int j = intersectingCircles.Count - 1; j >= 0; j--)
                {
                    if (intersectingCircles[j].Right < circles[i].Left)
                    {
                        intersectingCircles.RemoveAt(j);
                    }
                }

                //The non-repeat intersection count will equal que number of elements in the intersection list
                intersections += intersectingCircles.Count;
                if (intersections > 1e7)
                {
                    return -1;
                }

                //Add ourselves to the possible intersectingCircles for the next run
                intersectingCircles.Add(circles[i]);
            }

            return intersections;
        }
    }
}
