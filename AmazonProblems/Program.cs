using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonProblems
{
    class Program
    {
        //checkMirrorTree
        public static void checkMirrorTree()
        {
         //No of test cases
            int T = int.Parse(Console.ReadLine());
            string[] originalTreeIP = new string[T], mirrorTreeIP = new string[T];
            for (int i = 0; i < T; i++)
            {
                originalTreeIP[i] = Console.ReadLine();
                mirrorTreeIP[i] = Console.ReadLine();
            }
            for (int i = 0; i < T; i++)
            {
               // int n = int.Parse(Console.ReadLine());
                //int e = int.Parse(Console.ReadLine());
                string[] originalTree = originalTreeIP[i].Split(' ');
                string[] mirrorTree = mirrorTreeIP[i].Split(' ');

                if (NAryTree.checkMirror(originalTree, mirrorTree))
                    Console.WriteLine("Mirror");
                else
                    Console.WriteLine("Not mirror");

                Console.ReadLine();
            }
        }

        public static void rearangeCharacters()
        {
            RearrangeCharacters obj = new RearrangeCharacters();
            Console.WriteLine("Rearange Characters");
            Console.WriteLine("Enter the number of test cases: ");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter input strings");
            string[] input = new string[t];
            for (int i = 0; i < t; i++)
            {
                input[i] = Console.ReadLine();
            }

            
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine("Input: " + input[i]);
                string str = input[i];
                char c = str[0];
                int maxFreq = 0,cnt =0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (c == str[j])
                    {
                        cnt++;
                        if (maxFreq < cnt)
                            maxFreq = cnt;
                    }
                    else
                    {
                        cnt = 0;
                        c = str[j];
                    }
                }
                if (str.Length % 2 == 0)
                {
                    if (maxFreq > str.Length / 2 )
                        Console.WriteLine("Cannot be rearranged");
                    else
                        Console.WriteLine("Can be rearranged");
                }
                else
                {
                    if (maxFreq > str.Length / 2 + 1)
                        Console.WriteLine("Cannot be rearranged");
                    else
                        Console.WriteLine("Can be rearranged");
                }

            }
            Console.ReadLine();

        }

        //Rearrange characters in a string such that no two adjacent are same
        public static void rearangeCharactersWithPattern()
        {
            RearrangeCharacters obj = new RearrangeCharacters();
            Console.WriteLine("Rearange Characters");
            Console.WriteLine("Enter the number of test cases: ");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter input strings");
            string[] input = new string[t];
            for (int i = 0; i < t; i++)
			{
			    input[i] = Console.ReadLine();
			}


            for (int i = 0; i < t; i++)
			{
			    Console.WriteLine("Input: "+  input[i] );
                string[] res = obj.checkRearrangementPossibility(input[i]);
                if (Array.IndexOf(res, null) == -1)
                {
                    Console.WriteLine("Rearrangement is possible");
                    string ret = "";
                    for (int j = 0; j < res.Length; j++)
                    {
                        
                        ret = string.Concat(ret, res[j].ToString());
                    }
                    Console.WriteLine("Output: " + ret);
                }
                else
                    Console.WriteLine("Rearrangement is Not Possible");
			}
            Console.ReadLine();
        
        }

        //Check if string is rotated by two places
        public static void rotatedString()
        {
            Console.WriteLine("");
            Console.WriteLine("Check if string is rotated by two places");
            Console.WriteLine("Enter strings: ");
            string originalString = Console.ReadLine();
            string rotatedString = Console.ReadLine();
            Console.WriteLine("originalString: " + originalString);
            Console.WriteLine("rotatedString: " + rotatedString);

            //clockwise
            string clockwiseShifted = originalString.Substring(0, originalString.Length - 2);
            clockwiseShifted = string.Concat(clockwiseShifted, originalString.Substring(originalString.Length - 2, 2));

            //anti-clockwise
            string antiClockShifted = originalString.Substring(2, originalString.Length - 2);
            antiClockShifted = string.Concat(antiClockShifted, originalString.Substring(0, 2));

            if (antiClockShifted.Equals(rotatedString) || clockwiseShifted.Equals(rotatedString))
                Console.WriteLine("Shifted correctly");
            else
                Console.WriteLine("Shifted uncorrectly");
        }

        //Smallest subarray with sum greater than x
        public static void smallestSubArrayGtX()
        {
            Console.WriteLine("Smallest subarray");
           /* //Console.WriteLine("Enter the number of test cases");
            //int t = int.Parse(Console.ReadLine());

            //Dictionary<List<int>, int> l = new Dictionary<List<int>, int>();
            //for (int i = 0; i < t; i++)
            //{
                
            //}
            //int[] arr = new int[6] { 1, 4, 45, 6, 0, 19 };
            //int x = 51;*/
            int[] arr = new int[5] { 1, 10, 5, 2, 7 };
            int x = 9;
            int currSum = 0, minSubArrLen = arr.Length;
            int startIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                while (currSum > x)
                {
                    int len = i - startIndex;
                    if (len < minSubArrLen)
                        minSubArrLen = len;
                    currSum = currSum - arr[startIndex];
                    startIndex++;
                }

                currSum = currSum + arr[i];
            }

            Console.WriteLine("smallestSubArraygtX: "+ minSubArrLen);
        }

        //Largest subarray with sum greater than x
        public static void largestSubArrLtX()
        {
            Console.WriteLine("Largest Subarray Greater than X");
            Console.WriteLine("");

            int[] arr = new int[5] { 1, 10, 5, 2, 7 };
            int x = 9;
            int maxLen = 0, endIndex = 0, currSum = 0;
            int startIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
               
                while (currSum <= x && endIndex < arr.Length)
                 {
                     int len = endIndex - i;
                    if (maxLen < len)
                    {
                        maxLen = len;
                        startIndex = i;                        
                    }
                    currSum = currSum + arr[endIndex];
                    endIndex++;
                }
                currSum = currSum - arr[i];
                 
            }

            Console.WriteLine("Largest: "+ maxLen);
            int index = startIndex;
            while ( maxLen --> 0)
            {
                if (index < arr.Length)
                {
                    Console.Write(arr[index] + " ");
                    index++;
                }
            }

            Console.WriteLine("");


            
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Amazon Interview Questions");
                
                Console.WriteLine("1. Check Mirror of Tree");
                Console.WriteLine("2. Rearrange Characters");
                Console.WriteLine("3. Rearrange Characters and return pattern");
                Console.WriteLine("4. Rotated String");
                Console.WriteLine("5. Smallest subarray with sum greater than x");
                Console.WriteLine("6. Largest subarray with sum less than x");
                Console.WriteLine("5. Longest Increasing Subsequence Size (N log N)");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select question: ");

                int s = int.Parse(Console.ReadLine());

                switch (s)
                {
                    case 1:
                        checkMirrorTree();
                        break;
                    case 2:
                        rearangeCharacters();
                        break;
                    case 3:
                        rearangeCharacters();
                        break;
                    case 4:
                        rotatedString();
                        break;
                    case 5:
                        smallestSubArrayGtX();
                        break;
                    case 6:
                        largestSubArrLtX();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }


            }
           
            
 

        }
    }
}
