using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonProblems
{
    class RearrangeCharacters
    {
        public string[] checkRearrangementPossibility(string input)
        {
            Dictionary<string,int> freqTable = new Dictionary<string,int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!freqTable.ContainsKey(input[i].ToString()))
                {
                    freqTable.Add(input[i].ToString(), 1);
                }
                else
                {                    
                    freqTable[input[i].ToString()]++;
                }
            }

            var pairs = freqTable.OrderByDescending(pair => pair.Value);
            string[] rearrangeArray = new string[input.Length];
            
            
            foreach (var item in pairs)
            {
                int startIndex = Array.IndexOf(rearrangeArray, null);

                for (int i = 0; i < item.Value; i++ )
                {
                    if (startIndex != -1 && startIndex < rearrangeArray.Length)
                    {
                        rearrangeArray[startIndex] = item.Key;
                        startIndex = startIndex + 2;
                    }

                    
                }
            }


            return rearrangeArray;
        }
    }
    class MaxHeap
    {
        public int[] array;
        public int count;
        public int capacity;
        
        public int leftChild(int p)
        {
            int left = p * 2 + 1;
            if(left >= this.count)
                return -1;

            return left;
        }

        public int rightChild(int p)
        {
            int right = p * 2 + 2;
            if(right >= this.count)
                return -1;

            return right;
        }

    }
}
