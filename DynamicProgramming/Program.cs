using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Dynamic Programming");
                
                Console.WriteLine("1. Longest Increasing Subsequence Size-Dynamic (N*N)");
                Console.WriteLine("2. Longest Increasing Subsequence Size (N log N)");
                Console.WriteLine("3. Longest Common Subsequence");
                Console.WriteLine("4. Edit Distance");
                Console.WriteLine("5. Coin Change");
                //Console.WriteLine("6. Largest subarray with sum less than x");
                //Console.WriteLine("5. Longest Increasing Subsequence Size (N log N)");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select question: ");

                int s = int.Parse(Console.ReadLine());

                switch (s)
                {
                    case 1:
                        LongestIncreasingSubsequence lisDyna = new LongestIncreasingSubsequence();
                        lisDyna.LISMain();
                        break;
                    case 2:
                        LISNLogN lis = new LISNLogN();
                        lis.LISNLogNMain();
                        break;
                    case 3:
                        LongestCommonSubsequence ls = new LongestCommonSubsequence();
                        ls.LongestCommonSubsequenceMain();
                        break;
                    case 4:
                        EditDistance ed = new EditDistance();
                        ed.EditDistanceMain();
                        break;
                    case 5:
                        CoinChange cc = new CoinChange();
                        cc.CoinChangeMain();
                        break;
                    //case 6:
                    //    largestSubArrLtX();
                    //    break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }


            }
           
            
 

        
        }
    }
}
