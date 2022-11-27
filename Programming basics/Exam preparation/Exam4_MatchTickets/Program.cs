using System;

namespace Exam4_MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int fansCount = int.Parse(Console.ReadLine());

            double transportPercents = 0;
            if (fansCount <= 4) transportPercents = 0.75;
            else if (fansCount <= 9) transportPercents = 0.6;
            else if (fansCount <= 24) transportPercents = 0.5;
            else if (fansCount <= 49) transportPercents = 0.4;
            else transportPercents = 0.25;

            double ticketPrice = 0;
            if (category == "VIP") ticketPrice = 499.99;
            else if (category == "Normal") ticketPrice = 249.99;

            double total = budget * transportPercents + fansCount * ticketPrice;
            if (total > budget)
                Console.WriteLine($"Not enough money! You need {total - budget:f2} leva.");
            else Console.WriteLine($"Yes! You have {budget - total:f2} leva left.");
        }
    }
}
