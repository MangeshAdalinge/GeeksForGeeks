using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BTreeLinkedList
    {
        public BTNode root;

        public BTreeLinkedList()
        {
            root = null;
        }

        // Recursive insert with height calculation

        public int insertBTRecursive(BTNode currRoot, object data, Queue<BTNode> BTQueue)
        {
            int h = 0;
          
            if (currRoot == null)
            {
                root = new BTNode(data,h);
                return h;
            }
          //  Queue<BTNode> BTQueue = new Queue<BTNode>();
            if (currRoot.Left == null)
            {
                h = currRoot.Height+ 1;
                currRoot.Left = new BTNode(data, h);
                return h;
            }
            else if (currRoot.Right == null)
            {
                h = currRoot.Height + 1;
                currRoot.Right = new BTNode(data, h);
                return h;
            }
            else
            {
                BTQueue.Enqueue(currRoot.Left);
                BTQueue.Enqueue(currRoot.Right);
            }

            h = insertBTRecursive(BTQueue.Dequeue(), data, BTQueue);

            return h;
        }

        public List<int> height(BTNode currRoot)
        {
            List<int> hList = new List<int>();
            List<int> hList1 = new List<int>();
            if (currRoot == null)
                return hList;

            hList = height(currRoot.Left);
            hList1 = height(currRoot.Right);
            hList.AddRange(hList1);
            hList.Add(currRoot.Height);

            return hList;
        }

        public int diameterBT(BTNode currRoot)
        {
            List<int> l = new List<int>();

            l = height(currRoot);
            l.Sort();
            return l[l.Count - 2] + l[l.Count - 1] + 1;
        }

        public BTNode insertBT(BTNode currRoot, object data)
        {
        
            if (currRoot == null)
            {
                currRoot = new BTNode(data);
                return currRoot;
            }
            else
            {
                Queue<BTNode> inQueue = new Queue<BTNode>();
                inQueue.Enqueue(currRoot);
                while(inQueue.Count > 0)
                {
                    BTNode tempNode = inQueue.Dequeue();
                    if (tempNode != null)
                    {
                        if (tempNode.Left != null)
                        {
                            inQueue.Enqueue(tempNode.Left);
                        }
                        else
                        {
                            tempNode.Left = new BTNode(data);
                            return currRoot;
                        }

                        if (tempNode.Right != null)
                        {
                            inQueue.Enqueue(tempNode.Right);
                        }
                        else
                        {
                            tempNode.Right = new BTNode(data);
                            return currRoot;
                        }
                    }
                }
                return currRoot;
            }
            
        }

        //Iterative
        //DLR
        public void iPreOrder(BTNode currRoot)
        {
            if (currRoot == null)
                return;

            //if (currRoot.Left == null && currRoot.Right == null)
            //    Console.Write(currRoot.Data);

            Stack<BTNode> st = new Stack<BTNode>();
            st.Push(currRoot);
            while (st.Count > 0)
            {
                BTNode myNode = st.Peek();
                Console.Write(myNode.Data + " ");
                st.Pop();

                if (myNode.Right != null)
                    st.Push(myNode.Right);
                if(myNode.Left != null)
                    st.Push(myNode.Left);
               // currRoot = currRoot.Left;
            }

            

        }

        //LDR
        public void iInOrder(BTNode currRoot)
        { 
            if(currRoot == null)
                return;

            Stack<BTNode> treeStack = new Stack<BTNode>();

            while (currRoot != null)
            {
                treeStack.Push(currRoot);
                currRoot = currRoot.Left;
            }

            while (treeStack.Count > 0)
            {
                currRoot = treeStack.Pop();
                Console.Write(currRoot.Data + " ");

                if (currRoot.Right != null)
                {
                    currRoot = currRoot.Right;

                    while (currRoot != null)
                    {
                        treeStack.Push(currRoot);
                        currRoot = currRoot.Left;
                    }
                }
            }
        }

        //LRD
        public void iPostOrder(BTNode currRoot)
        {
            bool done = false;
            Stack<BTNode> treeStack = new Stack<BTNode>();
            treeStack.Push(currRoot);

            while (!done)
            {
                if (currRoot != null)
                {
                    treeStack.Push(currRoot);
                    currRoot = currRoot.Left;
                }
                else if (treeStack.Count == 0)
                {
                    done = true;
                }
                else
                {
                    currRoot = treeStack.Pop();
                    Console.Write(currRoot.Data + " ");
                    currRoot = treeStack.Pop();
                }
                
            }

        }

        //Recursive
        public void preOrder(BTNode currRoot)
        { 
            if(currRoot == null)
                return;
            Console.Write(currRoot.Data+" ");
            preOrder(currRoot.Left);
            preOrder(currRoot.Right);
        }

        public void postOrder(BTNode currRoot)
        {
            if (currRoot == null)
                return;
            postOrder(currRoot.Left);
            postOrder(currRoot.Right);
            Console.Write(currRoot.Data+" ");
        }

        public void inOrder(BTNode currRoot)
        {
            if (currRoot == null)
                return;

            inOrder(currRoot.Left);
            Console.Write(currRoot.Data+ " ");
            inOrder(currRoot.Right);
        }


        //maxElementInTreeUsingBFS
        object max = -999;        
        Queue<BTNode> maxTreeElementQueue = new Queue<BTNode>();
        public object maxElementInTree(BTNode currRoot)
        { 
            if (currRoot == null)
                return null;

            IComparer compareObj = new BTNode();
            //Console.Write(currRoot.Data + " ");
            if (-1==compareObj.Compare(max ,currRoot.Data))
            {
                max = currRoot.Data;
            }
            if (currRoot.Left != null)
            {
                maxTreeElementQueue.Enqueue(currRoot.Left);
            }

            if (currRoot.Right != null)
            {
                maxTreeElementQueue.Enqueue(currRoot.Right);
            }

            if (maxTreeElementQueue.Count > 0)
            {
                maxElementInTree(maxTreeElementQueue.Dequeue());
            }
            return max;
        }

        //Level Order
        Queue<BTNode> treeQueue = new Queue<BTNode>();
        public void levelOrder(BTNode currRoot)
        {
            if (currRoot == null)
                return;

            Console.Write(currRoot.Data + " ");
            if (currRoot.Left != null)
            {
                treeQueue.Enqueue(currRoot.Left);
            }

            if (currRoot.Right != null)
            {
                treeQueue.Enqueue(currRoot.Right);
            }

            if (treeQueue.Count > 0)
            {
                levelOrder(treeQueue.Dequeue());
            }
        }

        //maxElementInTreeUsingPreOrder
        public Object maxElementInTreePreOrder(BTNode currRoot)
        {
            if (currRoot == null)
                return max;
            IComparer compareObj = new BTNode();
            if (-1 == compareObj.Compare(max, currRoot.Data))
            {
                max = currRoot.Data;
            }
            maxElementInTreePreOrder(currRoot.Left);
            maxElementInTreePreOrder(currRoot.Right);

            return max;
        }

        //search elemnt of tree 
        
        public BTNode searchBT(BTNode currRoot,Object data)
        {
            BTNode rightRoot = null,leftRoot = null;

            if (currRoot == null)
                return null;
            IComparer compareObj = new BTNode();
            
            leftRoot = searchBT(currRoot.Left, data);
            rightRoot = searchBT(currRoot.Right, data);

            if (0 == compareObj.Compare(currRoot.Data, data))
                return currRoot;

            if (leftRoot != null)
                return leftRoot;
            else if (rightRoot != null)
                return rightRoot;

            return null;
        }

        //sizeOfBT
        public int sizeOfBT(BTNode currRoot)
        {
            int size = 0;
            if (currRoot == null)
                return 0;

            size = size + 1;
            size += sizeOfBT(currRoot.Left);
            size += sizeOfBT(currRoot.Right);

            return size;
        }

    
    }


}
