using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1, number2, temp;

            Console.Write("Input the First Number : ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Input the Second Number : ");
            number2 = int.Parse(Console.ReadLine());
            temp = number1;
            number1 = number2;
            number2 = temp;

            Console.WriteLine("After Swapping : ");
            Console.WriteLine("First Number : " + number1); 
            Console.WriteLine("Second Number : " + number2);

            ques2();
            ques3();
            ques4();
            ques5();
            ques6();
            Console.ReadLine();
        }


        static void ques2()
        {
            Console.WriteLine("----------------------------------------");
            int num;
            Console.Write("Enter a digit: ");
            num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                Console.Write(num);
            }
            Console.WriteLine();

        }   

        static void ques3()
        {
            Console.WriteLine("------------------------------");
            Console.Write("Enter a day number (1 to 7): ");
            int number;

            if (int.TryParse(Console.ReadLine(), out number))
            {
                string dayName;
                switch (number)
                {
                    case 1:
                        dayName = "Monday";
                        break;
                    case 2:
                        dayName = "Tuesday";
                        break;
                    case 3:
                        dayName = "Wednesday";
                        break;
                    case 4:
                        dayName = "Thursday";
                        break;
                    case 5:
                        dayName = "Friday";
                        break;
                    case 6:
                        dayName = "Saturday";
                        break;
                    case 7:
                        dayName = "Sunday";
                        break;
                    default:
                        dayName = "Invalid day number. Please enter a number between 1 and 7.";
                        break;
                }

                Console.WriteLine(dayName);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        //-------------ARRAYS-----------------

        static void ques4()
        {
            Console.WriteLine("----------------------------");
            int[] arr1 = new int[100];
            int i, max, min, n;

            Console.WriteLine("Find maximum and minimum element in an array :");

            Console.Write("Input the number of elements stored in the array :");
            n = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("Input {0} elements in the array :", n);
            for (i = 0; i < n; i++)
            {
                Console.Write("element - {0} : ", i);
                arr1[i] = Convert.ToInt32(Console.ReadLine());  
            }
            max = arr1[0];
            min = arr1[0];

            for (i = 1; i < n; i++)
            {
                if (arr1[i] > max) 
                {
                    max = arr1[i]; 
                }

                if (arr1[i] < min) 
                {
                    min = arr1[i]; 
                }
            }

            Console.WriteLine("Maximum element is : {0}", max);
            Console.WriteLine("Minimum element is : {0}", min);
        }


        static void ques5()
        {
            Console.WriteLine("----------------------------------");
            int i, n, sum = 0; 
            double avg; 
            int[] marks = new int[10];
            Console.WriteLine(" 10 marks of a student and  calculate sum, average min max:"); 
           
            Console.WriteLine("Input the 10 Marks : "); 
            for (i = 0; i < 10; i++) 
            {
                marks[i] = Convert.ToInt32(Console.ReadLine()); 
                sum += marks[i];
            }

            avg = sum / 10;
            Console.WriteLine("The sum of 10 numbers is : {0}\nThe Average is : {1}", sum, avg);
            Array.Sort(marks);
            Console.WriteLine("Min element : "+ marks[0]);
            Console.WriteLine("Max element : " + marks[9]);
        }
        static void ques6()
        {

            Console.WriteLine("------------------------------------------------------");
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            int i, n;

            Console.Write("Input the number of elements in array: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input {0} elements in the array:\n", n);

            for (i = 0; i < n; i++)
            {
                Console.Write("element - {0} : ", i);
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (i = 0; i < n; i++)
            {
                arr2[i] = arr1[i];
            }

            Console.WriteLine("The elements copied into the second array are:");
            for (i = 0; i < n; i++)
            {
                Console.Write("{0}  ", arr2[i]);
            }
        }
    }
}
