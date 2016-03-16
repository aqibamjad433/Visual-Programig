
////////////////////////////////  SWAPING WITHOUT USING THE 3RD VARIABLE ///////////////////////////////////////////////////////////


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Swaping
//{
//    class Swap
//    {
//        int x;
//        int y;

//        public void getData()
//        {
//            Console.WriteLine("\t \t S W A P I N G   W I T H O U T   3 R D   V A R I A B L E  ");

//            Console.WriteLine("\n Please Enter the Value of 1st Integer");
//            x = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Enter the Value of 2nd Integer");
//            y = Convert.ToInt32(Console.ReadLine());
//        }

//        public void swaping()
//        {
//            x = x + y;
//            y = x - y;
//            x = x - y;

//        }
//        public void ShowData()
//        {
//            Console.WriteLine("Value of 1st Integer after swaping is {0}",x);
//            Console.WriteLine("Value of 2nd Integer after swaping is {0}",y);
//        }
//    };
//    class Program
//    {
//        static void Main(string[] args)
//        {
            
//            Swap s1 = new Swap();
//            s1.getData();
//            s1.swaping();
//            s1.ShowData();
            
//        }
//    }
//}



////////////////////////////////  SWAPING BY USING THE 3RD VARIABLE ///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swaping
{
    class Swap
    {
        int x;
        int y;
        int temp;

        public void getData()
        {
            Console.WriteLine("\t \t S W A P I N G   W I T H   3 R D   V A R I A B L E  ");

            Console.WriteLine("\n Please Enter the Value of 1st Integer");
            x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Value of 2nd Integer");
            y = Convert.ToInt32(Console.ReadLine());
        }

        public void swaping()
        {

            temp = x;
            x = y;
            y = temp;

        }
        public void ShowData()
        {
            Console.WriteLine("Value of 1st Integer after swaping is {0}", x);
            Console.WriteLine("Value of 2nd Integer after swaping is {0}", y);
        }
    };
    class Program
    {
        static void Main(string[] args)
        {

            Swap s1 = new Swap();
            s1.getData();
            s1.swaping();
            s1.ShowData();

        }
    }
}

