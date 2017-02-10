using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public Node next;
        public Object data;
    }

    public class LinkedList
    {
        private Node head;

        //Reverse Linked list
        public void addFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.next = head;

            head = toAdd;            
        }

        //Print all nodes
        public void printAllNodes()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }


        
    }
    
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add First:");
            LinkedList myList1 = new LinkedList();

            myList1.addFirst("Hello");
            myList1.addFirst("Magical");
            myList1.addFirst("World");
            myList1.printAllNodes();

            //Console.WriteLine();

            //Console.WriteLine("Add Last:");
            //LinkedList myList2 = new LinkedList();

            //myList2.AddLast("Hello");
            //myList2.AddLast("Magical");
            //myList2.AddLast("World");
            //myList2.printAllNodes();

            Console.ReadLine();
        }
    }
}
