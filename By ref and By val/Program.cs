using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @ref
{
    class byreference
    {

        public void input(ref int x, ref int y)
        {
            Console.WriteLine("Enter first Number");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            y = Convert.ToInt32(Console.ReadLine());
        }
        public int sum(int a, int b)
        {
            a = 10; b = 10;
            return a + b;
        }
        public int sumrefer(ref int a, ref int b)
        {
            a = 10; b = 10;
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;
            byreference obj = new byreference();
            obj.input(ref num1, ref num2);
            Console.WriteLine(obj.sum(num1, num2));
            Console.WriteLine(num1 + "" + num2);
            Console.WriteLine(obj.sumrefer(ref num1, ref  num2));
            Console.WriteLine(num1 + "" + num2);
        }
    }
}