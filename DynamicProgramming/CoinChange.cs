using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class CoinChange
    {
        /// <summary>
        /// Coin Change
        /// </summary>
        public void CoinChangeMain()
        {
            int[] coins = { 2,3,5,6};
            int n = 10;

            Console.WriteLine("CountWays: "+ CC(coins,n));
        }

        private int CC(int[] coins, int n)
        {
            int[] table = new int[n+1];

            table[0] = 1;
            for (int i = 1; i < n; i++)
            {
                table[i] = int.MaxValue;
            }


            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= n; j++)
                {
                    int index = j - coins[i];
                    if (index >= 0)
                    {
                        if (table[j] == int.MaxValue)
                            table[j] = 0;
                        if (table[index] != int.MaxValue)
                            table[j] += table[index];
                    }
                }
            }

            return table[n];
        }
    }
}
