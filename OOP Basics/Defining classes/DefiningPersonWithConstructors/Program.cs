using System.Collections.Generic;
using System.Reflection;
using System;

namespace DefiningPersonWithConstructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
            ConstructorInfo nameAgeAccountsCtor = personType.GetConstructor(new[] { typeof(string), typeof(int), typeof(List<BankAccount>) });

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
            Console.WriteLine($"{basePerson.Name} {basePerson.Age}");
            Console.WriteLine($"{personWithAge.Name} {personWithAge.Age}");

            Person personWithAgeAndName = (Person)nameAgeCtor.Invoke(new object[] { name, age });
            Console.WriteLine($"{personWithAgeAndName.Name} {personWithAgeAndName.Age}");
            Console.WriteLine($"{personWithAgeAndName.GetBalance():F2}");

            int length = int.Parse(Console.ReadLine());
            List<BankAccount> accounts = new List<BankAccount>();

            for (int i = 0; i < length; i++)
            {
                BankAccount account = new BankAccount();
                account.Id = 1;
                account.Balance = double.Parse(Console.ReadLine());

                accounts.Add(account);
            }

            Person personWithAccounts = (Person)nameAgeAccountsCtor.Invoke(new object[] { name, age, accounts });
            Console.WriteLine($"{personWithAccounts.Name} {personWithAccounts.Age}");
            Console.WriteLine($"{personWithAccounts.GetBalance():F2}");
        }
    }
}