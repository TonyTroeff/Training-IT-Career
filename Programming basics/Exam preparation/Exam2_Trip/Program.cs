using System;

namespace Exam2_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "", tripType = "";
            double costPercentage = 0;
            if (budget <= 100)
            {
                if (season == "summer")
                {
                    costPercentage = 0.3;
                    tripType = "Camp";
                }
                else if (season == "winter")
                {
                    costPercentage = 0.7;
                    tripType = "Hotel";
                }

                destination = "Bulgaria";
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    costPercentage = 0.4;
                    tripType = "Camp";
                }
                else if (season == "winter")
                {
                    costPercentage = 0.8;
                    tripType = "Hotel";
                }

                destination = "Balkans";
            }
            else
            {
                costPercentage = 0.9;
                tripType = "Hotel";
                destination = "Europe";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{tripType} - {budget * costPercentage:f2}");
        }
    }
}
