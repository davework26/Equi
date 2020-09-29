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
            for (var j = 1; j < len; j++)
            {
                higherTotal += A[j];
            }

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
