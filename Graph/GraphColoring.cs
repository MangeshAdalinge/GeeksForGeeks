using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class GraphColoring
    {
        //Number of colors
        int m = 3;
        //Number of Nodes
        int V = 4;
        //Graph
        int[,] graph ={{0, 1, 1, 1},
                       {1, 0, 1, 0},
                       {1, 1, 0, 1},
                       {1, 0, 1, 0},
                     };

        public void graphColoring()
        {
            //initialise color array to 0
            int[] color = new int[V];
            
                if (!graphColoringUtil(graph, m,color,0))
                {
                    Console.WriteLine("False");
                    return;
                }
                foreach (var item in color)
                {
                    Console.Write(item+" ");
                } 
            Console.WriteLine("True");            
            
        }

        private bool graphColoringUtil(int[,] graph, int m,int[] color, int v)
        {
            //All Vertices are colored
            if (v == V)
                return true;

            // Assign color
            for (int c = 1; c <= m; c++)
            {
                if (isSafe(graph, color, v, c))
                {
                    color[v] = c;
                    if(graphColoringUtil(graph, m, color, v + 1))
                        return true;

                    color[v] = 0;
                }
                
            }
            return false;
        }

        private bool isSafe(int[,] graph,int[] color, int v, int c)
        {
            for (int i = 0; i < V; i++)
            {
                if (graph[v, i] == 1 && color[i] == c)
                    return false;
            }

            return true;
        }

    }
}
