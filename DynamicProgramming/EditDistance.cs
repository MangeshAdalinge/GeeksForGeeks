using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// EditDistance
    /// </summary>
    class EditDistance
    {
        public void EditDistanceMain() 
        {
            string str1 = "$sunday", str2 = "$saturday";
            Console.WriteLine("Edit Distance is "+ ED(str1,str2,str1.Length,str2.Length));
            
        }

        private int ED(string str1, string str2, int m, int n)
        {
            int[,] edMatrix = new int[m,n];

            for (int j = 0; j < m; j++)
            {
                edMatrix[j, 0] = j;
            }
            for (int j = 0; j < n; j++)
            {
                edMatrix[0, j] = j;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (str1[i] == str2[j])
                        edMatrix[i, j] = edMatrix[i - 1, j - 1];
                    else
                        edMatrix[i, j] = min(edMatrix[i, j-1]+1, edMatrix[i-1, j-1]+1, edMatrix[i-1, j]+1);
                }
            }
            
            return edMatrix[m-1,n-1];
        }

        private int min(int p1, int p2, int p3)
        {
            SortedSet<int> list = new SortedSet<int>();

            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            return list.ElementAt(0);
        }
    }
}
