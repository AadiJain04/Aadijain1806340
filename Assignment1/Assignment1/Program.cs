using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a, b;
            Console.Write("\n");
            Console.Write("Check whether two integers are equal or not:\n");
            Console.Write("\n");
            Console.Write("Input 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("{0} and {1} are equal.\n", a, b);
            }
            else
            {
                Console.WriteLine("{0} and {1} are not equal.\n", a, b);
            }
            ques2();
            ques3();
            ques4();
            ques5();
            Console.ReadLine();
        }

        //Given No. is Positive or Negative

        static void ques2()
        {
            int c;
            Console.Write("\n");
            Console.Write("------------------------------------------");
            Console.Write("\n\n");
            Console.Write("Check whether Given No. is Positive or Negative:\n");
            Console.Write("\n");
            Console.Write("Input an integer : ");
            c = Convert.ToInt32(Console.ReadLine());

            if (c >= 0)
            {
                Console.WriteLine("{0} is a positive number.\n", c);
            }
            else
            {
                Console.WriteLine("{0} is a negative number. \n", c);
            }
            Console.ReadLine();

        }


        //takes two numbers as input and performs all operations

        static void ques3()
        {
            int d, e;
            Console.Write("\n");
            Console.Write("------------------------------------------");
            Console.Write("\n\n");
            char operation;

            Console.Write("Input first number: ");
            d = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input operation:+,-,*,/ =  ");
            operation = Convert.ToChar(Console.ReadLine());

            Console.Write("Input second number: ");
            e = Convert.ToInt32(Console.ReadLine());

            if (operation == '+')
            {
                Console.WriteLine($"{d} + {e} = {d + e}");
            }
            else if (operation == '-')
            {
                Console.WriteLine($"{d} - {e} = {d - e}");
            }
            else if ((operation == '*'))
            {
                Console.WriteLine($"{d} * {e} = {d * e}");
            }
            else if (operation == '/')
            {
                Console.WriteLine($"{d} / {e} = {d / e}");
            }
            else
            {
                Console.WriteLine("Wrong Character");
            }
            Console.ReadLine();
        }


        //multiplication table

        static void ques4()
        {
            int f;
            Console.Write("\n");
            Console.Write("------------------------------------------");
            Console.Write("\n\n");
            Console.Write("Input a Number : ");
            f = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{f}  * {i} = {f * i} ");
            }
            Console.ReadLine();
        }

        //sum of two given integers. If two values are the same, return the triple of their sum.


        static void ques5()
        {
            int g, h, result;
            Console.Write("------------------------------------------");
            Console.Write("\n");
            Console.Write("Input 1st number: ");
            g = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input 2nd number: ");
            h = Convert.ToInt32(Console.ReadLine());

            result = g + h;

            if (g == h)
            {
                Console.WriteLine($" {(result) * 3}");
            }
            else
            {
                Console.WriteLine($"{result} ");
            }
            Console.ReadLine();


        }
    }
}

