using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class arraysWhoseSumIsX
    {
        public int[] sumIsX(HashSet<int> arr1, int arr2, int x)
        { 
            int[] res = new int[2];
            foreach (int item in arr1)
	    {
            if (x == item + arr2)
            {
                res[0] = item;
                res[1] = arr2;
                return res;
            }
	    }
           
            return null;
        }
    }
}
