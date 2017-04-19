using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftProblem
{
    class Program
    {
        //Longest Palindromic Substring O(n) space O(2*n+1) Manacher's Algorithm
        public static string longestPalindromeSubstringLT(string str)
        {
            int n = 2 * str.Length + 1,j=0;
            string[] stringArr = new string[n];
            int[] palindromeLength = new int[n];

            //create modified array with #
            for (int i = 0; i < n-2; i++)
            {
                if (j < str.Length)
                {
                    stringArr[i] = "#";
                    stringArr[i + 1] = str[j].ToString();
                    palindromeLength[i] = 0;
                    palindromeLength[i + 1] = 0;
                    i++;
                    j++;
                }
            }
            stringArr[n-1] = "#";
            palindromeLength[n-1] = 0;


            int c = 0, r = 0,  maxLength=0, index =0;

            for (int i = 0; i < n; i++)
            {
                int mirror = 2 * c - i;

                if (i < r)
                { 
                    palindromeLength[i] = Math.Min(r-i , palindromeLength[mirror]);
                }

                int leftIndex, rightIndex;

                leftIndex = i - (1 + palindromeLength[i]);
                rightIndex = i + (1 + palindromeLength[i]);

                if ((leftIndex >= 0 && leftIndex < n) && (rightIndex >= 0 && rightIndex < n))
                {
                    while (stringArr[leftIndex] == stringArr[rightIndex])
                    {
                        
                            palindromeLength[i]++;
                        leftIndex = i - (1 + palindromeLength[i]);
                        rightIndex = i + (1 + palindromeLength[i]);
                        if ((leftIndex < 0 || leftIndex >= n) || (rightIndex < 0 || rightIndex >= n))
                            break;
                    }
                    
                }

                if (maxLength < palindromeLength[i])
                { 
                    maxLength = palindromeLength[i];
                    index = i;
                }

                if (r < i + palindromeLength[i])
                {
                    c = i;
                    r = i + palindromeLength[i];
                }

            }

            str = "";
            for (int i = index - maxLength; i < maxLength + index; i++)
            {
                if (stringArr[i] != "#")
                {
                    str = string.Concat(str,stringArr[i]);
                }
            }

            return str;        
        }
        
        
        //Linked List Palindrome

        LinkedList list1 = new LinkedList();
        Node left;
        public void createLinkedList(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                list1.addLast(s[i].ToString());
            }   
        }
        
        private bool isPalindromeLL(Node right)
        {
             left = list1.head;

            if (right == null)
                return true;

            bool isP = this.isPalindromeLL(right.next);

            if (!isP)
                return false;


            IComparer n = new Node();
            bool isP1 = n.Compare(right.data, left.data) == 0 ? true : false;
            if (!isP1)
                return false;

            left = left.next;
            return true;
        }

        //Dynamic O(n^2) space O(n^2)
     /*   private static int longestPalindromeSubstringDynamic(string p)
        {
            int len = p.Length,j=0;
            int[,] matrix = new int[len, len];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i,i] = 1;
            }

            for (int subStrLen = 2; subStrLen < len; subStrLen++)
            {
                for (int i = 0; i < length; i++)
                {
                    
                }
                
            }

            return 1;
        }*/

        //Continuous Subarray with maximum sum #Kadane's Algorithm
        public static void subArrayMaxSum(int[] inputArr)
        {
            int currStartIndex = 0, startIndexUntilNow = 0, endIndex=0;
            int maxSum = int.MinValue,currSum = 0;
            for (int arrIndex = 0; arrIndex < inputArr.Length; arrIndex++)
            {
                currSum += inputArr[arrIndex];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    currStartIndex = startIndexUntilNow;
                    endIndex = arrIndex;
                }

                if (currSum < 0)
                {
                    currSum = 0;
                    startIndexUntilNow = arrIndex+1;
                }

            }
            Console.WriteLine("Max Sum: "+ maxSum);
            Console.WriteLine("Start Index: " + currStartIndex+" End Index: "+endIndex);
            Console.WriteLine("");
            for (int i = currStartIndex; i <= endIndex; i++)
            {
                Console.Write(inputArr[i]+" ");
            }
            Console.WriteLine("");
             
            
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Microsoft's Questions");
                Console.WriteLine("1. Longest Palindromic Substring ( Linear Time )");
                Console.WriteLine("2. Longest Palindromic Substring ( Dynamic Programming )");
                Console.WriteLine("3. Longest Palindromic Substring ( Linked List )");
                Console.WriteLine("4. subArrayMaxSum");
                Console.WriteLine("5. Count distinct elements in every window: Sliding Window");
                Console.WriteLine("6. Word Boggle");
                Console.WriteLine("0. Exit");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                { 
                    case 1:
                        Console.WriteLine("Enter input string: ");
                        string res = longestPalindromeSubstringLT(Console.ReadLine());
                       // string res = pali(Console.ReadLine());
                        
                        Console.WriteLine("longestPalindromeSubstring : "+ res + " with "+ res.Length);
                        break;
                    case 2:
                       // Console.WriteLine("Enter input string: ");
                       //// res = longestPalindromeSubstringDynamic(Console.ReadLine());
                       // Console.WriteLine("longestPalindromeSubstring : "+ res + " with "+ res.Length);
                        break;
                    case 3:
                        Console.WriteLine("Linked List Palindrome: ");
                        Console.WriteLine("Enter input string: ");
                        res = Console.ReadLine();
                        string[] s = new string[res.Length];
                        for (int i = 0; i < res.Length; i++)
                        {
                            s[i] = res[i].ToString();
                        }
                        
                        Program obj = new Program();
                        obj.createLinkedList(s);
                        bool res1 = obj.isPalindromeLL(obj.list1.head);
                        Console.WriteLine("isPalindrome: "+ res1);
                        Console.WriteLine("");
                        break;

                    case 4:
                        Console.WriteLine("subArrayMaxSum");
                        Console.WriteLine("Input String");
                        int[] inputArr = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
                        subArrayMaxSum(inputArr);
                        break;

                    case 5:
                        Console.WriteLine("Count distinct elements in every window");
                        Console.WriteLine("Input String");
                        inputArr = new int[] { 1, 2, 1, 3, 4, 2, 3 };
                        Console.WriteLine("ENTER VALUE OF SLIDING WINDOW: ");
                        int k = 4;//int.Parse(Console.ReadLine());
                        inputArr = new int[] { 1, 2, 1, 3, 4, 2, 3 };
                        countDistinctElementsInWindow(inputArr,k);

                        break;

                    case 6:
                        Console.WriteLine("Word Boggle");
                       // Console.WriteLine("Input String");
                        string[] dictionary = { "GEEKS", "FOR", "QUIZ", "GO" };
                       // Console.WriteLine("ENTER VALUE OF SLIDING WINDOW: ");
                       // char[][] boggle = {'G','I','Z','U','E','K','Q','S','E'};
                        inputArr = new int[] { 1, 2, 1, 3, 4, 2, 3 };
                        countDistinctElementsInWindow(inputArr, k);

                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }

            }
        }

        private static void countDistinctElementsInWindow(int[] inputArr, int k)
        {
            List<int> lElements = new List<int>();
            int count = 0;
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (!lElements.Contains(inputArr[i]))
                    count++;
                lElements.Add(inputArr[i]);    
                if ((i + 1) >= k)
                {
                    Console.WriteLine("Number of distinct elements: " + count);
                    Console.WriteLine("StartIndex: "+(i-3)+"End Index: "+i);
                    lElements.Remove(lElements[0]);
                    count = lElements.Count;
                }
                
            }
        }

        

        
    }
}
