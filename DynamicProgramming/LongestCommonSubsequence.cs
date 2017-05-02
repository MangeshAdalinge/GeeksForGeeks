using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// LongestCommonSubsequence
    /// </summary>
    class LongestCommonSubsequence
    {
        public void LongestCommonSubsequenceMain()
        {
            string str1 = "AGGTAB", str2 = "GXTXAYB";
            //Console.WriteLine("Length Longest Common Subsequence is "+LongestCommonSubsequenceDyna(str1,str2));
            Console.WriteLine("Length Longest Common Subsequence is " + lcs(str1, str2,str1.Length,str2.Length));
        }

        private int LongestCommonSubsequenceDyna(string str1, string str2)
        {
            int m = str1.Length, n = str2.Length;
            int[,] matrix = new int[m,n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        if (str1[i] == str2[j])
                            matrix[i, j] = 1;
                        else
                            matrix[i, j] = 0;
                    else if (str1[i] == str2[j])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }          

            
            return matrix[m-1,n-1];
        }


        private int lcs(string str1, string str2, int m, int n)
        { 
            int[,] matrix = new int[m,n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        if (str1[i] == str2[j])
                            matrix[i, j] = 1;
                        else
                            matrix[i, j] = 0;
                    else if (str1[i] == str2[j])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = max(matrix[i,j-1],matrix[i-1,j]);
                }
            }
            return matrix[m-1,n-1];
        }

        private int max(int p1, int p2)
        {
            if (p1 > p2)
                return p1;
            else
                return p2;
        }
    }
}
