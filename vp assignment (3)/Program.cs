using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vp_assignment__3_
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;
            do
            {
                int siblings;
                Console.WriteLine("Enter Number of Siblings : ");
                siblings = Convert.ToInt32(Console.ReadLine());
                if (siblings > 0)
                {
                    DateTime[] ages = new DateTime[siblings];
                    for (int i = 0; i < ages.Length; i++)
                    {
                        Console.WriteLine("Enter age of Sibling {0}", i + 1);
                        ages[i] = Convert.ToDateTime(Console.ReadLine());
                    }




                    int[] days = new int[siblings];
                    int[] months = new int[siblings];
                    int[] years = new int[siblings];

                    for (int i = 0; i < ages.Length; i++)
                    {
                        days[i] = ages[i].Day;
                        months[i] = ages[i].Month;
                        years[i] = ages[i].Year;
                    }
                    //for (int i = 0; i <ages.Length; i++)
                    //{
                    //    Console.WriteLine("Date of birth of Sibling {0}, {1} days,{2} months,{3} years",i+1,days[i],months[i],years[i]);
                    //}

                    DateTime dt = DateTime.Now;
                    Console.WriteLine("Todays Date is {0}", dt);

                    for (int i = 0; i < ages.Length; i++)
                    {
                        days[i] = DateTime.Now.Day - days[i];
                        months[i] = DateTime.Now.Month - months[i];
                        years[i] = DateTime.Now.Year - years[i];

                        if (days[i] < 0)
                        {
                            days[i] = days[i] - (days[i] * 2);
                            days[i] = 30 - days[i];
                            months[i] = months[i] - 1;
                        }

                        if (months[i] < 0)
                        {
                            months[i] = months[i] - (months[i] * 2);
                            months[i] = 12 - months[i];
                            years[i] = years[i] - 1;
                        }
                    }
                    for (int i = 0; i < ages.Length; i++)
                    {
                        Console.WriteLine("Age of Sibling {0} is : {1}days , {2}months , {3}years", i + 1, days[i], months[i], years[i]);

                    }

                    for (int i = 0; i < ages.Length - 1; i++)
                    {

                        int months_diff, days_diff, years_diff;
                        days_diff = days[i] - days[i + 1];
                        months_diff = months[i] - months[i + 1];
                        years_diff = years[i] - years[i + 1];

                        if (days_diff < 0)
                        {
                            days_diff = days_diff - (days_diff * 2);
                            days_diff = 30 - days_diff;
                            months_diff = months_diff - 1;
                        }

                        if (months_diff < 0)
                        {
                            months_diff = months_diff - (months_diff * 2);
                            months_diff = 12 - months_diff;
                            years_diff = years_diff - 1;

                        }

                        if (years_diff < 0)
                        {
                            years_diff = 0;

                        }

                        Console.WriteLine("Difference between sibling {0} and {1} is: ", i, i + 1);
                        Console.WriteLine("{0} years , {1} months, {2} days", years_diff, months_diff, days_diff);

                    }


                }
                else
                {
                    Console.WriteLine("Please Enter Siblings Greater then zero");
                }

                Console.WriteLine("do you want to continue");
                ch = Convert.ToChar(Console.ReadLine());
            } 
            while (ch == 'y');
            
            }
        }
    }
