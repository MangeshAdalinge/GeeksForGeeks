using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// Longest Increasing Subsequence Size 
    /// </summary>
    class LISNLogN
    {
        public void LISNLogNMain()
        { 
            int[] A = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };
            int n = A.Length;
            Console.WriteLine("Length of Longest Increasing Subsequence is "+LongestIncreasingSubsequenceLength(A, n));
            
        }

        /// <summary>
        /// LongestIncreasingSubsequenceLength ()
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private int LongestIncreasingSubsequenceLength(int[] A, int n)
        {
            int[] tailTable = new int[n];
            
            tailTable[0] = A[0];
            int len = 1;

            for (int i = 1; i < n; i++)
            {
                if (A[i] < tailTable[0])
                    tailTable[0] = A[i];
                else if (A[i] > tailTable[len - 1])
                    tailTable[len++] = A[i];
                else
                    tailTable[CeilIndex(tailTable,-1,len-1,A[i])]=A[i];                
            }


            return len;
        }

        private int CeilIndex(int[] A, int l, int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;
                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }
            return r;
        }
    }
}
