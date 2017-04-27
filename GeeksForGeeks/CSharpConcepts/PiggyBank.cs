using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    public delegate void piggyBankEventHandler(int cost);
    class myPiggyBank
    {
        private int amt;

        public event piggyBankEventHandler balance;

        public int Amount
        {
            get
            {
                return amt;
            }
            set
            {
                amt += value;
                if (amt >= 500)
                    balance(amt);
            }
        }

    }
    class PiggyBank
    {

        public void PiggyBankMain()
        {
            Console.WriteLine("Welcome to Piggy Bank");
            myPiggyBank obj = new myPiggyBank();
           // obj.balance += obj_BalanceReached;
            obj.balance += obj.Amount => Console.WriteLine("You have reched your goal and balance is "+ cost);
            
            
            while(true)
            {
                Console.WriteLine("Enter the amount");
                int p = int.Parse(Console.ReadLine());
                obj.Amount = p;
                
            }
            
        }

        void obj_BalanceReached(int cost)
        {
            Console.WriteLine("You have reched your goal and balance is "+ cost);
            
        }
    }
}
