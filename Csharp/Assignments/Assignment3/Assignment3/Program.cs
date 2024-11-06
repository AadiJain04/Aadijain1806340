using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            string x;

            Console.WriteLine("Find the length of a string:");

            Console.WriteLine("Input the string: ");
            x = Console.ReadLine();

            int len = x.Length;

            Console.WriteLine("Length of the string is: {0}", len);

            ques2();
            ques3();
            Console.ReadLine();
        }

        static void ques2()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Reverse of a string");
            string x = Console.ReadLine();
            char[] ch = x.ToCharArray();
            Array.Reverse(ch);
            string res = new string(ch);

            Console.WriteLine("Reversed String "+ res);
        }

        static void ques3()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("If words are equal or not");
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (a == b) {
                Console.WriteLine("Both the words are equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        }  
        
        //--------------INHERITANCE------------------



    }
}
