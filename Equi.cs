/*
 * Medium: Equi
Find the indicies in an array such that its prefix sum equals its suffix sum.

An array A consisting of N integers is given. An equilibrium index of this array is any integer P such that 
0 ≤ P < N and the sum of elements of lower indices is equal to the sum of elements of higher indices, i.e.
A[0] + A[1] + ... + A[P−1] = A[P+1] + ... + A[N−2] + A[N−1].
Sum of zero elements is assumed to be equal to 0. This can happen if P = 0 or if P = N−1.

For example, consider the following array A consisting of N = 8 elements:

  A[0] = -1
  A[1] =  3
  A[2] = -4
  A[3] =  5
  A[4] =  1
  A[5] = -6
  A[6] =  2
  A[7] =  1

P = 1 is an equilibrium index of this array, because:
A[0] = −1 = A[2] + A[3] + A[4] + A[5] + A[6] + A[7]

P = 3 is an equilibrium index of this array, because:
A[0] + A[1] + A[2] = −2 = A[4] + A[5] + A[6] + A[7]

P = 7 is also an equilibrium index, because:
A[0] + A[1] + A[2] + A[3] + A[4] + A[5] + A[6] = 0
and there are no elements with indices greater than 7.

P = 8 is not an equilibrium index, because it does not fulfill the condition 0 ≤ P < N.

Write a function:

def solution(A)

that, given an array A consisting of N integers, returns all of its equilibrium indices. 
The function should return −1 if no equilibrium index exists.

For example, given array A shown above, the function should return 1, 3 and 7, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..100,000];
each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace EquiCodility
{
    class Solution
    {
        public List<int> solution(int[] A)
        {
            List<int> equiIndexes = new List<int>();

            if (A.Length == 0) {
                equiIndexes.Add(-1);

                return equiIndexes;
            }

            int len = A.Length;
            long lowerTotal = 0;
            long higherTotal = 0;

            // Exclude first equilibrium's value from totals.
            //for (var j = 1; j < len; j++)
            //{
            //    higherTotal += A[j];
            //}
            higherTotal = A.Skip(1).Take(len - 1).Sum(i => (long)i);

            /*
             Move equilibrium from lower to upper by one position, adding previous equilibrium value to 
             lower total (as this was excluded from totals but is now available to lower total), and 
             subtracting new equilibrium value from upper total (as this was previously included in upper 
             total but is now unavailable).
             Note: we are testing the current equilibrium position's totals but calculating totals for the 
             next position, because we can pre-calculate the first equilibrium's lower and higher totals 
             before the start of the main loop.
             */
            for (var i = 0; i < len; i++)
            {
                if (lowerTotal == higherTotal)
                {
                    // Equilibrium found at current position.
                    equiIndexes.Add(i);
                }
                // Last iteration, so don't need to calc totals for next equilibrium position.
                if (i < len - 1)
                {
                    // Calc totals for NEXT equilibrium position.
                    lowerTotal += A[i];
                    higherTotal -= A[i + 1];
                }
            }

            // No equilibriums found.
            if (equiIndexes.Count == 0)
            {
                equiIndexes.Add(-1);
            }

            return equiIndexes;
        }

        public void test(int[] A, int[] expected)
        {
            List<int> equiIndex = solution(A);
            // Pass if actual result array "A" equals expected result.
            string result = equiIndex.OrderBy(a => a).SequenceEqual(expected.OrderBy(a => a)) ? "Pass" : "Fail";

            Console.WriteLine("Array = ");
            Array.ForEach(A, Console.WriteLine);

            Console.WriteLine("Expected = ");
            Array.ForEach(expected, Console.WriteLine);

            Console.WriteLine("Equilibrium Indicies = ");
            equiIndex.ForEach(i => Console.WriteLine("{0}", i));

            Console.WriteLine("Test Result: {0}\n\n", result);
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            solution.test(new int[] { -1, 3, -4, 5, 1, -6, 2, 1 }, new int[] { 1, 3, 7 });

            solution.test(new int[] { }, new int[] { -1 });

            solution.test(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 1, 2, 3, 4 });

            solution.test(new int[] { 0 }, new int[] { 0 });
            solution.test(new int[] { 1 }, new int[] { 0 });

            solution.test(new int[] { 0, 0 }, new int[] { 0, 1 });
            solution.test(new int[] { 1, 1 }, new int[] { -1 });
            solution.test(new int[] { 1, 0 }, new int[] { 0 });
            solution.test(new int[] { 0, 1 }, new int[] { 1 });

            solution.test(new int[] { 1, 1, 1 }, new int[] { 1 });
            solution.test(new int[] { 1, 0, 1 }, new int[] { 1 });
            solution.test(new int[] { -1, 2, -1 }, new int[] { 1 });

            solution.test(new int[] {-2147483648, -2147483648, -2147483648, -2147483648, -2147483648 }, new int[] { 2 });
            solution.test(new int[] {2147483647, 2147483647, 2147483647, 2147483647, 2147483647 }, new int[] { 2 });
        }
    }
}
