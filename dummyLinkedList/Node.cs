using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyLinkedList
{
    class Node
    {
        public Object data;
        public Node next;
    }


    class LinkedList
    {
        public Node head;

        public void addElementAtEnd(Object data)
        {
            Node currentHead = head;
            Node newElement = new Node();
            if (currentHead == null)
            {
                newElement.data = data;
                newElement.next = null;
                head = newElement;
            }
            else 
            {
                while (currentHead.next != null)
                {
                    currentHead = currentHead.next;
                }
                currentHead.next = newElement;
                newElement.data = data;
                newElement.next = null;
            }
        }


        public void display()
        { 
            Node currentElement = head;
            
            while (currentElement.next != null)
            {
                Console.Write(currentElement.data + " ");
                currentElement = currentElement.next;
            }
            if (currentElement.next == null)
            {
                Console.Write(currentElement.data + " ");
            }
        }
    }
}
