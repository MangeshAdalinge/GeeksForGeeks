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
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        minHeap();
                        break;

                    case 2:
                        maxHeap();
                        break;
                    case 3:
                        medianOfStream();

                        break;

                
                }
            }
           
            

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
            HeapMaxMin objMax = new HeapMaxMin(noStreams, "MAX");
            HeapMaxMin objMin = new HeapMaxMin(noStreams, "MIN");

            for (int i = 0; i < streamArr.Length; i++)
            {
                if (effectiveMedian < streamArr[i])
                    objMin.insertElement(streamArr[i]);
                else
                    objMax.insertElement(streamArr[i]);

                if (objMin.count > objMax.count + 1)
                {
                    int switchElement = objMin.array[0];
                    objMin.delete();
                    objMin.buildHeap(objMin, objMin.array, objMin.array.Length);

                    objMax.insertElement(switchElement);
                    objMax.buildHeap(objMax,objMax.array,objMax.array.Length);
                
                }
                else if (objMax.count  > objMin.count+1)
                {
                    int switchElement = objMax.array[0];
                    objMax.delete();
                    objMax.buildHeap(objMax, objMax.array, objMax.array.Length);

                    objMin.insertElement(switchElement);
                    objMin.buildHeap(objMin, objMin.array, objMin.array.Length);
                }
                //else 
                //{
                    if (objMin.count == objMax.count)
                        effectiveMedian = (objMin.array[0] + objMax.array[0]) / 2;
                    else if (objMin.count > objMax.count)
                        effectiveMedian = objMin.array[0];
                    else if (objMax.count > objMin.count)
                        effectiveMedian = objMax.array[0];
               // }

                Console.WriteLine("Element Inserted: "+ streamArr[i] +" Median: "+effectiveMedian);
            }
        
        }

        static void minHeap()
        {
            Console.WriteLine("Welcome to HEAP");

            Heap objMin = new Heap(4, "MIN");
            int[] ipArr = new int[4] { 5,15,0,0 };
            objMin.buildHeap(objMin, ipArr, ipArr.Length);
            objMin.display(objMin);
            Console.WriteLine();

            objMin.deleteMax();
            objMin.display(objMin);

            //obj.insert(10);
            //obj.insert(32);
            //obj.insert(16);
            //obj.insert(9);
            //obj.insert(8);
            //obj.insert(40);
            // Console.WriteLine(obj.array);
        }

        static void maxHeap()
        {
            //Heap obj = new Heap(10,"MAX");
            HeapMaxMin objMax = new HeapMaxMin(7, "MAX");
            int[] ipArr = new int[7] { 10, 9, 12, 1, 21, 18, 31 };
            objMax.buildHeap(objMax, ipArr, ipArr.Length);
            objMax.display(objMax);
            Console.WriteLine();
        }



    }
}
