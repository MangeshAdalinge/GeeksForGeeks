using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    
    class LamdaExpressionDemo
    {
        private delegate int del1(int x);
        private delegate void del2(int x, int y);
        private delegate bool del3(int x);
        public void LamdaExpressionDemoMain()
        {
            del1 square = x => x * x;
            Console.WriteLine("Int Del1: "+ square(5));
            square = x => x * 10;
            Console.WriteLine("int Del1: " + square(5));

            del2 print = (x, y) =>
                {
                    Console.WriteLine("Void Delegate: "+x*10+" "+y);
                };
            print(10,20);
            del3 comparatorDel = (x) => x > 10;
            Console.WriteLine("Bool Del: " + comparatorDel(5));
        
        }
    }
}
