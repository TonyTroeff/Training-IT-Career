using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sumOfDataSizesBySet = new Dictionary<string, int>();
            Dictionary<string, List<string>> dataKeysBySet = new Dictionary<string, List<string>>();
            HashSet<string> addedSets = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "thetinggoesskrra")
            {
                string[] inputData = input.Split(" | ");

                if (inputData.Length == 1)
                {
                    // A new data set is added.
                    addedSets.Add(inputData[0]);
                }
                else
                {
                    string[] keyData = inputData[0].Split(" -> ");
                    string key = keyData[0];
                    int size = int.Parse(keyData[1]);
                    string set = inputData[1];

                    if (!sumOfDataSizesBySet.ContainsKey(set))
                    {
                        sumOfDataSizesBySet[set] = 0;
                        dataKeysBySet[set] = new List<string>();
                    }
                    sumOfDataSizesBySet[set] += size;
                    dataKeysBySet[set].Add(key);
                }

                input = Console.ReadLine();
            }

            if (addedSets.Count > 0)
            {
                // Check the .MaxBy extension method.
                string maxSetName = sumOfDataSizesBySet
                    .Where(x => addedSets.Contains(x.Key))
                    .OrderByDescending(x => x.Value)
                    .First()
                    .Key;

                Console.WriteLine($"Data Set: {maxSetName}, Total Size: {sumOfDataSizesBySet[maxSetName]}");
                foreach (var dataKey in dataKeysBySet[maxSetName])
                    Console.WriteLine($"$.{dataKey}");
            }
        }
    }
}