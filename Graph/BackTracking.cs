using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class BackTracking
    {
       

        public void backTrackingProblems()
        {
            while (true)
            {
                Console.WriteLine("Welcome to BackTracking");
                Console.WriteLine("1. Rat In A Maze");
                Console.WriteLine("2. GraphColoring");
                Console.WriteLine("3. Kight TOur");
                Console.WriteLine("4. NQueen");
                //Console.WriteLine("5. ");
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
                        RatInMaze rm = new RatInMaze();
                        rm.ratInMaze();
                        break;

                    case 2:
                        GraphColoring gc = new GraphColoring();
                        gc.graphColoring();
                        break;

                    case 3:
                        KightTour kt = new KightTour();
                        kt.findKightTour();
                        break;

                    case 4:
                        NQueen nq = new NQueen(4);
                        nq.NQueenProcess();
                        break;

                    case 5:                       
                        break;

                }
            }
        }

             
    }
}
