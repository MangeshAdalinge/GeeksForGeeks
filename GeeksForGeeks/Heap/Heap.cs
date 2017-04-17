using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Heap
    {
        public int[] array;
        public int count;           // Number of elements in heap
        public int capacity;        // Size of heap
        public string heapType;

        public Heap(int capacity, string heapType)
        {
            this.heapType = heapType;
            this.count = 0;
            this.capacity = capacity;
            this.array = new int[capacity];
        }

        // Find parent index
        public int parent(int c)
        {
            if (c <= 0 || c >= this.count)
                return -1;
            return (c - 1) / 2;
        }

        // Find child left index
        public int leftChild(int p)
        {
            int left = p * 2 + 1;
            if(left >= this.count)
                return -1;
            return left;
        }

        // Find right child index
        public int rightChild(int p)
        {
            int right = p * 2 + 2;
            if(right >= this.count)
                return -1;
            return right;
        }

        // Resize Heap size
        public void resizeHeap()
        { 
            int[] arrayOld = new int[this.capacity];
            Array.Copy(arrayOld, array, this.count - 1);

            // Double the heap capacity
            this.array = new int[capacity * 2];

            for (int i = 0; i < arrayOld.Length; i++)
            {
                array[i] = arrayOld[i];
            }
            this.capacity *= 2;
            arrayOld = null;
        }

        // Insert into Heap -- Percolate-up
        public void insert(int data)
        {
            int i;
            if (this.count == this.capacity)
                resizeHeap();
            this.count++;
            i = this.count-1;

            
            while (i > 0 && data > array[(i - 1) / 2])
            {
                if (i == 0 && array == null)
                {
                    break;
                }
                array[i] = array[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            
            array[i] = data;
            
        }

        public void display(Heap h)
        {
            
            for (int i = 0; i < h.array.Length; i++)
            {                
                Console.Write(h.array[i] + " ");
            }
        }

        //Percolate-down
        public void percolateDown(int i)
        {
            int l, r, max, temp;

            l = leftChild(i);
            r = rightChild(i);

            if (l != -1 && array[l] > array[i])
                max = l;
            else
                max = i;

            if (r != -1 && array[r] > array[max])
                max = r;

            if (max != i)
            {
                temp = array[i];
                array[i] = array[max];
                array[max] = temp;
            }
            else
                max++;
            if(l != -1 && r != -1)
                percolateDown(max);
        }

        //Array range of elements to existing heap
        public void buildHeap(Heap h, int[] arr, int n)
        {
            if (h == null)
                return;
            while (n > this.capacity)
                resizeHeap();

            for (int i = 0; i < n; i++)
            {
                h.array[i] = arr[i];
            }
            h.count = n;

            for (int i = (n-1)/2; i >=0 ; i--)
            {
                h.percolateDown(i);
            }
        
        }

        // Delete element from heap
        public int deleteMax()
        {
            if (this.count <= 0)
                return -1;

            int data = array[0];
            array[0] = array[this.count - 1];
            this.count--;
            array[count] = 0;
            percolateDown(0);
            return data;
        }
    }
}
