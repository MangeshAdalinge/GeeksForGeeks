using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    public delegate void myEventHandler(string s);
    class EventPublisher
    {
        private string theVal;
        public event myEventHandler valueChanged;

        public string Val
        {
            get
            {
                return theVal;
            }
            set
            {
                theVal = value;
                //Fire Event
                this.valueChanged(theVal);
            }
        }
    }

    class EventHandlingDemo
    {   
        
        public void EventHandlingMain()
        {
            EventPublisher obj = new EventPublisher();
            obj.valueChanged += obj_valueChanged;

            string str="";
            do
            {
                Console.WriteLine("Enter Value: ");
                str = Console.ReadLine();
                if (str != "exit")
                    obj.Val = str;
            } while (str != "exit");
            
        }

        void obj_valueChanged(string s)
        {
            Console.WriteLine("Value changed: "+s);
        }
    }
}
