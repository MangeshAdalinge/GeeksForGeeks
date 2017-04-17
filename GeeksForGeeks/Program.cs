using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinkedList
{
    public class Node : IComparer
    {
        
        public Object data;
        public Node next;

         int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x, y));
        }

        
        //public int data;
    }

    public class LinkedListClass 
    {
        public Node head;

       /* //public void addLast(int data)
        //{
        //    if (head == null)
        //    {
        //        head = new Node();

        //        head.data = data;
        //        head.next = null;
        //    }
        //    else
        //    {
        //        Node toAdd = new Node();

        //        toAdd.data = data;
        //        Node current = head;

        //        while (current.next != null)
        //        {
        //            current = current.next;
        //        }

        //        current.next = toAdd;
        //    }
        } */

        //linked list  OBJECT
        public void addLast(Object data)
        {
            if (head == null)
            {
                head = new Node();

                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();

                toAdd.data = data;
                Node current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }    

        //delete node by Key
        public void deleteNodeByKey(Object dataKey)
        {
            Node prev=null, temp = head;

            if (temp != null && temp.data == dataKey)
            {
                head = temp.next;
                return;
            }

            while (temp != null && temp.data != dataKey)
            {
                prev = temp;
                temp = temp.next;
            }

            // key is not present
            if (temp == null)
                return;

            if (temp.next == null )
                prev.next = null;
            else
                prev.next = temp.next;

        }

        //delete node by position
        public void deleteNodeByPosition(int position)
        { 
            // Empty list
            if(head == null)
                return;

            Node temp = head;
            if (position == 0)
            {
                head = temp.next;
                return;
            }
            
            //get previous node
            for (int i = 0; temp != null && i < position-1; i++)
            {
                temp = temp.next;
            }

            if (temp == null || temp.next == null)
                return;

            Node next = temp.next.next;

            temp.next = next;

        }
                
        //Swap nodes without swapping values
        public void swapByRef(Object x, Object y)
        {
            // if x and y are same -> do nothing
            if (x == y)
                return;

            // Search for x (keep track of prevX and currX)
            Node prevX = null, currX = head;
            while (currX != null && currX.data != x)
            {
                prevX = currX;
                currX = currX.next;
            }

            // Search for y (keep track of prevY and currY)
            Node prevY = null, currY = head;
            while (currY != null && currY.data != y)
            {
                prevY = currY;
                currY = currY.next;
            }

            // If either x or y is not present, nothing to do
            if (currX == null || currY == null)
                return;

            // If x is not head of linked list
            if (prevX != null)
                prevX.next = currY;
            else //make y the new head
                head = currY;

            // If y is not head of linked list
            if (prevY != null)
                prevY.next = currX;
            else // make x the new head
                head = currX;

            // Swap next pointers
            Node temp = currX.next;
            currX.next = currY.next;
            currY.next = temp;


            





            Console.ReadLine();
            
        }

        public void swapXOR()
        {
            int a = 4, b = 6;
            Console.WriteLine(a+" "+b);
            //a ^= b;
            //b ^= a;
            //a ^= b;

            a = a ^ b ^ (b = a);
            Console.WriteLine(a +" "+ b);
        }

        public void reverseLinkedList()
        {
            Node currNode = head, prevNode = null, nextNode = null;

            while (currNode != null)
            {
                nextNode = currNode.next;
                currNode.next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            head = prevNode;
        }

        //print linked list
        public void printAllNodes()
        {
            Node current =  head;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }

        //Merge two Sorted linked lists
        public Node sortedLLMerge(Node a, Node b)
        {
            Node res = null;

            if (a == null && b == null)
                return res;
            if(a == null)
                return(b);
            if(b == null)
                return(a);

           // Console.WriteLine("Value: " +a.data.ToString().CompareTo(b.data.ToString()));

            //            Console.WriteLine("Object equals returns: "+a.data.Equals(b.data));


           // Console.WriteLine();   

            
            IComparer n = new Node();
           // Console.WriteLine(n.Compare(b.data, a.data));
            
            
            //String
            switch (n.Compare(a.data, b.data))
            {
                case -1:
                    // Console.WriteLine(" 1: a > b " + a.data + b.data);
                    res = a;
                    res.next = sortedLLMerge(a.next, b);
                    break;
                case 0:
                   // Console.WriteLine(" 0 " + a.data + b.data);
                    res = a;
                    res.next = sortedLLMerge(a.next, b.next);
                    break;
                case 1:
                   // Console.WriteLine("a < b " + a.data + b.data);
                    res = b;
                    res.next = sortedLLMerge(a, b.next);
                    break;
            }
            
           



            return res;
        }

        public Node sortedList = new Node();

        //Merge sort linked list
        public void mergeSortLL(Node head)
        {
            if (head == null || head.next == null)
                return;

            Node slow = head, fast = head, temp = head;

            while (fast != null && fast.next != null)
            {
                temp = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast == null) // even list - 6 elements
            {
                temp.next = null;
            }
            else // odd list - 7 elements
            {
                if (fast.next == null)
                {
                    temp = slow;
                    slow = slow.next;
                    temp.next = null;
                }
            }
            Node fHead = head, sHead = slow;

            // recusive call to split
           mergeSortLL(fHead);
           mergeSortLL(sHead);

            // merge two sorted lists  
           head = sortedLLMerge(fHead, sHead);

           if (sortedList.data == null)
           {
               sortedList = head;
           }
           else
           {
               sortedList = sortedLLMerge(sortedList, head);
           }
            
        }

        //count
        public int countLL(Node currHead)
        {
            int cnt = 0;
            while (currHead != null)
            {
                cnt++;
                currHead = currHead.next;
            }
            return cnt;
        }

        //Reverse LL by group
        public Node reverseLLByGroup(Node currHead, int k)
        {
            Node currNode = currHead, prevNode = null, nextNode = null;
            int count = 0;

            while(count < k && currNode != null)
            {
                nextNode = currNode.next;
                currNode.next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
                count++;
            }

            if (nextNode != null)
                currHead.next = reverseLLByGroup(nextNode,k);
            

            return prevNode;
        }
        //Reverse LL 
        public Node reverse(Node currHead)
        {
            Node currNode = currHead, prevNode = null, nextNode = null;

            while (currNode != null)
            {
                nextNode = currNode.next;
                currNode.next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            
            return prevNode;
        }

        
    
    }




    class Program
    {
        public static LinkedListClass addList(LinkedListClass list)
        {
            list.addLast(1);
            list.addLast(2);
            list.addLast(3);
            list.addLast(4);
            list.addLast(5);
            list.addLast(6);
            list.addLast(7);
            list.addLast(8);

            //list1.addLast(5);
            //list1.addLast("b");
            //list1.addLast("c");
            //list1.addLast("g");
            //list1.addLast("h");
            //list1.addLast("z");
            //list1.addLast("d");
            //list1.addLast("e");
            //list1.addLast("f");

            return list;
        }
        public static void processLinkList()
        {             
             while (true)
             {
                 Console.WriteLine("Welcome to Linked List.");
                 Console.WriteLine("What do you want to do?");
                 Console.WriteLine("1. Create a Linked List.");
                 Console.WriteLine("2. Reverse Linked List.");
                 Console.WriteLine("3. Reverse Linked List with group of K.");
                 Console.WriteLine("4. Merge two Linked Lists.");
                 Console.WriteLine("5. Sort Linked Lists.");
                 Console.WriteLine("6. deleteNodeByKey.");
                 Console.WriteLine("7. deleteNodeByPosition");
                 Console.WriteLine("8. Swap by Ref");
                 Console.WriteLine("9. Swap XOR");
                 Console.WriteLine("10. Count");
                 Console.WriteLine("0. Exit");
                 Console.WriteLine();
                 Console.WriteLine("Enter your choice: ");
                 Console.WriteLine();
                 LinkedListClass list1 = new LinkedListClass();
                 LinkedListClass list2 = new LinkedListClass();
                 string userChoice = Console.ReadLine();
                 switch (userChoice)
                 {
                     case "1":
                         Console.WriteLine();
                         list1 = addList(list1);
                         Console.WriteLine("Original linked list: ");
                         list1.printAllNodes();
                         Console.WriteLine();
                         list2 = addList(list2);
                         Console.WriteLine("Original linked list: ");
                         list2.printAllNodes();
                         Console.WriteLine();
                         break;
                     case "2":
                         Console.WriteLine();
                         list1 = addList(list1);                         
                         Console.WriteLine("Original linked list: ");
                         list1.printAllNodes();
                         Console.WriteLine();
                         Console.WriteLine("Reversed linked list: ");
                         list1.head = list1.reverse(list1.head);
                         list1.printAllNodes();
                         Console.WriteLine();
                         break;
                     case "3":
                         list2 = addList(list2);
                         Console.WriteLine("Original linked list: ");
                         list2.printAllNodes();
                         Console.WriteLine();
                         Console.WriteLine("Enter the value of K: ");
                         int k = int.Parse(Console.ReadLine());
                         Console.WriteLine("Reversed linked list: K = "+k);
                         list2.head = list1.reverseLLByGroup(list2.head, k);
                         list2.printAllNodes();
                         Console.WriteLine();
                         break;
                     case "4":
                         list1 = addList(list1);
                         list2 = addList(list2);
                         LinkedListClass mergeObj = new LinkedListClass();
                         mergeObj.head = mergeObj.sortedLLMerge(list1.head, list2.head);
                         Console.WriteLine("Merged.... ");
                         //Console.WriteLine("Head: "+ list1.head.data);
                         mergeObj.printAllNodes();
                         break;
                     case "5":
                         list1 = addList(list1);                         
                         Console.WriteLine("Unsorted linked list: ");
                         list1.printAllNodes();  
                         Console.WriteLine();
                         Console.WriteLine("Sorted linked list: " );
                         list1.head = list1.sortedList;
                         list1.printAllNodes();  
                         break;
                     case "6":
                         list1 = addList(list1); 
                         Console.WriteLine("Before Deletion: ");
                         list1.printAllNodes();  
                         list1.deleteNodeByKey(4);
                         Console.WriteLine("After Deletion: ");
                         list1.printAllNodes();  
                         break;
                     case "7":
                         list1 = addList(list1); 
                         Console.WriteLine("Before Deletion: ");
                         list1.printAllNodes();  
                         list1.deleteNodeByPosition(6);
                         Console.WriteLine("After Deletion: ");
                         list1.printAllNodes();  
                         break;
                     case "8":
                         list1 = addList(list1); 
                         Console.WriteLine("Before Swap: ");
                         list1.printAllNodes();
                         list1.swapByRef("d","f");
                         Console.WriteLine("After Swap: ");
                         list1.printAllNodes();
                         break;
                     case "9":
                         list1 = addList(list1); 
                         Console.WriteLine("Before XORSwap: ");
                         list1.printAllNodes();
                         list1.swapXOR();
                         Console.WriteLine("After XORSwap: ");
                         list1.printAllNodes();
                         break;
                     case "10":
                         list1 = addList(list1); 
                         int cnt = list1.countLL(list1.head);
                         Console.WriteLine("Count: " + list1.countLL(list1.head));
                         break;

                     case "0":
                         Environment.Exit(0);
                         break;
                 }
                 Console.WriteLine();
             }

        }

        public static void processZAlgorithm()
        {
            Console.WriteLine("Input String.....");
            string str = "vntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvciwrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmbifahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahjscrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqupxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvciwrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmbifahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxhcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvciwrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmbifahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjzpguidtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxhcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvciwrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmbifahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidtmsqucpsifncrfdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgjppnwcobjytsdtfahrxrffdaxqcrxnqzfdaxlifncuidtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjzpguidtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqdubpsfncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqqcrnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffhrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsrunpxhehvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxhcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcvntsizhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfdaxlifncutzhvcqvsjyorgtmsqucpsifncuidfahrxrffdaxqcrxnqzfcpsifncuidfahrxrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxycahwkozyjrpjhvaydzbntasnxirlimrqqfthfmukdswuqprzopiudyycrxnqzfdvcvntsizhvciwrffdaxqcrxnqzfdaxlifncuidfahrxrffdaxqcrxnqzfdvcerizxovaqyriqmlskbhoubnhlhnunubvohagmcsxzxdfzbzspzbceciijijhsjshpljsqeilsrxnqzfdvcvntsizhvcqvsjyorgtmsqucpbhporgtmsqucpsifnpuduiezjyhbywyiezyzkraqvagurjnmhjbhotlusotutzcspayaxybwaklxnpefo";
           string pattern = "usimockguhprcxwdrktbjasbfkrrnufznrwnnfuhgcwskhsffluwwvmuqnzfqlferxpehkncofeirtzpwqkxtqnozpfujeappaeaqlxqvmhippusgbwljdjybaxldsuqzocwoeyymysysyfvpaw";

            ZAlgorithm obj = new ZAlgorithm();
            int cnt = obj.zAlgo(str, pattern);
            Console.WriteLine("count " + cnt);


        }


        //findOddAppearingNumber
        // This method iterates over the array of numbers and perform XOR operation on each pair
        // using properties of XOR: The number appearing odd number of times will preserved
        // whereas number appearing even number of times will return 0
        // runtime complexity O(n)

        public static int findOddAppearingNumber(int[] number)
        {
            int num = number[0];
            for (int i = 1; i < number.Length; i++)
            {
                num = num ^ number[i];

            }
            return num;
        }

        public static int heavyCoin(int[] coinArray)
        {
            int res = 0, left = 0, right = coinArray.Length-1;

            while (left <= right)
            {
                if (coinArray[left] > coinArray[right])
                {
                    res = coinArray[left];
                    break;
                }
                else if (coinArray[left] < coinArray[right])
                {
                    res = coinArray[right];
                    break;
                }
                else if (left == right)
                {
                    res = coinArray[left];
                    break;
                }
                left++;
                right--;

            }

            return res;
        }


        static void Main(string[] args)
        {

            while (true)
            {
                 Console.WriteLine("Welcome to GeeksForGeeks Soltions.");
                 Console.WriteLine("What do you want to do?");
                 Console.WriteLine("1. Linked List.");
                 Console.WriteLine("2. Z Algorithm");
                 Console.WriteLine("3. findOddAppearingNumber.");
                 //Console.WriteLine("4. Merge two Linked Lists.");
                 //Console.WriteLine("5. Sort Linked Lists.");
                 //Console.WriteLine("6. deleteNodeByKey.");
                 //Console.WriteLine("7. deleteNodeByPosition");
                 Console.WriteLine("0. Exit");
                 Console.WriteLine();
                 Console.WriteLine("Enter your choice: ");
                 Console.WriteLine();
                 LinkedListClass list1 = new LinkedListClass();
                 LinkedListClass list2 = new LinkedListClass();
                 string userChoice = Console.ReadLine();
                 switch (userChoice)
                 {
                     case "1":
                         processLinkList();
                         break;
                     case "2":
                         processZAlgorithm();

                        /* string[] tokens_n = Console.ReadLine().Split(' ');
                         int n = Convert.ToInt32(tokens_n[0]);
                         int m = Convert.ToInt32(tokens_n[1]);
                         int q = Convert.ToInt32(tokens_n[2]);
                         int k = Convert.ToInt32(tokens_n[3]);
                         string s = Console.ReadLine();
                         int[][] pairs = new int[m][];
                         for (int pairs_i = 0; pairs_i < m; pairs_i++)
                         {
                             string[] pairs_temp = Console.ReadLine().Split(' ');
                             pairs[pairs_i] = Array.ConvertAll(pairs_temp, Int32.Parse);
                         }
                         for (int a0 = 0; a0 < q; a0++)
                         {
                             int bufSize = 1024;
                             Stream inStream = Console.OpenStandardInput(bufSize);
                             Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));

                             string[] tokens_w = Console.ReadLine().Split(' ');
                             string w = tokens_w[0];
                             int a = Convert.ToInt32(tokens_w[1]);
                             int b = Convert.ToInt32(tokens_w[2]);
                             // your code goes here
                             ZAlgorithm obj = new ZAlgorithm();
                             int cnt = 0;
                             for (int i = a; i <= b; i++)
                             {
                                 int l = pairs[i][1] - pairs[i][0] + 1;
                                 string pattern = w.Substring(pairs[i][0], l);
                                 //Console.WriteLine(" i " +i + " L "+pairs[i][1]+ " R " + pairs[i][0]);
                                 //Console.WriteLine(s+" " +pattern);
                                 cnt = cnt + obj.zAlgo(s, pattern);
                             }
                             Console.WriteLine(cnt);               
                         }*/
                         break;
                     case "3":
                        int[] num = new int[] {8, 6,6,6,6,6,6,6,6,6,6};
                        //int res = findOddAppearingNumber(num);
                        int res = heavyCoin(num);
                        Console.WriteLine(res);
                         break;
                     case "4":
                         break;
                     case "0":
                         Environment.Exit(0);
                         break;
                 }
                
            }
            
        }
    }
}
