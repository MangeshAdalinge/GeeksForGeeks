using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BTreeLinkedList tree = new BTreeLinkedList();

            Queue<BTNode> BTQueue = new Queue<BTNode>();

            tree.insertBTRecursive(tree.root, 1, BTQueue);
            tree.insertBTRecursive(tree.root, 6, BTQueue);
            tree.insertBTRecursive(tree.root, 2, BTQueue);
            tree.insertBTRecursive(tree.root, 13, BTQueue);
            BTQueue.Clear();
            tree.insertBTRecursive(tree.root, 4, BTQueue);
            BTQueue.Clear();
            tree.insertBTRecursive(tree.root, 5, BTQueue);
            BTQueue.Clear();
            tree.insertBTRecursive(tree.root, 9, BTQueue);

            Console.WriteLine("Diameter: ");
            Console.WriteLine(tree.diameterBT(tree.root));
            Console.ReadLine();

            //tree.root = tree.insertBT(tree.root, 1);
            //tree.root = tree.insertBT(tree.root, 6);
            //tree.root = tree.insertBT(tree.root, 2);
            //tree.root = tree.insertBT(tree.root, 13);
            //tree.root = tree.insertBT(tree.root, 4);
            //tree.root = tree.insertBT(tree.root, 5);
            //tree.root = tree.insertBT(tree.root, 9);
            
            Console.WriteLine("********Size of tree********");
            BTNode searchedRoot = tree.searchBT(tree.root,9);
            Console.WriteLine(tree.sizeOfBT(searchedRoot));
            Console.WriteLine("");
            Console.ReadLine();

            Console.WriteLine("*****************maxElementInTree**************"); 
            Console.WriteLine("Max element of tree - iterative");
            Console.WriteLine(tree.maxElementInTree(tree.root));
            Console.WriteLine("Max element of tree - recursive");
            Console.WriteLine(tree.maxElementInTreePreOrder(tree.root));            
            Console.ReadLine();


           /* tree.root = new BTNode(1);
            tree.root.Left = new BTNode(2);
            tree.root.Right = new BTNode(3);
            tree.root.Left.Left = new BTNode(4);
            tree.root.Right.Left = new BTNode(5);
            tree.root.Right.Right = new BTNode(6);*/

            Console.WriteLine("************* LEVEL ORDER *****************");
            Console.WriteLine("------------ BFS -------------------");
            tree.levelOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();
             
            Console.WriteLine("************* Iterative *****************");
           Console.WriteLine("------------ PRE-ORDER(DLR) -------------------");
            tree.iPreOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();

           Console.WriteLine("------------ IN-ORDER(LDR) -------------------");
            tree.iInOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();


           Console.WriteLine("------------ POST-ORDER(LRD) -------------------");
          // tree.iPostOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("************* Recursive *****************");
            Console.WriteLine("------------ PRE-ORDER(DLR) -------------------");
            tree.preOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("------------ IN-ORDER(LDR) -------------------");
            tree.inOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();
            

            Console.WriteLine("------------ POST-ORDER(LRD) -------------------");
            tree.postOrder(tree.root);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

           
        }
    }
}
