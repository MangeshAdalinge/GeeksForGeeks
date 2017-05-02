using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LINQ");

            string[] words = { "mangesh1", "mangesh2mangesh2", "mangesh3mangesh2", "mangesh4", "mangesh5mangesh2", "mangesh6", "mangesh7", "mangesh8mangesh2", "mangesh9mangesh2" };
            

            Console.WriteLine("Structured LINQ");
            var resLINQ = from w in words
                          where w.Length > 10
                          select w;
            
            foreach (var item in resLINQ)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("Lambda LINQ");
            var resLambdaLINQ = words.Where(w => w.Length > 10);
                                

            foreach (var item in resLambdaLINQ)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }
    }
}
