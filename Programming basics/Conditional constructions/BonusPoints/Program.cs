using System;

namespace BonusPoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());

            double bonus;
            if (points < 100) bonus = 5;
            else if (points < 1000) bonus = 0.2 * points;
            else bonus = 0.1 * points;

            if (points % 2 == 0) bonus++;
            if (points % 10 == 5) bonus += 2;

            Console.WriteLine(bonus);
            Console.WriteLine(points + bonus);
        }
    }
}
