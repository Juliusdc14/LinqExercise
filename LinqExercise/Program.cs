using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            
            var sum = numbers.Sum();
            
            var avg = numbers.Average();

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine($"Average: {avg}");

            
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("------------");
            Console.WriteLine("Asc");

            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("------------");
            Console.WriteLine("Desc");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            
            var greaterThanSix = numbers.Where(num => num > 6);

            Console.WriteLine("Greater than six:");

            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("First 4 asc");

            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            
            numbers[4] = 36;

            Console.WriteLine("With my age:");

            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            
            var employees = CreateEmployees();

            
            var filtered = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName[0] == 'S') .OrderBy(person => person.FirstName);

            Console.WriteLine("C or S Employees");

            foreach(var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            
            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            Console.WriteLine("Over 26");
            foreach (var person in overTwentySix)
            {
                Console.WriteLine($"Fullname: {person.FullName} Age: {person.Age} YOE: {person.YearsOfExperience}");
            }
            
            var yoeEMployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumOfYOE = yoeEMployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEMployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum {sumOfYOE} Avg {avgOfYOE}");

            
            employees = employees.Append(new Employee("first", "lastName", 56, 1)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
