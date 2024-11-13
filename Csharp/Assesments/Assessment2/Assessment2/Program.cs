using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program
    {

        public abstract class Student
        {
            string name { get; set; }
            int studentId { get; set; }
            double grade { get; set; }

            public Student(string name, int studentId, double grade)
            {
                this.name = name;
                this.studentId = studentId;
                this.grade = grade;
            }
            public abstract bool IsPassed(double grade);
        }

        public class Undergraduate : Student
        {
            public Undergraduate(string name, int studentId, double grade) : base(name, studentId, grade)
            {
            }

            public override bool IsPassed(double grade)
            {
                return grade > 70;
            }
        }
        public class Graduate : Student
        {
            public Graduate(string name, int studentId, double grade) : base(name, studentId, grade)
            {
            }

            public override bool IsPassed(double grade)
            {
                return grade > 80;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of undergraduate student : ");
            string undergraduateName = Console.ReadLine();

            Console.WriteLine("Student ID of undergraduate student : ");
            int undergraduateId = int.Parse(Console.ReadLine());

            Console.WriteLine("Grade of udergradute student : ");
            double undergraduateGrade = double.Parse(Console.ReadLine());

            Student undergraduateStudent = new Undergraduate(undergraduateName,undergraduateId,undergraduateGrade);
            Console.WriteLine($"Undergraduate Student - {undergraduateName} has passed : {undergraduateStudent.IsPassed(undergraduateGrade)}");

            Console.WriteLine("------------------------");
            Console.WriteLine("Name of Graduate Student : ");
            string graduateName = Console.ReadLine();
            Console.WriteLine("Student ID of graduate student");
            int graduateId = int.Parse(Console.ReadLine());
            Console.WriteLine("Grade of graduate student : ");
            double graduateGrade = double.Parse(Console.ReadLine());

            Student gradeuateStudent = new Graduate(graduateName, graduateId, graduateGrade);
            Console.WriteLine($"Graduate student - {graduateName} has passed : {gradeuateStudent.IsPassed(graduateGrade)}");

            //---------------2nd Anwer---------------------

            Console.WriteLine("==================================================================");
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter the product details {i + 1} : ");
                Console.Write("Product ID : ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Product Name : ");
                string productName = Console.ReadLine();

                Console.Write("Product Price : ");
                double price = double.Parse(Console.ReadLine());
                products.Add(new Product(productId,productName,price));

            }
            //-----------------------Answer 3-------------------------------
            Console.WriteLine("===============================");

            TestExceptionHandling();
            Console.ReadLine();
        }

        private static void TestExceptionHandling()
        {
            throw new NotImplementedException();
        }
    }
    //-------------------------Answer 2------------------------------------
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public Product (int productId, string productName, double productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        //-------------------Anwer 3-----------------------
        public static void CheckPositive(int number)
        {
            if (number < 0)
                throw new ArgumentException("Number cannot be negative.");
            Console.WriteLine($"The number {number} is positive.");
        }

        public static void TestExceptionHandling()
        {
            Console.WriteLine("Enter a number to check if it is positive:");
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckPositive(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }
    }
}
