using System;
using System.IO;
using System.Security.Policy;


namespace Assessment_3
{
    // Class for problem no.1
    class CricketTeam
    {
        public void PointsCalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            Console.WriteLine($"Enter the scores for {no_of_matches} matches:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());
                sum += scores[i];
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine("--- Result ---");
            Console.WriteLine($"Total Matches: {no_of_matches}");
            Console.WriteLine($"Sum of Scores: {sum}");
            Console.WriteLine($"Average Score: {average:F2}");
        }
    }
    //class for problem no. 2
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box()
        {
            Length = 0;
            Breadth = 0;
        }
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box AddBoxes(Box box1, Box box2)
        {
            return new Box(box1.Length + box2.Length, box1.Breadth + box2.Breadth);
        }
        public void DisplayBoxDetails()
        {
            Console.WriteLine($"Box Dimensions - Length: {Length}, Breadth: {Breadth}");
        }
    }


        //Main 


        class Program
    {
        // Declaring delegate for Answer no.4
         delegate int CalculatorOperation(int a, int b);

        static void Main(string[] args)
        {
            //-------------------ANSWER 1------------------------

            Console.Write("Enter the number of matches: ");
            int no_of_matches = int.Parse(Console.ReadLine());
            CricketTeam team = new CricketTeam();
            team.PointsCalculation(no_of_matches);

            //-------------------ANSWER 2-------------------------
            Console.WriteLine("-------------------ANSWER2-------------------------\n");
            Console.WriteLine("Enter details for Box 1:");
            Console.Write("Length: ");
            double length1 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = double.Parse(Console.ReadLine());
            Box box1 = new Box(length1, breadth1);

            Console.WriteLine("Enter details for Box 2:");
            Console.Write("Length: ");
            double length2 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = double.Parse(Console.ReadLine());
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.AddBoxes(box1, box2);

            Console.WriteLine("\nDetails of Box 3 (Sum of Box 1 and Box 2):");
            box3.DisplayBoxDetails();

            //-------------------ANSWER 3-------------------------
            Console.WriteLine("-------------------ANSWER 3-------------------------");
            Console.WriteLine("Write the filename with .txt extension!");
            string fileName = Console.ReadLine();

            Console.WriteLine("enter the text want to append to the file:");
            string textToAppend = Console.ReadLine();


            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("File created and first line added.");
                }
                Console.WriteLine("File does not exist.It has been created with the first line.");
            }

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(textToAppend);
            }
            Console.WriteLine("Text has been appended to the file.");

            //-------------------ANSWER 4-------------------------
            Console.WriteLine("-------------------ANSWER 4------------------------\n");
            Console.WriteLine("Calculator Program");

            Console.Write("Enter the first integer: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Calculations");
            PerformOperation(num1, num2, Addition);
            PerformOperation(num1, num2, Subtraction);
            PerformOperation(num1, num2, Multiplication);
            Console.ReadLine();
        }
        static void PerformOperation(int num1, int num2, CalculatorOperation operation)
        {
            int result = operation(num1, num2);
            Console.WriteLine($"Result: {result}");
        }
        static int Addition(int a, int b)
        {
            Console.WriteLine("Addition:");
            return a + b;
        }
        static int Subtraction(int a, int b)
        {
            Console.WriteLine("Subtraction:");
            return a - b;
        }
        static int Multiplication(int a, int b)
        {
            Console.WriteLine("Multiplication:");
            return a * b;
        }
    }
}
