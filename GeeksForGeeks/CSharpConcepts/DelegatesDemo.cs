using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class MyClass
    {
        public int func1(int a, int b)
        {
            return (a + b)*b;
        }
    }

    class DelegatesDemo
    {
        private delegate int mydelegate(int a, int b);

        private int func1(int a, int b)
        {
            return a + b;
        }

        private int func2(int a, int b)
        {
            return a * b;
        }

        private int func3(int a, int b)
        {
            return a - b;
        }

        private int func4(int a, int b)
        {
            return a / b;
        }

        //Anonymous Delegate
        private void anonymousDelegate(int a, int b)
        {
            //Anonymous Delegate
            mydelegate d = delegate(int a1, int b1)
            {
                return a1 + b1;
            };
            Console.WriteLine("Anonymous Delegate Addition: " + d(a, b));
        }

        //Composite Delegate
        private void compositeDelegate(int a,int b)
        {
            mydelegate f1 = func1;
            mydelegate f2 = func2;
            mydelegate f1f2 = f1 + f2;
            Console.WriteLine("Chained delegate: "+f1f2(4,2));
        }

        public void myDelegate(int a,int b)
        {
            Console.WriteLine("Input:" + a + " " + b);
            mydelegate f = func1;
            Console.WriteLine("Addition: " + f(a, b));
            f = func2;
            Console.WriteLine("Multiplication: " + f(a, b));
            f = func3;
            Console.WriteLine("Substraction: " + f(a, b));
            f = func4;
            Console.WriteLine("Division: " + f(a, b));
            MyClass m = new MyClass();
            f = m.func1;
            Console.WriteLine("MyCalss: " + f(a, b));

            anonymousDelegate(a, b);
            compositeDelegate(a, b);

        }

        public void myDelegateMain()
        {

             while (true)
            {
                Console.WriteLine("Welcome to Delegates");
                Console.WriteLine("1. Delegates");
                Console.WriteLine("2. Composite Delegates");
                Console.WriteLine("3. Shipping Fee Calc");
                Console.WriteLine("4. Event Handler");
                Console.WriteLine("5. Piggy Bank ");
                Console.WriteLine("6. Lamda Expression ");
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
                        d.myDelegate(4,2);
                        break;

                    case 2:
                        CompositeDelegates cd = new CompositeDelegates();
                        cd.compositeDelegatesMain(4, 2);
                        break;

                    case 3:
                        ShippingFee sf = new ShippingFee();
                        sf.ShippingFeeMain();
                        break;

                    case 4:
                        EventHandlingDemo ev = new EventHandlingDemo();
                        ev.EventHandlingMain();
                        break;

                    case 5:
                        PiggyBank p = new PiggyBank();
                        p.PiggyBankMain();
                        break;
                    
                    case 6:
                        LamdaExpressionDemo l = new LamdaExpressionDemo();
                        l.LamdaExpressionDemoMain();
                        break;

                }
            }          
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
