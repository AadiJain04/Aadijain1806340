using System;
using ClassLibrary1;


namespace ClassLibrary1
{
   internal class Class1
    {
        static void main()
        {
            Class2 calculator = new Class2();
            Console.Write("\nEnter your Age:");

            int age = int.Parse(Console.ReadLine());
            string Result = calculator.CalculateConcession(age);
            Console.WriteLine(Result);
            Console.ReadLine();
        }
    }
}
