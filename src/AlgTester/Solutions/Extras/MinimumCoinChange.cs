using System;
using System.Collections.Generic;
using System.Text;

namespace AlgTester.Solutions.Extras
{
    class MinimumCoinChange
    {
        /*Given a value V, if we want to make change for V cents, and we have infinite supply of each of C = { C1, C2, .. , Cm} valued coins, 
     * what is the minimum number of coins to make the change?
     */
        public int solution(int[] coins, int value)
        {
            return calculateMinCoins(coins, value);
        }

        int calculateMinCoins(int[] coins, int value)
        {
            if (value == 0)
            {
                return 0;
            }

            int totalMinCoins = int.MaxValue;

            foreach (var coin in coins)
            {
                if (coin <= value)
                {
                    int minCoins = calculateMinCoins(coins, value - coin) + 1;

                    if (minCoins < totalMinCoins)
                    {
                        totalMinCoins = minCoins;
                    }
                }
            }

            return totalMinCoins == int.MaxValue ? 1 : totalMinCoins;
        }
    }
}
