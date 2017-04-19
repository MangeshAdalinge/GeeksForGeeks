using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BTNode : IComparer
    {
        private BTNode left, right;       
        private Object data;
        private int height =0; 
        

        public BTNode Left 
        { 
            get
            {
                return left;
            }
            set
            {
                left = value;
            }                
       }

        public BTNode Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public Object Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public BTNode()
        {
            Data = 0;
            Left = null;
            Right = null;            
        }

        public BTNode(Object d)
        {
            Data = d;
            Left = null;
            Right = null;
        }

        public BTNode(Object d,int h)
        {
            Data = d;
            Left = null;
            Right = null;
            Height = h;
        }

        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x, y));
        }

        
    }
}
