using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class AssignmentProblem
    {
        

        private int[,] rowMin(int[,] inputArr, int row, int col)
        {
            //Row
            int[] minRow = new int[row];
            for (int i = 0; i < minRow.Length; i++)
            {
                minRow[i] = int.MaxValue;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (inputArr[i, j] < minRow[i])
                        minRow[i] = inputArr[i, j];
                }
            }
            //substract min from each row
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    inputArr[i, j] = inputArr[i, j] - minRow[i];
                    
                }
            }

            return inputArr;
        }

        private int[,] colMin(int[,] inputArr, int row, int col)
        {
            //Column
            int[] minCol = new int[row];
            for (int i = 0; i < minCol.Length; i++)
            {
                minCol[i] = int.MaxValue;
            }
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (inputArr[j, i] < minCol[i])
                        minCol[i] = inputArr[j, i];
                }
            }
            //substract min from each column
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    inputArr[j, i] = inputArr[j, i] - minCol[i];
                    
                }
            }

            return inputArr;
        }

        private Dictionary<int, List<int>> HashMapZeroIndex(int[,] inputArr, int row, int col)
        { 
            Dictionary<int, List<int>> zeroIndex = new Dictionary<int, List<int>>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    if (inputArr[i, j] == 0)
                    {
                        if (zeroIndex.ContainsKey(i))
                        {
                            zeroIndex[i].Add(j);
                        }
                        else
                        {
                            List<int> l = new List<int>();
                            l.Add(j);
                            zeroIndex.Add(i, l);
                        }
                    }
                }

            }
            return zeroIndex;
        }



        public Dictionary<int, int> hungarianAlgorithm(int[,] inputArr, int row, int col)
        {
            inputArr = rowMin(inputArr,row,col);
            inputArr = colMin(inputArr, row, col);
            Dictionary<int, List<int>> zeroIndex = HashMapZeroIndex(inputArr, row, col);
            Dictionary<int, int> costArrIndex = new Dictionary<int, int>();
            
            for (int i = 0; i < row; i++)
            {
                if (zeroIndex[i].Count == 1)
                {
                    List<int> l = zeroIndex[i];
                    int e = l[0];
                    if(!costArrIndex.ContainsKey(e))
                        costArrIndex.Add(e, i);
                }               
            }

            for (int i = 0; i < row; i++)
            {
                 int cnt = zeroIndex[i].Count;
                 
                     //for (int j = 0; j < cnt; j++)
                     //{
                 int j = 0;
                while(j < cnt)
                {
                         if (zeroIndex[i].Count > 1)
                         {
                             if (costArrIndex.ContainsKey(zeroIndex[i].ElementAt(j)))
                             {
                                 zeroIndex[i].RemoveAt(j);
                                 j = 0;
                                 cnt--;
                                 
                             }
                             else
                                 j++;
                        }
                        else
                         j++;
                    }
            }

            for (int i = 0; i < row; i++)
            {
                if (zeroIndex[i].Count == 1)
                {
                    List<int> l = zeroIndex[i];
                    int e = l[0];
                    if (!costArrIndex.ContainsKey(e))
                        costArrIndex.Add(e, i);
                }
            }

            return costArrIndex;
        }


    }
}
