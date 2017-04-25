using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class RatInMaze
    {
        int n = 4;
        int[,] maze = new int[,] { {1, 0, 0, 0},
                                   {1, 1, 0, 1},
                                   {0, 1, 0, 0},
                                   {1, 1, 0, 1}};
        int[] dest = new int[] { 3, 3 };

        //ratInMaze --> Backtracking Graph 
        public void ratInMaze()
        {
            Console.WriteLine(ratInMazeUtil(maze, 0, 0));
        }

        private bool ratInMazeUtil(int[,] maze, int row, int col)
        {
            Console.WriteLine(row + "->" + col);
            //Base Condition
            if (row == dest[0] && col == dest[1])
                return true;

            //Forward Move
            if (!isBlocked(maze, row, col + 1))
                if (ratInMazeUtil(maze, row, col + 1))
                    return true;

            //Down Move
            if (!isBlocked(maze, row + 1, col))
                if (ratInMazeUtil(maze, row + 1, col))
                    return true;

            return false;
        }

        //Inside bound
        private bool isValid(int x, int y)
        {
            if (x >= n || y >= n)
                return false;

            return true;
        }

        //Blocked
        private bool isBlocked(int[,] maze, int x, int y)
        {
            if (isValid(x, y))
                if (maze[x, y] == 1)
                    return false;

            return true;
        }
    }
}
