using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Linked List: ");
            LinkedList l1 = new LinkedList();

            l1.addElementAtEnd("a");
            l1.addElementAtEnd("b");
            l1.addElementAtEnd("d");
            l1.addElementAtEnd("c");
            l1.addElementAtEnd("e");

            l1.display();
            Console.ReadLine();

        }
    }
}
