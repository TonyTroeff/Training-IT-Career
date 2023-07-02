using System;
using System.Collections.Generic;

namespace PreliminaryExam
{
    public class Program
    {
        static CoffeeShop coffeeShop = new CoffeeShop("CoffeeShop1");

        static void Main(string[] args)
        {
            string line;

            while ("END" != (line = Console.ReadLine()))
            {
                string[] cmdArgs = line.Split(' ');

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddCoffee(cmdArgs[1], double.Parse(cmdArgs[2]));
                        break;
                    case "AveragePrice":
                        AverageResultInRange(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "FilterCoffees":
                        FilterCoffeesByPrice(double.Parse(cmdArgs[1]));
                        break;
                    case "SortByType":
                        SortAscendingByType();
                        break;
                    case "SortByPrice":
                        SortDescendingByPrice();
                        break;
                    case "CheckCoffee":
                        CheckCoffeeIsInCoffeeShop(cmdArgs[1]);
                        break;
                    case "Print":
                        ProvideInformationAboutAllCoffees();
                        break;
                }
            }
        }

        private static void ProvideInformationAboutAllCoffees()
        {
            string[] info = coffeeShop.ProvideInformationAboutAllCoffees();
            foreach (string item in info)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckCoffeeIsInCoffeeShop(string type)
        {
            if (coffeeShop.CheckCoffeeIsInCoffeeShop(type))
            {
                Console.WriteLine($"Coffee {type} is available.");
            }
            else
            {
                Console.WriteLine($"Coffee {type} is not available.");
            }
        }
        private static void SortDescendingByPrice()
        {
            List<Coffee> sortedCoffees = coffeeShop.SortDescendingByPrice();
            Console.WriteLine("The cheapest coffee is: " + sortedCoffees[coffeeShop.Coffees.Count - 1].Type);
        }
        private static void SortAscendingByType()
        {
            List<Coffee> sortedCoffees = coffeeShop.SortAscendingByType();
            Console.WriteLine("First coffee is: " + sortedCoffees[0].Type);
        }
        private static void FilterCoffeesByPrice(double price)
        {
            List<string> leftCoffees = coffeeShop.FilterCoffeesByPrice(price);
            Console.WriteLine("Filtered coffees: " + string.Join(", ", leftCoffees));
        }

        private static void AverageResultInRange(double start, double end)
        {
            double averageGrade = coffeeShop.AveragePriceInRange(start, end);
            Console.WriteLine($"Average result: {averageGrade:f2}");
        }

        private static void AddCoffee(string type, double grade)
        {
            coffeeShop.AddCoffee(type, grade);
            Console.WriteLine($"Added coffee {type}.");
        }
    }
}
