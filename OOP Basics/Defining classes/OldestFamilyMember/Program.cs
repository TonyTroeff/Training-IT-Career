using System;

namespace OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();

                // This syntax with the curly brackets is called "object initializer"
                Person person = new Person { Name = personData[0], Age = int.Parse(personData[1]) };

                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}