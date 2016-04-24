
// Question : Make an array of 5 and insert values in it and then mark a key. When the Key is entered your program
// should add all the values in the array less than the key and print the sum.

// Do the same but  program should add the values of array greater then the key

// Make Functions for each


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            int [] arr = {1,2,3,4,5};
            Console.WriteLine("sum is {0}",reverse_sum(arr, 3));
            Console.WriteLine("sum is {0}",forward_sum(arr, 3)); 
            

        }

        public static int reverse_sum (int [] arr, int x)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                
                if(arr[i] == x)
                {
                    for (int j = i; j>=0; j--)
                    {
                        sum = sum + arr[j];
                    }
                }
                
            }
            return sum;


        }


        public static int forward_sum(int[] arr, int x)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] == x)
                {
                    for (int j = i; j<arr.Length; j++)
                    {
                        sum = sum + arr[j];
                    }
                }

            }
            return sum;


        }
    }
}
