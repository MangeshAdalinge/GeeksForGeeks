using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class ZAlgorithm
    {
        public int zAlgo(string str, string pattern)
        {
            string s = pattern + "$" + str;
           // Console.WriteLine("Input: "+s);
            int[] z = new int[s.Length];
            int l = 0, r = 0;

            z[0] = 0;
            

            for (int i = 1; i < s.Length; i++)
            {
                bool flag = false;
                l = 0;
                r = i;
                while (r < s.Length && s[l] == s[r])
                {
                    l++;
                    r++;
                    z[i]++;
                }
                if (z[i] > 1)
                {
                    for (int j = 1; j < z[i] ; j++)
                    {
                        if (i + j + z[j] < r)
                            z[i + j] = z[j];
                        else
                        {
                            flag = true;
                            i = i + j - 1;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        i = r - 1;
                    }
                    
                }
                //else
                   // 
                
            }
           // Console.WriteLine("here");

            return cntOccurances(z,pattern);
        }

        public int cntOccurances(int[] z, string pattern)
        {
            int cnt = 0;
            for (int i = 0; i < z.Length; i++)
            {
                if (z[i] == pattern.Length)
                {
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
