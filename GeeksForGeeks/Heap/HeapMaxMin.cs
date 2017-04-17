using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class HeapMaxMin
    {
        public int[] array;
        public int capacity, count;
        string heapType;

        public HeapMaxMin(int cap, string hType)
        {
            capacity = cap;
            array = new int[capacity];
            count = 0;
            heapType = hType;

        }

        public int parent(int childIndex)
        {
            if (childIndex <= 0 && childIndex >= count)
                return -1;

            return (childIndex - 1) / 2;
            
        }

        public int leftChild(int parentIndex)
        {
            int childIndex = parentIndex * 2 + 1;

            if (childIndex > count)
                return -1;

            return childIndex;
        }

        public int rightChild(int parentIndex)
        {
            int childIndex = parentIndex * 2 + 2;

            if (childIndex > count)
                return -1;

            return childIndex;
        }

        public void resizeHeap(int capacity)
        { 
            int[] oldArr = new int[capacity];
            Array.Copy(array,oldArr,array.Length);
            this.capacity = 2*capacity;
            array = new int[this.capacity];
            for (int i = 0; i < oldArr.Length; i++)
            {
                array[i] = oldArr[i];
            }
        }

        public void insertElement(int data)
        {
            int childIndex;
            if (this.count == this.capacity)
                resizeHeap(this.capacity);
            this.count++;
            childIndex = this.count - 1;
            
           // int parentIndex = parent(childIndex);
            if (heapType == "MIN")
            {
                while (childIndex > 0 && data < array[(childIndex - 1) / 2])
                {
                    if (childIndex == 0 && array == null)
                    {
                        break;
                    }
                    array[childIndex] = array[(childIndex - 1) / 2];
                    childIndex = (childIndex - 1) / 2;
                }

                array[childIndex] = data;
            }
            else if (heapType == "MAX")
            {
                while (childIndex > 0 && data > array[(childIndex - 1) / 2])
                {
                    if (childIndex == 0 && array == null)
                    {
                        break;
                    }
                    array[childIndex] = array[(childIndex - 1) / 2];
                    childIndex = (childIndex - 1) / 2;
                }

                array[childIndex] = data;
            
            }
            
        }

        public void percolateDown(int parentIndex)
        {
            int leftIndex, rightIndex,index=0;

            leftIndex = leftChild(parentIndex);
            rightIndex = rightChild(parentIndex);

            if (heapType == "MIN")
            {
                //if (leftIndex != -1 )
                //    if(leftIndex >= array.Length || array[leftIndex] == 0)                    
                //        leftIndex = -1;
                //if (rightIndex != -1)
                //    if (rightIndex >= array.Length || array[rightIndex] == 0)                    
                //        rightIndex = -1;
                if (leftIndex < array.Length && leftIndex != -1)
                    if ((array[leftIndex] != 0 && array[parentIndex] == 0) || (array[leftIndex] < array[parentIndex]))
                {
                    index = leftIndex;
                }
                else 
                    index = parentIndex;

                if (rightIndex < array.Length)
                if (rightIndex != -1 && array[rightIndex] < array[parentIndex])
                    index = rightIndex;

                if (index != parentIndex)
                {
                    int temp = array[parentIndex];
                    array[parentIndex] = array[index];
                    array[index] = temp;
                }
                else //if(index < array.Length)
                    index++;

                if (rightIndex != -1 && leftIndex != -1)
                    percolateDown(index);
            }
            else if (heapType == "MAX")
            {
                if (leftIndex < array.Length && leftIndex != -1)
                    if ((array[leftIndex] != 0 && array[parentIndex] == 0) || (array[leftIndex] < array[parentIndex]))
                {
                    index = leftIndex;
                }
                else
                    index = parentIndex;
                if (rightIndex < array.Length)
                if (rightIndex != -1 && array[rightIndex] > array[parentIndex])
                    index = rightIndex;
                

                if (index != parentIndex)
                {
                    int temp = array[parentIndex];
                    array[parentIndex] = array[index];
                    array[index] = temp;
                }
                else
                    index++;

                if (rightIndex != -1 && leftIndex != -1)
                    percolateDown(index);
            }

            
        }

        public void buildHeap(HeapMaxMin h,int[] arr, int n)
        {
            if (h == null)
                return;

            while (n > capacity)
                resizeHeap(capacity);

            //count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = arr[i];
              //  if(array[i]!=0)
               // count++;
            }

            for (int i = (n-1)/2; i >= 0; i--)
            {
                h.percolateDown(i);
            }
        }

        public void display(HeapMaxMin h)
        {

            for (int i = 0; i < h.array.Length; i++)
            {
                Console.Write(h.array[i] + " ");
            }
        }

        public int delete()
        {
            if (count <= 0)
                return -1;

            int data = array[0];
            array[0] = array[array.Length - 1];
            array[array.Length - 1] = 0;
            count--;
            
           // array[capacity-1] = 0;
            percolateDown(array[0]);
            return data;
        }
    }
}
