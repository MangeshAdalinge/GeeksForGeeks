using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Heap");
                Console.WriteLine("1. Max Heap");
                Console.WriteLine("2. Min Heap");
                Console.WriteLine("3. Median in a stream of integers (running integers)");
                Console.WriteLine("4. Merge k sorted arrays");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        maxHeap();                        
                        break;

                    case 2:
                        minHeap();
                        break;
                    case 3:
                        //Amazon
                        medianOfStream();
                        break;
                    case 4:
                        //Amazon
                        mergeKSortedArrays();
                        break;
                
                }
            }
           
            

        }

        private static void mergeKSortedArrays()
        {
            Console.WriteLine("Merge K-Sorted Arrays");
            int numberOfArrays = 3, numberOfElements = 4,k=0,x=0,y=0,z=0;
            int[,] arr = new int[,]{ {1, 3, 5, 7},
            {2, 4, 6, 8},
            {0, 9, 10, 11}};
            MinHeapKSortedArray obj = new MinHeapKSortedArray(numberOfArrays);
            Dictionary<int, int> elementIndexMapping = new Dictionary<int, int>();


            while(k < numberOfArrays)
            {
                obj.insertElement(arr[k,0],k);
                if (!elementIndexMapping.ContainsKey(k))
                    elementIndexMapping.Add(k, 0);
                k++;
            }

            while (elementIndexMapping.Count >= 0)
            {
                int delIndex = obj.delete();
                if (delIndex < 0)
                    break;
               
                    Console.Write(arr[delIndex, elementIndexMapping[delIndex]] + " ");
                    elementIndexMapping[delIndex]++;

                    if (elementIndexMapping[delIndex] >= numberOfElements)
                        elementIndexMapping.Remove(delIndex);
                    if (elementIndexMapping.ContainsKey(delIndex))
                        if (elementIndexMapping[delIndex] < numberOfElements)
                            obj.insertElement(arr[delIndex, elementIndexMapping[delIndex]], delIndex);
                
                
                
            }
            Console.WriteLine("Complexity n*k*log(k)");
           /* while (x < numberOfElements || y < numberOfElements || z < numberOfElements)
            {
                int delIndex = obj.delete();

                if (delIndex == 0 )
                {
                    Console.Write(arr[delIndex, x] + " ");
                    x++;
                    if (x < numberOfElements)
                        obj.insertElement(arr[delIndex, x], delIndex);
                }
                if (delIndex == 1)
                {
                    Console.Write(arr[delIndex, y] + " ");
                    y++;
                    if (y < numberOfElements)
                        obj.insertElement(arr[delIndex, y], delIndex);
                }
                if (delIndex == 2)
                {
                    Console.Write(arr[delIndex, z] + " ");
                    z++;
                    if (z < numberOfElements)
                        obj.insertElement(arr[delIndex, z], delIndex);
                }

            }*/
            Console.WriteLine("");

        }

        private static void medianOfStream()
        {
            Console.WriteLine("Enter number of streams: ");
            int noStreams = int.Parse(Console.ReadLine());
            int[] streamArr = new int[noStreams];

            for (int i = 0; i < noStreams; i++)
            {
                streamArr[i] = int.Parse(Console.ReadLine());
            }

            int effectiveMedian = 0;
            MaximumHeap objMax = new MaximumHeap(noStreams);
            MinimumHeap objMin = new MinimumHeap(noStreams);

            for (int i = 0; i < streamArr.Length; i++)
            {
                
                if (effectiveMedian < streamArr[i])
                    objMin.insertElement(streamArr[i]);
                else
                    objMax.insertElement(streamArr[i]);

               
                if (objMin.count - objMax.count >= 2)
                {
                    int switchElement = objMin.array[0];
                    objMin.delete();
                    objMax.insertElement(switchElement);
                }
                else if (objMax.count  - objMin.count>=2)
                {
                    int switchElement = objMax.array[0];
                    objMax.delete();
                    objMin.insertElement(switchElement);                   
                }
                
                if (objMin.count == objMax.count)
                    effectiveMedian = (objMin.array[0] + objMax.array[0]) / 2;
                else if (objMin.count > objMax.count)
                    effectiveMedian = objMin.array[0];
                else if (objMax.count > objMin.count)
                    effectiveMedian = objMax.array[0];

                Console.WriteLine("Element Inserted: "+ streamArr[i] +" Median: "+effectiveMedian);
            }
        
        }

        private static void minHeap()
        {
            Console.WriteLine("Welcome to MIN HEAP");
            MinimumHeap objMin = new MinimumHeap(4);
            int[] ipArr = new int[4] { 5, 15, 10, 3 };
            objMin.buildHeap(objMin, ipArr, ipArr.Length);
            Console.WriteLine("Min Heap Elements");
            objMin.display(objMin);
            Console.WriteLine("");
            Console.WriteLine("Deleted element: " + objMin.delete());
            Console.WriteLine("");
            Console.WriteLine("Min Heap Elements");
            objMin.display(objMin);
            objMin.insertElement(1);
            Console.WriteLine("");
            Console.WriteLine("Min Heap Elements");
            objMin.display(objMin);
            Console.WriteLine("");
        }

        private static void maxHeap()
        {
            
            MaximumHeap objMax = new MaximumHeap(4);
            int[] ipArr = new int[4] { 5, 15, 10, 3 };
            objMax.buildHeap(objMax, ipArr, ipArr.Length);
            Console.WriteLine("Max Heap Elements");
            objMax.display(objMax);
            Console.WriteLine("");
            Console.WriteLine("Deleted element: " + objMax.delete());
            Console.WriteLine("");
            Console.WriteLine("Max Heap Elements");
            objMax.display(objMax);
            objMax.insertElement(25);
            Console.WriteLine("");
            Console.WriteLine("Max Heap Elements");
            objMax.display(objMax);
            Console.WriteLine("");
        }



    }
}
