using System.Collections.Generic;
using System;

class Program
{
    // Task 1: Query to return numbers and their squares only if square is greater than 20
    static void NumbersAndSquares()
    {
        Console.WriteLine("Enter a list of numbers separated by spaces:");
        var input = Console.ReadLine();
        var numbers = input.Split(' ');
        List<string> result = new List<string>();

        foreach (var num in numbers)
        {
            if (int.TryParse(num, out int number)) // Ensuring the input is a valid integer
            {
                int square = number * number;
                if (square > 20)
                {
                    result.Add($"{number} - {square}");
                }
            }
            else
            {
                Console.WriteLine($"{num} is not a valid number.");
            }
        }

        if (result.Count == 0)
        {
            Console.WriteLine("No numbers found with square greater than 20.");
        }
        else
        {
            Console.WriteLine("\nNumbers with square greater than 20:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    // Task 2: Query to return words starting with 'a' and ending with 'm'
    static void WordsStartingWithAEndingWithM()
    {
        Console.WriteLine("Enter words separated by spaces:");
        var words = Console.ReadLine().Split(' ');
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            // Check if the word is not empty and starts with 'a' and ends with 'm'
            if (word.Length > 0 && word[0] == 'a' && word[word.Length - 1] == 'm')
            {
                result.Add(word);
            }
        }

        if (result.Count == 0)
        {
            Console.WriteLine("No words found that start with 'a' and end with 'm'.");
        }
        else
        {
            Console.WriteLine("\nWords starting with 'a' and ending with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }

    // Task 3: Employee-related queries
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return $"EmpId: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}";
        }
    }

    static void EmployeeQueries()
    {
        // Sample employee data
        var employees = new List<Employee>();

        // Prompt the user to enter employee data
        Console.WriteLine("How many employees do you want to enter?");
        int numEmployees;
        while (!int.TryParse(Console.ReadLine(), out numEmployees) || numEmployees <= 0)
        {
            Console.WriteLine("Please enter a valid number of employees.");
        }

        for (int i = 0; i < numEmployees; i++)
        {
            Console.WriteLine($"\nEnter details for employee {i + 1}:");

            // Employee ID
            Console.Write("Enter Employee ID: ");
            int empId = int.Parse(Console.ReadLine());

            // Employee Name
            Console.Write("Enter Employee Name: ");
            string empName = Console.ReadLine();

            // Employee City
            Console.Write("Enter Employee City: ");
            string empCity = Console.ReadLine();

            // Employee Salary
            double empSalary;
            Console.Write("Enter Employee Salary: ");
            while (!double.TryParse(Console.ReadLine(), out empSalary) || empSalary < 0)
            {
                Console.WriteLine("Please enter a valid salary.");
            }

            // Add employee to the list
            employees.Add(new Employee { EmpId = empId, EmpName = empName, EmpCity = empCity, EmpSalary = empSalary });
        }

        // a. Display all employee data
        Console.WriteLine("\nAll Employees:");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }

        // b. Display employees with salary greater than 45000
        Console.WriteLine("\nEmployees with salary greater than 45000:");
        foreach (var emp in employees)
        {
            if (emp.EmpSalary > 45000)
            {
                Console.WriteLine(emp);
            }
        }

        // c. Display employees from Bangalore
        Console.WriteLine("\nEmployees from Bangalore:");
        foreach (var emp in employees)
        {
            if (emp.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(emp);
            }
        }

        // d. Display employees sorted by name in ascending order
        Console.WriteLine("\nEmployees sorted by name:");
        employees.Sort((e1, e2) => e1.EmpName.CompareTo(e2.EmpName));
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }
    }
    static void Main()
    {
        // ques1
        NumbersAndSquares();

        // ques2
        WordsStartingWithAEndingWithM();

        // ques3
        EmployeeQueries();

    }
}