using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class NQueen
    {
        int n = 0;
        List<int[]> sol;
        int[] placedQueen;
        public NQueen(int n)
        {
            this.n = n;
            placedQueen = new int[n];
            sol = new List<int[]>();
            //for (int i = 0; i < placedQueen.Length; i++)
            //{
            //    placedQueen[i] = -1;
            //}
        }

        public void NQueenProcess()
        {
            nQueenUtil(placedQueen,0);
            foreach (var item in sol)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i]+" ");
                }
                Console.WriteLine("");
            }
            
        }

        private void nQueenUtil(int[] placedQueen, int row)
        {
            if (row == n)
            {
                   
               // sol.Add((int[])placedQueen.Clone());
                sol.Add(placedQueen);
               // placedQueen = new int[n];
                return;
            }

            for (int col = 0; col < n; col++)
            {
                placedQueen[row] = col;
                if (isSafe(placedQueen, row, col))
                {
                    nQueenUtil(placedQueen,row+1);
                }
            }


        }
       

        private bool isSafe(int[] placedQueen,int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if(Math.Abs(i-row) == Math.Abs(placedQueen[i]-col) || col == placedQueen[i])
                return false;
                
            }

            return true;
        }
    }
}
