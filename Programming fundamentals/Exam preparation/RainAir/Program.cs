using System;
using System.Collections.Generic;
using System.Linq;

namespace RainAir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> flightsByPerson = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();
            while (input != "I believe I can fly!")
            {
                string[] inputData = input.Split(" = ");

                if (inputData.Length == 2)
                {
                    string left = inputData[0], right = inputData[1];
                    flightsByPerson[left] = new List<int>(flightsByPerson[right]);
                }
                else if (inputData.Length == 1)
                {
                    inputData = input.Split(' ');
                    string person = inputData[0];

                    if (!flightsByPerson.ContainsKey(person)) flightsByPerson[person] = new List<int>();

                    for (int i = 1; i < inputData.Length; i++)
                        flightsByPerson[person].Add(int.Parse(inputData[i]));
                }

                input = Console.ReadLine();
            }

            foreach (var (person, flights) in flightsByPerson.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                Console.WriteLine($"#{person} ::: {string.Join(", ", flights.OrderBy(x => x))}");
        }
    }
}