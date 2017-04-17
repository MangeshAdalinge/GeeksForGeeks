using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftProblem
{
    public class Node : IComparer
    {
        public Object data;
        public Node next;


        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x, y));
        }
    }

    public class LinkedList
    {
        public Node head;

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
        public bool isPalindromeLL(Node right)
        {
            Node left = head;

            if (right == null)
                return true;

            bool isP= this.isPalindromeLL(right.next);

            if (!isP)
                return false;

            
            IComparer n = new Node();
            bool isP1 = n.Compare(right.data, left.data) == 0 ?  true : false;
            //bool isP1;
            //if (n.Compare(right.data, left) == 0)
            //    isP1 = true;
            //else
            //    return false;
            if (!isP1)
                return false;

            left = left.next;
            return true;
        }

        
    }

}
