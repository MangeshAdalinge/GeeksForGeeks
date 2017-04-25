using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Graph");
                Console.WriteLine("1. DFS");
                Console.WriteLine("2. BFS");
                Console.WriteLine("3. Detect Cycle");
                Console.WriteLine("4. Hungarian Algorithm for Assignment Problem - GOOGLE");
                Console.WriteLine("5. Backtracking ");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice");
                int ch = int.Parse(Console.ReadLine());

               // int[,] inputArr = new int[,]

                switch (ch)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        DFS();
                        break;

                    case 2:
                        BFS();
                        break;
                    
                    case 3:                        
                        detectCycle();
                        break;
                    
                    case 4:
                        //Google
                        assignmentProblem();
                        break;

                    case 5:
                        BackTracking bkt = new BackTracking();
                        bkt.backTrackingProblems();
                        break;

                }
            }
 
        }
        //Hungarian Algorithm O(n3)
        private static void assignmentProblem()
        {
            /*
3
2500 4000 3500 4000 6000 3500 2000 4000 2500
             * 
2
3 5 10 1
             * 
3
2 1 2 9 8 1 1 1 1
             * 
             */
            Console.WriteLine("Welcome to Google's Assignment Problem");
            Console.WriteLine("Enter number of jobs and people");
            int row = int.Parse(Console.ReadLine());
            int col = row;
            string[] input = Console.ReadLine().Split(' ');
            int[,] inputArr = new int[row, col];
            int[,] resArr = new int[row, col];
            int arrRow = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    inputArr[arrRow, j] = Convert.ToInt32(input[i]);
                    resArr[arrRow, j] = Convert.ToInt32(input[i]);
                    i++;
                }
                arrRow++;
                i--;

            }
            /*int[,] inputArr = new int[,]{{2500,  4000,  3500}
                                          ,{4000,  6000,  3500}
                                          ,{2000,  4000,  2500}};
            int[,] resArr = new int[,]{{2500,  4000,  3500}
                                          ,{4000,  6000,  3500}
                                          ,{2000,  4000,  2500}};
            int row = inputArr.GetLength(0), col = inputArr.GetLength(1);*/
              

           /* int[,] inputArr = new int[,]{{2, 1, 2}
                                          ,{9, 8, 1}
                                          ,{1, 1, 1}};
            int[,] resArr = new int[,]{{2, 1, 2}
                                          ,{9, 8, 1}
                                          ,{1, 1, 1}};
            int row = inputArr.GetLength(0), col = inputArr.GetLength(1);*/

            AssignmentProblem obj = new AssignmentProblem();
            Dictionary<int, int> resIndex = obj.hungarianAlgorithm(inputArr, row, col);

            int cost =0;
            foreach (var item in resIndex)
            {
                cost = cost + resArr[item.Value, item.Key];
            }
            Console.WriteLine("Minmal Cost: " + cost);
            
        }

        private static void detectCycle()
        {
            throw new NotImplementedException();
        }

        private static void BFS()
        {
            throw new NotImplementedException();
        }

        private static void DFS()
        {
            throw new NotImplementedException();
        }
    }
}
