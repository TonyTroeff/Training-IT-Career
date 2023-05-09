using System;

namespace SortPeopleByNameAndAge
{
    internal class Person
    {
        private const int MinNameLength = 3;
        private const double MinSalary = 460;

        public Person(string firstName, string lastName, int age, double salary)
        {
            if (firstName == null || firstName.Length < 3) throw new ArgumentException($"First name cannot be less than {MinNameLength} symbols");
            if (lastName == null || lastName.Length < 3) throw new ArgumentException($"Last name cannot be less than {MinNameLength} symbols");
            if (age <= 0) throw new ArgumentException("Age cannot be zero or negative integer");
            if (salary < MinSalary) throw new ArgumentException($"Salary cannot be less than {MinSalary} leva");

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public double Salary { get; }

        public override string ToString()
            => $"{this.FirstName} {this.LastName} get {this.Salary:f2} leva";
    }
}
