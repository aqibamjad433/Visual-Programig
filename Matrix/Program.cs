

// Practicing 2D array
// Getting an input in 2x2 matrics and print them


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Matrix
//{
//    class matrix
//    {
//        public int[,] m1 = new int[2,2];
//        public void insert()
//        {
//            Console.WriteLine("Enter Values in 2D array matrics");
//            for (int i = 0; i < 2; i++)

//            {
                
//                for (int j = 0; j < 2; j++)
//                {
                    
//                    m1[i, j] = Convert.ToInt32(Console.ReadLine());
//                }
//            }
//        }
//        public void display()
//        {
//            for (int i = 0; i < 2; i++)
//            {
//                for (int j = 0; j < 2; j++)
//                {

//                    Console.Write(m1[i,j]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            matrix m = new matrix();
//            m.insert();
//            m.display();
//        }

//    }
//}


// Getting Input in 2x2 matrics and printing Transpose of the matrics


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class matrix
    {
        public int[,] m1 = new int[2, 2];
        public void insert()
        {
            Console.WriteLine("Enter Values in 2D array matrics");
            for (int i = 0; i < 2; i++)
            {

                for (int j = 0; j < 2; j++)
                {

                    m1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void display()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    Console.Write(m1[j,i]);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            matrix m = new matrix();
            m.insert();
            m.display();
        }

    }
}
