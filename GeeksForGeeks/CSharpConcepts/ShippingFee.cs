using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class ShippingFee
    {
        //Dictionary<string, int> zone = new Dictionary<string, int>();
        private delegate int shippingFeeCalc(string s);

        int zone1(string s)
        {
            return 25;
        }
        int zone2(string s)
        {
            return 12+25;
        }
        int zone3(string s)
        {
            return 8;
        }
        int zone4(string s)
        {
            return 4+25;
        }

        public void ShippingFeeMain()
        {
            ////initialize Zone
            //zone.Add("zone1",25);
            //zone.Add("zone2", 37);
            //zone.Add("zone3", 8);
            //zone.Add("zone4", 29);

            Console.WriteLine("Welcome to Shipping Fee Calculator");
            Console.WriteLine("Enter the Zone");
            string z = Console.ReadLine();
            Console.WriteLine("Enter the Price");
            int price = int.Parse(Console.ReadLine());
            shippingFeeCalc f = zone1;
            switch (z)
            { 
                case "zone1":
                    f = zone1;
                    break;
                    
                case "zone2":
                    f = zone2;                    
                    break;
                case "zone3":
                    f = zone3;
                    break;
                case "zone4":
                    f = zone4;
                    break;

            }
            Console.WriteLine("Shipping Fee: " + f(z));

            
        }
    }
}
