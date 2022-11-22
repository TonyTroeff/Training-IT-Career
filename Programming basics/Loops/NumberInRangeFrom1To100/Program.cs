using System;

namespace NumberInRangeFrom1To100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = ReadNumber();
            while (number < 1 || number > 100)
            {
                Console.WriteLine("Invalid number!");
                number = ReadNumber();
            }

            Console.WriteLine($"The number is {number}");
        }

        static int ReadNumber()
        {
            Console.Write("Enter a number in the range [1...100]: ");
            int numberFromConsole = int.Parse(Console.ReadLine());
            return numberFromConsole;
        }
    }
}
