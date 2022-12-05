using System;

namespace WinterHoliday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nights = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string roomType = Console.ReadLine();

            double price = 0;
            if (destination == "Colorado")
            {
                if (roomType == "double room") price = 38;
                else if (roomType == "apartment") price = 45;
            }
            else if (destination == "Alps")
            {
                if (roomType == "double room") price = 35;
                else if (roomType == "apartment") price = 42;
            }
            else if (destination == "Andie")
            {
                if (roomType == "double room") price = 39;
                else if (roomType == "apartment") price = 49;
            }

            double total = price * nights;
            Console.WriteLine($"They have to spend {total:f2} leva.");
        }
    }
}
