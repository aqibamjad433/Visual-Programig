using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void dl();

    class Student
    {
        public void Test()
        {
            Console.WriteLine("I am in Student Class");
        } // end function

    } // end class Student
    class Program
    {

       
        static void Main(string[] args)
        {
            Student obj = new Student();
            dl d1 = new dl(obj.Test);
            d1();
            Call_Delegate(d1);
        } // end main

        public static void Call_Delegate(dl _d)
        {
            _d();
        } // end Function
    }
}
