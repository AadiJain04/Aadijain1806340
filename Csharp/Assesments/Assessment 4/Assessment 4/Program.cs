using System;
using System.Collections.Generic;
using System.Linq;
class Employees
{
    public int EmpId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string DOB { get; set; }
    public string DOJ { get; set; }
    public string Location { get; set; }
    public Employees(int empId, string firstName, string lastName, string title, string dob, string doj, string location)
    {
        EmpId = empId;
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        DOB = dob;
        DOJ = doj;
        Location = location;
    }
    public override string ToString()
    {
        return $"EmpId: {EmpId}, FirstName: {FirstName}, LastName: {LastName}, Title: {Title}, DOB: {DOB}, DOJ: {DOJ}, Location: {Location}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create and populate the Generic List collection
        List<Employees> empList = new List<Employees>
       {
           new Employees(1001, "Malcolm", "Daruwalla", "Manager", "16-11-1984", "08-06-2011", "Mumbai"),
           new Employees(1002, "Asdin", "Dhalla", "AsstManager", "20-08-1994", "07-07-2012", "Mumbai"),
           new Employees(1003, "Madhavi", "Oza", "Consultant", "14-11-1987", "12-04-2015", "Pune"),
           new Employees(1004, "Saba", "Shaikh", "SE", "03-06-1990", "02-02-2016", "Pune"),
           new Employees(1005, "Nazia", "Shaikh", "SE", "08-03-1991", "02-02-2016", "Mumbai"),
           new Employees(1006, "Amit", "Pathak", "Consultant", "07-11-1989", "08-08-2014", "Chennai"),
           new Employees(1007, "Vijay", "Natrajan", "Consultant", "02-12-1989", "01-06-2015", "Mumbai"),
           new Employees(1008, "Rahul", "Dubey", "Associate", "11-11-1993", "06-11-2014", "Chennai"),
           new Employees(1009, "Suresh", "Mistry", "Associate", "12-08-1992", "03-12-2014", "Chennai"),
           new Employees(1010, "Sumit", "Shah", "Manager", "12-04-1991", "02-01-2016", "Pune")
       };
        // ----------------------ANSWER 1-------------------------
        Console.WriteLine("All Employees:");
        var allEmployees = empList.Select(emp => emp);
        foreach (var emp in allEmployees)
        {
            Console.WriteLine(emp);
        }
        // ----------------------ANSWER 2-------------------------
        Console.WriteLine("\nEmployees whose location is not Mumbai:");
        var nonMumbaiEmployees = empList.Where(emp => emp.Location != "Mumbai");
        foreach (var emp in nonMumbaiEmployees)
        {
            Console.WriteLine(emp);
        }
        // ----------------------ANSWER 3-------------------------
        Console.WriteLine("\nEmployees whose title is AsstManager:");
        var asstManagerEmployees = empList.Where(emp => emp.Title == "AsstManager");
        foreach (var emp in asstManagerEmployees)
        {
            Console.WriteLine(emp);
        }
        // ----------------------ANSWER 4-------------------------
        Console.WriteLine("\nEmployees whose Last Name starts with S:");
        var lastNameStartsWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
        foreach (var emp in lastNameStartsWithS)
        {
            Console.WriteLine(emp);
            Console.ReadLine();
        }
    }
}
