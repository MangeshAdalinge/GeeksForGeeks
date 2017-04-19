using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MaximumHeap
    {
        public int[] array;
        public int capacity, count;

        public MaximumHeap(int cap)
        {
            capacity = cap;
            array = new int[capacity];            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.MaxValue;
            }            
            count = 0;           

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

            if (childIndex >= count)
                return -1;

            return childIndex;
        }

        public int rightChild(int parentIndex)
        {
            int childIndex = parentIndex * 2 + 2;

            if (childIndex >= count)
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

                for (int i = (array.Length - 1) / 2; i >= 0; i--)
                {
                    heapify(i);
                }
           

        }

        private void heapify(int parentIndex)
        {
            int leftIndex, rightIndex, index = 0;

            leftIndex = leftChild(parentIndex);
            rightIndex = rightChild(parentIndex);

            if (leftIndex < array.Length && leftIndex != -1)
            {
                if (array[leftIndex] > array[parentIndex])
                {
                    index = leftIndex;
                }
                else
                    index = parentIndex;
            }
            else
                index = parentIndex;

            if (rightIndex > array.Length)
                if (rightIndex != -1 && array[rightIndex] < array[parentIndex])
                    index = rightIndex;

            swap(parentIndex,index);
        
        }

        private void swap(int parentIndex,int index)
        {
            int temp = array[parentIndex];
            array[parentIndex] = array[index];
            array[index] = temp;
        }

        public void buildHeap(MaximumHeap h, int[] arr, int n)
        {
            if (h == null)
                return;

            while (n > capacity)
                resizeHeap(capacity);

            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = arr[i];
                count++;
            }

            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                h.heapify(i);
            }
        }

        public void display(MaximumHeap h)
        {

            for (int i = 0; i < h.count; i++)
            {
                Console.Write(h.array[i] + " ");
            }
        }

        public int delete()
        {
            if (count <= 0)
                return -1;

            int data = array[0];
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
            //array[0] = array[array.Length - 1];
            array[array.Length - 1] = int.MaxValue;
            count--;

            for (int i = (array.Length - 1) / 2; i >= 0; i--)
            {
                heapify(i);
            }
            return data;
        }

    }
}
