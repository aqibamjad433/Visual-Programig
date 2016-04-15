using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace property
{
    class A
    {
        int x;

        public int X
        {
            set
        {
            x = value;
        }//end set
            get
        {
            return x;
        }// end get


        } // end property

    } // end class A
    class Program
    {
        static void Main(string[] args)
        {
             A obj = new A();
            obj.X = 20;
            int a = obj.X; // assigning property X to variable a or assigning value of x to a
        }
    }
}
