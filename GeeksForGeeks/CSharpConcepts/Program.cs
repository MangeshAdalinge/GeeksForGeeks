using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to C# Demo");
                Console.WriteLine("1. Delegates");
                //Console.WriteLine("2. Composite Delegates");
                //Console.WriteLine("3. Shipping Fee Calc");
                //Console.WriteLine("4. Event Handler");
                //Console.WriteLine("5. Lamda Expression ");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice");
                int ch = int.Parse(Console.ReadLine());

                // int[,] inputArr = new int[,]

                switch (ch)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        DelegatesDemo d = new DelegatesDemo();
                        d.myDelegateMain();
                        break;

                    //case 2:
                    //    CompositeDelegates cd = new CompositeDelegates();
                    //    cd.compositeDelegatesMain(4, 2);
                    //    break;

                    //case 3:
                    //    ShippingFee sf = new ShippingFee();
                    //    sf.ShippingFeeMain();
                    //    break;

                    //case 4:
                    //    EventHandlingDemo ev = new EventHandlingDemo();
                    //    ev.EventHandlingMain();
                    //    break;

                    //case 5:
                    //    LamdaExpressionDemo l = new LamdaExpressionDemo();
                    //    l.LamdaExpressionDemoMain();
                    //    break;

                }
            }
        }
    }
}
