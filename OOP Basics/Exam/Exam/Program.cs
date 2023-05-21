using System;
using System.Collections.Generic;

namespace Exam
{
    internal class Program
    {
        static Dictionary<int, Perfume> perfumes = new Dictionary<int, Perfume>();
        static Dictionary<string, Perfumery> perfumeries = new Dictionary<string, Perfumery>();

        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "STOP")
            {
                string[] splittedInput = input.Split(' ');
                string command = splittedInput[0];

                switch (command)
                {
                    case "AddPerfume":
                        AddPerfume(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "SellPerfume":
                        SellPerfume(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "CalculateTotalPrice":
                        CalculateTotalPrice(splittedInput[1]);
                        break;
                    case "GetPerfumeWithHighestPrice":
                        GetPerfumeWithHighestPrice(splittedInput[1]);
                        break;
                    case "GetPerfumeWithLowestPrice":
                        GetPerfumeWithLowestPrice(splittedInput[1]);
                        break;
                    case "RenamePerfumery":
                        RenamePerfumery(splittedInput[1], splittedInput[2]);
                        break;
                    case "SellAllPerfumes":
                        SellAllPerfumes(splittedInput[1]);
                        break;
                    case "PerfumeryInfo":
                        PerfumeryInfo(splittedInput[1]);
                        break;
                    case "CreatePerfumery":
                        CreatePerfumery(splittedInput[1]);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

        }

        private static void AddPerfume(string brand, double price, string name)
        {
            try
            {
                Perfume perfume = new Perfume(brand, price);
                if (!perfumeries.ContainsKey(name))
                {
                    Console.WriteLine("Could not add this perfume to your perfumery.");
                    return;
                }
                Perfumery perfumery = perfumeries[name];
                perfumery.AddPerfume(perfume);
                Console.WriteLine($"You added perfume {brand} to perfumery {perfumery.Name}.");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SellPerfume(string brand, double price, string name)
        {
            try
            {
                if (!perfumeries.ContainsKey(name))
                {
                    Console.WriteLine("Could not sell this perfume from your perfumery.");
                    return;
                }

                Perfume perfume = new Perfume(brand, price);
                Perfumery perfumery = perfumeries[name];
                if (perfumery.SellPerfume(perfume))
                {
                    Console.WriteLine($"You sold perfume {brand} from perfumery {name}.");
                }
                else
                {
                    Console.WriteLine($"Did not sell perfume {brand} from perfumery {name}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CalculateTotalPrice(string name)
        {
            try
            {
                if (!perfumeries.ContainsKey(name))
                {
                    Console.WriteLine("Could not calculate total price.");
                    return;
                }
                Perfumery perfumery = perfumeries[name];

                Console.WriteLine($"Total price: {perfumery.CalculateTotalPrice():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RenamePerfumery(string name, string newName)
        {

            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine($"Could not rename the perfumery {name}.");
                return;
            }
            Perfumery perfumery = perfumeries[name];

            try
            {
                perfumery.RenamePerfumery(newName);
                perfumeries.Remove(name);
                perfumeries.Add(newName, perfumery);
                Console.WriteLine($"You renamed your perfumery from {name} to {newName}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SellAllPerfumes(string name)
        {

            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine($"Could not sell all perfumes from perfumery {name}.");
                return;
            }
            Perfumery perfumery = perfumeries[name];

            perfumery.SellAllPerfumes();
            Console.WriteLine($"You sold all perfumes from perfumery {name}.");
        }

        private static void PerfumeryInfo(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine($"Could not get perfumery {name}.");
                return;
            }
            Perfumery perfumery = perfumeries[name];
            Console.WriteLine(perfumery.ToString());
        }

        private static void GetPerfumeWithLowestPrice(string name)
        {

            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine($"Could not get perfume with lowest price from store {name}.");
                return;
            }
            Perfumery perfumery = perfumeries[name];

            Console.WriteLine($"Perfume from perfumery {name} has lowest price: {perfumery.GetPerfumeWithLowestPrice().Price:F2}");
        }

        private static void GetPerfumeWithHighestPrice(string name)
        {

            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine($"Could not get perfume with highest price from perfumery {name}.");
                return;
            }
            Perfumery perfumery = perfumeries[name];

            Console.WriteLine($"Perfume from perfumery {name} has highest price: {perfumery.GetPerfumeWithHighestPrice().Price:F2}");
        }


        private static void CreatePerfumery(string name)
        {

            try
            {
                Perfumery perfumery = new Perfumery(name);
                perfumeries.Add(name, perfumery);
                Console.WriteLine($"You created perfumery {name}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
