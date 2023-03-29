using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dataByCountry = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalPopulationByCountry = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] data = input.Split('|');
                string town = data[0];
                string country = data[1];
                int population = int.Parse(data[2]);

                if (!dataByCountry.ContainsKey(country))
                {
                    dataByCountry[country] = new Dictionary<string, int>();
                    totalPopulationByCountry[country] = 0;
                }

                dataByCountry[country][town] = population;
                totalPopulationByCountry[country] += population;

                input = Console.ReadLine();
            }

            foreach (var (country, totalPopulation) in totalPopulationByCountry.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country} (total population: {totalPopulation})");

                foreach (var (town, townPopulation) in dataByCountry[country].OrderByDescending(x => x.Value))
                    Console.WriteLine($"=>{town}: {townPopulation}");
            }
        }
    }
}