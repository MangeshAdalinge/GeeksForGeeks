using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class KightTour
    {
        int[,] next = new int[8, 2]{ { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 },
			{ 2, -1 } };
        
        int[,] chessBoard = new int[8, 8];
        int n = 8;
        public void findKightTour()
        {
            chessBoard[0, 0] = 1;

            if (findKightTourUtil(0, 0, 2))
            {
                Console.WriteLine("true");
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        Console.Write(chessBoard[r, c] + " | ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("False");
            }
        
        }

        private bool findKightTourUtil(int i,int j, int move)
        {
            //if (move == 4)
            //{
            //    for (int r = 0; r < n; r++)
            //    {
            //        for (int c = 0; c < n; c++)
            //        {
            //            Console.Write(chessBoard[r, c] + " | ");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}
           
            if (move >64)
                return true;

            //if (!isValid(i, j))
            //    return false;
            for (int item = 0; item < n; item++)
            {
                int x = i + next[item, 0], y = j+next[item, 1];
                if (!isAssigned(x, y))
                {                    
                    chessBoard[x, y] = move;                    
                    if (findKightTourUtil(x, y, move+1))
                        return true;
                   // else
                        chessBoard[x, y] = 0;                         
                }             
            }

            return false;
        }

        //isValid
        private bool isValid(int i, int j)
        {
            if (i < 0 || i >= n || j < 0 || j >= n)
                return false;
            return true;
        }

        //isAssigned
        private bool isAssigned(int i, int j)
        {
            if (isValid(i,j) && chessBoard[i, j] == 0)
                return false;
            return true;
        }
    }
}
