using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------Answer 1--------------------------");
            Console.WriteLine(check("Python", 1)); 
            Console.WriteLine(check("Python", 0)); 
            Console.WriteLine(check("Python", 4));

            ques2();
            ques3();
            ques4();
            Console.ReadLine();                  
        }
        public static string check(string a, int n)
        {
            return a.Remove(n, 1);
        }

        public static void ques2()
        {
            Console.WriteLine("--------------------Answer 2--------------------------");

            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

              string swapString = SwapLetters(inputString);

            Console.WriteLine("Swapped string: " + swapString);

            }
            public static string SwapLetters(string input)
            {
                if (input.Length <= 1)
                {
                    return input;
                }

                char[] charArr = input.ToCharArray();
                char temp = charArr[0];
                charArr[0] = charArr[charArr.Length - 1];
                charArr[charArr.Length - 1] = temp;

                return new string(charArr);
            } 


        public static void ques3()
        {
            Console.WriteLine("--------------------Answer 3--------------------------");
            Console.WriteLine("Enter 3 integers :");
            string input = Console.ReadLine();

            string[] numbers = input.Split(',');
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);
            int num3 = int.Parse(numbers[2]);

            int largest = Largest(num1, num2, num3);

            Console.WriteLine("The largest number is: " + largest);
        }
        public static int Largest(int a, int b, int c)
        {
            if (a >= b && a >= c)
            {
                return a;
            }
            else if (b >= a && b >= c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        public static void ques4()
        {
            Console.WriteLine("--------------------Answer 4--------------------------");

            Console.Write("Enter a string: ");
            string word = Console.ReadLine();
            Console.Write("Enter the letter to count: ");
            char letter = Console.ReadKey().KeyChar;

            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.ToLower(word[i]) == char.ToLower(letter))
                {
                    count++;
                }
            }
            Console.WriteLine( letter + "' appears " + count + " times.");
        }
    }
}
