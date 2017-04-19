using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MinHeapKSortedArray
    {
        private int[] array;
        private int[] indexArray;
        private int capacity, count;

        public MinHeapKSortedArray(int cap)
        {
            capacity = cap;
            array = new int[capacity];
            indexArray = new int[capacity];  
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.MaxValue;
                indexArray[i] = int.MaxValue;
            }            
            count = 0;           

        }

        private int parent(int childIndex)
        {
            if (childIndex <= 0 && childIndex >= count)
                return -1;

            return (childIndex - 1) / 2;
            
        }

        private int leftChild(int parentIndex)
        {
            int childIndex = parentIndex * 2 + 1;

            if (childIndex >= count)
                return -1;

            return childIndex;
        }

        private int rightChild(int parentIndex)
        {
            int childIndex = parentIndex * 2 + 2;

            if (childIndex >= count)
                return -1;

            return childIndex;
        }

        private void resizeHeap(int capacity)
        { 
            int[] oldArr = new int[capacity];
            Array.Copy(array,oldArr,array.Length);
            this.capacity = 2*capacity;
            array = new int[this.capacity];
            for (int i = 0; i < oldArr.Length; i++)
            {
                array[i] = oldArr[i];
            }
            resizeHeapIndex(capacity/2);
        }

        private void resizeHeapIndex(int capacity)
        {
            int[] oldArrIndex = new int[capacity];
            Array.Copy(indexArray, oldArrIndex, indexArray.Length);
           // this.capacity = 2 * capacity;
            indexArray = new int[this.capacity];
            for (int i = 0; i < oldArrIndex.Length; i++)
            {
                indexArray[i] = oldArrIndex[i];
            }
        }

        public void insertElement(int data,int index)
        {
            int childIndex;
            if (this.count == this.capacity)
                resizeHeap(this.capacity);
            this.count++;
            childIndex = this.count - 1;

            while (childIndex > 0 && data < array[(childIndex - 1) / 2])
            {
                if (childIndex == 0 && array == null)
                {
                    break;
                }
                array[childIndex] = array[(childIndex - 1) / 2];
                indexArray[childIndex] = indexArray[(childIndex - 1) / 2];
                childIndex = (childIndex - 1) / 2;
            }

                array[childIndex] = data;
                indexArray[childIndex] = index;

                for (int i = (array.Length - 2) / 2; i >= 0; i--)
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
                if (array[leftIndex] < array[parentIndex])
                {
                    index = leftIndex;
                }
                else
                    index = parentIndex;
            }
            else
                index = parentIndex;

            if (rightIndex < array.Length)
                if (rightIndex != -1 && array[rightIndex] < array[parentIndex])
                    index = rightIndex;

            swap(parentIndex,index);
        
        }

        private void swap(int parentIndex,int index)
        {
            int temp = array[parentIndex];
            array[parentIndex] = array[index];
            array[index] = temp;

            int temp1 = indexArray[parentIndex];
            indexArray[parentIndex] = indexArray[index];
            indexArray[index] = temp1;
        }

        public void buildHeap(MinHeapKSortedArray h, int[] arr, int n)
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

        public void display(MinHeapKSortedArray h)
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

            Dictionary<int, int> res = new Dictionary<int, int>();
           int data = array[0];
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
            int dataIndex = indexArray[0];
            for (int i = 0; i < indexArray.Length - 1; i++)
            {
                indexArray[i] = indexArray[i + 1];
            }
            //array[0] = array[array.Length - 1];
            array[array.Length - 1] = int.MaxValue;
            indexArray[indexArray.Length - 1] = int.MaxValue;
            count--;

            res.Add(data, dataIndex);
            for (int i = (array.Length - 1) / 2; i >= 0; i--)
            {
                heapify(i);
            }
            return dataIndex;
        }

    }
}
