using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfEmployees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<Employee>> employeesByDepartment = new Dictionary<string, List<Employee>>();
            for (int i = 0; i < n; i++)
            {
                Employee employee = ReadEmployee();

                if (!employeesByDepartment.ContainsKey(employee.Department))
                    employeesByDepartment[employee.Department] = new List<Employee>();
                employeesByDepartment[employee.Department].Add(employee);
            }

            string highestAverageSalaryDepartment = employeesByDepartment
                .MaxBy(x => x.Value.Sum(e => e.Salary) / x.Value.Count)
                .Key;

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment}");
            foreach (Employee employee in employeesByDepartment[highestAverageSalaryDepartment]
                .OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }

        static Employee ReadEmployee()
        {
            string[] inputData = Console.ReadLine().Split();

            Employee employee = new Employee();
            employee.Name = inputData[0];
            employee.Salary = decimal.Parse(inputData[1]);
            employee.Position = inputData[2];
            employee.Department = inputData[3];

            if (inputData.Length == 6)
            {
                employee.Email = inputData[4];
                employee.Age = int.Parse(inputData[5]);
            }
            else if (inputData.Length == 5)
            {
                if (int.TryParse(inputData[4], out int age))
                    employee.Age = age;
                else employee.Email = inputData[4];
            }

            return employee;
        }
    }
}