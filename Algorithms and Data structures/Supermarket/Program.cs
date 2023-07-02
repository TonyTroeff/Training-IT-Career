using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static Supermarket supermarket = new Supermarket("Supermarket1");

        static void Main(string[] args)
        {
            string line;

            while ("END" != (line = Console.ReadLine()))
            {
                string[] cmdArgs = line.Split(' ');

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddProduct(cmdArgs[1], double.Parse(cmdArgs[2]));
                        break;
                    case "AveragePrice":
                        AveragePriceInRange(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "FilterProducts":
                        FilterProductsByPrice(double.Parse(cmdArgs[1]));
                        break;
                    case "SortByName":
                        SortAscendingByName();
                        break;
                    case "SortByPrice":
                        SortDescendingByPrice();
                        break;
                    case "CheckProduct":
                        CheckProductIsInSupermarket(cmdArgs[1]);
                        break;
                    case "Print":
                        ProvideInformationAboutAllProducts();
                        break;
                }
            }
        }

        private static void ProvideInformationAboutAllProducts()
        {
            string[] info = supermarket.ProvideInformationAboutAllProducts();
            foreach (string item in info)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckProductIsInSupermarket(string name)
        {
            if (supermarket.CheckProductIsInSupermarket(name))
            {
                Console.WriteLine($"Product {name} is available.");
            }
            else
            {
                Console.WriteLine($"Product {name} is not available.");
            }
        }
        private static void SortDescendingByPrice()
        {
            supermarket.SortDescendingByPrice();
            Console.WriteLine("The cheapest product is: " + supermarket.Products[supermarket.Products.Count - 1].Name);
        }
        private static void SortAscendingByName()
        {
            supermarket.SortAscendingByName();
            Console.WriteLine("First product is: " + supermarket.Products[0].Name);
        }
        private static void FilterProductsByPrice(double grade)
        {
            List<string> leftStudents = supermarket.FilterProductsByPrice(grade);
            Console.WriteLine("Filtered products: " + string.Join(", ", leftStudents));
        }

        private static void AveragePriceInRange(double start, double end)
        {
            double averageGrade = supermarket.AveragePriceInRange(start, end);
            Console.WriteLine($"Average price: {averageGrade:f2}");
        }

        private static void AddProduct(string name, double price)
        {
            supermarket.AddProduct(name, price);
            Console.WriteLine($"Added product {name}.");
        }
    }
}
