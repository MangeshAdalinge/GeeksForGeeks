using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{

    class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welecome to HASHING");
                Console.WriteLine("1. Sub-Array Whose Sum Is X");
                Console.WriteLine("2. Vertical Order Traversal");
                Console.WriteLine("3. Check duplicate within K in array");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        break;

                    case 2:
                        TreeNode root = new TreeNode(1);
                        root.left = new TreeNode(2);
                        root.right = new TreeNode(3);
                        root.left.left = new TreeNode(4);
                        root.left.right = new TreeNode(5);
                        root.right.left = new TreeNode(6);
                        root.right.right = new TreeNode(7);
                        root.right.left.right = new TreeNode(8);
                        root.right.right.right = new TreeNode(9);
                        Console.WriteLine("Vertical order traversal is \n");
                        printVerticalOrder(root);
                        break;
                    case 3:
                        int[] arr = { 10, 5, 3, 4, 13, 5, 6 };
                        int k = 3;
                        if(checkDuplicateWithinK(arr, k))
                             Console.WriteLine("Contains duplicates ");
                        else
                            Console.WriteLine("Does not contains duplicates ");
                        
                        break;
                }

            }

        }

        private static bool checkDuplicateWithinK(int[] arr, int k)
        {
            //Dictionary<int,int> elementsWithinK = new Dictionary<int,int>();

            List<int> elementsWithinK = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (elementsWithinK.Contains(arr[i]))
                    return true;

                elementsWithinK.Add(arr[i]);

                if (i >= k)
                {
                    elementsWithinK.Remove(arr[i - k]);
                }

            }
            return false;
            

        }        

        public static void subArrWhoseSumIsX()
        {
            int[] arr1 = new int[] { -1, -2, 4, -6, 5, 7 }, arr2 = new int[] { 6, 3, 4, 0 };
            int x = 8;
            Console.WriteLine("Given two unsorted arrays, find all pairs whose sum is " + x);

            arraysWhoseSumIsX obj1 = new arraysWhoseSumIsX();
            HashSet<int> arr1Set = new HashSet<int>(arr1);

            for (int i = 0; i < arr2.Length; i++)
            {
                int[] res = obj1.sumIsX(arr1Set, arr2[i], x);
                if (res != null)
                    Console.WriteLine(res[0] + " " + res[1]);
            }

        }        

        // Vertical Order Traversal
        private static void printVerticalOrder(TreeNode root)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            int hd = 0;

            findMinMax(root, map, hd);

            

            foreach (var item in map.OrderBy(i => i.Key))
            {
                Console.Write(item.Key+": ");
                foreach (var l in item.Value)
                {
                    Console.Write(l+" ");
                }
                Console.WriteLine();
            }

        }

        private static void findMinMax(TreeNode root, Dictionary<int, List<int>> map, int hd)
        {
            if (root == null)
                return;

            List<int> l = new List<int>();
            l.Add(root.data);

            if (map.ContainsKey(hd))
            {
                map[hd].Add(root.data);
                
            }
            else
            {
                
                map.Add(hd, l);
            }
            findMinMax(root.left, map,hd-1);
            findMinMax(root.right, map, hd + 1);


        }
    }
}
