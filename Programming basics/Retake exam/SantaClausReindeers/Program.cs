using System;

namespace SantaClausReindeers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double reindeerOne = double.Parse(Console.ReadLine());
            double reindeerTwo = double.Parse(Console.ReadLine());
            double reindeerThree = double.Parse(Console.ReadLine());

            double total = reindeerOne * days + reindeerTwo * days + reindeerThree * days;
            if (total > food)
                Console.WriteLine($"{Math.Ceiling(total - food)} more kilos of food are needed.");
            else
                Console.WriteLine($"{Math.Floor(food - total)} kilos of food left.");
        }
    }
}
