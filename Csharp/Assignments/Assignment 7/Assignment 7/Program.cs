using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{

    class employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public employee(int empID,string fName,string lname,string title,DateTime dob,DateTime doj,string city) 
        { 
            EmployeeID = empID;
            FirstName = fName;
            LastName = lname;
            Title = title;
            DOB = dob;
            DOJ = doj;
            City = city;
        }

        public void employeeInfo()
        {
            Console.WriteLine("Employee Id :" + EmployeeID);
            Console.WriteLine("Name :" + FirstName + LastName);
            Console.WriteLine("Title :" + Title);
            Console.WriteLine("Date of Birth :" + DOB);
            Console.WriteLine("Date of Joining :"+ DOJ);
            Console.WriteLine("City :" + City);
            Console.WriteLine();
        }
    }


        internal class Program
    {
        static void Main(string[] args)
        {
            List<employee> empList = new List<employee>
            {
                new employee(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai"),
                new employee(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"),
                new employee(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "Pune"),
                new employee(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"),
                new employee(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"),
                new employee(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"),
                new employee(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"),
                new employee(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"),
                new employee(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"),
                new employee(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune")
            };


            //SOLUTION 1
            var joinedBefore = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 1/1/2015:");
            foreach (var emp in joinedBefore)
            {
                emp.employeeInfo();
            }
            Console.WriteLine("----------------------------------");


            //SOLUTION 2
            var dobAfter = empList.Where(emp => emp.DOB > new DateTime(1990,1,1));
            Console.WriteLine("Employees born after 1/1/1990:");
            foreach (var emp in dobAfter)
            {
                emp.employeeInfo();
            }
            Console.WriteLine("----------------------------------");


            //SOLUTION 3
            var designation = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            Console.WriteLine("Employees who are Consultant or Associate:");
            foreach (var emp in designation)
            {
                emp.employeeInfo();
            }
            Console.WriteLine("----------------------------------");


            //SOLUTION 4
            var totalEmployees = empList.Count();
            Console.WriteLine("Total Number of employees:" + totalEmployees);
            Console.WriteLine("----------------------------------");


            //SOLUTION 5
            var chennaiEmployees = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine("Employees from Chennai :" + chennaiEmployees);
            Console.WriteLine("----------------------------------");


            //SOLUTION 6
            var highestEmpID = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine("Highest Employee ID:" + highestEmpID);
            Console.WriteLine("----------------------------------");


            //SOLUTION 7
            var joinedAfter = empList.Count(emp => emp.DOJ > new DateTime(2015,1,1));
            Console.WriteLine("total number of employee who have joined after 1/1/2015:" + joinedAfter);
            Console.WriteLine("----------------------------------");


            //SOLUTION 8
            var designationNotAssociate = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine("total number of employee whose designation is not Associate : " + designationNotAssociate);
            Console.WriteLine("----------------------------------");


            //SOLUTION 9
            var employeesBasedOnCity = empList.GroupBy(emp => emp.City).Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("Employees count by City:");
            foreach (var cityGroup in employeesBasedOnCity)
            {
                Console.WriteLine($"{cityGroup.City}: {cityGroup.Count}");
            }
            Console.WriteLine("----------------------------------");


            //SOLUTION 10
            var CityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title }).Select(group => new { CityTitle = group.Key, Count = group.Count() });
            Console.WriteLine("Employees count by City and Title:");
            foreach (var group in CityAndTitle)
            {
                Console.WriteLine($"{group.CityTitle.City} - {group.CityTitle.Title}: {group.Count}");
            }
            Console.WriteLine("----------------------------------");


            //SOLUTION 11
            var youngestEmp = empList.Select(e => e).Where(e => e.DOB == empList.Max(emp => emp.DOB));
            Console.WriteLine("Youngest employee in the list:");
            foreach (var emp in youngestEmp)
            {
               emp.employeeInfo();
            }
            Console.WriteLine("----------------------------------");

            Console.ReadLine();
        }
    }
}
