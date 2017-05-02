using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class LongestIncreasingSubsequence
    {
        /// <summary>
        /// LongestIncreasingSubsequenceLength Dynamic (N^2)
        /// </summary>
        public void LISMain()
        {
            int[] A = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };
            int n = A.Length;
            Console.WriteLine("Length of Longest Increasing Subsequence is " + LongestIncreasingSubsequenceLength(A, n));
        }


        private int LongestIncreasingSubsequenceLength(int[] arr, int n)
        {
            int[] list = new int[n];

            //Initialize to 1
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = 1;
            }


            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j])
                        if (list[i] < list[j] + 1)
                            list[i] = list[j] + 1;
                }
            }

            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (list[i] > max)
                    max = list[i];
            }
            return max;
        }
    }
}
