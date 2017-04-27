using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    

    class CompositeDelegates
    {
        private delegate void myDelegate(int a, int b);
        private delegate void myDelegateRef(int a, ref int b);
        void add(int a, int b)
        {
            int res = a + b;
            Console.WriteLine("Add: "+ res);
        }

        void mult(int a, int b)
        {
            int res = a * b;
            Console.WriteLine("mult: " + res);
        }

        void addRef(int a, ref int b)
        {
            int res = a + b;
            b += 2;
            Console.WriteLine("Add by ref : " + res);
        }

        void multRef(int a, ref int b)
        {
            int res = a * b;
            Console.WriteLine("mult by ref : " + res);
        }

        private void compositeDel(int a, int b)
        {
            myDelegate f1 = add;
            myDelegate f2 = mult;
            myDelegate f1f2 = f1 + f2;
            f1f2(a, b);
        }


        private void compositeDelRef(int a,ref int b)
        {
            myDelegateRef f1 = addRef;
            myDelegateRef f2 = multRef;
            myDelegateRef f1f2 = f1 + f2;
            f1f2(a, ref b);
        }
        public void compositeDelegatesMain(int a, int b)
        {
            compositeDel(a,b);
            compositeDelRef(a, ref b);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
