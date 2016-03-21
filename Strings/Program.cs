// Practicing String Functions

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _3212016
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string str1 = "Testing";
//            string str2;
//            str2 = string.Copy(str1);
//            Console.WriteLine(str1);
//            Console.WriteLine(str2);
//            Console.ReadKey();

           
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Muhammad Aqib";
            string str2 = "Amjad";
// Using trim function to remove spaces from string 1 
            
            str1.Trim();
            Console.WriteLine(str1);

// Using String Replace Function instead of trim

            str1 = str1.Replace(" ", string.Empty);
            string.Compare(str1, str2);
            Console.WriteLine(str1);

            Console.ReadLine();
        }
    }
}