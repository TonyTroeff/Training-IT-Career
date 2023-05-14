using System;

namespace InstancesCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Person p = new Person($"{i}", i);
            }

            Console.WriteLine(Person.Count);
        }
    }
}
