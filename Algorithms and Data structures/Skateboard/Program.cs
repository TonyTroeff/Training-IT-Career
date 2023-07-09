using System;
using System.Collections.Generic;

namespace Skateboard
{
    public class Program
    {
        static SkateboardShop skateboardShop = new SkateboardShop("SkateboardShop1");
        static void Main(string[] args)
        {
            string line;

            while ("END" != (line = Console.ReadLine()))
            {
                string[] cmdArgs = line.Split(' ');

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddSkateboard(cmdArgs[1], double.Parse(cmdArgs[2]));
                        break;
                    case "AveragePrice":
                        AveragePriceInRange(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "FilterSkateboards":
                        FilterSkateboardsByPrice(double.Parse(cmdArgs[1]));
                        break;
                    case "SortByModel":
                        SortAscendingByModel();
                        break;
                    case "SortByPrice":
                        SortDescendingByPrice();
                        break;
                    case "CheckSkateboard":
                        CheckSkateboardIsInShop(cmdArgs[1]);
                        break;
                    case "Print":
                        ProvideInformationAboutAllSkateboards();
                        break;
                }
            }
        }

        private static void ProvideInformationAboutAllSkateboards()
        {
            string[] info = skateboardShop.ProvideInformationAboutAllSkateboards();
            foreach (string item in info)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckSkateboardIsInShop(string model)
        {
            if (skateboardShop.CheckSkateboardIsInShop(model))
            {
                Console.WriteLine($"Skateboard {model} is available.");
            }
            else
            {
                Console.WriteLine($"Skateboard {model} is not available.");
            }
        }
        private static void SortDescendingByPrice()
        {
            skateboardShop.SortDescendingByPrice();
            Console.WriteLine("The cheapest skateboard is: " + skateboardShop.Skateboards[skateboardShop.Skateboards.Count - 1].Model);
        }
        private static void SortAscendingByModel()
        {
            skateboardShop.SortAscendingByModel();
            Console.WriteLine("First skateboard is: " + skateboardShop.Skateboards[0].Model);
        }
        private static void FilterSkateboardsByPrice(double price)
        {
            List<string> filteredSkateboards = skateboardShop.FilterSkateboardsByPrice(price);
            Console.WriteLine("Filtered skateboards: " + string.Join(", ", filteredSkateboards));
        }

        private static void AveragePriceInRange(double start, double end)
        {
            double averagePrice = skateboardShop.AveragePriceInRange(start, end);
            Console.WriteLine($"Average price: {averagePrice:f2}");
        }

        private static void AddSkateboard(string model, double price)
        {
            skateboardShop.AddSkateboard(model, price);
            Console.WriteLine($"Added skateboard {model}.");
        }
    }
}
