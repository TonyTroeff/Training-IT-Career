using System;

namespace Greeting
{
    public class Program
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}.");
            Console.WriteLine($"You are {age} years old.");
        }
    }
}